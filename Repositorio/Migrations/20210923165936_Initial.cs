using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genero_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtoStatus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtoStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tamanhos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tamanho_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tamanhos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarioEndereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuarioid = table.Column<int>(type: "int", nullable: false),
                    end_descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_referencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioEndereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarioTipo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioTipo_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioTipo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prod_Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    prod_preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    prod_dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prod_statuspublicacao = table.Column<int>(type: "int", nullable: false),
                    prod_usuariocadastro = table.Column<int>(type: "int", nullable: false),
                    produtoCategoriaid = table.Column<int>(type: "int", nullable: false),
                    produtoMarcaid = table.Column<int>(type: "int", nullable: true),
                    produtoGeneroid = table.Column<int>(type: "int", nullable: true),
                    produtoTamanhoid = table.Column<int>(type: "int", nullable: true),
                    produtoStatusid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_produtos_categorias_produtoCategoriaid",
                        column: x => x.produtoCategoriaid,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produtos_generos_produtoGeneroid",
                        column: x => x.produtoGeneroid,
                        principalTable: "generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_produtos_marcas_produtoMarcaid",
                        column: x => x.produtoMarcaid,
                        principalTable: "marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_produtos_produtoStatus_produtoStatusid",
                        column: x => x.produtoStatusid,
                        principalTable: "produtoStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_produtos_tamanhos_produtoTamanhoid",
                        column: x => x.produtoTamanhoid,
                        principalTable: "tamanhos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioTipoid = table.Column<int>(type: "int", nullable: false),
                    usu_nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usu_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usu_senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioEnderecoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuario_usuarioEndereco_usuarioEnderecoid",
                        column: x => x.usuarioEnderecoid,
                        principalTable: "usuarioEndereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_usuarioTipo_UsuarioTipoid",
                        column: x => x.UsuarioTipoid,
                        principalTable: "usuarioTipo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "imagens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produtoid = table.Column<int>(type: "int", nullable: false),
                    img_caminho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_imagens_produtos_Produtoid",
                        column: x => x.Produtoid,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imagens_Produtoid",
                table: "imagens",
                column: "Produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_produtoCategoriaid",
                table: "produtos",
                column: "produtoCategoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_produtoGeneroid",
                table: "produtos",
                column: "produtoGeneroid");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_produtoMarcaid",
                table: "produtos",
                column: "produtoMarcaid");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_produtoStatusid",
                table: "produtos",
                column: "produtoStatusid");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_produtoTamanhoid",
                table: "produtos",
                column: "produtoTamanhoid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_usuarioEnderecoid",
                table: "Usuario",
                column: "usuarioEnderecoid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioTipoid",
                table: "Usuario",
                column: "UsuarioTipoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagens");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "usuarioEndereco");

            migrationBuilder.DropTable(
                name: "usuarioTipo");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "generos");

            migrationBuilder.DropTable(
                name: "marcas");

            migrationBuilder.DropTable(
                name: "produtoStatus");

            migrationBuilder.DropTable(
                name: "tamanhos");
        }
    }
}
