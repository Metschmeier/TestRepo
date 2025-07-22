using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktikum.Services.Migrations.SteuersatzDb
{
    /// <inheritdoc />
    public partial class AddSteuersatzzeile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Steuersatz",
                columns: table => new
                {
                    SteuersatzzeileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SteuersatzInProzent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prozentsatz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steuersatz", x => x.SteuersatzzeileId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steuersatz");
        }
    }
}
