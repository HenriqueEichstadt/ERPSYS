using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class TabelaPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PESSOAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATAINCLUSAO = table.Column<DateTime>(nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(nullable: false),
                    UsuarioInclusaoId = table.Column<int>(nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true),
                    NOME = table.Column<string>(nullable: false),
                    DATANASCIMENTO = table.Column<DateTime>(nullable: false),
                    GENERO = table.Column<string>(nullable: true),
                    RG = table.Column<string>(maxLength: 15, nullable: true),
                    CPF = table.Column<string>(maxLength: 18, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 50, nullable: false),
                    TELEFONEUM = table.Column<string>(maxLength: 14, nullable: false),
                    TELEFONEDOIS = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PESSOAS_USUARIOS_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PESSOAS_USUARIOS_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_UsuarioAlteracaoId",
                table: "PESSOAS",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_UsuarioInclusaoId",
                table: "PESSOAS",
                column: "UsuarioInclusaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PESSOAS");
        }
    }
}
