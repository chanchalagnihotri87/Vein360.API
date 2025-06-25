using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Products_Schema_and_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Vein360ProductId",
                table: "Products",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Vein360ProductId" },
                values: new object[] { "ClosureFast Catheter", "CF7-3-60" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Type", "Vein360ProductId" },
                values: new object[] { "ClosureFast Catheter", 1, "CF7-7-100" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Type", "Vein360ProductId" },
                values: new object[] { "ClosureFast Catheter, 60 cm", 1, "CF7-7-60" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Type", "Vein360ProductId" },
                values: new object[] { "Clinically Soiled Visions PV 018", 2, "86700" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Type", "Vein360ProductId" },
                values: new object[] { "Clinically Soiled Visions PV 035", 2, "88901" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Type", "Vein360ProductId" },
                values: new object[] { "Clinically Soiled Refinity IVUS Catheter", 2, "89900" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Image", "IsDeleted", "Name", "Price", "Type", "UpdatedDate", "Vein360ProductId" },
                values: new object[,]
                {
                    { 7, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Clinically Soiled Visions PV014P RX", 1500m, 2, null, "014R" },
                    { 8, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Clinicially Soiled Eagle Eye Platinum", 1500m, 2, null, "85900P" },
                    { 9, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Clinically Soiled Eagle Eye Platinum ST", 1500m, 2, null, "85900PST" },
                    { 10, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Clinically Soiled Visions 014 Platinum", 1500m, 2, null, "85910P" },
                    { 11, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, " Ambu® aScope™ 4 Cysto, Reverse Deflection", 1500m, 3, null, "600001000" },
                    { 12, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, " Ambu® aScope™ 4 Cysto, Standard Deflection", 1500m, 3, null, "601001000" },
                    { 13, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "aScope 5 Cysto HD – Reverse Deflection", 1500m, 3, null, "602001000" },
                    { 14, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "aScope 5 Cysto HD – Standard Deflection", 1500m, 3, null, "603001000" },
                    { 15, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Dornier Axis II Model E Reverse Deflection", 1500m, 3, null, "AX20408" },
                    { 16, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Dornier Axis II Model E Standard Deflection", 1500m, 3, null, "AX20409" },
                    { 17, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Dornier Axis II Cystoscope", 1500m, 3, null, "AX20411" },
                    { 18, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Dornier Axis II Model D Reverse Deflection", 1500m, 3, null, "AX20413" },
                    { 19, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Dornier Axis II Model D Standard Deflection", 1500m, 3, null, "AX20414" },
                    { 20, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "Dornier Axis Ureteroscope", 1500m, 3, null, "AX93US31B" },
                    { 21, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "LithoVue Standard Deflection", 1500m, 3, null, "M0067913500" },
                    { 22, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "LithoVue Reverse Deflection", 1500m, 3, null, "M0067913600" },
                    { 23, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "LithoVue Empower", 1500m, 3, null, "M0067919900" },
                    { 24, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "LithoVue™ Elite Standard Deflection w/ pressure monitoring", 1500m, 3, null, "M0067940000" },
                    { 25, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "LithoVue™ Elite Reverse Deflection w/ pressure monitoring", 1500m, 3, null, "M0067940500" },
                    { 26, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "LithoVue™ Elite Standard Deflection w/o pressure monitoring", 1500m, 3, null, "M0067941000" },
                    { 27, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "ven-7-100b.jpg", false, "LithoVue™ Elite Reverse Deflection w/o pressure monitoring", 1500m, 3, null, "M0067941500" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Vein360ProductId",
                table: "Products",
                column: "Vein360ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Vein360ProductId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DropColumn(
                name: "Vein360ProductId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description1", "Vein360 Reprocessed ClosureFast Catheter (VEN-7-60B)" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Description2", "Vein360 Complete Procedure Pack - 7F x 7 cm Introducer Kit", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Description2", "Vein360 7F x 7 cm Introducer Sheath Kit", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Description2", "Vein360 Basic Procedure Pack", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Description2", "Vein360 Reprocessed ClosureFast Catheter (VEN-7-80B)", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Description2", "Vein360 Reprocessed ClosureFast Catheter (VEN-7-100B)", 1 });
        }
    }
}
