using Microsoft.EntityFrameworkCore.Migrations;

namespace wypozyczalnia_gier.Migrations
{
    public partial class WypozyczalniaGier4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gry_Deweloperzy_DeweloperGryID",
                table: "Gry");

            migrationBuilder.RenameColumn(
                name: "DeweloperGryID",
                table: "Gry",
                newName: "DeweloperGryId");

            migrationBuilder.RenameIndex(
                name: "IX_Gry_DeweloperGryID",
                table: "Gry",
                newName: "IX_Gry_DeweloperGryId");

            migrationBuilder.AlterColumn<int>(
                name: "DeweloperGryId",
                table: "Gry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Deweloperzy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gry_Deweloperzy_DeweloperGryId",
                table: "Gry",
                column: "DeweloperGryId",
                principalTable: "Deweloperzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gry_Deweloperzy_DeweloperGryId",
                table: "Gry");

            migrationBuilder.RenameColumn(
                name: "DeweloperGryId",
                table: "Gry",
                newName: "DeweloperGryID");

            migrationBuilder.RenameIndex(
                name: "IX_Gry_DeweloperGryId",
                table: "Gry",
                newName: "IX_Gry_DeweloperGryID");

            migrationBuilder.AlterColumn<int>(
                name: "DeweloperGryID",
                table: "Gry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Deweloperzy",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gry_Deweloperzy_DeweloperGryID",
                table: "Gry",
                column: "DeweloperGryID",
                principalTable: "Deweloperzy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
