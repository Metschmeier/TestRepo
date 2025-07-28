using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class ColumnsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Kategorien_KategoriezeileId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Kostenstellen_KostenstellezeileId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Partner_PartnerzeileId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Steuersaetze_SteuersatzzeileId",
                table: "Buchungen");

            migrationBuilder.RenameColumn(
                name: "SteuersatzzeileId",
                table: "Buchungen",
                newName: "SteuersatzId");

            migrationBuilder.RenameColumn(
                name: "PartnerzeileId",
                table: "Buchungen",
                newName: "PartnerId");

            migrationBuilder.RenameColumn(
                name: "KostenstellezeileId",
                table: "Buchungen",
                newName: "KostenstelleId");

            migrationBuilder.RenameColumn(
                name: "KategoriezeileId",
                table: "Buchungen",
                newName: "KategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_SteuersatzzeileId",
                table: "Buchungen",
                newName: "IX_Buchungen_SteuersatzId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_PartnerzeileId",
                table: "Buchungen",
                newName: "IX_Buchungen_PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_KostenstellezeileId",
                table: "Buchungen",
                newName: "IX_Buchungen_KostenstelleId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_KategoriezeileId",
                table: "Buchungen",
                newName: "IX_Buchungen_KategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Kategorien_KategorieId",
                table: "Buchungen",
                column: "KategorieId",
                principalTable: "Kategorien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Kostenstellen_KostenstelleId",
                table: "Buchungen",
                column: "KostenstelleId",
                principalTable: "Kostenstellen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Partner_PartnerId",
                table: "Buchungen",
                column: "PartnerId",
                principalTable: "Partner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Steuersaetze_SteuersatzId",
                table: "Buchungen",
                column: "SteuersatzId",
                principalTable: "Steuersaetze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Kategorien_KategorieId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Kostenstellen_KostenstelleId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Partner_PartnerId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Steuersaetze_SteuersatzId",
                table: "Buchungen");

            migrationBuilder.RenameColumn(
                name: "SteuersatzId",
                table: "Buchungen",
                newName: "SteuersatzzeileId");

            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "Buchungen",
                newName: "PartnerzeileId");

            migrationBuilder.RenameColumn(
                name: "KostenstelleId",
                table: "Buchungen",
                newName: "KostenstellezeileId");

            migrationBuilder.RenameColumn(
                name: "KategorieId",
                table: "Buchungen",
                newName: "KategoriezeileId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_SteuersatzId",
                table: "Buchungen",
                newName: "IX_Buchungen_SteuersatzzeileId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_PartnerId",
                table: "Buchungen",
                newName: "IX_Buchungen_PartnerzeileId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_KostenstelleId",
                table: "Buchungen",
                newName: "IX_Buchungen_KostenstellezeileId");

            migrationBuilder.RenameIndex(
                name: "IX_Buchungen_KategorieId",
                table: "Buchungen",
                newName: "IX_Buchungen_KategoriezeileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Kategorien_KategoriezeileId",
                table: "Buchungen",
                column: "KategoriezeileId",
                principalTable: "Kategorien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Kostenstellen_KostenstellezeileId",
                table: "Buchungen",
                column: "KostenstellezeileId",
                principalTable: "Kostenstellen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Partner_PartnerzeileId",
                table: "Buchungen",
                column: "PartnerzeileId",
                principalTable: "Partner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Steuersaetze_SteuersatzzeileId",
                table: "Buchungen",
                column: "SteuersatzzeileId",
                principalTable: "Steuersaetze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
