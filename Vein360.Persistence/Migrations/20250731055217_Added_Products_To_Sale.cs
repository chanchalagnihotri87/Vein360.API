using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Products_To_Sale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Vein360ProductId",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<int>(
                name: "Trade",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter-100B.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "basic-procedure-pack.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-eagle-eye-platinum-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "7F-x-7-cm-Introducer-Sheath-Kit.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter-100B.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "basic-procedure-pack.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-eagle-eye-platinum-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Image", "Name", "Trade" },
                values: new object[] { "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", " Clinically Soiled Ambu® aScope™ 4 Cysto, Reverse Deflection", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Image", "Name", "Trade" },
                values: new object[] { "7F-x-7-cm-Introducer-Sheath-Kit.jpg", " Clinically Soiled Ambu® aScope™ 4 Cysto, Standard Deflection", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Image", "Name", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter.jpg", "Clinically Soiled Ambu aScope 5 Cysto HD – Reverse Deflection", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Image", "Name", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter-100B.jpg", "Clinically Soiled Ambu aScope 5 Cysto HD – Standard Deflection", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "basic-procedure-pack.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-eagle-eye-platinum-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "7F-x-7-cm-Introducer-Sheath-Kit.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-eagle-eye-platinum-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter-100B.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "basic-procedure-pack.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-eagle-eye-platinum-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "7F-x-7-cm-Introducer-Sheath-Kit.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-eagle-eye-platinum-catheter.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "reprocessed-closurefast-catheter-100B.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Image", "Trade" },
                values: new object[] { "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Image", "IsDeleted", "Name", "Price", "Trade", "Type", "UpdatedDate", "Vein360ProductId" },
                values: new object[,]
                {
                    { 28, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "reprocessed-closurefast-catheter.jpg", false, "Visions PV 018 Digital IVUS Catheter (Sterile Single)", 1500m, 2, 2, null, "VEN-PV-018" },
                    { 29, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "basic-procedure-pack.jpg", false, "Visions PV 035 Digital IVUS Catheter (Sterile Single)", 1500m, 2, 2, null, "VEN-PV-035" },
                    { 30, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "reprocessed-eagle-eye-platinum-catheter.jpg", false, "Visions 014 Platinum RX Catheter (Sterile Single)", 1500m, 2, 2, null, "VEN-PV-014R" },
                    { 31, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", false, "Eagle Eye Platinum Catheter (Sterile Single)", 1500m, 2, 2, null, "VEN-PV-EEP" },
                    { 32, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "7F-x-7-cm-Introducer-Sheath-Kit.jpg", false, "Eagle Eye Platinum Short Tip Catheter (Sterile Single)", 1500m, 2, 2, null, "VEN-PV-EEPST" },
                    { 33, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "reprocessed-closurefast-catheter.jpg", false, "Visions 014 Platinum Catheter (Sterile Single)", 1500m, 2, 2, null, "VEN-PV-014P" },
                    { 34, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "basic-procedure-pack.jpg", false, "Sterile case of 10 ClosureFast CF7-7-60 catheters: 7cm heating length x 60cm insertable length", 1500m, 2, 1, null, "VEN-7-60B" },
                    { 35, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "reprocessed-eagle-eye-platinum-catheter.jpg", false, "Sterile case of 10 ClosureFast CF7-7-100 catheters: 7cm heating length x 100cm insertable length", 1500m, 2, 1, null, "VEN-7-100B" },
                    { 36, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", false, "Sterile case of 10 ClosureFast CF7-3-60 catheters: 3cm heating length x 60cm insertable length", 1500m, 2, 1, null, "VEN-3-60B" },
                    { 37, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "7F-x-7-cm-Introducer-Sheath-Kit.jpg", false, "Merit Medical Basic Procedure Pack (single)", 1500m, 2, 5, null, "VEN-10142S" },
                    { 38, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "reprocessed-closurefast-catheter.jpg", false, "Merit Medical Premium Procedure Pack (single)", 1500m, 2, 5, null, "VEN-10144S" },
                    { 39, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "basic-procedure-pack.jpg", false, "Merit Medical Complete Pack (w/ 7/11 introducer sheath) (single)", 1500m, 2, 5, null, "VEN-10152S" },
                    { 40, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "reprocessed-eagle-eye-platinum-catheter.jpg", false, "Merit Procedure Pack Complete with Introducer Sheath 7Fx7cm w (single)", 1500m, 2, 5, null, "VEN-10165S" },
                    { 41, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", false, "Introducer Sheath K15-00201 (single)", 1500m, 2, 4, null, "VEN-10130S" },
                    { 42, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "7F-x-7-cm-Introducer-Sheath-Kit.jpg", false, "Introducer Sheath 7Fx11cm with Stainless (single)", 1500m, 2, 4, null, "VEN-10147S" },
                    { 43, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "reprocessed-closurefast-catheter.jpg", false, "7Fx7 Introducer Sheath 0.018 SS with Echo Needle (single)", 1500m, 2, 4, null, "VEN-10171S" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Trade",
                table: "Products",
                column: "Trade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Trade",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DropColumn(
                name: "Trade",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Vein360ProductId",
                table: "Products",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "ven-7-60b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "introducerkit.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "sheathkit.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "procedurepack.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "ven-7-80b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Image", "Name" },
                values: new object[] { "ven-7-100b.jpg", " Ambu® aScope™ 4 Cysto, Reverse Deflection" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Image", "Name" },
                values: new object[] { "ven-7-100b.jpg", " Ambu® aScope™ 4 Cysto, Standard Deflection" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Image", "Name" },
                values: new object[] { "ven-7-100b.jpg", "aScope 5 Cysto HD – Reverse Deflection" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Image", "Name" },
                values: new object[] { "ven-7-100b.jpg", "aScope 5 Cysto HD – Standard Deflection" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "Image",
                value: "ven-7-100b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Image",
                value: "ven-7-100b.jpg");
        }
    }
}
