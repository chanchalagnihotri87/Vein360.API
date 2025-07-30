using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Product_Relationship_To_UserProductRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserProductRates_ProductId",
                table: "UserProductRates",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProductRates_Products_ProductId",
                table: "UserProductRates",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProductRates_Products_ProductId",
                table: "UserProductRates");

            migrationBuilder.DropIndex(
                name: "IX_UserProductRates_ProductId",
                table: "UserProductRates");
        }
    }
}
