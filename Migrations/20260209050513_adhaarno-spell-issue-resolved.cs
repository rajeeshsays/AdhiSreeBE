using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdhiSreeTransportService.Migrations
{
    /// <inheritdoc />
    public partial class adhaarnospellissueresolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdharNo",
                table: "Driver",
                newName: "AdhaarNo");

            migrationBuilder.UpdateData(
                table: "Driver",
                keyColumn: "AddressLine1",
                keyValue: null,
                column: "AddressLine1",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Driver",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdhaarNo",
                table: "Driver",
                newName: "AdharNo");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Driver",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
