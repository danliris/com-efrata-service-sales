﻿using AutoMapper;
using Com.Danliris.Service.Sales.Lib.Helpers;
using Com.Danliris.Service.Sales.Lib.Models.CostCalculationGarments;
using Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.AutoMapperProfiles.CostCalculationGarmentProfiles
{
	public class CostCalculationGarmentMapper : Profile
	{
		public CostCalculationGarmentMapper()
		{
			CreateMap<CostCalculationGarment, CostCalculationGarmentViewModel>()
			  .ForPath(d => d.Unit.Id, opt => opt.MapFrom(s => s.UnitId))
			  .ForPath(d => d.Unit.Code, opt => opt.MapFrom(s => s.UnitCode))
			  .ForPath(d => d.Unit.Name, opt => opt.MapFrom(s => s.UnitName))
			  .ForPath(d => d.ImageFile, opt => opt.MapFrom(s => s.ImageFile))
			  .ForPath(d => d.ImagePath, opt => opt.MapFrom(s => s.ImagePath))
			  .ForPath(d => d.FabricAllowance, opt => opt.MapFrom(s => s.FabricAllowance))
			  .ForPath(d => d.AccessoriesAllowance, opt => opt.MapFrom(s => s.AccessoriesAllowance))
			  .ForPath(d => d.SizeRange, opt => opt.MapFrom(s => s.SizeRange))
			  .ForPath(d => d.Buyer.Id, opt => opt.MapFrom(s => s.BuyerId))
			  .ForPath(d => d.Buyer.Code, opt => opt.MapFrom(s => s.BuyerCode))
			  .ForPath(d => d.Buyer.Name, opt => opt.MapFrom(s => s.BuyerName))
			  .ForPath(d => d.Efficiency.Id, opt => opt.MapFrom(s => s.EfficiencyId))
			  .ForPath(d => d.Efficiency.Value, opt => opt.MapFrom(s => Percentage.ToPercent(s.EfficiencyValue)))
			  .ForPath(d => d.UOM.Id, opt => opt.MapFrom(s => s.UOMID))
			  .ForPath(d => d.UOM.code, opt => opt.MapFrom(s => s.UOMCode))
			  .ForPath(d => d.UOM.Unit, opt => opt.MapFrom(s => s.UOMUnit))
			  .ForPath(d => d.Wage.Id, opt => opt.MapFrom(s => s.WageId))
			  .ForPath(d => d.Wage.Value, opt => opt.MapFrom(s => s.WageRate ))
			  .ForPath(d => d.Comodity.Id, opt => opt.MapFrom(s => s.ComodityID))
			  .ForPath(d => d.Comodity.Code, opt => opt.MapFrom(s => s.ComodityCode))
			  .ForPath(d => d.Comodity.Name, opt => opt.MapFrom(s => s.Commodity))
			  .ForPath(d => d.CommodityDescription, opt => opt.MapFrom(s => s.CommodityDescription))
			  .ForPath(d => d.THR.Id, opt => opt.MapFrom(s => s.THRId))
			  .ForPath(d => d.THR.Value, opt => opt.MapFrom(s => s.THRRate))
			  .ForPath(d => d.Rate.Id, opt => opt.MapFrom(s => s.RateId))
			  .ForPath(d => d.Rate.Value, opt => opt.MapFrom(s => s.RateValue))
			  .ForPath(d => d.UOM.Id, opt => opt.MapFrom(s => s.UOMID))
			  .ForPath(d => d.UOM.code, opt => opt.MapFrom(s => s.UOMCode))
			  .ForPath(d => d.UOM.Unit, opt => opt.MapFrom(s => s.UOMUnit))
              .ForPath(d => d.BuyerBrand.Id, opt => opt.MapFrom(s => s.BuyerBrandId))
              .ForPath(d => d.BuyerBrand.Code, opt => opt.MapFrom(s => s.BuyerBrandCode))
              .ForPath(d => d.BuyerBrand.Name, opt => opt.MapFrom(s => s.BuyerBrandName))
              .ForPath(d => d.CommissionPortion, opt => opt.MapFrom(s =>(s.CommissionPortion)))
			  .ForPath(d => d.Risk, opt => opt.MapFrom(s => (s.Risk)))
			  .ForPath(d => d.OTL1.Id, opt => opt.MapFrom(s => s.OTL1Id))
			  .ForPath(d => d.OTL1.Value, opt => opt.MapFrom(s => s.OTL1Rate))
			  .ForPath(d => d.OTL1.CalculatedValue, opt => opt.MapFrom(s => s.OTL1CalculatedRate))
              .ForPath(d => d.LeadTime, opt => opt.MapFrom(s => s.LeadTime))
              .ForPath(d => d.OTL2.Id, opt => opt.MapFrom(s => s.OTL2Id))
			  .ForPath(d => d.OTL2.Value, opt => opt.MapFrom(s => s.OTL2Rate))
              .ForPath(d => d.UnitName, opt => opt.MapFrom(s => s.UnitName))
              .ForPath(d => d.OTL2.CalculatedValue, opt => opt.MapFrom(s => s.OTL2CalculatedRate))
			  .ForPath(d => d.NETFOBP, opt => opt.MapFrom(s => s.NETFOBP))
              .ForPath(d => d.Index, opt => opt.MapFrom(s =>s.Index))

              .ForPath(d => d.ApprovalMD.IsApproved, opt => opt.MapFrom(s => s.IsApprovedMD))
              .ForPath(d => d.ApprovalMD.ApprovedBy, opt => opt.MapFrom(s => s.ApprovedMDBy))
              .ForPath(d => d.ApprovalMD.ApprovedDate, opt => opt.MapFrom(s => s.ApprovedMDDate))

              .ForPath(d => d.ApprovalPurchasing.IsApproved, opt => opt.MapFrom(s => s.IsApprovedPurchasing))
              .ForPath(d => d.ApprovalPurchasing.ApprovedBy, opt => opt.MapFrom(s => s.ApprovedPurchasingBy))
              .ForPath(d => d.ApprovalPurchasing.ApprovedDate, opt => opt.MapFrom(s => s.ApprovedPurchasingDate))

              .ForPath(d => d.ApprovalIE.IsApproved, opt => opt.MapFrom(s => s.IsApprovedIE))
              .ForPath(d => d.ApprovalIE.ApprovedBy, opt => opt.MapFrom(s => s.ApprovedIEBy))
              .ForPath(d => d.ApprovalIE.ApprovedDate, opt => opt.MapFrom(s => s.ApprovedIEDate))

              .ForPath(d => d.ApprovalKadivMD.IsApproved, opt => opt.MapFrom(s => s.IsApprovedKadivMD))
              .ForPath(d => d.ApprovalKadivMD.ApprovedBy, opt => opt.MapFrom(s => s.ApprovedKadivMDBy))
              .ForPath(d => d.ApprovalKadivMD.ApprovedDate, opt => opt.MapFrom(s => s.ApprovedKadivMDDate))

              .ForPath(d => d.ApprovalPPIC.IsApproved, opt => opt.MapFrom(s => s.IsApprovedPPIC))
              .ForPath(d => d.ApprovalPPIC.ApprovedBy, opt => opt.MapFrom(s => s.ApprovedPPICBy))
              .ForPath(d => d.ApprovalPPIC.ApprovedDate, opt => opt.MapFrom(s => s.ApprovedPPICDate))

              .ReverseMap();
		}
	}
}
