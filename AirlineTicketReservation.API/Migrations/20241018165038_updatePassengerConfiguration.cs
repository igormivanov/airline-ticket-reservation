using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketReservation.API.Migrations
{
    /// <inheritdoc />
    public partial class updatePassengerConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyProgram_Passengers_PassengerId",
                table: "LoyaltyProgram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "tb_passengers");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "tb_passengers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityDocument",
                table: "tb_passengers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "tb_passengers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tb_passengers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_passengers",
                table: "tb_passengers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_passengers_Email_IdentityDocument",
                table: "tb_passengers",
                columns: new[] { "Email", "IdentityDocument" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyProgram_tb_passengers_PassengerId",
                table: "LoyaltyProgram",
                column: "PassengerId",
                principalTable: "tb_passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoyaltyProgram_tb_passengers_PassengerId",
                table: "LoyaltyProgram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_passengers",
                table: "tb_passengers");

            migrationBuilder.DropIndex(
                name: "IX_tb_passengers_Email_IdentityDocument",
                table: "tb_passengers");

            migrationBuilder.RenameTable(
                name: "tb_passengers",
                newName: "Passengers");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityDocument",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoyaltyProgram_Passengers_PassengerId",
                table: "LoyaltyProgram",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
