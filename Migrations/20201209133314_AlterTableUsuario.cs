using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPix4Fun.Migrations
{
    public partial class AlterTableUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "usuario");
        }
    }
}
