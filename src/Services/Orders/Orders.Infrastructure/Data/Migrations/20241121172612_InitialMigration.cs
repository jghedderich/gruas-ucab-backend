using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dni_Number = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Dni_Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OperatorName_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperatorName_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password_Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone_Value = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    AmountCovered = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Fees_BaseFee = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Fees_PerKm = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Price_AnnualPrice = table.Column<int>(type: "int", maxLength: 5, nullable: true),
                    Price_MonthlyPrice = table.Column<int>(type: "int", maxLength: 5, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Client_Name_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Client_Name_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Client_Dni_Number = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Client_Dni_Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Client_Phone_Value = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Client_Email_Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Client_ClientVehicle_Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Client_ClientVehicle_Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Client_ClientVehicle_Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Client_ClientVehicle_TypeV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAddress_AddressLine1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DestinationAddress_AddressLine2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DestinationAddress_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DestinationAddress_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DestinationAddress_Zip = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    IncidentAddress_AddressLine1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IncidentAddress_AddressLine2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IncidentAddress_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IncidentAddress_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IncidentAddress_Zip = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    OrderStatus_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Amount = table.Column<double>(type: "float", maxLength: 20, nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", maxLength: 5, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostDetails_OrderId",
                table: "CostDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OperatorId",
                table: "Orders",
                column: "OperatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostDetails");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Operators");
        }
    }
}
