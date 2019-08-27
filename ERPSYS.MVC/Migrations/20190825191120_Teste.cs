using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_USUARIOS_USUARIOALTERACAO",
                table: "CLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_USUARIOS_USUARIOINCLUSAO",
                table: "CLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECOS_USUARIOS_USUARIOALTERACAO",
                table: "ENDERECOS");

            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECOS_USUARIOS_USUARIOINCLUSAO",
                table: "ENDERECOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_USUARIOS_USUARIOALTERACAO",
                table: "PESSOAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_USUARIOS_USUARIOINCLUSAO",
                table: "PESSOAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTOS_USUARIOS_USUARIOALTERACAO",
                table: "PRODUTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTOS_USUARIOS_USUARIOINCLUSAO",
                table: "PRODUTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDAITENS_USUARIOS_USUARIOALTERACAO",
                table: "VENDAITENS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDAITENS_USUARIOS_USUARIOINCLUSAO",
                table: "VENDAITENS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_USUARIOS_USUARIOALTERACAO",
                table: "VENDAS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_USUARIOS_USUARIOINCLUSAO",
                table: "VENDAS");

            migrationBuilder.DropIndex(
                name: "IX_VENDAS_USUARIOALTERACAO",
                table: "VENDAS");

            migrationBuilder.DropIndex(
                name: "IX_VENDAS_USUARIOINCLUSAO",
                table: "VENDAS");

            migrationBuilder.DropIndex(
                name: "IX_VENDAITENS_USUARIOALTERACAO",
                table: "VENDAITENS");

            migrationBuilder.DropIndex(
                name: "IX_VENDAITENS_USUARIOINCLUSAO",
                table: "VENDAITENS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_USUARIOALTERACAO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_USUARIOINCLUSAO",
                table: "USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTOS_USUARIOALTERACAO",
                table: "PRODUTOS");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTOS_USUARIOINCLUSAO",
                table: "PRODUTOS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_USUARIOINCLUSAO",
                table: "PESSOAS");

            migrationBuilder.DropIndex(
                name: "IX_ENDERECOS_USUARIOALTERACAO",
                table: "ENDERECOS");

            migrationBuilder.DropIndex(
                name: "IX_ENDERECOS_USUARIOINCLUSAO",
                table: "ENDERECOS");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_USUARIOALTERACAO",
                table: "CLIENTES");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_USUARIOINCLUSAO",
                table: "CLIENTES");

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "VENDAS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "VENDAITENS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "PRODUTOS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "PESSOAS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "ENDERECOS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "CLIENTES",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "VENDAS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "VENDAITENS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "PRODUTOS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "PESSOAS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "ENDERECOS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "USUARIOINCLUSAO",
                table: "CLIENTES",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_USUARIOALTERACAO",
                table: "VENDAS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_USUARIOINCLUSAO",
                table: "VENDAS",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VENDAITENS_USUARIOALTERACAO",
                table: "VENDAITENS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAITENS_USUARIOINCLUSAO",
                table: "VENDAITENS",
                column: "USUARIOINCLUSAO",
                unique: true);

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
                name: "IX_PRODUTOS_USUARIOALTERACAO",
                table: "PRODUTOS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_USUARIOINCLUSAO",
                table: "PRODUTOS",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_USUARIOALTERACAO",
                table: "PESSOAS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_USUARIOINCLUSAO",
                table: "PESSOAS",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_USUARIOALTERACAO",
                table: "ENDERECOS",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_USUARIOINCLUSAO",
                table: "ENDERECOS",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_USUARIOALTERACAO",
                table: "CLIENTES",
                column: "USUARIOALTERACAO",
                unique: true,
                filter: "[USUARIOALTERACAO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_USUARIOINCLUSAO",
                table: "CLIENTES",
                column: "USUARIOINCLUSAO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_USUARIOS_USUARIOALTERACAO",
                table: "CLIENTES",
                column: "USUARIOALTERACAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_USUARIOS_USUARIOINCLUSAO",
                table: "CLIENTES",
                column: "USUARIOINCLUSAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECOS_USUARIOS_USUARIOALTERACAO",
                table: "ENDERECOS",
                column: "USUARIOALTERACAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECOS_USUARIOS_USUARIOINCLUSAO",
                table: "ENDERECOS",
                column: "USUARIOINCLUSAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTOS_USUARIOS_USUARIOALTERACAO",
                table: "PRODUTOS",
                column: "USUARIOALTERACAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTOS_USUARIOS_USUARIOINCLUSAO",
                table: "PRODUTOS",
                column: "USUARIOINCLUSAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAITENS_USUARIOS_USUARIOALTERACAO",
                table: "VENDAITENS",
                column: "USUARIOALTERACAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAITENS_USUARIOS_USUARIOINCLUSAO",
                table: "VENDAITENS",
                column: "USUARIOINCLUSAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_USUARIOS_USUARIOALTERACAO",
                table: "VENDAS",
                column: "USUARIOALTERACAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_USUARIOS_USUARIOINCLUSAO",
                table: "VENDAS",
                column: "USUARIOINCLUSAO",
                principalTable: "USUARIOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
