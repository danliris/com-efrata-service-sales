﻿using Com.Danliris.Service.Sales.Lib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.ViewModels.DOAval
{
    public class DOAvalItemViewModel : BaseViewModel
    {
        public string AvalType { get; set; }
        public double Packing { get; set; }
        public double Weight { get; set; }
    }
}
