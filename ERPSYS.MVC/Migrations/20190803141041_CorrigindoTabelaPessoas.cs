using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class CorrigindoTabelaPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PESSOAS_USUARIOALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PESSOAS_USUARIOINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "USUARIOINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.AddColumn<int>(
                name: "USUARIOALTERACAO",
                table: "PESSOAS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "PESSOAS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS",
                column: "USUARIOALTERACAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_USUARIOINCLUSAO",
                table: "PESSOAS",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAS_USUARIOS_USUARIOALTERACAO",
                table: "PESSOAS",
                column: "USUARIOALTERACAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAS_USUARIOS_USUARIOINCLUSAO",
                table: "PESSOAS",
                column: "USUARIOINCLUSAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_USUARIOS_USUARIOALTERACAO",
                table: "PESSOAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_USUARIOS_USUARIOINCLUSAO",
                table: "PESSOAS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_USUARIOINCLUSAO",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "USUARIOALTERACAO",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "USUARIOINCLUSAO",
                table: "PESSOAS");

            migrationBuilder.AddColumn<int>(
                name: "USUARIOALTERACAO",
                table: "USUARIOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "USUARIOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS",
                column: "USUARIOALTERACAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PESSOAS_USUARIOALTERACAO",
                table: "USUARIOS",
                column: "USUARIOALTERACAO",
                principalTable: "PESSOAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PESSOAS_USUARIOINCLUSAO",
                table: "USUARIOS",
                column: "USUARIOINCLUSAO",
                principalTable: "PESSOAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
