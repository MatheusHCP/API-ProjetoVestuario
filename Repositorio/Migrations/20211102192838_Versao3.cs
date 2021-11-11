using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class Versao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produtos_generos_produtoGeneroid",
                table: "produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_marcas_produtoMarcaid",
                table: "produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_tamanhos_produtoTamanhoid",
                table: "produtos");

            migrationBuilder.AddColumn<string>(
                name: "end_complemento",
                table: "usuarioEndereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "end_numero",
                table: "usuarioEndereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "produtoTamanhoid",
                table: "produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "produtoMarcaid",
                table: "produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "produtoGeneroid",
                table: "produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_generos_produtoGeneroid",
                table: "produtos",
                column: "produtoGeneroid",
                principalTable: "generos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_marcas_produtoMarcaid",
                table: "produtos",
                column: "produtoMarcaid",
                principalTable: "marcas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_tamanhos_produtoTamanhoid",
                table: "produtos",
                column: "produtoTamanhoid",
                principalTable: "tamanhos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produtos_generos_produtoGeneroid",
                table: "produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_marcas_produtoMarcaid",
                table: "produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_produtos_tamanhos_produtoTamanhoid",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "end_complemento",
                table: "usuarioEndereco");

            migrationBuilder.DropColumn(
                name: "end_numero",
                table: "usuarioEndereco");

            migrationBuilder.AlterColumn<int>(
                name: "produtoTamanhoid",
                table: "produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "produtoMarcaid",
                table: "produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "produtoGeneroid",
                table: "produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_generos_produtoGeneroid",
                table: "produtos",
                column: "produtoGeneroid",
                principalTable: "generos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_marcas_produtoMarcaid",
                table: "produtos",
                column: "produtoMarcaid",
                principalTable: "marcas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_tamanhos_produtoTamanhoid",
                table: "produtos",
                column: "produtoTamanhoid",
                principalTable: "tamanhos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
