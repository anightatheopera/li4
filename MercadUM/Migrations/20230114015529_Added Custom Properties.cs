using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercadUM.Migrations
{
    public partial class AddedCustomProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataNascimento",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Morada",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pagamento",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDeConta",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Morada",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Pagamento",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TipoDeConta",
                schema: "Identity",
                table: "User");
        }
    }
}
