using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPackageType_Detail_From_Donation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Vein360ContainerTypes_ContainerTypeId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_ContainerTypeId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ContainerTypeId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "FedexPackagingTypeId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "Donations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContainerTypeId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FedexPackagingTypeId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageType",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContainerTypeId", "FedexPackagingTypeId", "PackageType" },
                values: new object[] { 1, null, 2 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContainerTypeId", "FedexPackagingTypeId", "PackageType" },
                values: new object[] { 2, null, 2 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ContainerTypeId", "FedexPackagingTypeId", "PackageType" },
                values: new object[] { 3, null, 2 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ContainerTypeId", "FedexPackagingTypeId", "PackageType" },
                values: new object[] { 1, null, 2 });

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ContainerTypeId", "FedexPackagingTypeId", "PackageType" },
                values: new object[] { 2, null, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ContainerTypeId",
                table: "Donations",
                column: "ContainerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Vein360ContainerTypes_ContainerTypeId",
                table: "Donations",
                column: "ContainerTypeId",
                principalTable: "Vein360ContainerTypes",
                principalColumn: "Id");
        }
    }
}
