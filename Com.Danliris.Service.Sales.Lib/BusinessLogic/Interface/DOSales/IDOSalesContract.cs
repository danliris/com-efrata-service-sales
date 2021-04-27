﻿using Com.Danliris.Service.Sales.Lib.Models.DOSales;
using Com.Danliris.Service.Sales.Lib.Utilities;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseInterface;
using System.Collections.Generic;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.DOSales
{
    public interface IDOSalesContract : IBaseFacade<DOSalesModel>
    {
        ReadResponse<DOSalesModel> ReadDPAndStock(int page, int size, string order, List<string> select, string keyword, string filter);
    }
}
