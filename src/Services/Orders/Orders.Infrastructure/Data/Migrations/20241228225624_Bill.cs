using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Bill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Bill_BaseFee",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bill_CostPerKm",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bill_Coverage",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bill_Subtotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bill_Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "CostDetails",
                type: "decimal(18,2)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Operators_OperatorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OperatorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Bill_BaseFee",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Bill_CostPerKm",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Bill_Coverage",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Bill_Subtotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Bill_Total",
                table: "Orders");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "CostDetails",
                type: "float",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 20);
        }
    }
}
