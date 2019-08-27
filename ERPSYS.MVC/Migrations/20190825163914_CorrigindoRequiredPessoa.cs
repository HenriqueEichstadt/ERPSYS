using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class CorrigindoRequiredPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "PESSOAS",
                newName: "OBSERVACOES");

            migrationBuilder.AlterColumn<string>(
                name: "NOMERAZAOSOCIAL",
                table: "PESSOAS",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NOMEFANTASIA",
                table: "PESSOAS",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "INSCRICAOESTADUAL",
                table: "PESSOAS",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OBSERVACOES",
                table: "PESSOAS",
                newName: "Observacoes");

            migrationBuilder.AlterColumn<string>(
                name: "NOMERAZAOSOCIAL",
                table: "PESSOAS",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOMEFANTASIA",
                table: "PESSOAS",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "INSCRICAOESTADUAL",
                table: "PESSOAS",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
