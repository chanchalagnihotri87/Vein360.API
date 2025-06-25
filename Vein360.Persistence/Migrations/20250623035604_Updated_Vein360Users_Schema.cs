using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Vein360Users_Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Vein360Users",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_Vein360Users_Email",
                table: "Vein360Users",
                newName: "IX_Vein360Users_Username");

            migrationBuilder.AddColumn<bool>(
                name: "FirstTimeLogin",
                table: "Vein360Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Vein360CustomerId",
                table: "Vein360Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Vein360Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstTimeLogin", "Vein360CustomerId" },
                values: new object[] { true, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTimeLogin",
                table: "Vein360Users");

            migrationBuilder.DropColumn(
                name: "Vein360CustomerId",
                table: "Vein360Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Vein360Users",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Vein360Users_Username",
                table: "Vein360Users",
                newName: "IX_Vein360Users_Email");
        }
    }
}
