using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AtualizacoesDeTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NOMEUSUARIO",
                table: "USUARIOS");

            migrationBuilder.AlterColumn<string>(
                name: "SENHA",
                table: "USUARIOS",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "USUARIOS",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "USUARIOS",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "APELIDO",
                table: "USUARIOS",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "PESSOAS",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AddColumn<string>(
                name: "INSCRICAOESTADUAL",
                table: "PESSOAS",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NOMEFANTASIA",
                table: "PESSOAS",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NOMERAZAOSOCIAL",
                table: "PESSOAS",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "PESSOAS",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TIPOPESSOA",
                table: "PESSOAS",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "APELIDO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "INSCRICAOESTADUAL",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "NOMEFANTASIA",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "NOMERAZAOSOCIAL",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "TIPOPESSOA",
                table: "PESSOAS");

            migrationBuilder.AlterColumn<string>(
                name: "SENHA",
                table: "USUARIOS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "USUARIOS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "USUARIOS",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "NOMEUSUARIO",
                table: "USUARIOS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "PESSOAS",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18);
        }
    }
}
