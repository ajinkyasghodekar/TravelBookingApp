using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToJourneysTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirlineCode",
                table: "JourneysTable",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlightCode",
                table: "JourneysTable",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_JourneysTable_AirlineCode",
                table: "JourneysTable",
                column: "AirlineCode");

            migrationBuilder.CreateIndex(
                name: "IX_JourneysTable_FlightCode",
                table: "JourneysTable",
                column: "FlightCode");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneysTable_AirlinesTable_AirlineCode",
                table: "JourneysTable",
                column: "AirlineCode",
                principalTable: "AirlinesTable",
                principalColumn: "AirlineCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JourneysTable_FlightsTable_FlightCode",
                table: "JourneysTable",
                column: "FlightCode",
                principalTable: "FlightsTable",
                principalColumn: "FlightCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneysTable_AirlinesTable_AirlineCode",
                table: "JourneysTable");

            migrationBuilder.DropForeignKey(
                name: "FK_JourneysTable_FlightsTable_FlightCode",
                table: "JourneysTable");

            migrationBuilder.DropIndex(
                name: "IX_JourneysTable_AirlineCode",
                table: "JourneysTable");

            migrationBuilder.DropIndex(
                name: "IX_JourneysTable_FlightCode",
                table: "JourneysTable");

            migrationBuilder.DropColumn(
                name: "AirlineCode",
                table: "JourneysTable");

            migrationBuilder.DropColumn(
                name: "FlightCode",
                table: "JourneysTable");
        }
    }
}
