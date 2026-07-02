using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdhiSreeTransportService.Migrations
{
    /// <inheritdoc />
    public partial class Adddriverledgertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "DriverId",
                table: "DieselLogs",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenance_DriverId",
                table: "VehicleMaintenance",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleMaintenance_Driver_DriverId",
                table: "VehicleMaintenance",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleMaintenance_Driver_DriverId",
                table: "VehicleMaintenance");

            migrationBuilder.DropIndex(
                name: "IX_VehicleMaintenance_DriverId",
                table: "VehicleMaintenance");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "DieselLogs");
        }
    }
}
