using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class KategorieKostenstelleRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Kategorien_KategorieId",
                table: "Buchungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Buchungen_Kostenstellen_KostenstelleId",
                table: "Buchungen");

            migrationBuilder.DropIndex(
                name: "IX_Buchungen_KategorieId",
                table: "Buchungen");

            migrationBuilder.DropIndex(
                name: "IX_Buchungen_KostenstelleId",
                table: "Buchungen");

            migrationBuilder.DropColumn(
                name: "KategorieId",
                table: "Buchungen");

            migrationBuilder.DropColumn(
                name: "KostenstelleId",
                table: "Buchungen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorieId",
                table: "Buchungen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KostenstelleId",
                table: "Buchungen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_KategorieId",
                table: "Buchungen",
                column: "KategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_KostenstelleId",
                table: "Buchungen",
                column: "KostenstelleId");

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
        }
    }
}
