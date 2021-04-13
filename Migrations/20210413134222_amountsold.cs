using Microsoft.EntityFrameworkCore.Migrations;

namespace DelliItalia_Razor.Migrations
{
    public partial class amountsold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsBought_Orders_Order2Id",
                table: "ProductsBought");

            migrationBuilder.AlterColumn<int>(
                name: "Order2Id",
                table: "ProductsBought",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountSold",
                table: "ProductModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsBought_Orders_Order2Id",
                table: "ProductsBought",
                column: "Order2Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsBought_Orders_Order2Id",
                table: "ProductsBought");

            migrationBuilder.DropColumn(
                name: "AmountSold",
                table: "ProductModel");

            migrationBuilder.AlterColumn<int>(
                name: "Order2Id",
                table: "ProductsBought",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsBought_Orders_Order2Id",
                table: "ProductsBought",
                column: "Order2Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
