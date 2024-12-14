using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Providers.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PasswordAndStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password_Value",
                table: "Providers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password_Value",
                table: "Drivers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status_Type",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password_Value",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Password_Value",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Status_Type",
                table: "Drivers");
        }
    }
}
