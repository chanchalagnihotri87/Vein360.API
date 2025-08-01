using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_UserProductRates_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyingPrice",
                table: "UserProductRates");

            migrationBuilder.DropColumn(
                name: "PayFromSalesCredit",
                table: "UserProductRates");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "UserProductRates",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PayToSalesCredit",
                table: "UserProductRates",
                newName: "UseSalesCredit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UseSalesCredit",
                table: "UserProductRates",
                newName: "PayToSalesCredit");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "UserProductRates",
                newName: "SellingPrice");

            migrationBuilder.AddColumn<double>(
                name: "BuyingPrice",
                table: "UserProductRates",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PayFromSalesCredit",
                table: "UserProductRates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
