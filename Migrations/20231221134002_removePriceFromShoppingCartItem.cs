using Microsoft.EntityFrameworkCore.Migrations;

namespace ePharma_asp_mvc.Migrations
{
    public partial class removePriceFromShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShoppingCartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ShoppingCartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
