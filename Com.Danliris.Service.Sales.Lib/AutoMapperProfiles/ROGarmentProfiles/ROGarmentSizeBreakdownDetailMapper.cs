﻿using AutoMapper;
using Com.Danliris.Service.Sales.Lib.Models.ROGarments;
using Com.Danliris.Service.Sales.Lib.ViewModels.GarmentROViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.AutoMapperProfiles.ROGarmentProfiles
{
    public class ROGarmentSizeBreakdownDetailMapper : Profile
    {
        public ROGarmentSizeBreakdownDetailMapper()
        {
            CreateMap<RO_Garment_SizeBreakdown_Detail, RO_Garment_SizeBreakdown_DetailViewModel>()
            .ReverseMap();
        }
    }
}