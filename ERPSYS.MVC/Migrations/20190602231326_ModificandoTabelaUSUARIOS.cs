using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class ModificandoTabelaUSUARIOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeUsuario",
                table: "USUARIOS",
                newName: "NOMEUSUARIO");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "USUARIOS",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "USUARIOS",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "NOMEUSUARIO",
                table: "USUARIOS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "USUARIOS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "USUARIOS",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SENHA",
                table: "USUARIOS",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "SENHA",
                table: "USUARIOS");

            migrationBuilder.RenameColumn(
                name: "NOMEUSUARIO",
                table: "USUARIOS",
                newName: "NomeUsuario");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "USUARIOS",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "USUARIOS",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "NomeUsuario",
                table: "USUARIOS",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "USUARIOS",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
