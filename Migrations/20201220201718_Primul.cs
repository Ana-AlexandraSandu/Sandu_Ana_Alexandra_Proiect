using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandu_Ana_Alexandra_Proiect.Migrations
{
    public partial class Primul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacanta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tara = table.Column<string>(nullable: true),
                    Ghid = table.Column<string>(nullable: true),
                    Categorie = table.Column<string>(nullable: true),
                    Pret = table.Column<decimal>(nullable: false),
                    Dataplecare = table.Column<DateTime>(nullable: false),
                    Datasosire = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacanta", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacanta");
        }
    }
}
