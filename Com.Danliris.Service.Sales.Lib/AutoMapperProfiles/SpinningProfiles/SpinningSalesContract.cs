﻿using AutoMapper;
using Com.Danliris.Service.Sales.Lib.Models.Spinning;
using Com.Danliris.Service.Sales.Lib.ViewModels.Spinning;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.AutoMapperProfiles.SpinningProfiles
{
    public class SpinningSalesContract : Profile
    {
        public SpinningSalesContract()
        {
            CreateMap<SpinningSalesContractModel, SpinningSalesContractViewModel>()
                .ForPath(d => d.Buyer.Id, opt => opt.MapFrom(s => s.BuyerId))
                .ForPath(d => d.Buyer.Code, opt => opt.MapFrom(s => s.BuyerCode))
                .ForPath(d => d.Buyer.Name, opt => opt.MapFrom(s => s.BuyerName))
                .ForPath(d => d.Buyer.Type, opt => opt.MapFrom(s => s.BuyerType))

                .ForPath(d => d.Comodity.Id, opt => opt.MapFrom(s => s.ComodityId))
                .ForPath(d => d.Comodity.Code, opt => opt.MapFrom(s => s.ComodityCode))
                .ForPath(d => d.Comodity.Name, opt => opt.MapFrom(s => s.ComodityName))
                .ForPath(d => d.Comodity.Type, opt => opt.MapFrom(s => s.ComodityType))

                .ForPath(d => d.Quality.Id, opt => opt.MapFrom(s => s.QualityId))
                .ForPath(d => d.Quality.Code, opt => opt.MapFrom(s => s.QualityCode))
                .ForPath(d => d.Quality.Name, opt => opt.MapFrom(s => s.QualityName))

                .ForPath(d => d.TermOfPayment.Id, opt => opt.MapFrom(s => s.TermOfPaymentId))
                .ForPath(d => d.TermOfPayment.Code, opt => opt.MapFrom(s => s.TermOfPaymentCode))
                .ForPath(d => d.TermOfPayment.Name, opt => opt.MapFrom(s => s.TermOfPaymentName))
                .ForPath(d => d.TermOfPayment.IsExport, opt => opt.MapFrom(s => s.TermOfPaymentIsExport))

                .ForPath(d => d.AccountBank.Id, opt => opt.MapFrom(s => s.AccountBankId))
                .ForPath(d => d.AccountBank.Code, opt => opt.MapFrom(s => s.AccountBankCode))
                .ForPath(d => d.AccountBank.AccountName, opt => opt.MapFrom(s => s.AccountBankName))
                .ForPath(d => d.AccountBank.AccountNumber, opt => opt.MapFrom(s => s.AccountBankNumber))
                .ForPath(d => d.AccountBank.BankName, opt => opt.MapFrom(s => s.BankName))
                .ForPath(d => d.AccountBank.AccountCurrencyId, opt => opt.MapFrom(s => s.AccountCurrencyId))
                .ForPath(d => d.AccountBank.AccountCurrencyCode, opt => opt.MapFrom(s => s.AccountCurrencyCode))

                .ForPath(d => d.Agent.Id, opt => opt.MapFrom(s => s.AgentId))
                .ForPath(d => d.Agent.Code, opt => opt.MapFrom(s => s.AgentCode))
                .ForPath(d => d.Agent.Name, opt => opt.MapFrom(s => s.AgentName))
                .ReverseMap();
        }
    }
}
