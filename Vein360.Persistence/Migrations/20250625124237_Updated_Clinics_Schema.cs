using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Clinics_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "StreetLine",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "ClinicCode",
                table: "Clinics",
                newName: "AddressLine1");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Clinics",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryContactEmail",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryContactName",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryContactPhone",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddressLine1", "AddressLine2", "PrimaryContactEmail", "PrimaryContactName", "PrimaryContactPhone" },
                values: new object[] { "CLINIC STREET LINE 1", null, null, null, "9876543210" });

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddressLine1", "AddressLine2", "PrimaryContactEmail", "PrimaryContactName", "PrimaryContactPhone" },
                values: new object[] { "CLINIC STREET LINE 1", null, null, null, "9876543210" });

            migrationBuilder.UpdateData(
                table: "Vein360Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAIAAYagAAAAEAws2AnjTEGbr+kBOKLA6qybchEzxQaAyJcdMDkIdeT3lopkhRdv4RYFKiIdaVid3g==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "PrimaryContactEmail",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "PrimaryContactName",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "PrimaryContactPhone",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Clinics",
                newName: "ClinicCode");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Clinics",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Clinics",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clinics",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetLine",
                table: "Clinics",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClinicCode", "Phone", "StreetLine" },
                values: new object[] { "Clinic-0001", "9876543210", "CLINIC STREET LINE 1" });

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClinicCode", "Phone", "StreetLine" },
                values: new object[] { "Clinic-0002", "9876543210", "CLINIC STREET LINE 1" });

            migrationBuilder.UpdateData(
                table: "Vein360Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "chanchal");
        }
    }
}
