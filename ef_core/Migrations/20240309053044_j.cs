using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharpTest.Migrations
{
    /// <inheritdoc />
    public partial class j : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Families",
                table: "Families");

            migrationBuilder.RenameTable(
                name: "Families",
                newName: "Family");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Family",
                table: "Family",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Family",
                table: "Family");

            migrationBuilder.RenameTable(
                name: "Family",
                newName: "Families");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Families",
                table: "Families",
                column: "Id");
        }
    }
}
