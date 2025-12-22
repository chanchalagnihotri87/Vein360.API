using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Pickups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PickupId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pickups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    PickupTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pickups_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Donations_PickupId",
                table: "Donations",
                column: "PickupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pickups_ClinicId",
                table: "Pickups",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Pickups_PickupId",
                table: "Donations",
                column: "PickupId",
                principalTable: "Pickups",
                principalColumn: "Id");

            migrationBuilder.Sql(@"INSERT Pickups (ClinicId, PickupTransactionId, PickupConfirmationCode, PickupDateTime, CreatedDate, IsDeleted) 
                                    SELECT MAX(ClinicId) AS ClinicId,MAX(PickupTransactionId) AS PickupTransactionId, 
                                           MAX(PickupConfirmationCode)  AS PickupConfirmationCode, GETDATE() AS PickupDate, 
                                           GETDATE() as CreatedDate, 0 AS Deleted FROM Donations
                                    WHERE PickupTransactionId IS NOT NULL
                                    GROUP BY ClinicId,  PickupTransactionId, PickupConfirmationCode");

            migrationBuilder.Sql(@"UPDATE D SET D.PickupId = P.Id FROM DONATIONS D
                                    INNER JOIN Pickups P ON D.PickupTransactionId = P.PickupTransactionId
                                        AND D.PickupConfirmationCode = P.PickupConfirmationCode AND D.ClinicId = P.ClinicId
                                    WHERE D.PickupTransactionId IS NOT NULL AND D.PickupConfirmationCode IS NOT NULL");

            migrationBuilder.DropColumn(
                name: "PickupConfirmationCode",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "PickupTransactionId",
                table: "Donations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PickupConfirmationCode",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickupTransactionId",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(@"UPDATE D SET D.PickupTransactionId = P.PickupTransactionId, D.PickupConfirmationCode = P.PickupConfirmationCode 
                                    FROM DONATIONS D
                                    INNER JOIN Pickups P ON D.PickupId = P.Id
                                    WHERE D.PickupId IS NOT NULL");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Pickups_PickupId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Pickups");

            migrationBuilder.DropIndex(
                name: "IX_Donations_PickupId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "PickupId",
                table: "Donations");
        }
    }
}
