using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class BuchungFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locked",
                table: "Buchungen");

            migrationBuilder.RenameColumn(
                name: "Betrag",
                table: "Buchungen",
                newName: "BetragNetto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BetragNetto",
                table: "Buchungen",
                newName: "Betrag");

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "Buchungen",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
