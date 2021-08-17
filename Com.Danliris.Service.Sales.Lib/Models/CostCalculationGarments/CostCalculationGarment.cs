//using Com.Danliris.Service.Sales.Lib.Models.ROGarments;
using Com.Danliris.Service.Sales.Lib.Utilities.BaseClass;
using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Com.Danliris.Service.Sales.Lib.Models.CostCalculationGarments
{
    public class CostCalculationGarment : BaseModel
    {
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string RO_Number { get; set; }
        //public string RO { get; set; }
        [MaxLength(50)]
        public string Article { get; set; }
        [MaxLength(50)]
        public string ComodityID { get; set; }
        [MaxLength(50)]
        public string ComodityCode { get; set; }
        [MaxLength(255)]
        public string Commodity { get; set; }
        [MaxLength(1000)]
        public string CommodityDescription { get; set; }
        public double FabricAllowance { get; set; }
        public double AccessoriesAllowance { get; set; }
        [MaxLength(50)]
        public string Section { get; set; }
        [MaxLength(255)]
        public string SectionName { get; set; }
        [MaxLength(50)]
        public string UOMID { get; set; }
        [MaxLength(50)]
        public string UOMCode { get; set; }
        [MaxLength(100)]
        public string UOMUnit { get; set; }
        public int Quantity { get; set; }
        [MaxLength(50)]
        public string SizeRange { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public DateTimeOffset ConfirmDate { get; set; }
        public int LeadTime { get; set; }
        public double SMV_Cutting { get; set; }
        public double SMV_Sewing { get; set; }
        public double SMV_Finishing { get; set; }
        public double SMV_Total { get; set; }
        [MaxLength(50)]
        public string BuyerId { get; set; }
        [MaxLength(50)]
        public string BuyerCode { get; set; }
        [MaxLength(255)]
        public string BuyerName { get; set; }
        public int EfficiencyId { get; set; }
        public double EfficiencyValue { get; set; }
        public double Index { get; set; }
        public int WageId { get; set; }
        public double WageRate { get; set; }
        public int THRId { get; set; }
        public double THRRate { get; set; }
        public double ConfirmPrice { get; set; }
        public int RateId { get; set; }
        public double RateValue { get; set; }
        public ICollection<CostCalculationGarment_Material> CostCalculationGarment_Materials { get; set; }
        public double Freight { get; set; }
        public double Insurance { get; set; }
        public double CommissionPortion { get; set; }
        public double CommissionRate { get; set; }
        public int OTL1Id { get; set; }
        public double OTL1Rate { get; set; }
        public double OTL1CalculatedRate { get; set; }
        public int OTL2Id { get; set; }
        public double OTL2Rate { get; set; }
        public double OTL2CalculatedRate { get; set; }
        public double Risk { get; set; }
        public double ProductionCost { get; set; }
        public double NETFOB { get; set; }
        public double FreightCost { get; set; }
        public double NETFOBP { get; set; }
        [MaxLength(3000)]
        public string Description { get; set; }
        public string ImageFile { get; set; }
        [MaxLength(1000)]
        public string ImagePath { get; set; }
        public int? RO_GarmentId { get; set; }
        public int UnitId { get; set; }
        [MaxLength(50)]
        public string UnitCode { get; set; }
        [MaxLength(255)]
        public string UnitName { get; set; }
        public int AutoIncrementNumber { get; set; }
        //[ForeignKey("RO_GarmentId")]
        //public virtual RO_Garment RO_Garment { get; set; }

        public int BuyerBrandId { get; set; }
        [MaxLength(50)]
        public string BuyerBrandCode { get; set; }
        [MaxLength(255)]
        public string BuyerBrandName { get; set; }
        public long? SCGarmentId { get; set; }

        public long PreSCId { get; set; }
        [MaxLength(255)]
        public string PreSCNo { get; set; }

        public bool IsApprovedMD { get; set; }
        public DateTimeOffset ApprovedMDDate { get; set; }
        [MaxLength(50)]
        public string ApprovedMDBy { get; set; }

        public bool IsApprovedPurchasing { get; set; }
        public DateTimeOffset ApprovedPurchasingDate { get; set; }
        [MaxLength(50)]
        public string ApprovedPurchasingBy { get; set; }

        public bool IsApprovedIE { get; set; }
        public DateTimeOffset ApprovedIEDate { get; set; }
        [MaxLength(50)]
        public string ApprovedIEBy { get; set; }

        public bool IsApprovedKadivMD { get; set; }
        public DateTimeOffset ApprovedKadivMDDate { get; set; }
        [MaxLength(50)]
        public string ApprovedKadivMDBy { get; set; }

        public bool IsApprovedPPIC { get; set; }
        public DateTimeOffset ApprovedPPICDate { get; set; }
        [MaxLength(50)]
        public string ApprovedPPICBy { get; set; }

        public bool IsValidatedROSample { get; set; }
        public DateTimeOffset ValidationSampleDate { get; set; }
        [MaxLength(50)]
        public string ValidationSampleBy { get; set; }

        public bool IsValidatedROMD { get; set; }
        public DateTimeOffset ValidationMDDate { get; set; }
        [MaxLength(50)]
        public string ValidationMDBy { get; set; }

        public bool IsValidatedROPPIC { get; set; }
        public DateTimeOffset ValidationPPICDate { get; set; }
        [MaxLength(50)]
        public string ValidationPPICBy { get; set; }

        public bool IsROAccepted { get; set; }
        public DateTimeOffset ROAcceptedDate { get; set; }
        [MaxLength(50)]
        public string ROAcceptedBy { get; set; }
        public bool IsROAvailable { get; set; }
        public DateTimeOffset ROAvailableDate { get; set; }
        [MaxLength(50)]
        public string ROAvailableBy { get; set; }
        public bool IsRODistributed { get; set; }
        public DateTimeOffset RODistributionDate { get; set; }
        [MaxLength(50)]
        public string RODistributionBy { get; set; }

        public bool IsPosted { get; set; }

        public int SourceId { get; set; }
        public string SourceName { get; set; }
        public string SourceCode { get; set; }
    }
}
