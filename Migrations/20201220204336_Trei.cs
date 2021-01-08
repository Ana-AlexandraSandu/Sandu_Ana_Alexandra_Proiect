using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandu_Ana_Alexandra_Proiect.Migrations
{
    public partial class Trei : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ghid",
                table: "Vacanta");

            migrationBuilder.AddColumn<int>(
                name: "GhidID",
                table: "Vacanta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ghid",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeGhid = table.Column<string>(nullable: true),
                    Telefon = table.Column<int>(nullable: false),
                    Dataangajare = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghid", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacanta_GhidID",
                table: "Vacanta",
                column: "GhidID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacanta_Ghid_GhidID",
                table: "Vacanta",
                column: "GhidID",
                principalTable: "Ghid",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacanta_Ghid_GhidID",
                table: "Vacanta");

            migrationBuilder.DropTable(
                name: "Ghid");

            migrationBuilder.DropIndex(
                name: "IX_Vacanta_GhidID",
                table: "Vacanta");

            migrationBuilder.DropColumn(
                name: "GhidID",
                table: "Vacanta");

            migrationBuilder.AddColumn<string>(
                name: "Ghid",
                table: "Vacanta",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
