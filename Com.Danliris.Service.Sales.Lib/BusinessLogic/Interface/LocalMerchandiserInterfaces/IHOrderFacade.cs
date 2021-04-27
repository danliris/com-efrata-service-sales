﻿using Com.Danliris.Service.Sales.Lib.ViewModels.IntegrationViewModel.LocalMerchandiserViewModels;
using System.Collections.Generic;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.LocalMerchandiserInterfaces
{
    public interface IHOrderFacade
    {
        List<string> GetKodeByNo(string no = null);
        List<HOrderDataForProductionReportViewModel> GetDataForProductionReportByNo(string ro);
    }
}
