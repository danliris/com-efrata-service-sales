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
    [Route("v{version:apiVersion}/report/available-ros")]
    [Authorize]
    public class AvailableROReportController : BaseMonitoringController<AvailableROReportViewModel, IAvailableROReportFacade>
    {
        private readonly static string apiVersion = "1.0";

        public AvailableROReportController(IIdentityService identityService, IAvailableROReportFacade facade) : base(identityService, facade, apiVersion)
        {
        }
    }
}
