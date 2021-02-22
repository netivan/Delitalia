using Microsoft.EntityFrameworkCore.Migrations;

namespace DelliItalia_Razor.Migrations.CartPage
{
    public partial class CartModelStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PhotoNamn = table.Column<string>(nullable: true),
                    PhotoAdress = table.Column<string>(nullable: true),
                    Sale = table.Column<decimal>(nullable: false),
                    Sale_Percent = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartModel");
        }
    }
}
