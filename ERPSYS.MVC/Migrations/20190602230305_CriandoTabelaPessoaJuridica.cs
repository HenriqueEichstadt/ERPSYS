using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class CriandoTabelaPessoaJuridica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOASFISICAS_USUARIOS_UsuarioAlteracaoId",
                table: "PESSOASFISICAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOASFISICAS_USUARIOS_UsuarioInclusaoId",
                table: "PESSOASFISICAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PESSOASFISICAS",
                table: "PESSOASFISICAS");

            migrationBuilder.RenameTable(
                name: "PESSOASFISICAS",
                newName: "Pessoa");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOASFISICAS_UsuarioInclusaoId",
                table: "Pessoa",
                newName: "IX_Pessoa_UsuarioInclusaoId");

            migrationBuilder.RenameIndex(
                name: "IX_PESSOASFISICAS_UsuarioAlteracaoId",
                table: "Pessoa",
                newName: "IX_Pessoa_UsuarioAlteracaoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "PessoaFisica",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 6, 2, 19, 56, 9, 611, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeFantasia = table.Column<string>(maxLength: 50, nullable: false),
                    NomeRazaoSocial = table.Column<string>(maxLength: 50, nullable: false),
                    InscricaoEstadual = table.Column<string>(maxLength: 50, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 18, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    TelefoneUm = table.Column<string>(maxLength: 14, nullable: false),
                    TelefoneDois = table.Column<string>(maxLength: 14, nullable: true),
                    Observacoes = table.Column<string>(maxLength: 200, nullable: true),
                    DataInclusão = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    UsuarioInclusaoId = table.Column<int>(nullable: true),
                    UsuarioAlteracaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_USUARIOS_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_USUARIOS_UsuarioInclusaoId",
                        column: x => x.UsuarioInclusaoId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_UsuarioAlteracaoId",
                table: "PessoaJuridica",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_UsuarioInclusaoId",
                table: "PessoaJuridica",
                column: "UsuarioInclusaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_USUARIOS_UsuarioAlteracaoId",
                table: "Pessoa",
                column: "UsuarioAlteracaoId",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_USUARIOS_UsuarioInclusaoId",
                table: "Pessoa",
                column: "UsuarioInclusaoId",
                principalTable: "USUARIOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_USUARIOS_UsuarioAlteracaoId",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_USUARIOS_UsuarioInclusaoId",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "PESSOASFISICAS");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_UsuarioInclusaoId",
                table: "PESSOASFISICAS",
                newName: "IX_PESSOASFISICAS_UsuarioInclusaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_UsuarioAlteracaoId",
                table: "PESSOASFISICAS",
                newName: "IX_PESSOASFISICAS_UsuarioAlteracaoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "PessoaFisica",
                nullable: false,
                defaultValue: new DateTime(2019, 6, 2, 19, 56, 9, 611, DateTimeKind.Local).AddTicks(4052),
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PESSOASFISICAS",
                table: "PESSOASFISICAS",
                column: "Id");

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
    }
}
