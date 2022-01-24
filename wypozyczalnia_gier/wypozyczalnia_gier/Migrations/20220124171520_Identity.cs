using Microsoft.EntityFrameworkCore.Migrations;

namespace wypozyczalnia_gier.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gry_Kategorie_KategoriaGryId",
                table: "Gry");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriaGryId",
                table: "Gry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gry_Kategorie_KategoriaGryId",
                table: "Gry",
                column: "KategoriaGryId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gry_Kategorie_KategoriaGryId",
                table: "Gry");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriaGryId",
                table: "Gry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Gry_Kategorie_KategoriaGryId",
                table: "Gry",
                column: "KategoriaGryId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
