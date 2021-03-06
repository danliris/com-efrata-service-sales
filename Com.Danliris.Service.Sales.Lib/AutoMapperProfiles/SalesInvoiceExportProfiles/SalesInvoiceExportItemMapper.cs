using AutoMapper;
using Com.Danliris.Service.Sales.Lib.Models.SalesInvoiceExport;
using Com.Danliris.Service.Sales.Lib.ViewModels.SalesInvoiceExport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.AutoMapperProfiles.SalesInvoiceExportProfiles
{
    public class SalesInvoiceExportItemMapper : Profile
    {
        public SalesInvoiceExportItemMapper()
        {
            CreateMap<SalesInvoiceExportItemModel, SalesInvoiceExportItemViewModel>()

                .ReverseMap();
        }
    }
}
