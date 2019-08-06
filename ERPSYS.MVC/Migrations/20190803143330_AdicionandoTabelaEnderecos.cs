using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AdicionandoTabelaEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATAINCLUSAO = table.Column<DateTime>(nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(nullable: false),
                    USUARIOINCLUSAO = table.Column<int>(nullable: false),
                    USUARIOALTERACAO = table.Column<int>(nullable: true),
                    PESSOA = table.Column<int>(nullable: false),
                    CEP = table.Column<string>(maxLength: 9, nullable: false),
                    ESTADO = table.Column<string>(maxLength: 50, nullable: false),
                    CIDADE = table.Column<string>(maxLength: 50, nullable: false),
                    BAIRRO = table.Column<string>(maxLength: 50, nullable: false),
                    RUA = table.Column<string>(maxLength: 100, nullable: false),
                    NUMERO = table.Column<string>(maxLength: 7, nullable: false),
                    COMPLEMENTO = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ENDERECOS_PESSOAS_PESSOA",
                        column: x => x.PESSOA,
                        principalTable: "PESSOAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ENDERECOS_USUARIOS_USUARIOALTERACAO",
                        column: x => x.USUARIOALTERACAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ENDERECOS_USUARIOS_USUARIOINCLUSAO",
                        column: x => x.USUARIOINCLUSAO,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_PESSOA",
                table: "ENDERECOS",
                column: "PESSOA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_USUARIOALTERACAO",
                table: "ENDERECOS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_USUARIOINCLUSAO",
                table: "ENDERECOS",
                column: "USUARIOINCLUSAO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECOS");
        }
    }
}
