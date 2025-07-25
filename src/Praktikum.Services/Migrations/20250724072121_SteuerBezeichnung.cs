using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class SteuerBezeichnung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SteuersatzInProzent",
                table: "Steuersaetze",
                newName: "Bezeichnung");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bezeichnung",
                table: "Steuersaetze",
                newName: "SteuersatzInProzent");
        }
    }
}
