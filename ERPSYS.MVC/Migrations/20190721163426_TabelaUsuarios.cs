using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class TabelaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DATAINCLUSAO = table.Column<DateTime>(nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(nullable: false),
                    UsuarioInclusaoId = table.Column<int>(nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true),
                    NOME = table.Column<string>(nullable: false),
                    NOMEUSUARIO = table.Column<string>(nullable: false),
                    EMAIL = table.Column<string>(nullable: false),
                    SENHA = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIOS_USUARIOS_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIOS_USUARIOS_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_UsuarioAlteracaoId",
                table: "USUARIOS",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_UsuarioInclusaoId",
                table: "USUARIOS",
                column: "UsuarioInclusaoId",
                unique: true,
                filter: "[UsuarioInclusaoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
