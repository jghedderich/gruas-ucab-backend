using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Providers.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company_Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company_Rif = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Company_State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dni_Number = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Dni_Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone_Value = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ProviderName_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProviderName_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dni_Number = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Dni_Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DriverName_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DriverName_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone_Value = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand_Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model_Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_ProviderId",
                table: "Drivers",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ProviderId",
                table: "Vehicles",
                column: "ProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
