﻿using Com.Danliris.Service.Sales.Lib;
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Logic.FinishingPrinting;
using Com.Danliris.Service.Sales.Lib.Models.FinishingPrinting;
using Com.Danliris.Service.Sales.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.Danliris.Sales.Test.BussinesLogic.Logic.FinishingPrinting
{
    public class FinishingPrintingSalesContractDetailLogicTest
    {

        private const string ENTITY = "FinishingPrintingSalesContractDetail";
        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return string.Concat(sf.GetMethod().Name, "_", ENTITY);
        }

        private SalesDbContext _dbContext(string testName)
        {
            DbContextOptionsBuilder<SalesDbContext> optionsBuilder = new DbContextOptionsBuilder<SalesDbContext>();
            optionsBuilder
                .UseInMemoryDatabase(testName)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            SalesDbContext dbContext = new SalesDbContext(optionsBuilder.Options);

            return dbContext;
        }

        public Mock<IServiceProvider> GetServiceProvider(string testname)
        {
            IIdentityService identityService = new IdentityService { Username = "Username", Token = "Token Test" };
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider
                .Setup(x => x.GetService(typeof(IdentityService)))
                .Returns(identityService);

            serviceProvider.Setup(s => s.GetService(typeof(SalesDbContext)))
                .Returns(_dbContext(testname));


            return serviceProvider;
        }

        [Fact]
        public async Task DeleteAsync_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            IIdentityService identityService = new IdentityService { Username = "Username" };
            var model = new FinishingPrintingSalesContractDetailModel()
            {
                FinishingPrintingSalesContract =new FinishingPrintingSalesContractModel()
                {
                    AccountBankAccountName ="Fetih"
                }
            };

            dbContext.FinishingPrintingSalesContractDetails.Add(model);
            dbContext.SaveChanges();

            FinishingPrintingSalesContractDetailLogic unitUnderTest = new FinishingPrintingSalesContractDetailLogic(GetServiceProvider(testName).Object, identityService, dbContext);
            await unitUnderTest.DeleteAsync(model.Id);
        }

        [Fact]
        public async Task DeleteAsync_Throws_Exception()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            Mock<IIdentityService> identityService = new Mock<IIdentityService>();
            identityService.Setup(s => s.Username).Throws(new Exception());
            var model = new FinishingPrintingSalesContractDetailModel()
            {
                FinishingPrintingSalesContract = new FinishingPrintingSalesContractModel()
                {
                    AccountBankAccountName = "Fetih"
                }
            };

            dbContext.FinishingPrintingSalesContractDetails.Add(model);
            dbContext.SaveChanges();

            FinishingPrintingSalesContractDetailLogic unitUnderTest = new FinishingPrintingSalesContractDetailLogic(GetServiceProvider(testName).Object, identityService.Object, dbContext);
            await Assert.ThrowsAsync<Exception>(() => unitUnderTest.DeleteAsync(model.Id));
        }
    }      
}
