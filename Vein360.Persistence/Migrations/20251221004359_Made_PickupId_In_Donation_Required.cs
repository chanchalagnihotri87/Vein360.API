using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Made_PickupId_In_Donation_Required : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Pickups_PickupId",
                table: "Donations");

            migrationBuilder.AlterColumn<int>(
                name: "PickupId",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Pickups_PickupId",
                table: "Donations",
                column: "PickupId",
                principalTable: "Pickups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Pickups_PickupId",
                table: "Donations");

            migrationBuilder.AlterColumn<int>(
                name: "PickupId",
                table: "Donations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Pickups_PickupId",
                table: "Donations",
                column: "PickupId",
                principalTable: "Pickups",
                principalColumn: "Id");
        }
    }
}
