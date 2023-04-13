using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Terminals");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Flights");

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Terminals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
