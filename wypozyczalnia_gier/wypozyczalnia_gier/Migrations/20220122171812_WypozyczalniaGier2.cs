using Microsoft.EntityFrameworkCore.Migrations;

namespace wypozyczalnia_gier.Migrations
{
    public partial class WypozyczalniaGier2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KategoriaGry",
                table: "Gry");

            migrationBuilder.AddColumn<int>(
                name: "KategoriaGryId",
                table: "Gry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gry_KategoriaGryId",
                table: "Gry",
                column: "KategoriaGryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gry_Kategorie_KategoriaGryId",
                table: "Gry",
                column: "KategoriaGryId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gry_Kategorie_KategoriaGryId",
                table: "Gry");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropIndex(
                name: "IX_Gry_KategoriaGryId",
                table: "Gry");

            migrationBuilder.DropColumn(
                name: "KategoriaGryId",
                table: "Gry");

            migrationBuilder.AddColumn<string>(
                name: "KategoriaGry",
                table: "Gry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
