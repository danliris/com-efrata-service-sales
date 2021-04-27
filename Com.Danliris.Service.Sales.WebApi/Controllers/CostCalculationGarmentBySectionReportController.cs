﻿
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.CostCalculationGarmentLogic;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment;
using Com.Danliris.Service.Sales.WebApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Sales.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/cost-calculation-display-by-section")]
    [Authorize]
    public class CostCalculationBySectionReportController : BaseMonitoringController<CostCalculationGarmentBySectionReportViewModel, ICostCalculationGarmentBySectionReport>
    {
        private readonly static string apiVersion = "1.0";

        public CostCalculationBySectionReportController(IIdentityService identityService, ICostCalculationGarmentBySectionReport facade) : base(identityService, facade, apiVersion)
        {
        }
    }
}