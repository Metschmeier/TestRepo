using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class IdBezeichnung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SteuersatzzeileId",
                table: "Steuersaetze",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PartnerzeileId",
                table: "Partner",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KostenstellezeileId",
                table: "Kostenstellen",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KategoriezeileId",
                table: "Kategorien",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Steuersaetze",
                newName: "SteuersatzzeileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Partner",
                newName: "PartnerzeileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Kostenstellen",
                newName: "KostenstellezeileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Kategorien",
                newName: "KategoriezeileId");
        }
    }
}
