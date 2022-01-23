using Microsoft.EntityFrameworkCore.Migrations;

namespace wypozyczalnia_gier.Migrations
{
    public partial class WypozyczalniaGier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TytulGry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriaGry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeweloperGry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PEGI = table.Column<int>(type: "int", nullable: false),
                    CenaWypozyczeniaGry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gry", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gry");
        }
    }
}
