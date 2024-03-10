using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpTest.Migrations
{
    /// <inheritdoc />
    public partial class Idddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Flight",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "FlightNumber",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "FlightTime",
                table: "Flight",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "FlightTime",
                table: "Flight");
        }
    }
}
