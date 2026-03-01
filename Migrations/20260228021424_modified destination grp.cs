using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdhiSreeTransportService.Migrations
{
    /// <inheritdoc />
    public partial class modifieddestinationgrp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {





            migrationBuilder.CreateIndex(
                name: "IX_DestinationGroups_TransportId",
                table: "DestinationGroups",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationGroups_TransportEntry_TransportId",
                table: "DestinationGroups",
                column: "TransportId",
                principalTable: "TransportEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationGroups_TransportEntry_TransportId",
                table: "DestinationGroups");

            migrationBuilder.DropIndex(
                name: "IX_DestinationGroups_TransportId",
                table: "DestinationGroups");

            migrationBuilder.AddColumn<long>(
                name: "TransportEntryID",
                table: "DestinationGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DestinationGroups_TransportEntryID",
                table: "DestinationGroups",
                column: "TransportEntryID");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationGroups_TransportEntry_TransportEntryID",
                table: "DestinationGroups",
                column: "TransportEntryID",
                principalTable: "TransportEntry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
