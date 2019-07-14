using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class CriandoTabelaPessoaFisica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_USUARIOS_UsuarioAlteracaoId",
                table: "PESSOAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_USUARIOS_UsuarioInclusaoId",
                table: "PESSOAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PESSOAS",
                table: "PESSOAS");

            migrationBuilder.RenameTable(
                name: "PESSOAS",
                newName: "PESSOASFISICAS");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAS_UsuarioInclusaoId",
                table: "PESSOASFISICAS",
                newName: "IX_PESSOASFISICAS_UsuarioInclusaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOAS_UsuarioAlteracaoId",
                table: "PESSOASFISICAS",
                newName: "IX_PESSOASFISICAS_UsuarioAlteracaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PESSOASFISICAS",
                table: "PESSOASFISICAS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(nullable: true),
                    RG = table.Column<string>(maxLength: 15, nullable: true),
                    CPF = table.Column<string>(maxLength: 18, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    TelefoneUm = table.Column<string>(maxLength: 14, nullable: false),
                    TelefoneDois = table.Column<string>(maxLength: 14, nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 2, 19, 56, 9, 611, DateTimeKind.Local).AddTicks(4052)),
                    UsuarioInclusaoId = table.Column<int>(nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_USUARIOS_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_USUARIOS_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_UsuarioAlteracaoId",
                table: "PessoaFisica",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_UsuarioInclusaoId",
                table: "PessoaFisica",
                column: "UsuarioInclusaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOASFISICAS_USUARIOS_UsuarioAlteracaoId",
                table: "PESSOASFISICAS",
                column: "UsuarioAlteracaoId",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOASFISICAS_USUARIOS_UsuarioInclusaoId",
                table: "PESSOASFISICAS",
                column: "UsuarioInclusaoId",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOASFISICAS_USUARIOS_UsuarioAlteracaoId",
                table: "PESSOASFISICAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOASFISICAS_USUARIOS_UsuarioInclusaoId",
                table: "PESSOASFISICAS");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PESSOASFISICAS",
                table: "PESSOASFISICAS");

            migrationBuilder.RenameTable(
                name: "PESSOASFISICAS",
                newName: "PESSOAS");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOASFISICAS_UsuarioInclusaoId",
                table: "PESSOAS",
                newName: "IX_PESSOAS_UsuarioInclusaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOASFISICAS_UsuarioAlteracaoId",
                table: "PESSOAS",
                newName: "IX_PESSOAS_UsuarioAlteracaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PESSOAS",
                table: "PESSOAS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAS_USUARIOS_UsuarioAlteracaoId",
                table: "PESSOAS",
                column: "UsuarioAlteracaoId",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAS_USUARIOS_UsuarioInclusaoId",
                table: "PESSOAS",
                column: "UsuarioInclusaoId",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
