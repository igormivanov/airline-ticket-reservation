using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineTicketReservation.API.Migrations
{
    /// <inheritdoc />
    public partial class updateLoyaltyProgramConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoyaltyProgram");

            migrationBuilder.CreateTable(
                name: "tb_loyalty_programs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointsBalance = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_loyalty_programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_loyalty_programs_tb_passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "tb_passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_loyalty_programs_PassengerId",
                table: "tb_loyalty_programs",
                column: "PassengerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_loyalty_programs");

            migrationBuilder.CreateTable(
                name: "LoyaltyProgram",
                columns: table => new
                {
                    LoyaltyNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    PointsBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyProgram", x => x.LoyaltyNumber);
                    table.ForeignKey(
                        name: "FK_LoyaltyProgram_tb_passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "tb_passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoyaltyProgram_PassengerId",
                table: "LoyaltyProgram",
                column: "PassengerId",
                unique: true);
        }
    }
}
