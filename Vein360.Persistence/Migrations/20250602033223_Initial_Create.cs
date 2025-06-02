using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vein360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vein360ContainerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedWeight = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vein360ContainerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vein360Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsDonor = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vein360Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vein360Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContainerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vein360Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vein360Containers_Vein360ContainerTypes_ContainerTypeId",
                        column: x => x.ContainerTypeId,
                        principalTable: "Vein360ContainerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetLine = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    City = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinics_Vein360Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Vein360Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationContainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerTypeId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    RequestedUnits = table.Column<int>(type: "int", nullable: false),
                    ApprovedUnits = table.Column<int>(type: "int", nullable: true),
                    ReplenishmentOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationContainers_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationContainers_Vein360ContainerTypes_ContainerTypeId",
                        column: x => x.ContainerTypeId,
                        principalTable: "Vein360ContainerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationContainers_Vein360Users_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Vein360Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    PackageType = table.Column<int>(type: "int", nullable: false),
                    ContainerTypeId = table.Column<int>(type: "int", nullable: true),
                    FedexPackagingTypeId = table.Column<int>(type: "int", nullable: true),
                    FedexTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterTrackingNumber = table.Column<long>(type: "bigint", nullable: true),
                    TrackingNumber = table.Column<long>(type: "bigint", nullable: true),
                    UseOldLabel = table.Column<bool>(type: "bit", nullable: false),
                    LabelFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    ContainerId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donations_Vein360ContainerTypes_ContainerTypeId",
                        column: x => x.ContainerTypeId,
                        principalTable: "Vein360ContainerTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Donations_Vein360Users_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Vein360Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingLabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<long>(type: "bigint", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingLabels_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonationProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Accepted = table.Column<int>(type: "int", nullable: false),
                    RejectedClogged = table.Column<int>(type: "int", nullable: false),
                    RejectedDamaged = table.Column<int>(type: "int", nullable: false),
                    RejectedFunction = table.Column<int>(type: "int", nullable: false),
                    RejectedKinked = table.Column<int>(type: "int", nullable: false),
                    RejectedOther = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationProduct_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonationProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Image", "IsDeleted", "Name", "Price", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "Description1", "ven-7-60b.jpg", false, "Vein360 Reprocessed ClosureFast Catheter (VEN-7-60B)", 1000m, 1, null },
                    { 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "Description2", "introducerkit.jpg", false, "Vein360 Complete Procedure Pack - 7F x 7 cm Introducer Kit", 1800m, 2, null },
                    { 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "Description2", "sheathkit.jpg", false, "Vein360 7F x 7 cm Introducer Sheath Kit", 900m, 2, null },
                    { 4, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "Description2", "procedurepack.jpg", false, "Vein360 Basic Procedure Pack", 2000m, 4, null },
                    { 5, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "Description2", "ven-7-80b.jpg", false, "Vein360 Reprocessed ClosureFast Catheter (VEN-7-80B)", 1200m, 1, null },
                    { 6, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "Description2", "ven-7-100b.jpg", false, "Vein360 Reprocessed ClosureFast Catheter (VEN-7-100B)", 1500m, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Vein360ContainerTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "EstimatedWeight", "Height", "Image", "IsDeleted", "Length", "Name", "UpdatedDate", "Width" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, null, 6, 12, null, false, 14, "Vein360 Kit", null, 11 },
                    { 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, null, 10, null, null, false, null, "Customer Shipper", null, null },
                    { 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, null, 20, 8, null, false, 24, "Urology Kit", null, 18 }
                });

            migrationBuilder.InsertData(
                table: "Vein360Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "IsDonor", "Name", "Password", "UpdatedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, "chanchalagnihotri1987@gmail.com", true, false, true, "Chanchal Kumar", "chanchal", null });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "Id", "City", "ClinicCode", "ClinicName", "Country", "CreatedDate", "DeletedDate", "IsDeleted", "Phone", "PostalCode", "State", "StreetLine", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "HARRISON", "Clinic-0001", "ABC Clinic", "US", new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, "9876543210", "72601", "AR", "CLINIC STREET LINE 1", null, 1 },
                    { 2, "HARRISON", "Clinic-0002", "XYZ Clinic", "US", new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, "9876543210", "72601", "AR", "CLINIC STREET LINE 1", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vein360Containers",
                columns: new[] { "Id", "ContainerCode", "ContainerTypeId", "CreatedDate", "DeletedDate", "IsDeleted", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "CNT100001", 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 2, "CNT100002", 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 3, "CNT100003", 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 4, "CNT100004", 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 1, null },
                    { 5, "CNT100005", 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 6, "CNT100006", 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 1, null },
                    { 7, "CNT100007", 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 8, "CNT100008", 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 9, "CNT100009", 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 10, "CNT100010", 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 11, "CNT100011", 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 12, "CNT100012", 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 2, null },
                    { 13, "CNT100013", 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 1, null },
                    { 14, "CNT100014", 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 1, null },
                    { 15, "CNT100015", 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 1, null },
                    { 16, "CNT100016", 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 1, null }
                });

            migrationBuilder.InsertData(
                table: "DonationContainers",
                columns: new[] { "Id", "ApprovedUnits", "ClinicId", "ContainerTypeId", "CreatedDate", "DeletedDate", "DonorId", "IsDeleted", "ReplenishmentOrderId", "RequestedUnits", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, 1, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1001L, 10, 1, null },
                    { 2, 9, 1, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1002L, 9, 2, null },
                    { 3, 8, 1, 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1003L, 8, 2, null },
                    { 4, 7, 1, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1004L, 7, 3, null },
                    { 5, 6, 1, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1005L, 6, 3, null },
                    { 6, 5, 1, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1006L, 5, 3, null },
                    { 7, 4, 2, 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1007L, 4, 3, null },
                    { 8, 3, 2, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1008L, 3, 3, null },
                    { 9, 4, 2, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1009L, 4, 3, null },
                    { 10, 5, 2, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1010L, 5, 2, null },
                    { 11, 6, 2, 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1011L, 6, 2, null },
                    { 12, 7, 2, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, false, 1012L, 7, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "ClinicId", "ContainerId", "ContainerTypeId", "CreatedDate", "DeletedDate", "DonorId", "FedexPackagingTypeId", "FedexTransactionId", "IsDeleted", "LabelFileName", "MasterTrackingNumber", "PackageType", "Status", "TrackingNumber", "UpdatedDate", "UseOldLabel" },
                values: new object[,]
                {
                    { 1, 0.0, 1, null, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, null, null, false, "label.pdf", null, 2, 1, 1234567890L, null, false },
                    { 2, 0.0, 1, null, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, null, null, false, "label.pdf", null, 2, 1, 1234567891L, null, false },
                    { 3, 0.0, 1, null, 3, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, null, null, false, "label.pdf", null, 2, 3, 1234567892L, null, false },
                    { 4, 0.0, 2, null, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, null, null, false, "label.pdf", null, 2, 4, 1234567893L, null, false },
                    { 5, 0.0, 2, null, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, 1, null, null, false, "label.pdf", null, 2, 1, 1234567894L, null, false }
                });

            migrationBuilder.InsertData(
                table: "ShippingLabels",
                columns: new[] { "Id", "ClinicId", "CreatedDate", "DeletedDate", "IsDeleted", "TrackingNumber", "UpdatedDate", "Used" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543211L, null, false },
                    { 2, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543212L, null, false },
                    { 3, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543213L, null, false },
                    { 4, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543214L, null, false },
                    { 5, 1, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543215L, null, false },
                    { 6, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543216L, null, false },
                    { 7, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543217L, null, false },
                    { 8, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543218L, null, false },
                    { 9, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543219L, null, false },
                    { 10, 2, new DateTimeOffset(new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 5, 30, 0, 0)), null, false, 9876543220L, null, false }
                });

            migrationBuilder.InsertData(
                table: "DonationProduct",
                columns: new[] { "Id", "Accepted", "DonationId", "ProductId", "RejectedClogged", "RejectedDamaged", "RejectedFunction", "RejectedKinked", "RejectedOther", "Units" },
                values: new object[,]
                {
                    { 1, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
                    { 2, 0, 1, 2, 0, 0, 0, 0, 0, 1 },
                    { 3, 0, 1, 3, 0, 0, 0, 0, 0, 1 },
                    { 4, 0, 2, 1, 0, 0, 0, 0, 0, 1 },
                    { 5, 0, 2, 3, 0, 0, 0, 0, 0, 1 },
                    { 6, 0, 2, 5, 0, 0, 0, 0, 0, 1 },
                    { 7, 0, 3, 1, 0, 0, 0, 0, 0, 1 },
                    { 8, 0, 3, 4, 0, 0, 0, 0, 0, 1 },
                    { 9, 0, 3, 5, 0, 0, 0, 0, 0, 1 },
                    { 10, 0, 4, 1, 0, 0, 0, 0, 0, 1 },
                    { 11, 0, 4, 5, 0, 0, 0, 0, 0, 1 },
                    { 12, 0, 4, 2, 0, 0, 0, 0, 0, 1 },
                    { 13, 0, 5, 1, 0, 0, 0, 0, 0, 1 },
                    { 14, 0, 5, 2, 0, 0, 0, 0, 0, 1 },
                    { 15, 0, 5, 4, 0, 0, 0, 0, 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_IsDeleted",
                table: "Clinics",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_UserId",
                table: "Clinics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationContainers_ClinicId",
                table: "DonationContainers",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationContainers_ContainerTypeId",
                table: "DonationContainers",
                column: "ContainerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationContainers_DonorId",
                table: "DonationContainers",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationContainers_IsDeleted",
                table: "DonationContainers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DonationProduct_DonationId",
                table: "DonationProduct",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationProduct_ProductId",
                table: "DonationProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ClinicId",
                table: "Donations",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ContainerTypeId",
                table: "Donations",
                column: "ContainerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_IsDeleted",
                table: "Donations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDeleted",
                table: "Products",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingLabels_ClinicId",
                table: "ShippingLabels",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingLabels_IsDeleted",
                table: "ShippingLabels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingLabels_TrackingNumber",
                table: "ShippingLabels",
                column: "TrackingNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vein360Containers_ContainerTypeId",
                table: "Vein360Containers",
                column: "ContainerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vein360Containers_IsDeleted",
                table: "Vein360Containers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Vein360ContainerTypes_IsDeleted",
                table: "Vein360ContainerTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Vein360Users_Email",
                table: "Vein360Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vein360Users_IsDeleted",
                table: "Vein360Users",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationContainers");

            migrationBuilder.DropTable(
                name: "DonationProduct");

            migrationBuilder.DropTable(
                name: "ShippingLabels");

            migrationBuilder.DropTable(
                name: "Vein360Containers");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Vein360ContainerTypes");

            migrationBuilder.DropTable(
                name: "Vein360Users");
        }
    }
}
