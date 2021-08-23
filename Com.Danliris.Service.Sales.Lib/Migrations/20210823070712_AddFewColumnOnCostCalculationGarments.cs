using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Danliris.Service.Sales.Lib.Migrations
{
    public partial class AddFewColumnOnCostCalculationGarments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CollectionCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CollectionName",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CounterCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CounterId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CounterName",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialCompositionCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialCompositionId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaterialCompositionName",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeasonCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SeasonName",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCounterCode",
                table: "CostCalculationGarments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCounterId",
                table: "CostCalculationGarments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubCounterName",
                table: "CostCalculationGarments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CollectionCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CollectionName",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CounterCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CounterId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "CounterName",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "MaterialCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "MaterialCompositionCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "MaterialCompositionId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "MaterialCompositionName",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "ProcessCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "SeasonCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "SeasonName",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "SubCounterCode",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "SubCounterId",
                table: "CostCalculationGarments");

            migrationBuilder.DropColumn(
                name: "SubCounterName",
                table: "CostCalculationGarments");
        }
    }
}
