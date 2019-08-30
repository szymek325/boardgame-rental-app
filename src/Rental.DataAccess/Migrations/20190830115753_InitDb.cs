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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 30, 11, 57, 52, 450, DateTimeKind.Utc).AddTicks(3185))
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
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 30, 11, 57, 52, 455, DateTimeKind.Utc).AddTicks(247))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    BoardGameId = table.Column<Guid>(nullable: false),
                    ChargedDeposit = table.Column<decimal>(nullable: false),
                    PaidMoney = table.Column<decimal>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 30, 11, 57, 52, 454, DateTimeKind.Utc).AddTicks(7746)),
                    FinishTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalSchema: "r",
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "r",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f05d8d5f-77aa-45c2-9a12-92e1d87bc436"), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 236m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("74b45786-1bd8-4dc0-b8d0-439f8eb338f2"), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 206m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7607ee88-6318-44d5-a55f-46d7c2fdf78a"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 75m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ed9689ee-2d4c-48ae-bcf3-fd27230e4848"), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 141m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8c706b61-1b30-4b83-bdf1-be14366bb0b2"), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 112m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4c107097-96a1-4063-bab3-a62d927751f8"), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 128m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8acb0734-20e6-4d20-9c63-23c1807891d3"), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 136m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("046dee67-f4cd-499c-ab10-9de094a4af94"), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 203m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("80c89cfb-05b5-4ef7-8c6f-1f16c2aad666"), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 55m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("142d0cc4-3f71-40be-8741-290e12b49b82"), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 110m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7d389881-0d7a-4a12-8e50-3a4c3818e47a"), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 174m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9d89717a-36d3-4dd1-bbe3-a2dce12c5309"), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 184m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6626d11c-988d-4240-b03b-c1fcdb28e60e"), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 114m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1fadde27-0498-4619-8c1d-d4fb737219ce"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 134m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("eda5043e-4996-4211-ba4e-c6180307e114"), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 231m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("56768934-8554-4311-b21a-5089ecaf1e3d"), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 208m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c639f90c-25bf-4ec5-8160-1119853e83c7"), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 248m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2927d65f-c88c-4081-b244-7283b398d73d"), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 144m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("028fe4fc-7a40-42f5-a997-2d9c16a22e53"), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 117m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d9f95282-68d6-471f-ab6e-90f78c2b581d"), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 178m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("219f779c-808c-4064-a582-f3fb11507779"), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 72m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1b20ee23-8186-46cc-bec1-854300b71256"), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 58m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("91ed416a-8d05-4b3f-b4d6-558c1653c87e"), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 58m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("96c56c74-d2a7-4eeb-b32c-28d4bcd78616"), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 97m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5d36cad2-b7fa-4a56-9f96-69e0fb2773b4"), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 91m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9dfb68f7-50e0-43f7-ae95-5f8fda5d65e8"), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 219m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0daa6b2e-90e9-4145-a74d-aaf0809833f2"), new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 78m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3ee971f1-c8f0-4ef3-af73-3040b73e0a53"), new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 74m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("666d83da-be57-478f-87b8-ef347deffdce"), new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 181m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5fb067f4-7e28-4d18-b34c-2a27576d867e"), new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 200m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d28262e0-6f03-4366-86b6-b83f330d8877"), new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 136m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("21a381e6-f91e-4088-96f2-82bafb2fd67f"), new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 61m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6506532a-88bf-4516-8410-54b0f0eb1dec"), new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 240m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("947bb161-43e9-4263-8b63-10e0df24feb1"), new DateTime(2019, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 84m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("741113eb-cffc-4d9f-815f-656ed864f362"), new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 233m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2815d1ce-52bf-4857-9a5a-410225fffe52"), new DateTime(2019, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 63m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("abb751b4-bb43-4c40-a20f-d5cb7f53daa1"), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 98m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7ca7a73e-5a17-4808-88f1-37c7f04d32ac"), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 190m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f3f17ea3-ed64-4358-9b10-f7a01a7cb5ac"), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 180m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("81bd326a-08cb-4dc2-b5e4-cd37f91170e3"), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 228m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9a9621cc-da84-4755-ba5d-a447157e8eac"), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 212m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3bf6e869-e63e-4e2e-971b-8f6120ae149d"), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 205m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5614ce9d-bff1-4028-b2d6-2907bee51233"), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 167m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a206a978-92b9-41b2-aaa6-4a0f2b4b616a"), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 156m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5610c99f-772e-42cb-aa05-ed5738b531eb"), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 218m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("48a618b8-7959-4540-809f-b98bb2d7603c"), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 75m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3f95ce06-d163-44f3-81e1-157aae136117"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 65m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f96c28d2-4f8e-4732-b637-ac58c3b5607a"), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 200m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c6316ce7-727b-4805-b92e-f154a8531924"), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 211m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("379270d0-e1e6-4489-bdcd-c1dc19bd2fbc"), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 51m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0cb45fe3-b58f-4e05-8220-3e24df04b8c0"), new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 68m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a3ad1fde-5dcd-4278-987d-5fd52797c360"), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 170m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("621f5ed5-0bb4-4536-9dc8-83c611b25c06"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 168m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("279e902a-fe55-4d7c-a55f-36a3dcbc0707"), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 156m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("72e76bb5-e46a-492c-8cbd-66559966ed14"), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 113m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9dd0f8a3-f5e4-4a7c-8ab9-8cb0fe2e4582"), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 229m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ea7fc6c1-2d9a-4e91-bcda-aa49f0b64cdc"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 199m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("10f48a4c-15e7-44dd-83d3-a3941703b11f"), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 224m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c94e6f9b-8d74-4140-9c85-54ffe90a07d7"), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 173m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("fc71bb5a-175f-48c5-ba66-762af62148e0"), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 190m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9fbaae26-da7e-4ff8-a173-8eb7ee21eef5"), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 205m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("26bfce91-c7e6-4395-84e8-e46af422943a"), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 186m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e53e33e4-965f-4986-8763-35c2f71fbbb2"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3593268e-3df9-4a15-8369-6b84987e979f"), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 137m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0ecfedc5-6fd8-4cc6-ae4c-616471670289"), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 138m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("26a53e28-9e74-47a2-8ae3-614c106a661f"), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 180m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("cb4fec82-aac5-484c-b54c-d09c6936727f"), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 153m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f374f21d-51cd-4e3b-badd-f8f4ac10fed5"), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 78m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("78ed0f1c-964d-4348-ac9e-3ac1ab117282"), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 232m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b07c96ae-2ee9-4530-aff8-a601a22488a5"), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 126m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6d64bad3-3496-4595-9b61-b0101939635b"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 87m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f6fb928b-711f-42fa-b050-329a5931084e"), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 184m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0455d9fe-9bb1-4dae-bc6f-6d68789ca072"), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 90m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1e451493-4166-48f1-aeb3-5e676dcea681"), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 90m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4edf4312-d08f-482e-93ee-13a89ba0e1f4"), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 89m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a4cec5fc-f37d-4444-9a01-20d0508a7094"), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 209m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b6ca8494-76a8-48fa-8bc9-b91575ff10b3"), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 51m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b9144853-16ee-4054-9c6a-1320bebf88bf"), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 168m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("aac2f630-1087-4c0e-918c-d68de9e11b52"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 82m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("aaccade7-e81f-4acd-b865-052023f28784"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 143m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2e68ad44-4799-498a-9979-5b642012b29d"), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 74m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("72a03a1b-443d-4869-8064-c68519ffdd20"), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 139m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("08e4877e-1f5c-4ced-b2a4-cee9684ab243"), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 199m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f6f62472-ba40-47bd-802c-0e72b011f750"), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 115m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ca3c406a-9791-463a-b96b-4431fd1bd0cd"), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 221m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("063cc9f7-f0e6-4cdc-94a5-f654c0bd5276"), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 243m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("67e2e4f4-c6d3-49f7-a4e3-a82f0f0c1c55"), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 198m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ae0cf641-7cad-4d44-877b-4240c5e2872a"), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 82m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("53d4b458-15ea-4cae-b054-f3f3ecf02a93"), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 65m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("26a7b153-4917-4ccb-884f-1fb084f4b4ae"), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 87m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("43b93c39-7944-4eea-b173-bbdb7d42bb39"), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 128m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1659cfe9-0f6d-4489-a658-4262773f2d6a"), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 88m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("81e72ff1-1446-4ab7-bcd3-5863c12324dc"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 246m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("73c1f583-2de0-4bb7-9dcb-1efc2bc57595"), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 213m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("20fb50b4-9484-4ff2-baa0-28cb6cb9bf07"), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 76m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5829f609-e0a9-45f9-8adc-aba5f5a896aa"), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a5bdc99c-bd72-427a-8f65-7a4c600d79c7"), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 233m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8119cf6e-38a0-4e36-a580-a4a27ca3fc79"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 119m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5fb7d375-4fff-45aa-ba5d-ec163f63bf95"), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 130m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("36b13504-1303-4d8d-a794-44be5ed7152c"), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 188m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cba4e233-6bfd-4b8b-9c27-af52be8c1b78"), "1-330-050-4714 x782", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cristal@mcglynnondricka.biz", "Milton", "Friesen" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4022eaa7-f6d3-4150-ab13-75d93e9bf26c"), "1-225-706-1554", new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeffery.wyman@grimesrippin.uk", "Kiara", "Hoppe" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("95f4db3b-2daf-497d-a88c-c69e489b0f85"), "(138)560-6311 x46152", new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "jessika_anderson@yost.co.uk", "Bernhard", "Gutmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3da6ddbd-2859-4f99-8eb5-82cab4abb509"), "(467)718-0057 x556", new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "shanna@considine.us", "Elmer", "Stanton" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1b88262a-2577-46c4-81d9-b1c315c90e94"), "1-134-325-3135 x30252", new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "camren.friesen@flatley.us", "Willy", "Friesen" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b3b39040-5ffb-49a3-8e35-589ca30e2bb3"), "1-887-287-2088 x72141", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "carmine_kunze@bodebednar.info", "Will", "Eichmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a75ba091-64e0-4f2e-9de9-a0bd1b616854"), "502-523-2357 x0104", new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "elsie@armstrongaltenwerth.co.uk", "Freida", "Grimes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("966753de-2c64-4330-9a63-63158bbd35b7"), "(760)478-0718", new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "merl@kiehnterry.uk", "Godfrey", "Streich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("00e3375f-34f3-4ec8-9e82-93d36f6bfd46"), "326-110-4881 x707", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "zoey.feeney@lueilwitz.us", "Francisco", "Huels" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d02519a4-44df-42f5-b90a-a81a6c13da4a"), "1-037-101-4861", new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "beulah@simonis.ca", "Kris", "Fay" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("19140824-2b56-4074-8758-3b14f66d99f2"), "1-568-505-6578 x1288", new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "thaddeus@collier.uk", "Daron", "Padberg" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d1a7a2d3-84ef-4208-b3f4-2b7bffe95eee"), "(318)300-6713 x05612", new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "amari_stiedemann@schroeder.ca", "Mallie", "Kshlerin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("844051f6-5736-48b2-9c0f-4cc1c235afc7"), "1-802-383-0046", new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "kelly_predovic@cassinbogisich.com", "Brionna", "Hudson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("49383f34-a586-4417-967b-71d0a18f1b2c"), "(510)003-0471 x2863", new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "elta_mitchell@pacocha.com", "Viviane", "Konopelski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6d156bf4-faf1-45bb-adbd-802053130436"), "885.137.5678 x1507", new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "otha.kris@ritchieschowalter.biz", "Rosalia", "Dare" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("62fc7430-fb06-4ba8-8d58-cccb2fd1d598"), "1-486-384-3170", new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "zella@braun.ca", "Kyle", "Dickens" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3cc438c5-5756-4356-897a-dc49dca80487"), "1-185-201-3671", new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "beth@wehner.biz", "Brody", "Feil" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e52316e9-14b8-49f7-bef1-f58e2c90ae31"), "1-166-700-1881", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "quincy_wolf@collier.co.uk", "Alphonso", "Heaney" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9d34cc29-bccc-4808-a3cc-de9b065fc45e"), "436.645.2437 x836", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "forrest@armstrong.name", "Nikki", "Flatley" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("22782edf-b9f9-4332-ad97-5ce75abf801d"), "(823)235-7622 x55812", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "lavada@cristhickle.name", "Dorothy", "Goldner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8ab870d2-0bf3-4737-af96-e6031179f16e"), "265.060.0762 x22564", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "esperanza.runte@lebsackanderson.info", "Annie", "Zboncak" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d25a2a06-6f66-4000-b826-397319a5c3f2"), "854.384.8358 x30722", new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethyl@kuvaliswatsica.co.uk", "Aletha", "Rogahn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b07fa060-cb26-439a-9857-a1522d6af6c2"), "086.654.3004", new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "onie@nitzsche.info", "Lilla", "Altenwerth" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("55d146e7-0fbc-456d-8dc4-17429abe050a"), "107-757-3666", new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "bradford@stanton.com", "Claudie", "Davis" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("878a3066-7dff-4788-b6f3-8f8a621bcf44"), "1-686-571-4615 x077", new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "zion.goldner@doyle.biz", "Rhiannon", "Stoltenberg" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("46038906-2b42-4a47-a3b4-518fce6b019c"), "1-260-732-1618", new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "kenna.hudson@mrazrussel.ca", "Jesse", "Wilkinson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c5b4473a-16fe-4d5a-86c6-1a638f3d9433"), "1-281-755-5646 x107", new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "delphia_stanton@kerlukehand.uk", "Uriel", "Brekke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("26ae61ef-f02e-40bd-901f-d30d92665edc"), "(400)650-6276", new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "chauncey_little@hickle.ca", "Louvenia", "Schuster" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8d880de9-cddd-4a95-bdad-799b2f848cd8"), "1-027-414-0608", new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "eldred_heaney@wyman.info", "Rosie", "Strosin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5b380cdf-2358-489f-a52c-c634824f2f55"), "(230)654-1264 x12278", new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dayne@pfannerstill.ca", "Giovanni", "Bartell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0f6511e9-fc96-4d09-a4d2-e68d97f2db3a"), "(378)113-3851 x750", new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "korey_stoltenberg@sauer.co.uk", "Elian", "Batz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6bee62ab-369b-4a76-a7b7-d164265c23ae"), "685.018.0457 x378", new DateTime(2019, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "tommie@pouros.info", "Maude", "Wilkinson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e618e0df-33cc-4681-9270-67339acf6070"), "230.330.4577 x0237", new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "stanton_hoeger@terry.us", "Harmony", "Emmerich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9c76b54f-cf73-435f-96ef-638b48b2db8e"), "(463)068-2483 x358", new DateTime(2019, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "kadin.hickle@parker.ca", "Nickolas", "Schulist" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b07e1bfd-50ae-4d6a-bfb2-24e463d9475b"), "1-587-837-0721", new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sid_senger@flatley.biz", "Gussie", "O'Conner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("51ab476d-9623-4492-9106-3d565850a984"), "242-853-3234 x2780", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "annette@davis.biz", "Rossie", "Emard" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("728cab47-2396-476e-afb1-bcfa548727a5"), "1-332-354-7353", new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "braxton.waelchi@mcdermottharris.com", "Nestor", "Ernser" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b3d65b69-3b20-4a96-a026-8c073aa8ba11"), "1-212-020-1018 x4621", new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "akeem_durgan@rolfson.name", "Nya", "Gusikowski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("02023505-78a8-47bb-b55f-539efdf71ced"), "1-374-607-1214", new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "josefina@koepp.ca", "Ellie", "Crona" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("85bad92b-b106-4ca6-a0df-2464b6675208"), "(356)877-0788", new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "jodie.abshire@dickinsonblick.ca", "Kasey", "Hettinger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e307fc60-6050-45cf-bc2a-efca15484e1c"), "1-607-175-2604 x3018", new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "julie_bechtelar@danielmosciski.us", "Rogelio", "Kessler" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7964f9cf-1899-40e5-9974-6d81ba2b3409"), "1-825-653-5703 x6674", new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeremy@grimes.name", "Connie", "Jast" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("fc2891ab-032c-468f-b995-0dea7c605dc1"), "(763)807-6530", new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sedrick@stokesjenkins.name", "Dedrick", "Glover" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7165a7e6-aec2-4b25-a6d2-dd106b2bc5e9"), "520-752-4616 x7501", new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "gaylord_mclaughlin@wyman.ca", "Judge", "Bosco" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ef9ec1e9-7444-466a-8ba0-b9ccaa089265"), "(350)186-3144", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "olin@wittingconroy.com", "Dax", "Bayer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3fba9bf6-b929-4c4d-b989-63e9c920fa10"), "242.107.3578 x82577", new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "kiana.hoppe@franecki.info", "Autumn", "Fritsch" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c4ebaa4d-6848-4089-a781-a3e40304dc73"), "(685)856-5638", new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "vanessa_stamm@damorestreich.biz", "Pat", "O'Conner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6cd3ff70-5c55-4418-bc9f-92be72da50ae"), "(182)445-2257 x107", new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "moshe@shanahan.ca", "Kallie", "Schinner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a7f17274-5fcb-417d-a701-4f30423fe00d"), "(218)884-7504", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "stanley_streich@wolf.us", "Emerald", "Pacocha" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5f015c5c-ec30-4627-8120-9b98d685ce05"), "350.600.0651", new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "cleora_muller@hermiston.name", "Luther", "Stracke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a70f8df8-aa32-4791-ad7a-ca31a2c2b558"), "1-451-145-5247 x245", new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "arnaldo@hermistonstroman.us", "Cleveland", "Steuber" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("810cb87f-801d-4bed-a238-498711c3843a"), "683-025-5347", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "foster.grimes@abshirehowell.name", "Roosevelt", "Ziemann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e89a5d41-6bdb-4d99-aa40-2a77b809c2e7"), "173-661-3123 x0284", new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "reid@turner.uk", "Anahi", "Kirlin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("75cfe566-af08-4f30-bb2d-faf92ea9143b"), "836-160-3160 x761", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "lauryn@yundt.biz", "Cordie", "Hegmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6f1a5e1a-6925-4457-8b50-3661ed76e6f9"), "254.827.8456", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "noah@bechtelaradams.biz", "Jalyn", "Goyette" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d617cb66-7644-4a01-8097-9b42d8f61e0a"), "628-858-4873 x174", new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnathan.ferry@schmidtkemmer.biz", "Rory", "Emmerich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("08f35829-80d8-4611-afb7-247244ef82ee"), "1-213-708-0405 x56223", new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "lance_hahn@murphykeeling.com", "Roger", "Kozey" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d84c274a-4468-4b44-8337-936822d60358"), "714-455-4562", new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "graciela.beier@pacocha.us", "Tiara", "Rutherford" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("00fa7aef-4e44-4cf7-b233-be747e66d653"), "437-138-0237 x13612", new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "jaylan@abernathyswaniawski.info", "Audra", "Hintz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5042e413-87e9-49ae-b453-7f7f15292060"), "1-276-104-6821 x58166", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "eleazar_gaylord@funkmcglynn.us", "Rachel", "Borer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("88526e9e-dec2-4bb2-bfc3-09979d07ce79"), "611-567-4650 x365", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "rowland_padberg@okondare.co.uk", "Icie", "Homenick" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6a5784fc-d92f-40cf-9722-51ef52de5eea"), "653-553-1233 x47575", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethel_ratke@rolfson.info", "Grover", "Herzog" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e78a91c7-3c32-4d29-8859-4557333706e7"), "614-274-2573 x18810", new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "brett_predovic@powlowski.info", "Buford", "Jones" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cf4a3506-9575-4f57-8362-d05d91184b01"), "1-280-678-0586 x61113", new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "caterina_douglas@fritsch.uk", "Kelsi", "Schaden" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7e34a133-bba8-49e1-88bf-8e43cb5d6e03"), "1-343-177-3878 x257", new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "melyssa_shields@zieme.co.uk", "Milo", "Labadie" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a7fdcb38-d1ec-4879-b086-7df88c9ea10a"), "430.211.4118", new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "hollis@bednar.biz", "Jaylon", "Block" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8a097f99-c1ad-4b7d-b0c6-c74c02e831f5"), "586-287-4182 x41568", new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "nedra.cassin@baumbach.co.uk", "Keara", "Schimmel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6153d06d-8045-4318-8590-cd94e854fdc8"), "(368)271-5638 x4368", new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "marianna_cronin@bauch.com", "Seth", "Jacobs" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("816eb5cd-e53b-4cbd-91b7-6913f3d03e70"), "135.661.0841 x44703", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "henri@blick.us", "Ricardo", "Kessler" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("531bbddf-70f7-4a0b-a4c1-ed74eda426c6"), "1-170-351-6754", new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "brad.oconnell@hagenes.biz", "Jeanne", "Dooley" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a3b84ef2-9bac-4426-99be-7dcfca65d24f"), "1-214-722-8783", new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ray.hintz@mraz.info", "Wendell", "Purdy" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1d99e35b-baec-4baa-9547-9aab3b24f2f6"), "216-885-8847", new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alicia@white.info", "Kelvin", "Heller" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("95ea575e-c768-4075-8b91-0aee610bb0d6"), "661.556.7321", new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "sadie@batz.info", "Kaylah", "Gusikowski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ab354534-2020-41cf-9fa8-dd30c06210f4"), "657-180-4525 x7526", new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "wilber.durgan@oreillyschuppe.info", "Forrest", "Tillman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cafce795-e0d7-4556-a2ee-0fae71ff8ae1"), "(240)281-0084 x4852", new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "bernadette.lowe@kertzmann.com", "Torey", "Gislason" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3d20dc4c-744f-4a4c-a634-e5d67447de15"), "(581)786-4464 x423", new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "oswaldo@hoegerconnelly.us", "Jacinthe", "Berge" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("fb9e2e4e-86ad-4c7d-a6d7-91d379378dd6"), "488.563.2720 x4515", new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ollie.kutch@larson.info", "Amie", "Bode" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c8c1ba44-4a7e-446a-b4a1-1a6bcebbae7c"), "418-451-1272", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "delfina@bergnaumtowne.us", "Dianna", "Gleason" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("dd9b12bf-b8ca-4941-921a-81333f597a3c"), "104.801.4471 x30467", new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "stuart_erdman@wizaoconner.us", "Abdul", "Quigley" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("138d5570-23f3-405a-8bf6-4e91550790b6"), "241-423-7721", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "francisco@howe.name", "Sheila", "Fay" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c49100e5-14d1-4ee7-93cd-593bbad94930"), "(004)774-5465", new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "lee@stamm.com", "Nicklaus", "Bergnaum" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("14d37150-1a31-41a4-8b09-634b56b9e551"), "1-304-433-0446 x6585", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "gail.ratke@raynor.biz", "Kendra", "Windler" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c55ea3c3-776b-41ec-a365-a0fd6b35d2f7"), "155-052-5538", new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "sonia.schumm@okon.ca", "Barrett", "Maggio" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3db7a4a2-ac28-43ba-89e1-65e1462b8c51"), "(607)117-2812 x8212", new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "jordi_leuschke@davis.us", "Dominique", "Dibbert" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ca2b553c-f391-4ff0-861e-4c911de37b5c"), "1-621-050-5535 x574", new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "vern@reilly.name", "Jameson", "Kuhic" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("247fca76-e008-4119-b5dd-379652b41f87"), "573.043.6001 x447", new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "carolyne_schmitt@sporer.ca", "Makayla", "Muller" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1e3f5049-60d5-45b2-9954-b53f83011758"), "(562)576-5456 x10261", new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "quincy.watsica@reichelshields.uk", "Erick", "Muller" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("de7b0dc6-4e58-4efe-acbd-633b8c9f72ac"), "258-240-4030", new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "merlin.okeefe@jaskolski.us", "Elfrieda", "Wisozk" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ed22c0b8-3b61-4965-94ed-7aa15978268d"), "(708)085-4142 x642", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "barry@blick.info", "Lacey", "Durgan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b3afaef0-48bf-4e1f-a03a-cadd3c7ab6e4"), "(538)078-4378", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "myrl_greenfelder@cristlangworth.co.uk", "Shana", "Ondricka" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("95e6856a-c52d-46a2-b5c1-3d3948ae6945"), "157-481-7683 x8617", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dax@schneiderjohnson.ca", "Unique", "Swift" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e0f83151-ee9a-4767-8c43-c579db9f420d"), "001.682.1767", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "roma@stantonward.co.uk", "Delaney", "Thompson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("554b26f4-ea33-4c39-9b94-1813126bfc21"), "(536)724-8041 x7131", new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "timmothy.roob@kassulkereynolds.info", "Erick", "Smitham" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d0265dac-e56a-41fe-81b3-ff7ab4620189"), "864.643.4411 x4802", new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "verona_conroy@will.uk", "Ola", "Brakus" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1ada9d2c-8f9c-4b60-91f3-f4b5f4ec32e6"), "1-207-382-7753 x438", new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "giuseppe_cronin@smitham.com", "Joshuah", "Waters" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("84d91191-c030-41d6-9d31-7fb044e1a528"), "(016)608-6625 x82344", new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "cassie@koelpin.uk", "Sydney", "Corkery" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5e1aaefd-bb8e-42d8-83fd-651975e1a4df"), "662-455-5368 x60610", new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "eloisa@dachoberbrunner.name", "Brady", "Weissnat" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3cced064-1122-4111-b2ee-d6e534c3e6ab"), "755.207.0135 x13507", new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "mack@jaskolski.co.uk", "Alice", "Rau" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ea3c4935-d5b2-4858-bdd7-5455b852c24d"), "740.587.5842", new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "patsy@harvey.name", "Jermey", "Abbott" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d629055d-582e-459a-9dfa-6900641cd878"), "343-031-7058 x1771", new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "wilton.senger@zboncak.com", "Maud", "Casper" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b09c6d92-20f7-4f0b-bf88-e361568264e2"), new Guid("81e72ff1-1446-4ab7-bcd3-5863c12324dc"), 15m, new Guid("816eb5cd-e53b-4cbd-91b7-6913f3d03e70"), new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 95m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f710a0bc-2d4e-41b6-b47d-6753a1f9e987"), new Guid("48a618b8-7959-4540-809f-b98bb2d7603c"), 15m, new Guid("8ab870d2-0bf3-4737-af96-e6031179f16e"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 47m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d96b9090-5908-4bfe-b6c7-abe80d0ce7e6"), new Guid("3ee971f1-c8f0-4ef3-af73-3040b73e0a53"), 15m, new Guid("8ab870d2-0bf3-4737-af96-e6031179f16e"), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5051eb21-4f9f-4873-8339-e22bcd9248b1"), new Guid("5829f609-e0a9-45f9-8adc-aba5f5a896aa"), 15m, new Guid("95f4db3b-2daf-497d-a88c-c69e489b0f85"), new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 97m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f7a63e08-98d3-40ae-9a91-768e3254f321"), new Guid("f96c28d2-4f8e-4732-b637-ac58c3b5607a"), 15m, new Guid("95f4db3b-2daf-497d-a88c-c69e489b0f85"), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 20m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("488a722c-bf24-41ee-b49e-c0a42c975393"), new Guid("8c706b61-1b30-4b83-bdf1-be14366bb0b2"), 15m, new Guid("3da6ddbd-2859-4f99-8eb5-82cab4abb509"), new DateTime(2019, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6f9a5dc3-3f86-44cf-b4e7-1b0a4207388a"), new Guid("f3f17ea3-ed64-4358-9b10-f7a01a7cb5ac"), 15m, new Guid("1b88262a-2577-46c4-81d9-b1c315c90e94"), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 75m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("cfe5f5a8-2639-477b-8c83-71b67a59e8f4"), new Guid("78ed0f1c-964d-4348-ac9e-3ac1ab117282"), 15m, new Guid("1b88262a-2577-46c4-81d9-b1c315c90e94"), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9eae62b2-0450-4617-846e-fff8ec5214a6"), new Guid("a206a978-92b9-41b2-aaa6-4a0f2b4b616a"), 15m, new Guid("b3b39040-5ffb-49a3-8e35-589ca30e2bb3"), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9119d8ba-1aff-4c0a-ae3a-ab64e269ca30"), new Guid("08e4877e-1f5c-4ced-b2a4-cee9684ab243"), 15m, new Guid("a75ba091-64e0-4f2e-9de9-a0bd1b616854"), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 67m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5c5bacbd-ae2a-47a3-bbce-6578a41e0a9e"), new Guid("91ed416a-8d05-4b3f-b4d6-558c1653c87e"), 15m, new Guid("a75ba091-64e0-4f2e-9de9-a0bd1b616854"), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 53m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1929e126-5094-466c-9845-6918e454bd87"), new Guid("08e4877e-1f5c-4ced-b2a4-cee9684ab243"), 15m, new Guid("00e3375f-34f3-4ec8-9e82-93d36f6bfd46"), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 76m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("160666b3-cb4b-4267-b3ea-1f5d453642e8"), new Guid("a206a978-92b9-41b2-aaa6-4a0f2b4b616a"), 15m, new Guid("cba4e233-6bfd-4b8b-9c27-af52be8c1b78"), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 38m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a917627d-2b56-4197-bd32-9a022193c2b0"), new Guid("96c56c74-d2a7-4eeb-b32c-28d4bcd78616"), 15m, new Guid("d02519a4-44df-42f5-b90a-a81a6c13da4a"), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 58m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d6bca534-d694-414d-be05-f6ee0bc21238"), new Guid("219f779c-808c-4064-a582-f3fb11507779"), 15m, new Guid("d02519a4-44df-42f5-b90a-a81a6c13da4a"), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 27m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a3a8c4cc-be05-4009-be5b-e2058a0f3d2b"), new Guid("b07c96ae-2ee9-4530-aff8-a601a22488a5"), 15m, new Guid("d02519a4-44df-42f5-b90a-a81a6c13da4a"), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8c39be67-0bdc-4cab-85db-e3ee35b3e03b"), new Guid("1e451493-4166-48f1-aeb3-5e676dcea681"), 15m, new Guid("d25a2a06-6f66-4000-b826-397319a5c3f2"), new DateTime(2019, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 92m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("c0df820f-902d-41ed-a2d0-5564bea5905f"), new Guid("abb751b4-bb43-4c40-a20f-d5cb7f53daa1"), 15m, new Guid("d25a2a06-6f66-4000-b826-397319a5c3f2"), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 88m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("08ffd4a7-b0de-4c45-ad55-73ce6f725432"), new Guid("80c89cfb-05b5-4ef7-8c6f-1f16c2aad666"), 15m, new Guid("d1a7a2d3-84ef-4208-b3f4-2b7bffe95eee"), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 63m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8ed81657-2470-4f3f-8fe8-fc0732b04ab9"), new Guid("d9f95282-68d6-471f-ab6e-90f78c2b581d"), 15m, new Guid("6d156bf4-faf1-45bb-adbd-802053130436"), new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 96m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1f789799-dea5-47b1-a220-98624b1d1a5c"), new Guid("5614ce9d-bff1-4028-b2d6-2907bee51233"), 15m, new Guid("6d156bf4-faf1-45bb-adbd-802053130436"), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 81m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("11f68142-3f64-4852-95b0-5cd71a86bbc0"), new Guid("b9144853-16ee-4054-9c6a-1320bebf88bf"), 15m, new Guid("6d156bf4-faf1-45bb-adbd-802053130436"), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 69m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f31fa8a9-e55b-41b8-88e6-8f4f88832106"), new Guid("81bd326a-08cb-4dc2-b5e4-cd37f91170e3"), 15m, new Guid("51ab476d-9623-4492-9106-3d565850a984"), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5c08a0a0-ebc3-415d-b0a4-e720b4f1d6f7"), new Guid("6506532a-88bf-4516-8410-54b0f0eb1dec"), 15m, new Guid("6d156bf4-faf1-45bb-adbd-802053130436"), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("74bde0b6-f5bb-4a0b-b5d7-50cb0b8281b9"), new Guid("5fb7d375-4fff-45aa-ba5d-ec163f63bf95"), 15m, new Guid("878a3066-7dff-4788-b6f3-8f8a621bcf44"), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 16m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("cee24a5b-317f-44d4-943a-decba2ff3185"), new Guid("78ed0f1c-964d-4348-ac9e-3ac1ab117282"), 15m, new Guid("878a3066-7dff-4788-b6f3-8f8a621bcf44"), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 71m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d9eb87df-350b-492b-b590-3b0b3c896fce"), new Guid("36b13504-1303-4d8d-a794-44be5ed7152c"), 15m, new Guid("55d146e7-0fbc-456d-8dc4-17429abe050a"), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 78m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e0260e5e-9b26-4975-8a96-2a25f387ba3d"), new Guid("9d89717a-36d3-4dd1-bbe3-a2dce12c5309"), 15m, new Guid("55d146e7-0fbc-456d-8dc4-17429abe050a"), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 68m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1ce1b5e8-c6a2-4bf3-a2d7-144a9af11a0b"), new Guid("9d89717a-36d3-4dd1-bbe3-a2dce12c5309"), 15m, new Guid("c5b4473a-16fe-4d5a-86c6-1a638f3d9433"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 72m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1aad5ff7-179c-40f3-9860-7ad70f8390f8"), new Guid("a4cec5fc-f37d-4444-9a01-20d0508a7094"), 15m, new Guid("26ae61ef-f02e-40bd-901f-d30d92665edc"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 61m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("39a1f33d-ba09-43a0-bd14-1642b02a6e0c"), new Guid("d28262e0-6f03-4366-86b6-b83f330d8877"), 15m, new Guid("8d880de9-cddd-4a95-bdad-799b2f848cd8"), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("34fcfb0e-6040-4641-9fc3-985ce5af96cb"), new Guid("26a7b153-4917-4ccb-884f-1fb084f4b4ae"), 15m, new Guid("0f6511e9-fc96-4d09-a4d2-e68d97f2db3a"), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 44m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("71275a9c-0b2a-4169-bfce-e4d75b65abc6"), new Guid("666d83da-be57-478f-87b8-ef347deffdce"), 15m, new Guid("0f6511e9-fc96-4d09-a4d2-e68d97f2db3a"), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 13m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8384c920-1064-4652-b093-0a25c1f8a2ca"), new Guid("142d0cc4-3f71-40be-8741-290e12b49b82"), 15m, new Guid("6bee62ab-369b-4a76-a7b7-d164265c23ae"), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9aabb084-a26f-43a7-9031-acc36b513700"), new Guid("f3f17ea3-ed64-4358-9b10-f7a01a7cb5ac"), 15m, new Guid("b07e1bfd-50ae-4d6a-bfb2-24e463d9475b"), new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 93m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("45fd2df7-a44a-4a66-9610-5cdfa06c3b0b"), new Guid("81e72ff1-1446-4ab7-bcd3-5863c12324dc"), 15m, new Guid("b07e1bfd-50ae-4d6a-bfb2-24e463d9475b"), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 43m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("58fbdfee-863b-43c3-b0fd-e878a69b2dcf"), new Guid("f6f62472-ba40-47bd-802c-0e72b011f750"), 15m, new Guid("728cab47-2396-476e-afb1-bcfa548727a5"), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 42m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("db3b285d-1dd4-4f33-91fd-963caac0ca5e"), new Guid("f6fb928b-711f-42fa-b050-329a5931084e"), 15m, new Guid("728cab47-2396-476e-afb1-bcfa548727a5"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7732ab5c-6f73-4710-a315-999c64c112bd"), new Guid("0455d9fe-9bb1-4dae-bc6f-6d68789ca072"), 15m, new Guid("b3d65b69-3b20-4a96-a026-8c073aa8ba11"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("c84a0f12-b8c0-4af4-8307-897a709c1116"), new Guid("9d89717a-36d3-4dd1-bbe3-a2dce12c5309"), 15m, new Guid("85bad92b-b106-4ca6-a0df-2464b6675208"), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("251d488a-601d-4da6-89c8-754965aba5f6"), new Guid("379270d0-e1e6-4489-bdcd-c1dc19bd2fbc"), 15m, new Guid("85bad92b-b106-4ca6-a0df-2464b6675208"), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 26m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("fc896850-9250-4868-b0a2-7ad7faa23e29"), new Guid("046dee67-f4cd-499c-ab10-9de094a4af94"), 15m, new Guid("fc2891ab-032c-468f-b995-0dea7c605dc1"), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 36m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("76a1e207-9b21-4058-b64d-8b1563f499c5"), new Guid("10f48a4c-15e7-44dd-83d3-a3941703b11f"), 15m, new Guid("7165a7e6-aec2-4b25-a6d2-dd106b2bc5e9"), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 74m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("4e2daf32-9337-4d47-bc63-0a9c89d6ea08"), new Guid("1b20ee23-8186-46cc-bec1-854300b71256"), 15m, new Guid("ef9ec1e9-7444-466a-8ba0-b9ccaa089265"), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 54m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1c4d5dc7-19a9-4c21-b8bd-a1d4697dc15a"), new Guid("73c1f583-2de0-4bb7-9dcb-1efc2bc57595"), 15m, new Guid("c4ebaa4d-6848-4089-a781-a3e40304dc73"), new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 91m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b414599e-99bc-4abb-a37b-7f9e2e8bf0d8"), new Guid("0ecfedc5-6fd8-4cc6-ae4c-616471670289"), 15m, new Guid("c4ebaa4d-6848-4089-a781-a3e40304dc73"), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("32808262-7fc4-408f-b17f-833ff60a60dc"), new Guid("36b13504-1303-4d8d-a794-44be5ed7152c"), 15m, new Guid("c4ebaa4d-6848-4089-a781-a3e40304dc73"), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ca6ae721-2056-4623-bc92-558528405a81"), new Guid("b07c96ae-2ee9-4530-aff8-a601a22488a5"), 15m, new Guid("878a3066-7dff-4788-b6f3-8f8a621bcf44"), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 35m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b09490ed-bc8d-456a-9d59-d2e516cdf0a9"), new Guid("ea7fc6c1-2d9a-4e91-bcda-aa49f0b64cdc"), 15m, new Guid("62fc7430-fb06-4ba8-8d58-cccb2fd1d598"), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 57m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7c3a162c-f5ef-4a4e-ba2c-35c21ca55c59"), new Guid("26a53e28-9e74-47a2-8ae3-614c106a661f"), 15m, new Guid("62fc7430-fb06-4ba8-8d58-cccb2fd1d598"), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 8m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e7e44548-6f06-418b-98a1-6453328f33e3"), new Guid("5fb067f4-7e28-4d18-b34c-2a27576d867e"), 15m, new Guid("3cc438c5-5756-4356-897a-dc49dca80487"), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 56m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bac646b2-2a43-41c0-a517-d58bf302ef1b"), new Guid("91ed416a-8d05-4b3f-b4d6-558c1653c87e"), 15m, new Guid("1ada9d2c-8f9c-4b60-91f3-f4b5f4ec32e6"), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 17m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("cdb53911-a20a-46fc-a0dd-cdaf6369e523"), new Guid("a5bdc99c-bd72-427a-8f65-7a4c600d79c7"), 15m, new Guid("1ada9d2c-8f9c-4b60-91f3-f4b5f4ec32e6"), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("dba66010-cf2f-442d-a7b4-1d231f2c08fd"), new Guid("b9144853-16ee-4054-9c6a-1320bebf88bf"), 15m, new Guid("5f015c5c-ec30-4627-8120-9b98d685ce05"), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 73m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("fd5900de-6b8c-4e4d-85ef-eecd7bfc4e8b"), new Guid("379270d0-e1e6-4489-bdcd-c1dc19bd2fbc"), 15m, new Guid("3cced064-1122-4111-b2ee-d6e534c3e6ab"), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 52m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5c3bbe69-3e3f-420e-aad1-3884e303ec9f"), new Guid("08e4877e-1f5c-4ced-b2a4-cee9684ab243"), 15m, new Guid("3d20dc4c-744f-4a4c-a634-e5d67447de15"), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 31m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("09e74ecc-a5d0-4559-b308-869b09262688"), new Guid("21a381e6-f91e-4088-96f2-82bafb2fd67f"), 15m, new Guid("ab354534-2020-41cf-9fa8-dd30c06210f4"), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2b04df8d-6597-4c35-ae97-8bed688b3f39"), new Guid("8119cf6e-38a0-4e36-a580-a4a27ca3fc79"), 15m, new Guid("e89a5d41-6bdb-4d99-aa40-2a77b809c2e7"), new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 99m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f632c760-ae71-49eb-af04-9d0b9f962589"), new Guid("eda5043e-4996-4211-ba4e-c6180307e114"), 15m, new Guid("6f1a5e1a-6925-4457-8b50-3661ed76e6f9"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 79m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("4ecae114-0f08-475c-9815-a92d8cd66046"), new Guid("56768934-8554-4311-b21a-5089ecaf1e3d"), 15m, new Guid("6f1a5e1a-6925-4457-8b50-3661ed76e6f9"), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 62m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6c884ee7-aa17-4cb6-9022-3da5f3b640fb"), new Guid("0455d9fe-9bb1-4dae-bc6f-6d68789ca072"), 15m, new Guid("6f1a5e1a-6925-4457-8b50-3661ed76e6f9"), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 37m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a1b0c3b3-b17d-4363-bd9f-8f4ede00cfe7"), new Guid("b6ca8494-76a8-48fa-8bc9-b91575ff10b3"), 15m, new Guid("d617cb66-7644-4a01-8097-9b42d8f61e0a"), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 89m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("752a8a5a-fe75-4d4a-b586-e75143bd263b"), new Guid("67e2e4f4-c6d3-49f7-a4e3-a82f0f0c1c55"), 15m, new Guid("08f35829-80d8-4611-afb7-247244ef82ee"), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("721e07b9-8c72-4003-8ff3-58a3364ce2f1"), new Guid("b07c96ae-2ee9-4530-aff8-a601a22488a5"), 15m, new Guid("d84c274a-4468-4b44-8337-936822d60358"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a12be059-5274-40db-a1b5-6b2123d8e932"), new Guid("6506532a-88bf-4516-8410-54b0f0eb1dec"), 15m, new Guid("5042e413-87e9-49ae-b453-7f7f15292060"), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("062ebd45-cec2-44d8-a321-e2ba4d857478"), new Guid("ed9689ee-2d4c-48ae-bcf3-fd27230e4848"), 15m, new Guid("88526e9e-dec2-4bb2-bfc3-09979d07ce79"), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("98a560d4-425b-4aed-b4e1-19e2dfb5beb8"), new Guid("9fbaae26-da7e-4ff8-a173-8eb7ee21eef5"), 15m, new Guid("e78a91c7-3c32-4d29-8859-4557333706e7"), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a1ed89eb-2e60-4ae8-851b-ab726dbe61e1"), new Guid("1e451493-4166-48f1-aeb3-5e676dcea681"), 15m, new Guid("cf4a3506-9575-4f57-8362-d05d91184b01"), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 64m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("cdcf607b-19f3-4ed5-804b-098fcbdb0bdb"), new Guid("379270d0-e1e6-4489-bdcd-c1dc19bd2fbc"), 15m, new Guid("cf4a3506-9575-4f57-8362-d05d91184b01"), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 51m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("05218e9d-ac10-4dca-8915-8eff2bbe6cf4"), new Guid("96c56c74-d2a7-4eeb-b32c-28d4bcd78616"), 15m, new Guid("7e34a133-bba8-49e1-88bf-8e43cb5d6e03"), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 77m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("eb9d77b7-662e-42ac-8c7e-3e3f955bc505"), new Guid("379270d0-e1e6-4489-bdcd-c1dc19bd2fbc"), 15m, new Guid("7e34a133-bba8-49e1-88bf-8e43cb5d6e03"), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("df3e07e2-1af5-42d8-861c-85a3b9987d69"), new Guid("81bd326a-08cb-4dc2-b5e4-cd37f91170e3"), 15m, new Guid("8a097f99-c1ad-4b7d-b0c6-c74c02e831f5"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 11m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("831e6ac9-19fc-4383-977f-cac6220f7f84"), new Guid("8c706b61-1b30-4b83-bdf1-be14366bb0b2"), 15m, new Guid("d0265dac-e56a-41fe-81b3-ff7ab4620189"), new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("72203e3a-ce6b-4c4c-850c-66c328d01a1f"), new Guid("a4cec5fc-f37d-4444-9a01-20d0508a7094"), 15m, new Guid("554b26f4-ea33-4c39-9b94-1813126bfc21"), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 48m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("231f71e6-5989-4987-ba25-edb5929afb29"), new Guid("fc71bb5a-175f-48c5-ba66-762af62148e0"), 15m, new Guid("95e6856a-c52d-46a2-b5c1-3d3948ae6945"), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("802a3935-7d91-4cbc-b7da-f61a1d835813"), new Guid("eda5043e-4996-4211-ba4e-c6180307e114"), 15m, new Guid("b3afaef0-48bf-4e1f-a03a-cadd3c7ab6e4"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 29m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("055a0a05-1c28-4ad6-841f-d3f07198f538"), new Guid("ea7fc6c1-2d9a-4e91-bcda-aa49f0b64cdc"), 15m, new Guid("e52316e9-14b8-49f7-bef1-f58e2c90ae31"), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 84m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1ddb0220-3733-43ca-8dea-b0f42b12e558"), new Guid("a5bdc99c-bd72-427a-8f65-7a4c600d79c7"), 15m, new Guid("9d34cc29-bccc-4808-a3cc-de9b065fc45e"), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 21m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("54bab1de-6286-47b0-9f33-4388dbafde1d"), new Guid("c6316ce7-727b-4805-b92e-f154a8531924"), 15m, new Guid("22782edf-b9f9-4332-ad97-5ce75abf801d"), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 24m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("c30ab90a-9c95-440e-862b-e05615f812e8"), new Guid("b9144853-16ee-4054-9c6a-1320bebf88bf"), 15m, new Guid("19140824-2b56-4074-8758-3b14f66d99f2"), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 32m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e8470d00-c05c-4a6b-a418-2ac19fa5482b"), new Guid("142d0cc4-3f71-40be-8741-290e12b49b82"), 15m, new Guid("46038906-2b42-4a47-a3b4-518fce6b019c"), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6e2462a7-9367-4c81-90d5-06854c852be4"), new Guid("f374f21d-51cd-4e3b-badd-f8f4ac10fed5"), 15m, new Guid("a7f17274-5fcb-417d-a701-4f30423fe00d"), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 66m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("39ad534e-4425-4d02-88ff-ba5c77082f4b"), new Guid("20fb50b4-9484-4ff2-baa0-28cb6cb9bf07"), 15m, new Guid("a70f8df8-aa32-4791-ad7a-ca31a2c2b558"), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 86m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("48f7f168-5a99-4254-8ec9-8a5828f4233b"), new Guid("c94e6f9b-8d74-4140-9c85-54ffe90a07d7"), 15m, new Guid("fb9e2e4e-86ad-4c7d-a6d7-91d379378dd6"), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 85m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1de1a7fa-ca3f-4d58-898e-d02f2735bd12"), new Guid("c6316ce7-727b-4805-b92e-f154a8531924"), 15m, new Guid("fb9e2e4e-86ad-4c7d-a6d7-91d379378dd6"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 34m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("31c52819-d525-4450-8ab4-a6357e0026a4"), new Guid("1659cfe9-0f6d-4489-a658-4262773f2d6a"), 15m, new Guid("fb9e2e4e-86ad-4c7d-a6d7-91d379378dd6"), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 19m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b90b6847-35f4-4d7a-8696-2d62d41c4288"), new Guid("7607ee88-6318-44d5-a55f-46d7c2fdf78a"), 15m, new Guid("1d99e35b-baec-4baa-9547-9aab3b24f2f6"), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 49m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("78bae553-59e2-46de-9490-6d9df722298a"), new Guid("eda5043e-4996-4211-ba4e-c6180307e114"), 15m, new Guid("fb9e2e4e-86ad-4c7d-a6d7-91d379378dd6"), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("097cfd21-d9e1-4b39-b72a-15f6022bbb5e"), new Guid("72e76bb5-e46a-492c-8cbd-66559966ed14"), 15m, new Guid("c49100e5-14d1-4ee7-93cd-593bbad94930"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 18m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5a56c780-b748-440d-bb41-b1458c51e0a1"), new Guid("379270d0-e1e6-4489-bdcd-c1dc19bd2fbc"), 15m, new Guid("14d37150-1a31-41a4-8b09-634b56b9e551"), new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 98m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("56fc17a2-1b5c-4628-b1e0-1629f62a56c6"), new Guid("20fb50b4-9484-4ff2-baa0-28cb6cb9bf07"), 15m, new Guid("c55ea3c3-776b-41ec-a365-a0fd6b35d2f7"), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 65m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("879dbb8e-203f-47af-b681-5c8a2a39e212"), new Guid("4edf4312-d08f-482e-93ee-13a89ba0e1f4"), 15m, new Guid("ca2b553c-f391-4ff0-861e-4c911de37b5c"), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 83m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5eb45b31-da43-4e9b-88d1-faa216db574a"), new Guid("67e2e4f4-c6d3-49f7-a4e3-a82f0f0c1c55"), 15m, new Guid("ca2b553c-f391-4ff0-861e-4c911de37b5c"), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 41m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7b1e021d-5355-4d2d-8c40-4e90eca42643"), new Guid("046dee67-f4cd-499c-ab10-9de094a4af94"), 15m, new Guid("247fca76-e008-4119-b5dd-379652b41f87"), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 87m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9c704564-754a-4cce-b138-0ba3e37e8191"), new Guid("666d83da-be57-478f-87b8-ef347deffdce"), 15m, new Guid("de7b0dc6-4e58-4efe-acbd-633b8c9f72ac"), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d9886893-6070-491e-b573-621eb23b2bcd"), new Guid("b9144853-16ee-4054-9c6a-1320bebf88bf"), 15m, new Guid("ea3c4935-d5b2-4858-bdd7-5455b852c24d"), new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5d33addd-1419-4909-95f5-8fc37faca9e2"), new Guid("a5bdc99c-bd72-427a-8f65-7a4c600d79c7"), 15m, new Guid("ea3c4935-d5b2-4858-bdd7-5455b852c24d"), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 59m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("942b98c0-5075-4c68-a947-f2930aa8ec7d"), new Guid("b9144853-16ee-4054-9c6a-1320bebf88bf"), 15m, new Guid("ea3c4935-d5b2-4858-bdd7-5455b852c24d"), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 28m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0fa74e78-d902-45ab-8ecb-063b53010603"), new Guid("741113eb-cffc-4d9f-815f-656ed864f362"), 15m, new Guid("c8c1ba44-4a7e-446a-b4a1-1a6bcebbae7c"), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 23m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("edec0022-e3c5-4173-b369-12c94a978311"), new Guid("c6316ce7-727b-4805-b92e-f154a8531924"), 15m, new Guid("d629055d-582e-459a-9dfa-6900641cd878"), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 39m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BoardGameId",
                schema: "r",
                table: "Rentals",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ClientId",
                schema: "r",
                table: "Rentals",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals",
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
