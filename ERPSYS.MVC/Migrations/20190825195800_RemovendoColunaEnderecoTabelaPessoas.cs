using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPSYS.MVC.Migrations
{
    public partial class RemovendoColunaEnderecoTabelaPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ENDERECO",
                table: "PESSOAS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ENDERECO",
                table: "PESSOAS",
                nullable: false,
                defaultValue: 0);
        }
    }
}
