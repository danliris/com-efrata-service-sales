﻿using Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.Garment;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.ViewModels.Garment;
using Com.Danliris.Service.Sales.WebApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Com.Danliris.Service.Sales.WebApi.Controllers.Garment.MonitoringControllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/report/available-ro-garment")]
    [Authorize]
    public class AvailableROGarmentReportController : BaseMonitoringController<AvailableROGarmentReportViewModel, IAvailableROGarmentReportFacade>
    {
        private readonly static string apiVersion = "1.0";

        public AvailableROGarmentReportController(IIdentityService identityService, IAvailableROGarmentReportFacade facade) : base(identityService, facade, apiVersion)
        {
        }
    }
}
