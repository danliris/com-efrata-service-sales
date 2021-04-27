﻿using Com.Danliris.Service.Sales.Lib.Models.GarmentBookingOrderModel;
using Com.Danliris.Service.Sales.Lib.Utilities;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.GarmentBookingOrderInterface
{
    public interface IGarmentBookingOrder : IBaseFacade<GarmentBookingOrder>
    {
        Task<int> BODelete(int id, GarmentBookingOrder model);
        Task<int> BOCancel(int id, GarmentBookingOrder model);
        ReadResponse<GarmentBookingOrder> ReadByBookingOrderNo(int page, int size, string order, List<string> select, string keyword, string filter);
    }
}
