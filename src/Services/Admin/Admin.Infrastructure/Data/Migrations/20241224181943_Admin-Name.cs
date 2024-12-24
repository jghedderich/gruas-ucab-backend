using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdminName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Administrators");

            migrationBuilder.AddColumn<string>(
                name: "Name_FirstName",
                table: "Administrators",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name_LastName",
                table: "Administrators",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name_FirstName",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "Name_LastName",
                table: "Administrators");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Administrators",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
