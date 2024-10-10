using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketReservation.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToPassenger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Passengers");
        }
    }
}
