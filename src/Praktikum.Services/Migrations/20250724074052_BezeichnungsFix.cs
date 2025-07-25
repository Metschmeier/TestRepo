using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class BezeichnungsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartnerTyp",
                table: "Partner",
                newName: "Typ");

            migrationBuilder.RenameColumn(
                name: "PartnerName",
                table: "Partner",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "KostenstelleOrt",
                table: "Kostenstellen",
                newName: "Kostenstelle");

            migrationBuilder.RenameColumn(
                name: "KostenstelleBeschreibung",
                table: "Kostenstellen",
                newName: "Beschreibung");

            migrationBuilder.RenameColumn(
                name: "KategorieName",
                table: "Kategorien",
                newName: "Kategorie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Typ",
                table: "Partner",
                newName: "PartnerTyp");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Partner",
                newName: "PartnerName");

            migrationBuilder.RenameColumn(
                name: "Kostenstelle",
                table: "Kostenstellen",
                newName: "KostenstelleOrt");

            migrationBuilder.RenameColumn(
                name: "Beschreibung",
                table: "Kostenstellen",
                newName: "KostenstelleBeschreibung");

            migrationBuilder.RenameColumn(
                name: "Kategorie",
                table: "Kategorien",
                newName: "KategorieName");
        }
    }
}
