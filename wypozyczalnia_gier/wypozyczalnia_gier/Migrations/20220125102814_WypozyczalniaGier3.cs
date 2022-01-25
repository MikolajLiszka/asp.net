using Microsoft.EntityFrameworkCore.Migrations;

namespace wypozyczalnia_gier.Migrations
{
    public partial class WypozyczalniaGier3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeweloperGry",
                table: "Gry");

            migrationBuilder.AddColumn<int>(
                name: "DeweloperGryID",
                table: "Gry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Deweloperzy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deweloperzy", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gry_DeweloperGryID",
                table: "Gry",
                column: "DeweloperGryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Gry_Deweloperzy_DeweloperGryID",
                table: "Gry",
                column: "DeweloperGryID",
                principalTable: "Deweloperzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gry_Deweloperzy_DeweloperGryID",
                table: "Gry");

            migrationBuilder.DropTable(
                name: "Deweloperzy");

            migrationBuilder.DropIndex(
                name: "IX_Gry_DeweloperGryID",
                table: "Gry");

            migrationBuilder.DropColumn(
                name: "DeweloperGryID",
                table: "Gry");

            migrationBuilder.AddColumn<string>(
                name: "DeweloperGry",
                table: "Gry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
