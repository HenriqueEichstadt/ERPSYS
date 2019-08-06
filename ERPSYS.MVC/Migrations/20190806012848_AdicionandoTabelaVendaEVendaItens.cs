using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AdicionandoTabelaVendaEVendaItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VENDAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATAINCLUSAO = table.Column<DateTime>(nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(nullable: true),
                    USUARIOINCLUSAO = table.Column<int>(nullable: false),
                    USUARIOALTERACAO = table.Column<int>(nullable: true),
                    TOTALUNIDADES = table.Column<double>(nullable: false),
                    DATA = table.Column<DateTime>(nullable: false),
                    PRECOTOTAL = table.Column<double>(nullable: false),
                    CLIENTE = table.Column<int>(nullable: false),
                    FORMAPAGAMENTO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VENDAS_CLIENTES_CLIENTE",
                        column: x => x.CLIENTE,
                        principalTable: "CLIENTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENDAS_USUARIOS_USUARIOALTERACAO",
                        column: x => x.USUARIOALTERACAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDAS_USUARIOS_USUARIOINCLUSAO",
                        column: x => x.USUARIOINCLUSAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VENDAITENS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATAINCLUSAO = table.Column<DateTime>(nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(nullable: true),
                    USUARIOINCLUSAO = table.Column<int>(nullable: false),
                    USUARIOALTERACAO = table.Column<int>(nullable: true),
                    VENDA = table.Column<int>(nullable: false),
                    PRODUTO = table.Column<int>(nullable: false),
                    UNIDADES = table.Column<double>(nullable: false),
                    PRECOTOTALITEM = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAITENS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VENDAITENS_PRODUTOS_PRODUTO",
                        column: x => x.PRODUTO,
                        principalTable: "PRODUTOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENDAITENS_USUARIOS_USUARIOALTERACAO",
                        column: x => x.USUARIOALTERACAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDAITENS_USUARIOS_USUARIOINCLUSAO",
                        column: x => x.USUARIOINCLUSAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDAITENS_VENDAS_VENDA",
                        column: x => x.VENDA,
                        principalTable: "VENDAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VENDAITENS_PRODUTO",
                table: "VENDAITENS",
                column: "PRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAITENS_USUARIOALTERACAO",
                table: "VENDAITENS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAITENS_USUARIOINCLUSAO",
                table: "VENDAITENS",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VENDAITENS_VENDA",
                table: "VENDAITENS",
                column: "VENDA");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_CLIENTE",
                table: "VENDAS",
                column: "CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_USUARIOALTERACAO",
                table: "VENDAS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_USUARIOINCLUSAO",
                table: "VENDAS",
                column: "USUARIOINCLUSAO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VENDAITENS");

            migrationBuilder.DropTable(
                name: "VENDAS");
        }
    }
}
