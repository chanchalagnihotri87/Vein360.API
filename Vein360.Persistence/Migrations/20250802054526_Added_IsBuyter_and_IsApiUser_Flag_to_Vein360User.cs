using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_IsBuyter_and_IsApiUser_Flag_to_Vein360User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApiUser",
                table: "Vein360Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBuyer",
                table: "Vein360Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Vein360Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsApiUser", "IsBuyer" },
                values: new object[] { false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApiUser",
                table: "Vein360Users");

            migrationBuilder.DropColumn(
                name: "IsBuyer",
                table: "Vein360Users");
        }
    }
}
