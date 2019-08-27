using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AlterandoFKTabelaEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECOS_PESSOAS_PESSOA",
                table: "ENDERECOS");

            migrationBuilder.DropIndex(
                name: "IX_ENDERECOS_PESSOA",
                table: "ENDERECOS");

            migrationBuilder.DropColumn(
                name: "PESSOA",
                table: "ENDERECOS");

            migrationBuilder.AddColumn<int>(
                name: "ENDERECO",
                table: "PESSOAS",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ENDERECO",
                table: "PESSOAS");

            migrationBuilder.AddColumn<int>(
                name: "PESSOA",
                table: "ENDERECOS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECOS_PESSOA",
                table: "ENDERECOS",
                column: "PESSOA",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECOS_PESSOAS_PESSOA",
                table: "ENDERECOS",
                column: "PESSOA",
                principalTable: "PESSOAS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
