using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdhiSreeTransportService.Migrations
{
    /// <inheritdoc />
    public partial class Adddriver2ledgertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverLedgers",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DriverId = table.Column<short>(type: "smallint", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Credit = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Remarks = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLedgers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DriverLedgers_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DriverLedgers_DriverId",
                table: "DriverLedgers",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverLedgers");
        }
    }
}
