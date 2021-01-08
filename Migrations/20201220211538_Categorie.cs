using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandu_Ana_Alexandra_Proiect.Migrations
{
    public partial class Categorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieVacanta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacantaID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieVacanta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieVacanta_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieVacanta_Vacanta_VacantaID",
                        column: x => x.VacantaID,
                        principalTable: "Vacanta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieVacanta_CategorieID",
                table: "CategorieVacanta",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieVacanta_VacantaID",
                table: "CategorieVacanta",
                column: "VacantaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieVacanta");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
