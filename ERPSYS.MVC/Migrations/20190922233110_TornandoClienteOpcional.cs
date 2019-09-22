using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class TornandoClienteOpcional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_CLIENTES_CLIENTE",
                table: "VENDAS");

            migrationBuilder.AlterColumn<int>(
                name: "CLIENTE",
                table: "VENDAS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_CLIENTES_CLIENTE",
                table: "VENDAS",
                column: "CLIENTE",
                principalTable: "CLIENTES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_CLIENTES_CLIENTE",
                table: "VENDAS");

            migrationBuilder.AlterColumn<int>(
                name: "CLIENTE",
                table: "VENDAS",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_CLIENTES_CLIENTE",
                table: "VENDAS",
                column: "CLIENTE",
                principalTable: "CLIENTES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
