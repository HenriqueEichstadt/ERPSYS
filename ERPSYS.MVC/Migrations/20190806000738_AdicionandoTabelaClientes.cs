using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AdicionandoTabelaClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "USUARIOS",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "PESSOAS",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "ENDERECOS",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATAINCLUSAO = table.Column<DateTime>(nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(nullable: true),
                    USUARIOINCLUSAO = table.Column<int>(nullable: false),
                    USUARIOALTERACAO = table.Column<int>(nullable: true),
                    PESSOA = table.Column<int>(nullable: false),
                    PONTOS = table.Column<int>(nullable: true),
                    ATIVO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENTES_PESSOAS_PESSOA",
                        column: x => x.PESSOA,
                        principalTable: "PESSOAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CLIENTES_USUARIOS_USUARIOALTERACAO",
                        column: x => x.USUARIOALTERACAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CLIENTES_USUARIOS_USUARIOINCLUSAO",
                        column: x => x.USUARIOINCLUSAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_PESSOA",
                table: "CLIENTES",
                column: "PESSOA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_USUARIOALTERACAO",
                table: "CLIENTES",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_USUARIOINCLUSAO",
                table: "CLIENTES",
                column: "USUARIOINCLUSAO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "USUARIOS",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "PESSOAS",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "ENDERECOS",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
