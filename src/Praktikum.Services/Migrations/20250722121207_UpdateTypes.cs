using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriezeileId",
                table: "Buchungen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KostenstellezeileId",
                table: "Buchungen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartnerzeileId",
                table: "Buchungen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SteuersatzzeileId",
                table: "Buchungen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategorien",
                columns: table => new
                {
                    KategoriezeileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorieNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorien", x => x.KategoriezeileId);
                });

            migrationBuilder.CreateTable(
                name: "Kostenstellen",
                columns: table => new
                {
                    KostenstellezeileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KostenstelleOrt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KostenstelleBeschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kostenstellen", x => x.KostenstellezeileId);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    PartnerzeileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kontonummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartnerTyp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.PartnerzeileId);
                });

            migrationBuilder.CreateTable(
                name: "Steuersaetze",
                columns: table => new
                {
                    SteuersatzzeileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SteuersatzInProzent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prozentsatz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steuersaetze", x => x.SteuersatzzeileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_KategoriezeileId",
                table: "Buchungen",
                column: "KategoriezeileId");

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_KostenstellezeileId",
                table: "Buchungen",
                column: "KostenstellezeileId");

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_PartnerzeileId",
                table: "Buchungen",
                column: "PartnerzeileId");

            migrationBuilder.CreateIndex(
                name: "IX_Buchungen_SteuersatzzeileId",
                table: "Buchungen",
                column: "SteuersatzzeileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Kategorien_KategoriezeileId",
                table: "Buchungen",
                column: "KategoriezeileId",
                principalTable: "Kategorien",
                principalColumn: "KategoriezeileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Kostenstellen_KostenstellezeileId",
                table: "Buchungen",
                column: "KostenstellezeileId",
                principalTable: "Kostenstellen",
                principalColumn: "KostenstellezeileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Partner_PartnerzeileId",
                table: "Buchungen",
                column: "PartnerzeileId",
                principalTable: "Partner",
                principalColumn: "PartnerzeileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buchungen_Steuersaetze_SteuersatzzeileId",
                table: "Buchungen",
                column: "SteuersatzzeileId",
                principalTable: "Steuersaetze",
                principalColumn: "SteuersatzzeileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Kategorien");

            migrationBuilder.DropTable(
                name: "Kostenstellen");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Steuersaetze");

            migrationBuilder.DropIndex(
                name: "IX_Buchungen_KategoriezeileId",
                table: "Buchungen");

            migrationBuilder.DropIndex(
                name: "IX_Buchungen_KostenstellezeileId",
                table: "Buchungen");

            migrationBuilder.DropIndex(
                name: "IX_Buchungen_PartnerzeileId",
                table: "Buchungen");

            migrationBuilder.DropIndex(
                name: "IX_Buchungen_SteuersatzzeileId",
                table: "Buchungen");

            migrationBuilder.DropColumn(
                name: "KategoriezeileId",
                table: "Buchungen");

            migrationBuilder.DropColumn(
                name: "KostenstellezeileId",
                table: "Buchungen");

            migrationBuilder.DropColumn(
                name: "PartnerzeileId",
                table: "Buchungen");

            migrationBuilder.DropColumn(
                name: "SteuersatzzeileId",
                table: "Buchungen");
        }
    }
}
