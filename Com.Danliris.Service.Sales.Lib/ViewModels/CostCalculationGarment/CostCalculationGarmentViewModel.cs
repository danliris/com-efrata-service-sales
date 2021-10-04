using Com.Danliris.Service.Sales.Lib.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace Com.Danliris.Service.Sales.Lib.ViewModels.CostCalculationGarment
{
    public class CostCalculationGarmentViewModel : BaseViewModel, IValidatableObject
    {
        public int AutoIncrementNumber { get; set; }
        public double? AccessoriesAllowance { get; set; }
        public string Article { get; set; }
        public BuyerViewModel Buyer { get; set; }
        public double? CommissionPortion { get; set; }
        public double CommissionRate { get; set; }
        public UOMViewModel UOM { get; set; }
        public BuyerBrandViewModel BuyerBrand { get; set; }
        public DateTimeOffset ConfirmDate { get; set; }
        public MasterPlanComodityViewModel Comodity { get; set; }
        public string CommodityDescription { get; set; }
        public double? ConfirmPrice { get; set; }
        public List<CostCalculationGarment_MaterialViewModel> CostCalculationGarment_Materials { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public string Description { get; set; }
        public EfficiencyViewModel Efficiency { get; set; }
        public double? FabricAllowance { get; set; }
        public double? Freight { get; set; }
        public double FreightCost { get; set; }
        public string ImageFile { get; set; }
        public double Index { get; set; }
        public double? Insurance { get; set; }
        public int? LeadTime { get; set; }
        public string Code { get; set; }
        public int? RO_GarmentId { get; set; }
        public string RO_Number { get; set; }
        public string Section { get; set; }
        public string SectionName { get; set; }
        public int? Quantity { get; set; }
        public string SizeRange { get; set; }
        public double? SMV_Cutting { get; set; }
        public double? SMV_Sewing { get; set; }
        public double? SMV_Finishing { get; set; }
        public double SMV_Total { get; set; }
        public RateViewModel Wage { get; set; }
        public RateViewModel THR { get; set; }
        public RateViewModel Rate { get; set; }
        public RateCalculatedViewModel OTL1 { get; set; }
        public RateCalculatedViewModel OTL2 { get; set; }
        public double Risk { get; set; }
        public double ProductionCost { get; set; }
        public double NETFOB { get; set; }
        public double NETFOBP { get; set; }
        public string ImagePath { get; set; }
        public int? RO_RetailId { get; set; }
        public UnitViewModel Unit { get; set; }
        public string UnitName { get; set; }

        public long? SCGarmentId { get; set; }

        public long PreSCId { get; set; }
        public string PreSCNo { get; set; }

        public Approval ApprovalMD { get; set; }
        public Approval ApprovalPurchasing { get; set; }
        public Approval ApprovalIE { get; set; }
        public Approval ApprovalPPIC { get; set; }
        public Approval ApprovalKadivMD { get; set; }

        public bool IsValidatedROSample { get; set; }
        public DateTimeOffset ValidationSampleDate { get; set; }
        public string ValidationSampleBy { get; set; }

        public bool IsValidatedROMD { get; set; }
        public DateTimeOffset ValidationMDDate { get; set; }
        public string ValidationMDBy { get; set; }

        public bool IsValidatedROPPIC { get; set; }
        public DateTimeOffset ValidationPPICDate { get; set; }
        public string ValidationPPICBy { get; set; }

        public bool IsROAccepted { get; set; }
        public DateTimeOffset ROAcceptedDate { get; set; }
        public string ROAcceptedBy { get; set; }
        public bool IsROAvailable { get; set; }
        public DateTimeOffset ROAvailableDate { get; set; }
        public string ROAvailableBy { get; set; }
        public bool IsRODistributed { get; set; }
        public DateTimeOffset RODistributionDate { get; set; }
        public string RODistributionBy { get; set; }

        public bool IsPosted { get; set; }

        public int SourceId { get; set; }
        public string SourceName { get; set; }
        public string SourceCode { get; set; }

        public ItemArticleProcesViewModel process { get; set; }
        public ItemArticleMaterialViewModel materials { get; set; }
        public ItemArticleMaterialCompositionViewModel materialCompositions { get; set; }
        public ItemArticleCollectionViewModel collections { get; set; }
        public ItemArticleSeasonViewModel seasons { get; set; }
        public ItemArticleCounterViewModel counters { get; set; }
        public ItemArticleSubCounterViewModel subCounters { get; set; }
        public ItemArticleCategoryViewModel categories { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PreSCId < 1 || string.IsNullOrWhiteSpace(PreSCNo))
            {
                yield return new ValidationResult("Sales Contract harus diisi", new List<string> { "PreSalesContract" });
            }

            if (string.IsNullOrWhiteSpace(this.Article))
                yield return new ValidationResult("Nama Artikel harus diisi", new List<string> { "Article" });
            if (string.IsNullOrWhiteSpace(this.SourceCode))
                yield return new ValidationResult("Asal harus diisi", new List<string> { "Source" });
            if (string.IsNullOrWhiteSpace(this.process.code))
                yield return new ValidationResult("Proses Harus diisi", new List<string> { "Process" });
            if (string.IsNullOrWhiteSpace(this.materials.code))
                yield return new ValidationResult("Bahan harus diisi", new List<string> { "Materials" });
            if (string.IsNullOrWhiteSpace(this.materialCompositions.code))
                yield return new ValidationResult("Komposisi Bahan harus diisi", new List<string> { "MaterialCompositions" });
            if (string.IsNullOrWhiteSpace(this.collections.code))
                yield return new ValidationResult("Koleksi harus diisi", new List<string> { "Collections" });
            if (string.IsNullOrWhiteSpace(this.seasons.code))
                yield return new ValidationResult("Season harus diisi", new List<string> { "Seasons" });
            if (string.IsNullOrWhiteSpace(this.counters.code))
                yield return new ValidationResult("Konter harus diisi", new List<string> { "Counters" });
            if (string.IsNullOrWhiteSpace(this.subCounters.code))
                yield return new ValidationResult("Style harus diisi", new List<string> { "SubCounters" });
            if (string.IsNullOrWhiteSpace(this.categories.code))
                yield return new ValidationResult("Kategori harus diisi", new List<string> { "Categories" });
            if (Unit == null || string.IsNullOrWhiteSpace(this.Unit.Code))
                yield return new ValidationResult("Konveksi harus diisi", new List<string> { "Unit" });
            if (Comodity == null || string.IsNullOrWhiteSpace(Comodity.Code))
                yield return new ValidationResult("Komoditi harus diisi", new List<string> { "Commodity" });

            if (FabricAllowance.GetValueOrDefault() < 0)
                yield return new ValidationResult("Fabric harus lebih dari atau sama dengan 0", new List<string> { "FabricAllowance" });

            if (AccessoriesAllowance.GetValueOrDefault() < 0)
                yield return new ValidationResult("Access harus lebih dari atau sama dengan 0", new List<string> { "AccessoriesAllowance" });

            if (UOM == null || string.IsNullOrWhiteSpace(UOM.Unit))
                yield return new ValidationResult("Satuan harus diisi", new List<string> { "UOM" });
            if (BuyerBrand == null || string.IsNullOrWhiteSpace(BuyerBrand.Code))
                yield return new ValidationResult("Brand Buyer harus diisi", new List<string> { "BuyerBrand" });

            if (this.Quantity == null)
                yield return new ValidationResult("Kuantitas harus diisi", new List<string> { "Quantity" });
            else if (this.Quantity <= 0)
                yield return new ValidationResult("Kuantitas harus lebih besar dari 0", new List<string> { "Quantity" });
            else if (this.Efficiency == null || this.Efficiency.Id == 0)
                yield return new ValidationResult("Tidak ditemukan Efisiensi pada kuantitas ini", new List<string> { "Quantity" });
            if (string.IsNullOrWhiteSpace(this.SizeRange))
                yield return new ValidationResult("Size Range harus diisi", new List<string> { "SizeRange" });
            if (this.DeliveryDate == null || this.DeliveryDate == DateTimeOffset.MinValue)
                yield return new ValidationResult("Delivery Date harus diisi", new List<string> { "DeliveryDate" });
            else if (this.DeliveryDate < DateTimeOffset.Now)
                yield return new ValidationResult("Delivery Date harus lebih besar dari hari ini", new List<string> { "DeliveryDate" });
            if (this.SMV_Cutting == null)
                yield return new ValidationResult("SMV Cutting harus diisi", new List<string> { "SMV_Cutting" });
            else if (this.SMV_Cutting <= 0)
                yield return new ValidationResult("SMV Cutting harus lebih besar dari 0", new List<string> { "SMV_Cutting" });
            if (this.SMV_Sewing == null)
                yield return new ValidationResult("SMV Sewing harus diisi", new List<string> { "SMV_Sewing" });
            else if (this.SMV_Sewing <= 0)
                yield return new ValidationResult("SMV Sewing harus lebih besar dari 0", new List<string> { "SMV_Sewing" });
            if (this.SMV_Finishing == null)
                yield return new ValidationResult("SMV Finishing harus diisi", new List<string> { "SMV_Finishing" });
            else if (this.SMV_Finishing <= 0)
                yield return new ValidationResult("SMV Finishing harus lebih besar dari 0", new List<string> { "SMV_Finishing" });
            if (Buyer == null || string.IsNullOrWhiteSpace(Buyer.Code))
                yield return new ValidationResult("Buyer harus diisi", new List<string> { "Buyer" });
            if (this.ConfirmPrice == null)
                yield return new ValidationResult("Confirm Price harus diisi", new List<string> { "ConfirmPrice" });
            else if (this.ConfirmPrice <= 0)
                yield return new ValidationResult("Confirm Price harus lebih besar dari 0", new List<string> { "ConfirmPrice" });

            int Count = 0;
            string costCalculationGarment_MaterialsError = "[";

            if (this.CostCalculationGarment_Materials == null || this.CostCalculationGarment_Materials.Count.Equals(0))
                yield return new ValidationResult("Tabel Cost Calculation Garment Material dibawah harus diisi", new List<string> { "CostCalculationGarment_MaterialTable" });
            else
            {
                foreach (CostCalculationGarment_MaterialViewModel costCalculation_Material in this.CostCalculationGarment_Materials)
                {
                    costCalculationGarment_MaterialsError += "{";
                    if (costCalculation_Material.Category == null || string.IsNullOrWhiteSpace(costCalculation_Material.Category.code))
                    {
                        Count++;
                        costCalculationGarment_MaterialsError += "Category: 'Kategori harus diisi', ";
                    }
                    else
                    {
                        //if (costCalculation_Material.Material == null || costCalculation_Material.Material.Id == 0)
                        //{
                        //    Count++;
                        //    costCalculationGarment_MaterialsError += "Material: 'Material harus diisi', ";
                        //}

                        if (costCalculation_Material.Quantity == null)
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "Quantity: 'Kuantitas harus diisi', ";
                        }
                        else if (costCalculation_Material.Quantity <= 0)
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "Quantity: 'Kuantitas harus lebih besar dari 0', ";
                        }
                        else if (costCalculation_Material.PRMasterItemId > 0)
                        {
                            var filteredQuantity = CostCalculationGarment_Materials.Where(w => w.PRMasterItemId == costCalculation_Material.PRMasterItemId).Sum(s => s.BudgetQuantity);
                            if (filteredQuantity > costCalculation_Material.AvailableQuantity)
                            {
                                Count++;
                                costCalculationGarment_MaterialsError += $"BudgetQuantity: 'Kuantitas Budget tidak boleh lebih dari Jumlah Tersedia ({costCalculation_Material.AvailableQuantity})', ";
                            }
                        }
                        if (costCalculation_Material.Price == null)
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "Price: 'Harga harus diisi', ";
                        }
                        //else if (costCalculation_Material.Price <= 0)
                        //{
                        //    Count++;
                        //    costCalculationGarment_MaterialsError += "Price: 'Harga harus lebih besar dari 0', ";
                        //}
                        if (costCalculation_Material.Conversion == null)
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "Conversion: 'Konversi harus diisi', ";
                        }
                        else if (costCalculation_Material.Conversion <= 0)
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "Conversion: 'Konversi harus lebih besar dari 0', ";
                        }

                        if (costCalculation_Material.UOMQuantity == null || string.IsNullOrWhiteSpace(costCalculation_Material.UOMQuantity.Unit))
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "UOMQuantity: 'Satuan Kuantitas harus diisi', ";
                        }
                        if (costCalculation_Material.UOMPrice != null && costCalculation_Material.UOMQuantity != null && costCalculation_Material.Conversion != null && costCalculation_Material.Conversion > 0)
                        {
                            if (costCalculation_Material.UOMPrice.Unit == costCalculation_Material.UOMQuantity.Unit && costCalculation_Material.Conversion > 1)
                            {
                                Count++;
                                costCalculationGarment_MaterialsError += "Conversion: 'Satuan Sama, Konversi harus 1', ";
                            }
                        }
                        if (costCalculation_Material.UOMPrice == null || string.IsNullOrWhiteSpace(costCalculation_Material.UOMPrice.Unit))
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "UOMPrice: 'Satuan Harga harus diisi', ";
                        }
                        if (costCalculation_Material.Description == null || string.IsNullOrWhiteSpace(costCalculation_Material.Description))
                        {
                            Count++;
                            costCalculationGarment_MaterialsError += "Description: 'Deskripsi harus diisi', ";
                        }
                        //if (costCalculation_Material.ProductRemark == null || string.IsNullOrWhiteSpace(costCalculation_Material.ProductRemark))
                        //{
                        //    Count++;
                        //    costCalculationGarment_MaterialsError += "ProductRemark: 'Detail Barang harus diisi', ";
                        //}
                    }
                    costCalculationGarment_MaterialsError += "},";
                }
            }

            costCalculationGarment_MaterialsError += "]";

            if (Count > 0)
            {
                yield return new ValidationResult(costCalculationGarment_MaterialsError, new List<string> { "CostCalculationGarment_Materials" });
            }
        }
    }

    public class Approval
    {
        public bool IsApproved { get; set; }
        public DateTimeOffset ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
    }

    public class ItemArticleProcesViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ItemArticleMaterialViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ItemArticleMaterialCompositionViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ItemArticleCollectionViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ItemArticleSeasonViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ItemArticleCounterViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ItemArticleSubCounterViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ItemArticleCategoryViewModel
    {
        public int _id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }
}
