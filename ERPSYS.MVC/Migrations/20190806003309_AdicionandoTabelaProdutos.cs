using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AdicionandoTabelaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATAINCLUSAO = table.Column<DateTime>(nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(nullable: true),
                    USUARIOINCLUSAO = table.Column<int>(nullable: false),
                    USUARIOALTERACAO = table.Column<int>(nullable: true),
                    NOME = table.Column<string>(maxLength: 30, nullable: false),
                    MARCA = table.Column<string>(maxLength: 30, nullable: false),
                    CATEGORIA = table.Column<string>(maxLength: 30, nullable: false),
                    PRECOVENDA = table.Column<double>(nullable: false),
                    PRECOCUSTO = table.Column<double>(nullable: false),
                    DESCRICAO = table.Column<string>(maxLength: 200, nullable: true),
                    ESTOQUEATUAL = table.Column<double>(nullable: false),
                    LIMITEESTOQUE = table.Column<double>(nullable: true),
                    DATAFABRICACAO = table.Column<DateTime>(nullable: true),
                    VALIDADE = table.Column<DateTime>(nullable: true),
                    QTDPONTOSPROGFIDELIDADE = table.Column<int>(nullable: true),
                    ATIVO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_USUARIOS_USUARIOALTERACAO",
                        column: x => x.USUARIOALTERACAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_USUARIOS_USUARIOINCLUSAO",
                        column: x => x.USUARIOINCLUSAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_USUARIOALTERACAO",
                table: "PRODUTOS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_USUARIOINCLUSAO",
                table: "PRODUTOS",
                column: "USUARIOINCLUSAO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOS");
        }
    }
}
