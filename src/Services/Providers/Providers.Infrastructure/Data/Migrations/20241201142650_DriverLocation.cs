using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Providers.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DriverLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location_AddressLine1",
                table: "Drivers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_AddressLine2",
                table: "Drivers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_City",
                table: "Drivers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_Coordinates_Latitude",
                table: "Drivers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_Coordinates_Longitude",
                table: "Drivers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_State",
                table: "Drivers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_Zip",
                table: "Drivers",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_AddressLine1",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Location_AddressLine2",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Location_City",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Location_Coordinates_Latitude",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Location_Coordinates_Longitude",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Location_State",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Location_Zip",
                table: "Drivers");
        }
    }
}
