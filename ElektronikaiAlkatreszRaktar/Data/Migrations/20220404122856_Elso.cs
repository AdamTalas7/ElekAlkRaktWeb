using Microsoft.EntityFrameworkCore.Migrations;

namespace ElektronikaiAlkatreszRaktar.Data.Migrations
{
    public partial class Elso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alkatresz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gyarto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beszerzes = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alkatresz", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alkatresz");
        }
    }
}
