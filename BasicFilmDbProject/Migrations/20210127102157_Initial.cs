using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicFilmDbProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmCertificate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
