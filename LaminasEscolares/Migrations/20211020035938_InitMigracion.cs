using Microsoft.EntityFrameworkCore.Migrations;

namespace LaminasEscolares.Migrations
{
    public partial class InitMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "LaminasPosts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "LaminasPosts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
