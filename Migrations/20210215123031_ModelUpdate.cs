using Microsoft.EntityFrameworkCore.Migrations;

namespace DelliItalia_Razor.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eco",
                table: "ProductModel",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eco",
                table: "ProductModel");
        }
    }
}
