using Microsoft.EntityFrameworkCore.Migrations;

namespace LaminasEscolares.Migrations
{
    public partial class AdicionCantidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "LaminasPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "LaminasPosts");
        }
    }
}
