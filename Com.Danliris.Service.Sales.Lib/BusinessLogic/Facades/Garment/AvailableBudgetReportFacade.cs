﻿using Com.Danliris.Service.Sales.Lib.BusinessLogic.Interface.Garment;
using Com.Danliris.Service.Sales.Lib.BusinessLogic.Logic.Garment;
using Com.Danliris.Service.Sales.Lib.Helpers;
using Com.Danliris.Service.Sales.Lib.Models.CostCalculationGarments;
using Com.Danliris.Service.Sales.Lib.Services;
using Com.Danliris.Service.Sales.Lib.ViewModels.Garment;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Com.Danliris.Service.Sales.Lib.BusinessLogic.Facades.Garment
{
    public class AvailableBudgetReportFacade : IAvailableBudgetReportFacade
    {
        private AvailableBudgetReportLogic logic;
        private IIdentityService identityService;

        public AvailableBudgetReportFacade(IServiceProvider serviceProvider)
        {
            logic = serviceProvider.GetService<AvailableBudgetReportLogic>();
            identityService = serviceProvider.GetService<IIdentityService>();
        }

        public Tuple<MemoryStream, string> GenerateExcel(string filter = "{}")
        {
            var Query = logic.GetQuery(filter);
            var data = GetData(Query.ToList());

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn() { ColumnName = "No", DataType = typeof(int) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "No RO", DataType = typeof(string) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Tanggal Cost Calculation", DataType = typeof(string) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Tanggal Kesiapan Budget\n(Validasi Kadiv Md)", DataType = typeof(string) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Tanggal Shipment", DataType = typeof(string) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "+/-\nSiap - Shipment", DataType = typeof(int) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Lead Time", DataType = typeof(double) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Kode Buyer", DataType = typeof(string) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Nama Buyer", DataType = typeof(string) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Artikel", DataType = typeof(string) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Quantity", DataType = typeof(double) });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Satuan", DataType = typeof(string) });

            List<(string, Enum, Enum)> mergeCells = new List<(string, Enum, Enum)>() { };

            if (data != null && data.Count > 0)
            {
                int i = 0;
                foreach (var d in data)
                {
                    dataTable.Rows.Add(++i, d.RONo, d.CostCalculationDate.ToString("dd MMMM yyyy", new CultureInfo("id-ID")), d.ApprovedKadivMDDate.ToString("dd MMMM yyyy", new CultureInfo("id-ID")), d.DeliveryDate.ToString("dd MMMM yyyy", new CultureInfo("id-ID")), d.DateDiff, d.LeadTime, d.BuyerCode, d.Buyer, d.Article, d.Quantity, d.Uom);
                }
                dataTable.Rows.Add(null, null, null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, null, null, null, null, null, null, null, null, null);

                var Count35 = data.Count(d => d.LeadTime == 35);
                var Count35Ok = data.Count(d => d.DateDiff >= 35 && d.LeadTime == 35);
                var Percent35Ok = ((decimal)Count35Ok / Count35).ToString("P", new CultureInfo("id-ID"));
                var Count35NotOk = data.Count(d => d.DateDiff < 35 && d.LeadTime == 35);
                var Percent35NotOk = ((decimal)Count35NotOk / Count35).ToString("P", new CultureInfo("id-ID"));

                var Count25 = data.Count(d => d.LeadTime == 25);
                var Count25Ok = data.Count(d => d.DateDiff >= 25 && d.LeadTime == 25);
                var Percent25Ok = ((decimal)Count25Ok / Count25).ToString("P", new CultureInfo("id-ID"));
                var Count25NotOk = data.Count(d => d.DateDiff < 25 && d.LeadTime == 25);
                var Percent25NotOk = ((decimal)Count25NotOk / Count25).ToString("P", new CultureInfo("id-ID"));

                var Count = Count25 + Count35;
                var CountOk = Count35Ok + Count25Ok;
                var PercentOk = ((decimal)CountOk / Count).ToString("P", new CultureInfo("id-ID"));
                var CountNotOk = Count35NotOk + Count25NotOk;
                var PercentNotOk = ((decimal)CountNotOk / Count).ToString("P", new CultureInfo("id-ID"));


                dataTable.Rows.Add(null, "KESIAPAN BUDGET DENGAN LEAD TIME 35 HARI", null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Status OK", null, "Selisih Tgl Kesiapan Budget dengan Tgl Shipment >= 35 hari", null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Persentase Status OK", null, $"{Count35Ok}/{Count35} X 100% = {Percent35Ok}", null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Status NOT OK", null, "Selisih Tgl Kesiapan Budget dengan Tgl Shipment < 35 hari", null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Persentase Status NOT OK", null, $"{Count35NotOk}/{Count35} X 100% = {Percent35NotOk}", null, null, null, null, null, null);

                dataTable.Rows.Add(null, null, null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, null, null, null, null, null, null, null, null, null);

                dataTable.Rows.Add(null, "KESIAPAN BUDGET DENGAN LEAD TIME 25 HARI", null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Status OK", null, "Selisih Tgl Kesiapan Budget dengan Tgl Shipment >= 25 hari", null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Persentase Status OK", null, $"{Count25Ok}/{Count25} X 100% = {Percent25Ok}", null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Status NOT OK", null, "Selisih Tgl Kesiapan Budget dengan Tgl Shipment < 25 hari", null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Persentase Status NOT OK", null, $"{Count25NotOk}/{Count25} X 100% = {Percent25NotOk}", null, null, null, null, null, null);

                dataTable.Rows.Add(null, null, null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, null, null, null, null, null, null, null, null, null);

                dataTable.Rows.Add(null, "AKUMULASI KESIAPAN BUDGET", null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Status OK", null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Persentase Status OK", null, $"{CountOk}/{Count} X 100% = {PercentOk}", null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Status NOT OK", null, null, null, null, null, null, null, null);
                dataTable.Rows.Add(null, "Persentase Status NOT OK", null, $"{CountNotOk}/{Count} X 100% = {PercentNotOk}", null, null, null, null, null, null);

                i += 3;
                mergeCells.Add(($"B{++i}:J{i}", ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Bottom));
                foreach (var n in Enumerable.Range(0, 4))
                {
                    mergeCells.Add(($"B{++i}:C{i}", ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Bottom));
                    mergeCells.Add(($"D{i}:J{i}", ExcelHorizontalAlignment.Left, ExcelVerticalAlignment.Bottom));
                }
            }
            else
            {
                dataTable.Rows.Add(null, null, null, null, null, null, null, null, null, null);
            }

            var excel = Excel.CreateExcel(new List<(DataTable, string, List<(string, Enum, Enum)>)>() { (dataTable, "AvailableBudget", mergeCells) }, false);

            return Tuple.Create(excel, string.Concat("Laporan Kesiapan Budget", GetSuffixNameFromFilter(filter)));
        }

        private string GetSuffixNameFromFilter(string filterString)
        {
            Dictionary<string, object> filter = JsonConvert.DeserializeObject<Dictionary<string, object>>(filterString);

            return string.Join(null, filter.Where(w => w.Value != null).Select(s => string.Concat(" - ", s.Value is string ? s.Value : ((DateTime)s.Value).AddHours(identityService.TimezoneOffset).ToString("dd MMMM yyyy") )).ToArray());
        }

        public Tuple<List<AvailableBudgetReportViewModel>, int> Read(int page = 1, int size = 25, string filter = "{}")
        {
            var Query = logic.GetQuery(filter);
            var data = GetData(Query.ToList());

            return Tuple.Create(data, data.Count);
        }

        private List<AvailableBudgetReportViewModel> GetData(IEnumerable<CostCalculationGarment> CostCalculationGarments)
        {
            var data = CostCalculationGarments.Select(cc => new AvailableBudgetReportViewModel
            {
                CostCalculationDate = cc.CreatedUtc.AddHours(identityService.TimezoneOffset).Date,
                ApprovedKadivMDDate = cc.ApprovedKadivMDDate.ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).Date,
                DeliveryDate = cc.DeliveryDate.ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).Date,
                RONo = cc.RO_Number,
                Article = cc.Article,
                DateDiff = (cc.DeliveryDate.ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).Date - cc.ApprovedKadivMDDate.ToOffset(TimeSpan.FromHours(identityService.TimezoneOffset)).Date).Days,
                BuyerCode = cc.BuyerBrandCode,
                Buyer = cc.BuyerBrandName,
                Quantity = cc.Quantity,
                Uom = cc.UOMUnit,
                LeadTime = cc.LeadTime
            }).ToList();

            return data;
        }
    }
}
