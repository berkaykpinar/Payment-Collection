using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyPhone.Migrations
{
    public partial class quantity_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAddedToCart",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsOrdered",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "InCart",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordered",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Items",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InCart",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Ordered",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsAddedToCart",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrdered",
                table: "Items",
                type: "bit",
                nullable: true);
        }
    }
}
