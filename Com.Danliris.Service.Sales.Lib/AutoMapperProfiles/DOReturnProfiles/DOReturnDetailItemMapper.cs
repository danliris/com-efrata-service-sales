﻿using AutoMapper;
using Com.Danliris.Service.Sales.Lib.Models.DOReturn;
using Com.Danliris.Service.Sales.Lib.ViewModels.DOReturn;

namespace Com.Danliris.Service.Sales.Lib.AutoMapperProfiles.DOReturnProfiles
{
    public class DOReturnDetailItemMapper : Profile
    {
        public DOReturnDetailItemMapper()
        {
            CreateMap<DOReturnDetailItemModel, DOReturnDetailItemViewModel>()
                
                //.ForPath(d => d.DOSales.Id, opt => opt.MapFrom(s => s.DOSalesId))
                //.ForPath(d => d.DOSales.DOSalesNo, opt => opt.MapFrom(s => s.DOSalesNo))

                .ReverseMap();
        }
    }
}
