using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimousineApi.Migrations
{
    public partial class InitialCreate16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarketId",
                table: "Rates",
                newName: "TripId");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Rates");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Rates",
                newName: "MarketId");
        }
    }
}
