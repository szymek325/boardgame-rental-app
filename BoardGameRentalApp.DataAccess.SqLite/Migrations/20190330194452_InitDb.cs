﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGameRentalApp.DataAccess.SqLite.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "gr");

            migrationBuilder.CreateTable(
                name: "BoardGames",
                schema: "gr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 3, 30, 19, 44, 52, 84, DateTimeKind.Utc).AddTicks(3336)),
                    Name = table.Column<string>(nullable: true),
                    PricePerDay = table.Column<float>(nullable: false),
                    Bail = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "gr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 3, 30, 19, 44, 52, 87, DateTimeKind.Utc).AddTicks(7597)),
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
                schema: "gr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 3, 30, 19, 44, 52, 87, DateTimeKind.Utc).AddTicks(7776)),
                    ClientId = table.Column<int>(nullable: false),
                    BoardGameId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PaymentAmount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRentals_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalSchema: "gr",
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRentals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "gr",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameRentals_BoardGameId",
                schema: "gr",
                table: "GameRentals",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRentals_ClientId",
                schema: "gr",
                table: "GameRentals",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRentals",
                schema: "gr");

            migrationBuilder.DropTable(
                name: "BoardGames",
                schema: "gr");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "gr");
        }
    }
}
