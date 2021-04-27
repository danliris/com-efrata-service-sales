﻿using Com.Danliris.Service.Sales.Lib;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseClass;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseInterface;
using Com.Moonlay.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace Com.Danliris.Sales.Test.BussinesLogic.Utils
{
    public abstract class BaseFacadeTest<TDbContext, TFacade, TLogic, TModel, TDataUtil>
        where TDbContext : StandardDbContext
        where TFacade : class, IBaseFacade<TModel>
        where TLogic : BaseLogic<TModel>
        where TModel : BaseModel
        where TDataUtil : BaseDataUtil<TFacade, TModel>
    {
        private string _entity;

        public  BaseFacadeTest(string entity)
        {
            _entity = entity;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return string.Concat(sf.GetMethod().Name, "_", _entity);
        }

        protected string GetCurrentAsyncMethod([CallerMemberName] string methodName="")
        {
            MethodBase method = new StackTrace()
                .GetFrames()
                .Select(frame => frame.GetMethod())
                .FirstOrDefault(item => item.Name == methodName);

            return method.Name;
        }

        protected TDbContext DbContext(string testName)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            DbContextOptionsBuilder<TDbContext> optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder
                .UseInMemoryDatabase(testName)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInternalServiceProvider(serviceProvider);

            TDbContext dbContext = Activator.CreateInstance(typeof(TDbContext), optionsBuilder.Options) as TDbContext;

            return dbContext;
        }

        protected virtual Mock<IServiceProvider> GetServiceProviderMock(TDbContext dbContext)
        {
            var serviceProviderMock = new Mock<IServiceProvider>();

            IIdentityService identityService = new IdentityService { Username = "Username" };

            serviceProviderMock
                .Setup(x => x.GetService(typeof(IdentityService)))
                .Returns(identityService);

            serviceProviderMock
                .Setup(x => x.GetService(typeof(TLogic)))
                .Returns(Activator.CreateInstance(typeof(TLogic), identityService, dbContext) as TLogic);

            return serviceProviderMock;
        }

        protected virtual TDataUtil DataUtil(TFacade facade, TDbContext dbContext = null)
        {
            TDataUtil dataUtil = Activator.CreateInstance(typeof(TDataUtil), facade) as TDataUtil;
            return dataUtil;
        }

        [Fact]
        public virtual async void Create_Success()
        {
            var dbContext = DbContext(GetCurrentMethod());
            var serviceProvider = GetServiceProviderMock(dbContext).Object;

            TFacade facade = Activator.CreateInstance(typeof(TFacade), serviceProvider, dbContext) as TFacade;

            var data = await DataUtil(facade, dbContext).GetNewData();

            var response = await facade.CreateAsync(data);

            Assert.NotEqual(response, 0);
        }

        [Fact]
        public virtual async void Get_All_Success()
        {
            var dbContext = DbContext(GetCurrentMethod());
            var serviceProvider = GetServiceProviderMock(dbContext).Object;

            TFacade facade = Activator.CreateInstance(typeof(TFacade), serviceProvider, dbContext) as TFacade;

            var data = await DataUtil(facade, dbContext).GetTestData();

            var Response = facade.Read(1, 25, "{}", new List<string>(), "", "{}");

            Assert.NotEqual(Response.Data.Count, 0);
        }

        [Fact]
        public virtual async void Get_By_Id_Success()
        {
            var dbContext = DbContext(GetCurrentMethod());
            var serviceProvider = GetServiceProviderMock(dbContext).Object;

            TFacade facade = Activator.CreateInstance(typeof(TFacade), serviceProvider, dbContext) as TFacade;

            var data = await DataUtil(facade, dbContext).GetTestData();

            var Response = facade.ReadByIdAsync((int)data.Id);

            Assert.NotEqual(Response.Id, 0);
        }

        [Fact]
        public virtual async void Update_Success()
        {
            var dbContext = DbContext(GetCurrentMethod());
            var serviceProvider = GetServiceProviderMock(dbContext).Object;

            TFacade facade = Activator.CreateInstance(typeof(TFacade), serviceProvider, dbContext) as TFacade;

            var data = await DataUtil(facade, dbContext).GetTestData();

            var response = await facade.UpdateAsync((int)data.Id, data);

            Assert.NotEqual(response, 0);
        }

        [Fact]
        public virtual async void Delete_Success()
        {
            var dbContext = DbContext(GetCurrentMethod());
            var serviceProvider = GetServiceProviderMock(dbContext).Object;

            TFacade facade = Activator.CreateInstance(typeof(TFacade), serviceProvider, dbContext) as TFacade;
            var data = await DataUtil(facade, dbContext).GetTestData();

            var Response = await facade.DeleteAsync((int)data.Id);
            Assert.NotEqual(Response, 0);
        }
    }
}
