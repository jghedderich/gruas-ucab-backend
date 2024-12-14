using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Providers.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status_Type",
                table: "Drivers",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Drivers",
                newName: "Status_Type");
        }
    }
}
