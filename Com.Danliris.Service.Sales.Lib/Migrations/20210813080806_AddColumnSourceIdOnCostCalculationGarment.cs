using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Danliris.Service.Sales.Lib.Migrations
{
    public partial class AddColumnSourceIdOnCostCalculationGarment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
//             migrationBuilder.DropIndex(
//                 name: "IX_GarmentPreSalesContracts_SalesContractNo",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropPrimaryKey(
//                 name: "PK_ArticleColor",
//                 table: "ArticleColor");

//             migrationBuilder.DropColumn(
//                 name: "SizeBreakdownDetailIndex",
//                 table: "SalesInvoiceExports");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankAccountName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankCurrencyCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankCurrencyID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankCurrencyRate",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankCurrencySymbol",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AccountBankNumber",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AgentCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AgentID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AgentName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "Amount",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "AutoIncrementNumber",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "BuyerCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "BuyerID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "BuyerName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "BuyerType",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "Code",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "Commission",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "CommodityCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "CommodityDescription",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "CommodityID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "CommodityName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "Condition",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "Date",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "DeliveredTo",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "DeliverySchedule",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "DesignMotiveCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "DesignMotiveID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "DesignMotiveName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "DispositionNumber",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "FromStock",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialConstructionCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialConstructionId",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialConstructionName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialPrice",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialTags",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "MaterialWidth",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "OrderTypeCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "OrderTypeID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "OrderTypeName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "Packing",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "PieceLength",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "PointLimit",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "PointSystem",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "PreSalesContractId",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "PreSalesContractNo",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "QualityCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "QualityID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "QualityName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "RemainingQuantity",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "SalesContractNo",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "SalesFirstName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "SalesId",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "SalesLastName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "SalesUserName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "ShipmentDescription",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "ShippingQuantityTolerance",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "TermOfPaymentCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "TermOfPaymentID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "TermOfPaymentIsExport",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "TermOfPaymentName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "TermOfShipment",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "TransportFee",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "UOMID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "UOMUnit",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "UnitName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "UseIncomeTax",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "YarnMaterialCode",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "YarnMaterialID",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.DropColumn(
//                 name: "YarnMaterialName",
//                 table: "GarmentPreSalesContracts");

//             migrationBuilder.RenameTable(
//                 name: "ArticleColor",
//                 newName: "ArticleColors");

//             migrationBuilder.AddColumn<string>(
//                 name: "SourceCode",
//                 table: "CostCalculationGarments",
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "SourceId",
//                 table: "CostCalculationGarments",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "SourceName",
//                 table: "CostCalculationGarments",
//                 nullable: true);

//             migrationBuilder.AddPrimaryKey(
//                 name: "PK_ArticleColors",
//                 table: "ArticleColors",
//                 column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
//             migrationBuilder.DropPrimaryKey(
//                 name: "PK_ArticleColors",
//                 table: "ArticleColors");

//             migrationBuilder.DropColumn(
//                 name: "SourceCode",
//                 table: "CostCalculationGarments");

//             migrationBuilder.DropColumn(
//                 name: "SourceId",
//                 table: "CostCalculationGarments");

//             migrationBuilder.DropColumn(
//                 name: "SourceName",
//                 table: "CostCalculationGarments");

//             migrationBuilder.RenameTable(
//                 name: "ArticleColors",
//                 newName: "ArticleColor");

//             migrationBuilder.AddColumn<int>(
//                 name: "SizeBreakdownDetailIndex",
//                 table: "SalesInvoiceExports",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "AccountBankAccountName",
//                 table: "GarmentPreSalesContracts",
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "AccountBankCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "AccountBankCurrencyCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "AccountBankCurrencyID",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<double>(
//                 name: "AccountBankCurrencyRate",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0.0);

//             migrationBuilder.AddColumn<string>(
//                 name: "AccountBankCurrencySymbol",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "AccountBankID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "AccountBankName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "AccountBankNumber",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "AgentCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "AgentID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "AgentName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<double>(
//                 name: "Amount",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0.0);

//             migrationBuilder.AddColumn<int>(
//                 name: "AutoIncrementNumber",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "BuyerCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "BuyerID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "BuyerName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "BuyerType",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "Code",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "Commission",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "CommodityCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "CommodityDescription",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "CommodityID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "CommodityName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "Condition",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<DateTimeOffset>(
//                 name: "Date",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

//             migrationBuilder.AddColumn<string>(
//                 name: "DeliveredTo",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<DateTimeOffset>(
//                 name: "DeliverySchedule",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

//             migrationBuilder.AddColumn<string>(
//                 name: "DesignMotiveCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "DesignMotiveID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "DesignMotiveName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "DispositionNumber",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<bool>(
//                 name: "FromStock",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: false);

//             migrationBuilder.AddColumn<string>(
//                 name: "MaterialCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "MaterialConstructionCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "MaterialConstructionId",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "MaterialConstructionName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "MaterialID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "MaterialName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<double>(
//                 name: "MaterialPrice",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0.0);

//             migrationBuilder.AddColumn<string>(
//                 name: "MaterialTags",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "MaterialWidth",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "OrderTypeCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "OrderTypeID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "OrderTypeName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "Packing",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "PieceLength",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<double>(
//                 name: "PointLimit",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0.0);

//             migrationBuilder.AddColumn<int>(
//                 name: "PointSystem",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<long>(
//                 name: "PreSalesContractId",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0L);

//             migrationBuilder.AddColumn<string>(
//                 name: "PreSalesContractNo",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 64,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "QualityCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "QualityID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "QualityName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<double>(
//                 name: "RemainingQuantity",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0.0);

//             migrationBuilder.AddColumn<string>(
//                 name: "SalesContractNo",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "SalesFirstName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1024,
//                 nullable: true);

//             migrationBuilder.AddColumn<long>(
//                 name: "SalesId",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0L);

//             migrationBuilder.AddColumn<string>(
//                 name: "SalesLastName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1024,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "SalesUserName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1024,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "ShipmentDescription",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<double>(
//                 name: "ShippingQuantityTolerance",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: false,
//                 defaultValue: 0.0);

//             migrationBuilder.AddColumn<string>(
//                 name: "TermOfPaymentCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "TermOfPaymentID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<bool>(
//                 name: "TermOfPaymentIsExport",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: false);

//             migrationBuilder.AddColumn<string>(
//                 name: "TermOfPaymentName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "TermOfShipment",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "TransportFee",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 1000,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "UOMID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "UOMUnit",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddColumn<string>(
//                 name: "UnitName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 512,
//                 nullable: true);

//             migrationBuilder.AddColumn<bool>(
//                 name: "UseIncomeTax",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: false);

//             migrationBuilder.AddColumn<string>(
//                 name: "YarnMaterialCode",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 25,
//                 nullable: true);

//             migrationBuilder.AddColumn<int>(
//                 name: "YarnMaterialID",
//                 table: "GarmentPreSalesContracts",
//                 nullable: false,
//                 defaultValue: 0);

//             migrationBuilder.AddColumn<string>(
//                 name: "YarnMaterialName",
//                 table: "GarmentPreSalesContracts",
//                 maxLength: 255,
//                 nullable: true);

//             migrationBuilder.AddPrimaryKey(
//                 name: "PK_ArticleColor",
//                 table: "ArticleColor",
//                 column: "Id");

//             migrationBuilder.CreateIndex(
//                 name: "IX_GarmentPreSalesContracts_SalesContractNo",
//                 table: "GarmentPreSalesContracts",
//                 column: "SalesContractNo",
//                 unique: true,
//                 filter: "[IsDeleted]=(0)");
        }
    }
}
