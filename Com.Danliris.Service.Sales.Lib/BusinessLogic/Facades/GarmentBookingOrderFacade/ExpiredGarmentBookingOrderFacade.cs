﻿using Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.GarmentBookingOrderInterface;
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Logic.GarmentBookingOrderLogics;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Com.Danliris.Service.Sales.Lib.Models.GarmentBookingOrderModel;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Facades.GarmentBookingOrderFacade
{
    public class ExpiredGarmentBookingOrderFacade : IExpiredGarmentBookingOrder
    {
        private readonly SalesDbContext DbContext;
        private readonly DbSet<GarmentBookingOrder> DbSet;
        private readonly IdentityService identityService;
        private readonly GarmentBookingOrderLogic garmentBookingOrderLogic;
        public IServiceProvider ServiceProvider;

        public ExpiredGarmentBookingOrderFacade(IServiceProvider serviceProvider, SalesDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<GarmentBookingOrder>();
            identityService = serviceProvider.GetService<IdentityService>();
            garmentBookingOrderLogic = serviceProvider.GetService<GarmentBookingOrderLogic>();
            ServiceProvider = serviceProvider;
        }
        public async Task<int> CreateAsync(GarmentBookingOrder model)
        {
            garmentBookingOrderLogic.Create(model);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            await garmentBookingOrderLogic.DeleteAsync(id);
            return await DbContext.SaveChangesAsync();
        }

        public ReadResponse<GarmentBookingOrder> Read(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            return garmentBookingOrderLogic.Read(page, size, order, select, keyword, filter);
        }

        public ReadResponse<GarmentBookingOrder> ReadExpired(int page, int size, string order, List<string> select, string keyword, string filter)
        {
            return garmentBookingOrderLogic.ReadExpired(page, size, order, select, keyword, filter);
        }

        public async Task<GarmentBookingOrder> ReadByIdAsync(int id)
        {
            return await garmentBookingOrderLogic.ReadByIdAsync(id);
        }
        public int BOCancelExpired(List<GarmentBookingOrder> list, string user)
        {
            return garmentBookingOrderLogic.BOCancelExpired(list, user);
        }

        public async Task<int> UpdateAsync(int id, GarmentBookingOrder model)
        {
            garmentBookingOrderLogic.UpdateAsync(id, model);
            return await DbContext.SaveChangesAsync();
        }
    }
}
