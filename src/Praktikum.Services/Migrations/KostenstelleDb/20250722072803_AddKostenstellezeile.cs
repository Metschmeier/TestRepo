using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations.KostenstelleDb
{
    /// <inheritdoc />
    public partial class AddKostenstellezeile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kostenstelle",
                columns: table => new
                {
                    KostenstellezeileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KostenstelleOrt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KostenstelleBeschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kostenstelle", x => x.KostenstellezeileId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kostenstelle");
        }
    }
}
