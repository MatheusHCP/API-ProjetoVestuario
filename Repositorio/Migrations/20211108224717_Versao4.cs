using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class Versao4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "end_numero",
                table: "usuarioEndereco",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Usuarioid",
                table: "produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_produtos_Usuarioid",
                table: "produtos",
                column: "Usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_Usuario_Usuarioid",
                table: "produtos",
                column: "Usuarioid",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produtos_Usuario_Usuarioid",
                table: "produtos");

            migrationBuilder.DropIndex(
                name: "IX_produtos_Usuarioid",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "Usuarioid",
                table: "produtos");

            migrationBuilder.AlterColumn<string>(
                name: "end_numero",
                table: "usuarioEndereco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}
