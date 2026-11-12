using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNKNOWN_SUN_Api.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteCatalogRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Items_ItemId",
                table: "Rating");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Items_ItemId",
                table: "Rating",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Items_ItemId",
                table: "Rating");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Items_ItemId",
                table: "Rating",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
