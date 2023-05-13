using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelBookingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlinesTable",
                columns: table => new
                {
                    AirlineCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirlineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlinesTable", x => x.AirlineCode);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightsTable",
                columns: table => new
                {
                    FlightCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirlineCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsTable", x => x.FlightCode);
                    table.ForeignKey(
                        name: "FK_FlightsTable_AirlinesTable_AirlineCode",
                        column: x => x.AirlineCode,
                        principalTable: "AirlinesTable",
                        principalColumn: "AirlineCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UsersTable",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "ajinkya@gmail.com", "Ajinkya", "Ajinkya123", "admin" },
                    { 2, "ajay@gmail.com", "Ajay", "Ajay123", "user" },
                    { 3, "Sam@gmail.com", "Sam", "Sam123", "user" },
                    { 4, "Ram@gmail.com", "Ram", "Ram123", "user" },
                    { 5, "john@gmail.com", "John", "John123", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightsTable_AirlineCode",
                table: "FlightsTable",
                column: "AirlineCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightsTable");

            migrationBuilder.DropTable(
                name: "UsersTable");

            migrationBuilder.DropTable(
                name: "AirlinesTable");
        }
    }
}
