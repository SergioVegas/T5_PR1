using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T5_PR1.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSomePropiertiesFromSimulations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Simulations");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Simulations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                table: "Simulations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Simulations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
