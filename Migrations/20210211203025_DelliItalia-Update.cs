using Microsoft.EntityFrameworkCore.Migrations;

namespace DelliItalia_Razor.Migrations
{
    public partial class DelliItaliaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoNamn",
                table: "ProductModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoNamn",
                table: "ProductModel");
        }
    }
}
