using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AlterandoNomeDeTabelasEAdicionandoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefoneUm",
                table: "PessoaJuridica",
                newName: "TELEFONEUM");

            migrationBuilder.RenameColumn(
                name: "TelefoneDois",
                table: "PessoaJuridica",
                newName: "TELEFONEDOIS");

            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "PessoaJuridica",
                newName: "OBSERVACOES");

            migrationBuilder.RenameColumn(
                name: "NomeRazaoSocial",
                table: "PessoaJuridica",
                newName: "NOMERAZAOSOCIAL");

            migrationBuilder.RenameColumn(
                name: "NomeFantasia",
                table: "PessoaJuridica",
                newName: "NOMEFANTASIA");

            migrationBuilder.RenameColumn(
                name: "InscricaoEstadual",
                table: "PessoaJuridica",
                newName: "INSCRICAOESTADUAL");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PessoaJuridica",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "DataAlteracao",
                table: "PessoaJuridica",
                newName: "DATAALTERACAO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PessoaJuridica",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DataInclusão",
                table: "PessoaJuridica",
                newName: "DATAINCLUSAO");

            migrationBuilder.RenameColumn(
                name: "TelefoneUm",
                table: "PessoaFisica",
                newName: "TELEFONEUM");

            migrationBuilder.RenameColumn(
                name: "TelefoneDois",
                table: "PessoaFisica",
                newName: "TELEFONEDOIS");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "PessoaFisica",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "PessoaFisica",
                newName: "GENERO");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PessoaFisica",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "PessoaFisica",
                newName: "DATANASCIMENTO");

            migrationBuilder.RenameColumn(
                name: "DataInclusao",
                table: "PessoaFisica",
                newName: "DATAINCLUSAO");

            migrationBuilder.RenameColumn(
                name: "DataAlteracao",
                table: "PessoaFisica",
                newName: "DATAALTERACAO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PessoaFisica",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAALTERACAO",
                table: "USUARIOS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATAINCLUSAO",
                table: "USUARIOS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioAlteracaoId",
                table: "USUARIOS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioInclusaoId",
                table: "USUARIOS",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_USUARIOS_UsuarioAlteracaoId",
                table: "USUARIOS",
                column: "UsuarioAlteracaoId",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_USUARIOS_UsuarioInclusaoId",
                table: "USUARIOS",
                column: "UsuarioInclusaoId",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_USUARIOS_UsuarioAlteracaoId",
                table: "USUARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_USUARIOS_UsuarioInclusaoId",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_UsuarioAlteracaoId",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_UsuarioInclusaoId",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "DATAALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "DATAINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracaoId",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusaoId",
                table: "USUARIOS");

            migrationBuilder.RenameColumn(
                name: "TELEFONEUM",
                table: "PessoaJuridica",
                newName: "TelefoneUm");

            migrationBuilder.RenameColumn(
                name: "TELEFONEDOIS",
                table: "PessoaJuridica",
                newName: "TelefoneDois");

            migrationBuilder.RenameColumn(
                name: "OBSERVACOES",
                table: "PessoaJuridica",
                newName: "Observacoes");

            migrationBuilder.RenameColumn(
                name: "NOMERAZAOSOCIAL",
                table: "PessoaJuridica",
                newName: "NomeRazaoSocial");

            migrationBuilder.RenameColumn(
                name: "NOMEFANTASIA",
                table: "PessoaJuridica",
                newName: "NomeFantasia");

            migrationBuilder.RenameColumn(
                name: "INSCRICAOESTADUAL",
                table: "PessoaJuridica",
                newName: "InscricaoEstadual");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "PessoaJuridica",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DATAALTERACAO",
                table: "PessoaJuridica",
                newName: "DataAlteracao");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PessoaJuridica",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DATAINCLUSAO",
                table: "PessoaJuridica",
                newName: "DataInclusão");

            migrationBuilder.RenameColumn(
                name: "TELEFONEUM",
                table: "PessoaFisica",
                newName: "TelefoneUm");

            migrationBuilder.RenameColumn(
                name: "TELEFONEDOIS",
                table: "PessoaFisica",
                newName: "TelefoneDois");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "PessoaFisica",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "GENERO",
                table: "PessoaFisica",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "PessoaFisica",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DATANASCIMENTO",
                table: "PessoaFisica",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "DATAINCLUSAO",
                table: "PessoaFisica",
                newName: "DataInclusao");

            migrationBuilder.RenameColumn(
                name: "DATAALTERACAO",
                table: "PessoaFisica",
                newName: "DataAlteracao");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PessoaFisica",
                newName: "Id");
        }
    }
}
