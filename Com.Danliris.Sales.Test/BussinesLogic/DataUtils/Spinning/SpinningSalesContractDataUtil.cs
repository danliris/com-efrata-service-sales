﻿using Com.Danliris.Sales.Test.BussinesLogic.Utils;
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Facades.Spinning;
using Com.Danliris.Service.Sales.Lib.Models.Spinning;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Sales.Test.BussinesLogic.DataUtils.SpinningSalesContractDataUtil
{
    public class SpinningSalesContractDataUtil : BaseDataUtil<SpinningSalesContractFacade, SpinningSalesContractModel>
    {
        public SpinningSalesContractDataUtil(SpinningSalesContractFacade facade) : base(facade)
        {
        }

        public override Task<SpinningSalesContractModel> GetNewData()
        {
            return Task.FromResult(new SpinningSalesContractModel()
            {
                SalesContractNo = "a",
                AccountBankCode = "a",
                DispositionNumber = "a",
                IncomeTax = "a",
                Price = 1,
                BuyerName = "a",
                QualityName = "a",
                AccountBankName = "name",
                AccountBankNumber = "nm",
                BuyerType = "type"
            });

        }
    }
}

