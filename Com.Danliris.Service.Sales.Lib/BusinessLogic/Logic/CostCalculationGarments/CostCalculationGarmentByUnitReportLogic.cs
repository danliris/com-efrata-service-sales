﻿using Com.Danliris.Service.Sales.Lib.Models.CostCalculationGarments;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseClass;
using Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Logic.CostCalculationGarments
{
    public class CostCalculationByUnitReportLogic : BaseMonitoringLogic<CostCalculationGarmentByUnitReportViewModel>
    {
        private IIdentityService identityService;
        private SalesDbContext dbContext;
        private DbSet<CostCalculationGarment> dbSet;

        public CostCalculationByUnitReportLogic(IIdentityService identityService, SalesDbContext dbContext)
        {
            this.identityService = identityService;
            this.dbContext = dbContext;
            dbSet = dbContext.Set<CostCalculationGarment>();
        }

        public override IQueryable<CostCalculationGarmentByUnitReportViewModel> GetQuery(string filter)
        {
            Filter _filter = JsonConvert.DeserializeObject<Filter>(filter);

            IQueryable<CostCalculationGarment> Query = dbSet;

            if (!string.IsNullOrWhiteSpace(_filter.unitName))
            {
                Query = Query.Where(cc => cc.UnitName == _filter.unitName);
            }
            if (_filter.dateFrom != null)
            {
                var filterDate = _filter.dateFrom.GetValueOrDefault().ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).Date;
                Query = Query.Where(cc => cc.ConfirmDate.AddHours(identityService.TimezoneOffset).Date >= filterDate);
            }
            if (_filter.dateTo != null)
            {
                var filterDate = _filter.dateTo.GetValueOrDefault().ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).AddDays(1).Date;
                Query = Query.Where(cc => cc.ConfirmDate.AddHours(identityService.TimezoneOffset).Date < filterDate);
            }

            Query = Query.OrderBy(o => o.UnitName).ThenBy(o => o.BuyerBrandName);

            var newQ = (from a in Query
                    select new CostCalculationGarmentByUnitReportViewModel
                    {
                        RO_Number = a.RO_Number,
                        ConfirmDate = a.ConfirmDate,
                        DeliveryDate = a.DeliveryDate,
                        UnitName = a.UnitName,
                        Description = a.CommodityDescription,
                        Section = a.Section,
                        Article = a.Article,
                        BuyerCode = a.BuyerCode,
                        BuyerName = a.BuyerName,
                        BrandCode = a.BuyerBrandCode,
                        BrandName = a.BuyerBrandName,
                        Comodity = a.ComodityCode,
                        Quantity = a.Quantity,
                        ConfirmPrice = a.ConfirmPrice,
                        UOMUnit = a.UOMUnit,
                        Amount = a.Quantity * a.ConfirmPrice,
                    });

            return newQ;
        }

        private class Filter
        {
            public string unitName { get; set; }

            public DateTimeOffset? dateFrom { get; set; }
            public DateTimeOffset? dateTo { get; set; }
        }
    }
}
