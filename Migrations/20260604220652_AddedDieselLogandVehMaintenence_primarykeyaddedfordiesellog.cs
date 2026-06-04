using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdhiSreeTransportService.Migrations
{
    /// <inheritdoc />
    public partial class AddedDieselLogandVehMaintenence_primarykeyaddedfordiesellog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationGroups_TransportEntry_TransportId",
                table: "DestinationGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportEntry_Vehicle_VehicleId",
                table: "TransportEntry");

            migrationBuilder.CreateTable(
                name: "DieselLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<short>(type: "smallint", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SourceId = table.Column<short>(type: "smallint", nullable: false),
                    OdometerReading = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieselLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DieselLogs_Party_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Party",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DieselLogs_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleAlerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<short>(type: "smallint", nullable: false),
                    Emi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmiDueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EmiDaysLeft = table.Column<short>(type: "smallint", nullable: false),
                    InsuranceExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    InsuranceDaysLeft = table.Column<short>(type: "smallint", nullable: false),
                    InsuranceStatus = table.Column<short>(type: "smallint", nullable: false),
                    PollutionExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    PollutionDaysLeft = table.Column<short>(type: "smallint", nullable: false),
                    PollutionStatus = table.Column<short>(type: "smallint", nullable: false),
                    FuelStationName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleAlerts_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DieselLogs_SourceId",
                table: "DieselLogs",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DieselLogs_VehicleId",
                table: "DieselLogs",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAlerts_VehicleId",
                table: "VehicleAlerts",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationGroups_TransportEntry_TransportId",
                table: "DestinationGroups",
                column: "TransportId",
                principalTable: "TransportEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportEntry_Vehicle_VehicleId",
                table: "TransportEntry",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationGroups_TransportEntry_TransportId",
                table: "DestinationGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportEntry_Vehicle_VehicleId",
                table: "TransportEntry");

            migrationBuilder.DropTable(
                name: "DieselLogs");

            migrationBuilder.DropTable(
                name: "VehicleAlerts");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationGroups_TransportEntry_TransportId",
                table: "DestinationGroups",
                column: "TransportId",
                principalTable: "TransportEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportEntry_Vehicle_VehicleId",
                table: "TransportEntry",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
