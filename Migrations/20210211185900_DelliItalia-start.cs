using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DelliItalia_Razor.Migrations
{
    public partial class DelliItaliastart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PhotoAdress = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Sale = table.Column<decimal>(nullable: false),
                    Sale_Percent = table.Column<decimal>(nullable: false),
                    DateIn = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Chosen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductModel");
        }
    }
}
