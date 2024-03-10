using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpTest.Migrations
{
    /// <inheritdoc />
    public partial class jk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirportArrival",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stop = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportArrival", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportDeparture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stop = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportDeparture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    DepartureId = table.Column<int>(type: "int", nullable: false),
                    ArrivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => new { x.DepartureId, x.ArrivalId });
                    table.ForeignKey(
                        name: "FK_Flight_AirportArrival_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "AirportArrival",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_AirportDeparture_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "AirportDeparture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ArrivalId",
                table: "Flight",
                column: "ArrivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "AirportArrival");

            migrationBuilder.DropTable(
                name: "AirportDeparture");
        }
    }
}
