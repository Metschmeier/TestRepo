using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddTypToBuchhaltung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Typ",
                table: "Buchungen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Typ",
                table: "Buchungen");
        }
    }
}
