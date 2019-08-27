using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class AdicionandoColunaEnderecoTabelaPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ENDERECO",
                table: "PESSOAS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_ENDERECO",
                table: "PESSOAS",
                column: "ENDERECO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PESSOAS_ENDERECOS_ENDERECO",
                table: "PESSOAS",
                column: "ENDERECO",
                principalTable: "ENDERECOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PESSOAS_ENDERECOS_ENDERECO",
                table: "PESSOAS");

            migrationBuilder.DropIndex(
                name: "IX_PESSOAS_ENDERECO",
                table: "PESSOAS");

            migrationBuilder.DropColumn(
                name: "ENDERECO",
                table: "PESSOAS");
        }
    }
}
