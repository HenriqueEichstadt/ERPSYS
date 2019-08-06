using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class CorrigindoFKNasTabelasUsuariosEPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS");

            migrationBuilder.RenameColumn(
                name: "UsuarioInclusaoId",
                table: "USUARIOS",
                newName: "USUARIOINCLUSAO");

            migrationBuilder.RenameColumn(
                name: "UsuarioAlteracaoId",
                table: "USUARIOS",
                newName: "USUARIOALTERACAO");

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOALTERACAO",
                table: "PESSOAS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS",
                column: "USUARIOINCLUSAO",
                unique: true,
                filter: "[USUARIOINCLUSAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS",
                column: "USUARIOALTERACAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS",
                column: "USUARIOINCLUSAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS");

            migrationBuilder.RenameColumn(
                name: "USUARIOINCLUSAO",
                table: "USUARIOS",
                newName: "UsuarioInclusaoId");

            migrationBuilder.RenameColumn(
                name: "USUARIOALTERACAO",
                table: "USUARIOS",
                newName: "UsuarioAlteracaoId");

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOALTERACAO",
                table: "PESSOAS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS",
                column: "USUARIOALTERACAO",
                unique: true);

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
    }
}
