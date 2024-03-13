using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpTest.Migrations
{
    /// <inheritdoc />
    public partial class Idd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_AirportDeparture_DepartureId",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureId",
                table: "Flight",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DepartureId1",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "DepartureId");

            migrationBuilder.CreateTable(
                name: "Quantities",
                columns: table => new
                {
                    QuantityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantities", x => x.QuantityID);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    SourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.SourceID);
                });

            migrationBuilder.CreateTable(
                name: "DataLog2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: true),
                    SourceID = table.Column<int>(type: "int", nullable: false),
                    QuantityID = table.Column<int>(type: "int", nullable: false),
                    QuantityID1 = table.Column<int>(type: "int", nullable: true),
                    SourceID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLog2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataLog2_Quantities_QuantityID",
                        column: x => x.QuantityID,
                        principalTable: "Quantities",
                        principalColumn: "QuantityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataLog2_Quantities_QuantityID1",
                        column: x => x.QuantityID1,
                        principalTable: "Quantities",
                        principalColumn: "QuantityID");
                    table.ForeignKey(
                        name: "FK_DataLog2_Sources_SourceID",
                        column: x => x.SourceID,
                        principalTable: "Sources",
                        principalColumn: "SourceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataLog2_Sources_SourceID1",
                        column: x => x.SourceID1,
                        principalTable: "Sources",
                        principalColumn: "SourceID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureId1",
                table: "Flight",
                column: "DepartureId1");

            migrationBuilder.CreateIndex(
                name: "IX_DataLog2_QuantityID",
                table: "DataLog2",
                column: "QuantityID");

            migrationBuilder.CreateIndex(
                name: "IX_DataLog2_QuantityID1",
                table: "DataLog2",
                column: "QuantityID1");

            migrationBuilder.CreateIndex(
                name: "IX_DataLog2_SourceID",
                table: "DataLog2",
                column: "SourceID");

            migrationBuilder.CreateIndex(
                name: "IX_DataLog2_SourceID1",
                table: "DataLog2",
                column: "SourceID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_AirportDeparture_DepartureId1",
                table: "Flight",
                column: "DepartureId1",
                principalTable: "AirportDeparture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_AirportDeparture_DepartureId1",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "DataLog2");

            migrationBuilder.DropTable(
                name: "Quantities");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DepartureId1",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DepartureId1",
                table: "Flight");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureId",
                table: "Flight",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                columns: new[] { "DepartureId", "ArrivalId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_AirportDeparture_DepartureId",
                table: "Flight",
                column: "DepartureId",
                principalTable: "AirportDeparture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
