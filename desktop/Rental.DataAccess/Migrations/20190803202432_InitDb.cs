using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "r");

            migrationBuilder.CreateTable(
                name: "BoardGames",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 3, 20, 24, 32, 726, DateTimeKind.Utc).AddTicks(3741)),
                    Name = table.Column<string>(nullable: true),
                    PricePerDay = table.Column<float>(nullable: false),
                    SuggestedDeposit = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 3, 20, 24, 32, 728, DateTimeKind.Utc).AddTicks(8211)),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameRentals",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 3, 20, 24, 32, 728, DateTimeKind.Utc).AddTicks(8403)),
                    ClientId = table.Column<int>(nullable: false),
                    BoardGameId = table.Column<int>(nullable: false),
                    ChargedDeposit = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PaidMoney = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRentals_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalSchema: "r",
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRentals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "r",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "FirstName", "LastName" },
                values: new object[] { 1, null, "mat", null });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "FirstName", "LastName" },
                values: new object[] { 2, null, "test2", null });

            migrationBuilder.CreateIndex(
                name: "IX_GameRentals_BoardGameId",
                schema: "r",
                table: "GameRentals",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRentals_ClientId",
                schema: "r",
                table: "GameRentals",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRentals",
                schema: "r");

            migrationBuilder.DropTable(
                name: "BoardGames",
                schema: "r");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "r");
        }
    }
}
