using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DelliItalia_Razor.Migrations.Order
{
    public partial class newordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePurchase = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    TotPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "ProductsBought",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    IdProductId = table.Column<int>(nullable: true),
                    Sale = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Sale_procent = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Order2Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsBought", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsBought_ProductModel_IdProductId",
                        column: x => x.IdProductId,
                        principalTable: "ProductModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsBought_Orders_Order2Id",
                        column: x => x.Order2Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsBought_IdProductId",
                table: "ProductsBought",
                column: "IdProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsBought_Order2Id",
                table: "ProductsBought",
                column: "Order2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsBought");


            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
