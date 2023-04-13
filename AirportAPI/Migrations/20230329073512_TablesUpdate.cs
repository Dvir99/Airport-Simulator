using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportAPI.Migrations
{
    /// <inheritdoc />
    public partial class TablesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terminals_Flights_FlightId",
                table: "Terminals");

            migrationBuilder.DropIndex(
                name: "IX_Terminals_FlightId",
                table: "Terminals");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Terminals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Terminals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Terminals");

            migrationBuilder.AlterColumn<int>(
                name: "FlightId",
                table: "Terminals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_FlightId",
                table: "Terminals",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Terminals_Flights_FlightId",
                table: "Terminals",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");
        }
    }
}
