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
    public class ProfitGarmentBySectionReportLogic : BaseMonitoringLogic<ProfitGarmentBySectionReportViewModel>
    {
        private IIdentityService identityService;
        private SalesDbContext dbContext;
        private DbSet<CostCalculationGarment> dbSet;

        public ProfitGarmentBySectionReportLogic(IIdentityService identityService, SalesDbContext dbContext)
        {
            this.identityService = identityService;
            this.dbContext = dbContext;
            dbSet = dbContext.Set<CostCalculationGarment>();
        }

        public override IQueryable<ProfitGarmentBySectionReportViewModel> GetQuery(string filter)
        {
            Filter _filter = JsonConvert.DeserializeObject<Filter>(filter);

            IQueryable<CostCalculationGarment> Query = dbSet;

            if (!string.IsNullOrWhiteSpace(_filter.section))
            {
                Query = Query.Where(cc => cc.Section == _filter.section);
            }
            if (_filter.dateFrom != null)
            {
                var filterDate = _filter.dateFrom.GetValueOrDefault().ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).Date;
                Query = Query.Where(cc => cc.DeliveryDate.AddHours(identityService.TimezoneOffset).Date >= filterDate);
            }
            if (_filter.dateTo != null)
            {
                var filterDate = _filter.dateTo.GetValueOrDefault().ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).AddDays(1).Date;
                Query = Query.Where(cc => cc.DeliveryDate.AddHours(identityService.TimezoneOffset).Date < filterDate);
            }
 
            Query = Query.OrderBy(o => o.Section).ThenBy(o => o.BuyerBrandCode);
            var newQ = (from a in Query
                        join b in dbContext.CostCalculationGarment_Materials on a.Id equals b.CostCalculationGarmentId
                        where b.CategoryName == "FABRIC" && a.IsApprovedKadivMD == true
                        group new { CMP = b.CM_Price.GetValueOrDefault() } by new { a.UnitName, a.Section, a.BuyerCode, a.BuyerName,
                                    a.BuyerBrandCode, a.BuyerBrandName, a.Commodity, a.CommodityDescription, a.RO_Number, a.Article, a.Quantity, a.UOMUnit,
                                    a.DeliveryDate, a.NETFOBP, a.ConfirmPrice, a.RateValue, a.FabricAllowance, a.AccessoriesAllowance } into G

            select new ProfitGarmentBySectionReportViewModel
                       {                
                            UnitName = G.Key.UnitName,
                            Section = G.Key.Section,
                            BuyerCode = G.Key.BuyerCode,
                            BuyerName = G.Key.BuyerName,
                            BrandCode = G.Key.BuyerBrandCode,
                            BrandName = G.Key.BuyerBrandName,
                            RO_Number = G.Key.RO_Number,
                            Comodity = G.Key.Commodity,
                            ComodityDescription = G.Key.CommodityDescription,
                            Profit = G.Key.NETFOBP, 
                            Article = G.Key.Article,
                            Quantity = G.Key.Quantity,
                            UOMUnit = G.Key.UOMUnit,
                            DeliveryDate = G.Key.DeliveryDate,
                            ConfirmPrice = G.Key.ConfirmPrice,
                            CurrencyRate = G.Key.RateValue,                          
                            CMPrice = Math.Round(G.Sum(m => m.CMP), 2) / G.Key.RateValue * 1.05,
                            FOBPrice = ((Math.Round(G.Sum(m => m.CMP), 2) / G.Key.RateValue) * 1.05) + G.Key.ConfirmPrice,
                            FabAllow = G.Key.FabricAllowance,
                            AccAllow = G.Key.AccessoriesAllowance, 
                            Amount = G.Key.Quantity * (((Math.Round(G.Sum(m => m.CMP), 2) / G.Key.RateValue) * 1.05) + G.Key.ConfirmPrice),
            });
            return newQ;
        }

        private class Filter
        {
            public string section { get; set; }
            public DateTimeOffset? dateFrom { get; set; }
            public DateTimeOffset? dateTo { get; set; }
        }
    }
}
