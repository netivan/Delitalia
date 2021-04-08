using Microsoft.EntityFrameworkCore.Migrations;

namespace DelliItalia_Razor.Migrations
{
    public partial class renameorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsBought_Orders2_Order2Id",
                table: "ProductsBought");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders2",
                table: "Orders2");

            migrationBuilder.RenameTable(
                name: "Orders2",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsBought_Orders_Order2Id",
                table: "ProductsBought",
                column: "Order2Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsBought_Orders_Order2Id",
                table: "ProductsBought");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders2",
                table: "Orders2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsBought_Orders2_Order2Id",
                table: "ProductsBought",
                column: "Order2Id",
                principalTable: "Orders2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
