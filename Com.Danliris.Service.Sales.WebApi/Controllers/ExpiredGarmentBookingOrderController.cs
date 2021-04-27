﻿using AutoMapper;
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Facades.GarmentBookingOrderFacade;
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.GarmentBookingOrderInterface;
using Com.Danliris.Service.Sales.Lib.Models.GarmentBookingOrderModel;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.Utilities;
using Com.Danliris.Service.Sales.Lib.ViewModels.GarmentBookingOrderViewModels;
using Com.Danliris.Service.Sales.WebApi.Helpers;
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
    [Route("v{version:apiVersion}/sales/booking-orders-expired")]
    [Authorize]
    public class ExpiredGarmentBookingOrderController : BaseController<GarmentBookingOrder, GarmentBookingOrderViewModel, IExpiredGarmentBookingOrder>
    {
        private readonly static string apiVersion = "1.0";
        private readonly IExpiredGarmentBookingOrder facades;
        private readonly IIdentityService Service;
        public ExpiredGarmentBookingOrderController(IIdentityService identityService, IValidateService validateService, IExpiredGarmentBookingOrder facade, IMapper mapper, IServiceProvider serviceProvider) : base(identityService, validateService, facade, mapper, apiVersion)
        {
            facades = facade;
            Service = identityService;
        }

        [HttpGet("Expired")]
        public IActionResult Get(int page = 1, int size = 25, [Bind(Prefix = "Select[]")]List<string> select = null, string order = "{}", string keyword = null, string filter = "{}")
        {
            try
            {
                ReadResponse<GarmentBookingOrder> read = Facade.ReadExpired(page, size, order, select, keyword, filter);

                List<GarmentBookingOrderViewModel> DataVM = Mapper.Map<List<GarmentBookingOrderViewModel>>(read.Data);

                Dictionary<string, object> Result =
                    new Utilities.ResultFormatter(ApiVersion, Common.OK_STATUS_CODE, Common.OK_MESSAGE)
                    .Ok<GarmentBookingOrderViewModel>(Mapper, DataVM, page, size, read.Count, DataVM.Count, read.Order, read.Selected);
                return Ok(Result);

            }
            catch (Exception e)
            {
                Dictionary<string, object> Result =
                    new Utilities.ResultFormatter(ApiVersion, Common.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(Common.INTERNAL_ERROR_STATUS_CODE, Result);
            }
        }

        [HttpPost("BOCancel")]
        public IActionResult ExpiredBoPost([FromBody]List<GarmentBookingOrderViewModel> ListGarmentBookingOrderViewModel)
        {
            IdentityService.Username = User.Claims.Single(p => p.Type.Equals("username")).Value;
            try
            {
                Facade.BOCancelExpired(
                    ListGarmentBookingOrderViewModel.Select(vm => Mapper.Map<GarmentBookingOrder>(vm)).ToList(), IdentityService.Username
                );

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE);
            }
        }
    }
}
