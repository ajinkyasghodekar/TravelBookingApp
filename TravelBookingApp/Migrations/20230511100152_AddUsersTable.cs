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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersTable");
        }
    }
}
