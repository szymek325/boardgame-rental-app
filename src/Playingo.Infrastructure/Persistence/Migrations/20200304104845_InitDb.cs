using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Playingo.Infrastructure.Persistence.Migrations
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 4, 10, 48, 44, 865, DateTimeKind.Utc).AddTicks(6432))
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 4, 10, 48, 44, 870, DateTimeKind.Utc).AddTicks(3841))
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 3, 4, 10, 48, 44, 870, DateTimeKind.Utc).AddTicks(736)),
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
                values: new object[] { new Guid("4a1d18c4-70b9-46b2-8bec-45585dce9896"), new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 128m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("900ad91d-80f2-4390-937f-9314dda0ec70"), new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 156m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("45e3b0cf-fa90-46de-91e2-ea7b28039eff"), new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 64m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a31407a8-a081-43f3-9886-1141713bf16f"), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 247m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6ab8d0dd-0561-4989-a986-c83c6788ba42"), new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 127m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1af9f84f-99b9-4d07-90f8-cafa9a2accf1"), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 186m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9b89a721-caa7-4584-97c6-4b221421e287"), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 140m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("649b7479-bccd-4d76-be46-fc6f5ed7dfe8"), new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 61m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ce243ad4-d101-4a50-8053-9fafb4264418"), new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 165m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b8fdd0e5-d927-4b0f-94cd-9fae6ea0ed96"), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 107m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c8f59991-59cd-493c-a108-223bb78edb7d"), new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 139m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("82e03e18-4e88-48a8-afa0-385c48ce817d"), new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 175m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("76d7c406-c8e1-4c6a-b2e6-b6fb50f6fdf6"), new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 94m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e5ab61e1-2ae6-47c4-b36b-fee1987fea07"), new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 197m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3623e1aa-4a76-49a9-8b8e-1b680087989e"), new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 242m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("65c553ab-8428-477f-b628-cba718c4a014"), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 93m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b0c50972-0742-4127-8366-f7d7cb3e46b0"), new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 62m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("78610159-e998-4bc6-9b55-cccf752e77fb"), new DateTime(2020, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 117m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b3bb8d43-4260-4ede-af3a-e6f95be6cfb5"), new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 173m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6567c22d-8a03-466b-8700-f679a0e0393d"), new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 203m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b5055002-c3f7-4742-ac19-3cc643f3f6d4"), new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 208m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4dd93ddb-1dfd-4c86-943d-6e109d8130eb"), new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 132m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e6112b05-3e97-478e-aa81-713baf0831db"), new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 230m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9aa7c1ef-9807-4741-92c6-c11f6d5ee9ed"), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 99m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("75042dd5-cc14-4a41-8ffb-c21be7ec943f"), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 70m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4f1448eb-7c88-4ba4-a9db-e6b45a55378e"), new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 127m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("432de4d6-ce24-4851-8b33-6b00863e463e"), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 187m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("729cb4f0-a9e2-4576-a476-f06f1441ff1d"), new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 237m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("01ab62f1-b21a-41b7-879f-977264b081f9"), new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 63m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("58a1752b-7f2a-4d86-80fa-8cbdbf02bb19"), new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 90m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e0264a14-4e41-475d-8b21-20e950ccab0b"), new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 86m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4be4f87a-58e2-49c0-8307-f8ad01307a17"), new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 201m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("20d7cd70-57c2-449e-9c5c-8033e08363bf"), new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 64m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5125abb7-0118-4022-a6e4-0995fb42f782"), new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 184m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e20ed224-57e2-41c4-9cbc-9b7b1944df6f"), new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 60m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3ff28d49-3e3b-42d1-8988-f24966454ec3"), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 159m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7597034d-072e-4dfe-bd61-f834d8725997"), new DateTime(2020, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 96m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("15f76fc8-143c-4244-ab1c-24f50d504691"), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 202m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b7c1ebe8-6b29-4c1e-9f9a-7c4582c26334"), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 105m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0e305e8e-f244-43b6-8748-89bc0a51691d"), new DateTime(2020, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 57m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5ed971c9-80f3-4bbd-b732-37ed730d5f0a"), new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 100m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("27a0458a-a965-4910-81c7-564c64d49f5c"), new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 202m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e57c3a57-09c1-45a2-838a-3474425e01e8"), new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 172m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b0882f81-2b67-43b3-bb20-8577d28069c3"), new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 122m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("84631b6e-1e1d-45cf-9179-2bdfa821c595"), new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 118m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2221b1e8-d957-4cc5-b596-e880dc60d1bf"), new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 162m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("69054514-642a-47e2-8d84-51c3d344b54c"), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 124m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2a084908-248b-4e00-9c59-fed2c99e8274"), new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 187m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f23484e8-eb5e-4e40-92d0-d82268ba4799"), new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 212m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("bc0e9bf3-358c-4a27-a508-bbb74b6c3a1e"), new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 59m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("52f79584-8d03-4c26-8208-91891b6ba1ce"), new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 181m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ad13dcfd-e754-4032-a78b-2afc5cbd9f85"), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 209m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5cdbfec5-5fe0-4466-84f0-b9b8c24c4eb3"), new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 204m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("08265d54-f108-4e58-80f9-60a0c7d50c53"), new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 208m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f3f6c77c-c132-4f67-84a6-9bda5465bc4a"), new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 184m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("689709e5-2465-4c17-8608-dfd75cc6e239"), new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 213m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("81aaee70-bb41-46c4-9010-ede5429da415"), new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 100m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("56f8f94d-fb74-48bf-81f4-c3fdce1d5a79"), new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 122m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e8e64597-2629-4921-b2ca-c8ed6bd2b908"), new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c61e8277-a446-4644-a4ac-a6a4342b222d"), new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 205m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("35050e65-4e5b-43f0-af37-a54f3bb53b5d"), new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 246m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("11060bf6-76ba-418c-a1f1-b9a3946f5909"), new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 183m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("53054c97-6b0c-489a-855e-385f2de3306e"), new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 103m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("595aa76a-51eb-442e-b23f-5536b8ad80f4"), new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 161m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2802ac39-5fad-4cc6-8ef6-9e7bbc15bc6d"), new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 199m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("719d8d07-28f9-497c-bf04-eb1cb5d7a1f8"), new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 105m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1a8e2f82-81f2-4e28-8892-d2a6e716bc4b"), new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 176m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ef882254-7af4-4966-8640-968138f34941"), new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 80m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2d0d6139-7b56-481d-89d5-4d245b597c43"), new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 99m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c4d88e12-1e56-4436-820d-686a0f49f27d"), new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 230m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e8273be7-3db6-45c2-b159-f8f111bd4bd9"), new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 184m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5aa45fb1-a906-4f05-b0d3-a7dd322920cf"), new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 249m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8dcd0617-05e5-4686-b941-c00377c9011d"), new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 227m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5c68e392-e50f-45ec-9d26-9ff9086515be"), new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 182m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("043ed6fc-22d0-47d3-9207-58eba2cb4acf"), new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 172m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0377f079-f0b9-497c-8f7d-71c1947a9484"), new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 219m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("db9a6f01-1c0a-4421-ad65-f942b7716014"), new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 106m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0ec6fe8f-dab3-4c67-9a2f-40b4ca75a7e4"), new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 187m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0e8f8566-fc15-4428-8eda-1c0961732e49"), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 238m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2cf38f9c-146c-4a2b-836b-45140a3f5de1"), new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 74m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a2ebc5cb-98cb-4cfa-b25a-6da4b43f7b6c"), new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 97m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b2abd1eb-3fe4-4ebc-a7d4-7869e2a6e51b"), new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 245m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b46822db-4d7d-44fe-b437-d0a928add820"), new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 126m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("32bac29e-b649-4f88-b4e5-30f99d6cd80d"), new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 188m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("782ac162-f21d-4242-b357-a1ad15ee5790"), new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 233m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8465fb50-d767-4a95-b668-aef923c3ee48"), new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f0074d7f-b90b-4858-a55b-22e893d40806"), new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 107m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1def40c3-3647-4e9a-bfa9-79f08f11ac88"), new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 196m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("833ca613-a8d9-482e-a9bb-45eb4805f4dd"), new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 135m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a15aaad2-fcec-4c8f-88c3-54274080355f"), new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 61m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("709afd1a-8393-4de4-8ef3-c9a334dd14ef"), new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 127m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("459c5223-9a86-464b-a2ac-49d68217e5a5"), new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 131m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3852760a-7230-49fd-92be-67cadfa7c866"), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 180m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("240b544b-ad54-48f0-a42b-979c7fc3c23c"), new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 110m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7b25e667-887d-4a9a-89ae-e837069c9ece"), new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 104m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3ebf0f7e-c7eb-4038-b20a-2bcf7264f73f"), new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 133m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("330152c9-f5de-4ede-8a1c-5a8740158071"), new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 171m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3dfd747d-bd20-4aa6-bc18-a849f0722b99"), new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 156m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0d207527-3a3b-4dfb-bf66-df6b6c88f68a"), new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 83m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("800e2456-0b5e-47ba-8885-ad4d53fadca3"), new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 187m });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("87b77aac-616e-4483-ae87-d353de67be13"), "1-636-546-4777 x622", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "maude_schmidt@reinger.co.uk", "Nyasia", "Hamill" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7f11c132-f46d-4814-a9ac-9c8dc2d90c02"), "342-325-3131", new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "betsy@casper.uk", "Miguel", "Schuster" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f8954afc-49a7-478c-8361-55330449ca58"), "1-885-706-5142 x80435", new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ona_schuppe@schuppe.name", "Nayeli", "Kilback" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f54bf440-c6c4-4eea-aa84-2cac307ca11e"), "758-020-3681 x6641", new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "juston.tromp@shields.us", "Vida", "Denesik" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7b37d4fc-fd98-4849-85f0-b4f10b436ac9"), "1-767-727-8074 x0366", new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "javon.hane@langosh.biz", "Cathy", "Botsford" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("498f53d9-c54f-477c-b464-017efb5627a3"), "425.750.3524 x54362", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jett.abbott@walter.com", "Maegan", "Grady" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b8493d7f-60ab-4b54-9013-7e321e8119b2"), "(824)202-7512 x68057", new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "zachary.kautzer@barrows.name", "Dave", "Walker" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6f24f9c2-edd9-4d33-88f4-0e054fdf2a92"), "(616)401-3546", new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "zander@aufderhar.co.uk", "Flavio", "Kertzmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5709cdc8-36ea-43a1-87ec-11820f75d0e7"), "347.476.6434 x74358", new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "felicity@towneortiz.com", "Alycia", "Witting" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ff030a33-ec62-4624-a747-1b53e3bddad7"), "1-122-584-7114 x17364", new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "lexus_yost@beierlang.ca", "Salma", "Towne" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1b3a6082-8619-4587-9bf3-9f5672b41e82"), "(550)640-2252 x28568", new DateTime(2020, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "marjorie@powlowski.ca", "Dillan", "Kertzmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7a10521f-578d-4f92-a7a1-8f0f68f29cc4"), "1-677-262-0648 x40181", new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "boris_homenick@kautzer.ca", "Aliya", "Willms" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5b034b13-10f7-4079-acb0-332e3bc8f052"), "(138)675-2438", new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jerome.blanda@brakus.name", "Reggie", "Williamson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("89a8d86c-1bbd-4c9c-836b-f4204e0cbcad"), "1-028-264-7740", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mathilde@swift.uk", "Eugene", "Herzog" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("14d95e91-7fa5-4e46-944b-8f9e7e6d5c17"), "848-631-1031 x64653", new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "federico.leannon@jacobs.uk", "Rodrick", "Larkin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("788e73aa-ce13-4293-acca-91831b0b2959"), "560-061-4067", new DateTime(2020, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "maurine_ullrich@haley.co.uk", "Grant", "Lesch" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e441128c-bf86-46a6-b135-74721f98707e"), "1-524-324-8158 x017", new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "claudia.gislason@jenkins.com", "Leopold", "VonRueden" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6c268fda-c9df-42af-88f5-aa37ebfb3eff"), "582.217.5267", new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "toby_gerlach@rodriguez.uk", "Marlen", "Nikolaus" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("178d55f7-a3bf-44cb-9d77-0996068d3869"), "253.144.0355", new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "favian@labadie.name", "Christine", "Gleason" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("49367320-0b02-4fa7-b2b5-986112841211"), "(773)855-0877", new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam@stoltenbergrippin.info", "Ewell", "Beer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("56a70550-873a-40ab-9acc-d28ccc70f958"), "214.668.6164", new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "antoinette.langworth@powlowski.info", "Keyon", "Dickinson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7ff7b741-12eb-4fa8-bb82-3d87ef4e9e3e"), "600.882.2508", new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "shaina.kemmer@johnston.us", "Norwood", "Morissette" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("eac6ee96-767e-4996-973b-efd0ccfcb976"), "214-637-5430", new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "juana@ullrichconn.name", "Minnie", "Johnston" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7eae7d49-7b0e-4b0a-98ba-129a394f4e08"), "1-645-764-0266 x861", new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "esta@dietrich.uk", "Kian", "Johns" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3ace8570-08ba-4eda-8331-133091bed88f"), "1-153-414-7516", new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "cassandra.lesch@schuster.biz", "Andre", "Haag" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a92cd4be-56c8-41be-8f9b-77cc787dcb84"), "(822)671-4527 x4465", new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "helga_flatley@durganbauch.name", "Esperanza", "Strosin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("815c63d4-c21d-46af-8bcb-184a4347db91"), "1-215-332-4070 x1568", new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "jackie.goodwin@steubermccullough.com", "Johathan", "Gibson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0700a395-c52f-4765-8e8e-57c9a51bcf7c"), "400.245.5725 x360", new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "judah@runte.co.uk", "Kaylah", "Langworth" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("858ef013-3c26-4e2b-9243-37b720d63b9a"), "067-570-5778", new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mabelle@barton.name", "Moshe", "Ebert" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3b585ba2-6fb7-4ee9-836e-9a6889e9d050"), "(283)244-8578 x48500", new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "aric.hahn@olson.ca", "Tiana", "Zemlak" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e18956a6-8193-4d6d-9a3a-f78252edefed"), "(856)084-8455 x16404", new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "buck@beer.name", "Rosanna", "Donnelly" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c82c4dd8-f1e2-4014-8bae-e53bdc5be181"), "864-421-0108 x877", new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "aidan@pfannerstill.name", "Milo", "Spencer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7dcdc52b-e007-4bf2-b15e-19f274acf72a"), "(822)456-1503 x3126", new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "retha_rice@wunsch.info", "Robert", "Volkman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("78e64bc9-3ea2-4582-b344-1f337e655579"), "212-312-3654", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bo@schneider.uk", "Trent", "Volkman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a74c1ade-f11e-48dc-a5a6-6e7697a21017"), "031.161.0017 x15632", new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "judd_marks@wunsch.co.uk", "Pansy", "Towne" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7a316b51-b1f1-4905-9128-c87a4ed53726"), "1-713-840-7475", new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "luther_russel@bins.name", "Kobe", "Ondricka" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0d0b6d84-f48d-448c-ae79-65ade64dd7af"), "1-602-668-2240 x745", new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "breanna.pagac@leuschke.ca", "Nash", "Raynor" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0b4811f3-6979-490b-beb0-b527c710fbe2"), "(131)076-6883", new DateTime(2020, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "josie@braundubuque.uk", "Lacy", "Hermann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("48c6553a-b5b1-471c-a55c-a23bea844bb7"), "1-758-326-7334 x5321", new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "abdul@powlowskiwelch.com", "Flo", "Romaguera" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("01318898-7f65-45e3-bc2b-9e6ce731f9dc"), "(056)181-2115", new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "leone@collins.ca", "Mohamed", "Jacobs" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bfc183f4-cd97-4388-b726-1c10b9fb215d"), "1-884-051-0130 x16533", new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "domingo_bartoletti@kreiger.co.uk", "Rickey", "Fahey" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("afead73a-e762-400f-8a1d-9eda322d5ca7"), "101-112-3188 x484", new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "adrain@johnson.uk", "Lillian", "Schroeder" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a746356a-6e4e-4795-b5bc-30ce05201cab"), "1-681-634-0384 x8337", new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "coty@blick.us", "Furman", "Dietrich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("098ba540-2884-4f9e-bd68-d8d1dc545467"), "(405)186-2374 x0321", new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "enrique@lebsack.us", "Franco", "Reilly" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("26c490bc-ac0f-44d6-aee5-6067edbb7405"), "514.408.8714 x1528", new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "lilliana@hesselthiel.biz", "Garry", "Rice" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("aa5d3144-8baa-4fbe-985b-3cc5269df5f3"), "432.127.0366 x36405", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "jevon_batz@bernhard.info", "Matteo", "Ullrich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a17797cc-bde3-448e-a4c5-7d51ef42c0e5"), "773.562.7084 x3165", new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "jana@kuhicbayer.info", "Khalil", "Heaney" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e1ccffed-f5dc-46a2-9cd7-025089e6a5f5"), "754.273.0127 x3514", new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "mireille@dietrich.name", "Gilbert", "Deckow" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d6e29ae4-3259-422b-a59e-1cacd487ccbd"), "(502)242-2405 x2444", new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "bernadine@braun.biz", "Winifred", "Blanda" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b3d23b0b-dc67-4fca-8127-39734c4c02b6"), "(373)765-3728", new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "frederick@reillyjenkins.co.uk", "Marcos", "Morissette" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b1e0006e-4017-4e35-b0a4-211385b29c4e"), "1-538-537-6830", new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "lamont@kilbackreichel.ca", "Lemuel", "Mohr" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8b435a38-642c-4918-aec6-e14718e738de"), "771.557.7363", new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "dorian_buckridge@bayerrempel.name", "Ernestine", "Kihn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8ef92b86-0661-4deb-b3f7-989c490af32e"), "410.157.3120 x372", new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tiara@donnelly.co.uk", "Davonte", "Brekke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3ac037b9-b5ab-4e92-8088-b22066a965ac"), "(788)457-0165 x42731", new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "shawna_pollich@adamswisoky.biz", "Emmalee", "Dach" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("04678e00-af6a-49d3-8d84-0c65c85b0a61"), "1-000-337-0078 x053", new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "shawn@howerunolfsdottir.name", "Jarrell", "Carter" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("501bf077-8df0-48be-a58b-ed2ac3efc7a4"), "660-568-4181 x5648", new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "nelle_kilback@jenkins.name", "Garry", "Emard" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9aea76dd-1ec9-4088-977e-8e7cffae2540"), "122.255.5120 x1342", new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaycee.reichert@reilly.name", "Quinn", "Skiles" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("152514a8-83ba-4413-9772-a21bf9131aab"), "804.881.4480", new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "timmothy_bernier@vonrueden.com", "Yadira", "Ratke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("688a8a87-b41d-48af-917b-022e656c448f"), "220.077.4344 x07226", new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "jacinto.beier@kassulke.info", "Elwyn", "Goyette" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ef6f985d-565d-4a10-8acb-bc994d83cdd9"), "362-056-5503 x411", new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayla@abshirequitzon.ca", "Horacio", "Greenfelder" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cf3166f4-055e-4e59-b1b3-bcd01e889a5c"), "1-608-800-6248", new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "adella.roob@kemmerbernier.com", "Shakira", "Hamill" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("88190953-45e5-4285-bf54-ec43ba87f2bc"), "1-386-504-4180", new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "laurence@willms.biz", "Jacinto", "Raynor" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("dbb47d28-492d-4626-87a0-92c49802e9d0"), "1-545-788-0288 x811", new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "foster_luettgen@batzherman.ca", "Alba", "Wiegand" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("318e742c-6bc7-42c1-ae25-74c33b4d80fc"), "1-352-756-0873 x5852", new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "zetta.bauch@keebler.co.uk", "Lukas", "Baumbach" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e7abc034-0782-4f6d-a3fe-327a2a0f1432"), "1-500-341-0653 x73852", new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "orpha@cartwrightlockman.name", "Monte", "Huel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7d8cbcb8-2714-43f6-ab5e-aa3178a7e2c9"), "661-116-3741", new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "maritza@pagac.info", "Ford", "Fay" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b7667ffd-4e93-457b-a077-16c4279834d1"), "282.744.2660 x825", new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "tate.funk@toy.com", "Emmet", "Kunde" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2cb91aae-08ea-42b0-8415-020e6208b70b"), "(010)625-4473 x0156", new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ed_cartwright@crist.biz", "Elyssa", "Heidenreich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("49fe8128-6c5b-489c-809d-f825df5f2afa"), "102.274.5682", new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "euna.volkman@windler.us", "Loren", "Botsford" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2801ae13-9840-41ae-8781-c8bfa140ec32"), "(207)052-0566 x5518", new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "quinn@schinner.info", "Virginia", "Cummerata" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1dca49cb-0ffc-480b-ba48-da8028c0bc6e"), "(408)335-0604 x82813", new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "nadia.olson@hodkiewiczskiles.us", "Zack", "Kunze" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2b3a7862-c8fc-401a-b7d3-0ae344c10ccb"), "442-160-3114 x1766", new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "cletus.krajcik@hammes.us", "Jackeline", "Kovacek" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f3f0f14c-e179-484c-b39f-b09361e0532f"), "1-104-452-6118", new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "arnoldo@fahey.uk", "Neva", "Conn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("706ba8cc-3c4d-4570-ac79-12ab71fb4dfa"), "(465)428-0553", new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "dax@haagbaumbach.biz", "Celine", "Rempel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0e92d195-7a77-477d-b6a5-8a2b63eb8f0c"), "850.143.6177", new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "kyla@corkerykunde.biz", "Sandrine", "Moore" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c61978a3-207d-4ac1-aa39-921cba89c62b"), "1-145-616-7666 x843", new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "zola_pouros@leannonbergstrom.com", "Harvey", "Lemke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("53139477-12b0-42b1-9c00-57a117817962"), "1-785-861-4726 x437", new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "katelyn@smithsipes.co.uk", "Ova", "Kulas" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c235989b-672d-400e-9756-8a0093ba3ec4"), "816-750-3334 x05532", new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "rocky.weimann@armstrong.us", "Larue", "Gerlach" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7e787a65-178d-4aa5-8107-090edcf65cbd"), "232-634-2883 x86275", new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "zelma@howegoodwin.name", "Emil", "VonRueden" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c3d33aa4-83ce-44c2-ad44-38a3a288602e"), "705-118-8188", new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "brandt@quitzonkutch.us", "Elouise", "Hegmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7d9f7e58-14a2-4b85-93c5-4e2ae6d76b98"), "516.000.5384 x46757", new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ernie@mullerpouros.us", "Adolph", "Morissette" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("becf272a-51fe-471c-b2ff-4a8a4098b660"), "(258)021-7538 x267", new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "aleen.weissnat@lang.ca", "Lou", "Grimes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5d97979f-9aa9-4fb9-b7f2-26b449d071fb"), "560.018.6265 x13118", new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "lavonne.damore@turner.uk", "Garrick", "Marvin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2840484a-697e-42ff-bbd0-856a5647d148"), "466.672.0838 x7531", new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jack_kessler@zulauf.biz", "Dedrick", "Fadel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d9db71f2-f09a-49b4-953f-ea4cde6adea9"), "280.137.0830 x48084", new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ophelia@watsica.biz", "Yadira", "Leannon" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6109ee9a-a304-4885-8dba-5d21a21567fa"), "(887)804-3382 x7310", new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "katharina_herzog@frami.info", "Mohamed", "Bechtelar" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6bf3ba71-65cf-47df-b8f2-7314b7628915"), "508.350.7472", new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "olen@tromp.com", "Eliezer", "Labadie" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("60d505b4-eb4a-4b83-ab4f-9017ecc96510"), "1-681-847-8085 x11231", new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "dennis@bauchkovacek.co.uk", "Danyka", "Stokes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2ec4a35d-1c1b-4536-bbe9-2d510f232b1d"), "848.461.6314 x6828", new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "norene@reichel.name", "Liam", "Nader" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("888b2ee3-58a2-4ee9-b1d7-25274eb1734c"), "1-386-754-3250 x348", new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "rey@mertzzemlak.info", "Bryce", "Mitchell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b20c0a23-6134-4440-908f-62b0482e0119"), "752-457-8551 x012", new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mack.hammes@satterfield.biz", "Xavier", "Kulas" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5d46a9f9-e244-47be-b6f6-ed80b38e71d3"), "383.608.8640 x65258", new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "rigoberto.sipes@borer.ca", "Quincy", "Ward" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("adb8497c-cfe3-4e09-908d-ef1f2f58d7e8"), "(758)138-2657 x6743", new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dustin@goldner.uk", "Scarlett", "Bashirian" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5650118f-d2aa-4893-bba9-a19c50a69994"), "1-337-500-6357", new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "kylie.koepp@mraz.ca", "Freda", "Hammes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2761ae3e-7ef5-4941-a6c6-e31660e740b7"), "(877)071-3163", new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tod_halvorson@morar.biz", "Ella", "Feil" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("089acea1-311c-4a6b-acd4-2d106e1f0103"), "116-226-6878 x860", new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "kari_kling@lemke.info", "Edna", "Harber" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4d80ed53-dad5-4861-a9d7-5080fd6aa377"), "1-551-330-3227", new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "amely@leannonlangosh.us", "Rogelio", "Stokes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4100d829-6736-47d3-9671-26a8a6ea239e"), "627.600.5513", new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariela@schuppewaelchi.uk", "Kenyon", "Russel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e54710c2-ea37-437e-acdf-f3a85b643f0a"), "(532)813-6388", new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "abbey.torp@pacocha.ca", "Leon", "Shanahan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a88c7509-1e3a-48ab-9601-c168c09408c4"), "1-005-331-8008 x14478", new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "kian_jast@farrellkohler.ca", "Merle", "Roob" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("76096ab7-25e2-4416-b2d3-1b0ca83e2ed7"), new Guid("bc0e9bf3-358c-4a27-a508-bbb74b6c3a1e"), 15m, new Guid("1dca49cb-0ffc-480b-ba48-da8028c0bc6e"), new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9ea3d485-1946-4be8-9bc4-25a242391d65"), new Guid("432de4d6-ce24-4851-8b33-6b00863e463e"), 15m, new Guid("b8493d7f-60ab-4b54-9013-7e321e8119b2"), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 89m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("10adf78e-d8fe-4cbb-b361-f8a7bc01fe44"), new Guid("900ad91d-80f2-4390-937f-9314dda0ec70"), 15m, new Guid("b8493d7f-60ab-4b54-9013-7e321e8119b2"), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 47m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("3952e706-96f7-4de9-8217-c6c3859b1ba1"), new Guid("330152c9-f5de-4ede-8a1c-5a8740158071"), 15m, new Guid("7ff7b741-12eb-4fa8-bb82-3d87ef4e9e3e"), new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 78m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("737bdae5-c578-4e69-9b87-eadd71a88101"), new Guid("b5055002-c3f7-4742-ac19-3cc643f3f6d4"), 15m, new Guid("7ff7b741-12eb-4fa8-bb82-3d87ef4e9e3e"), new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d01d4169-df16-4579-abc8-762260605dfa"), new Guid("459c5223-9a86-464b-a2ac-49d68217e5a5"), 15m, new Guid("788e73aa-ce13-4293-acca-91831b0b2959"), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 76m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("4bca4d6c-46db-4382-adac-7b0ecd3fa629"), new Guid("719d8d07-28f9-497c-bf04-eb1cb5d7a1f8"), 15m, new Guid("788e73aa-ce13-4293-acca-91831b0b2959"), new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("777d5788-3338-4caf-b121-d52d04a0f834"), new Guid("c61e8277-a446-4644-a4ac-a6a4342b222d"), 15m, new Guid("788e73aa-ce13-4293-acca-91831b0b2959"), new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f4552855-1af3-4e6a-a315-e115ed5dd3eb"), new Guid("2802ac39-5fad-4cc6-8ef6-9e7bbc15bc6d"), 15m, new Guid("1b3a6082-8619-4587-9bf3-9f5672b41e82"), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 69m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("231f7850-902a-4e9a-b51a-d480c17640a9"), new Guid("ad13dcfd-e754-4032-a78b-2afc5cbd9f85"), 15m, new Guid("1b3a6082-8619-4587-9bf3-9f5672b41e82"), new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("3c1d7d8a-ad18-4f99-b5ff-112b18382084"), new Guid("8dcd0617-05e5-4686-b941-c00377c9011d"), 15m, new Guid("d6e29ae4-3259-422b-a59e-1cacd487ccbd"), new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 38m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6d4f2e01-d33b-40e2-92fc-cfb6ebc19f40"), new Guid("0377f079-f0b9-497c-8f7d-71c1947a9484"), 15m, new Guid("d6e29ae4-3259-422b-a59e-1cacd487ccbd"), new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 15m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0e0b07f1-e396-4077-b5ef-f53df46237ed"), new Guid("4be4f87a-58e2-49c0-8307-f8ad01307a17"), 15m, new Guid("b1e0006e-4017-4e35-b0a4-211385b29c4e"), new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 81m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("40297d20-98be-42ca-a217-fab6c8a7921b"), new Guid("65c553ab-8428-477f-b628-cba718c4a014"), 15m, new Guid("b1e0006e-4017-4e35-b0a4-211385b29c4e"), new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 36m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("04dccddb-fabc-403a-969b-09b1a3a89fdd"), new Guid("7b25e667-887d-4a9a-89ae-e837069c9ece"), 15m, new Guid("53139477-12b0-42b1-9c00-57a117817962"), new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("850f41ce-60ca-4203-ba98-3fae31fb636a"), new Guid("c4d88e12-1e56-4436-820d-686a0f49f27d"), 15m, new Guid("53139477-12b0-42b1-9c00-57a117817962"), new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 67m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("46dcf421-d633-484a-bfc8-2f8d5d6a7298"), new Guid("81aaee70-bb41-46c4-9010-ede5429da415"), 15m, new Guid("53139477-12b0-42b1-9c00-57a117817962"), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 65m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("fe4e6832-d0ac-434b-b242-edf11bc0caef"), new Guid("c61e8277-a446-4644-a4ac-a6a4342b222d"), 15m, new Guid("53139477-12b0-42b1-9c00-57a117817962"), new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 11m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d0a04748-f599-4d0b-884a-ad40c19f411c"), new Guid("b8fdd0e5-d927-4b0f-94cd-9fae6ea0ed96"), 15m, new Guid("c235989b-672d-400e-9756-8a0093ba3ec4"), new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 88m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("4752116b-67d5-4991-b721-9eeb4ff11ed5"), new Guid("b7c1ebe8-6b29-4c1e-9f9a-7c4582c26334"), 15m, new Guid("c235989b-672d-400e-9756-8a0093ba3ec4"), new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 56m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e1a512d0-da61-4327-8fde-55d1c538fbb0"), new Guid("a2ebc5cb-98cb-4cfa-b25a-6da4b43f7b6c"), 15m, new Guid("7d9f7e58-14a2-4b85-93c5-4e2ae6d76b98"), new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 54m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("753bca16-1ec6-44a5-ac44-b6a9dd756827"), new Guid("1a8e2f82-81f2-4e28-8892-d2a6e716bc4b"), 15m, new Guid("5d97979f-9aa9-4fb9-b7f2-26b449d071fb"), new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 95m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("00644f9b-0aeb-432c-aeab-240c85c804e7"), new Guid("5ed971c9-80f3-4bbd-b732-37ed730d5f0a"), 15m, new Guid("f54bf440-c6c4-4eea-aa84-2cac307ca11e"), new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 23m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f378547e-55fe-49cb-bb4d-e6d9df34c3b6"), new Guid("459c5223-9a86-464b-a2ac-49d68217e5a5"), 15m, new Guid("5d97979f-9aa9-4fb9-b7f2-26b449d071fb"), new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 19m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("20d026d4-7ddf-4011-8c97-29eb323386a1"), new Guid("db9a6f01-1c0a-4421-ad65-f942b7716014"), 15m, new Guid("f8954afc-49a7-478c-8361-55330449ca58"), new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ed9ae018-a079-4207-b1ad-92e032258d99"), new Guid("043ed6fc-22d0-47d3-9207-58eba2cb4acf"), 15m, new Guid("f8954afc-49a7-478c-8361-55330449ca58"), new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 91m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f1f86ddd-8fc1-4d04-952e-e296a397824b"), new Guid("7b25e667-887d-4a9a-89ae-e837069c9ece"), 15m, new Guid("815c63d4-c21d-46af-8bcb-184a4347db91"), new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 51m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9a7ca88b-7787-40e2-9e81-f181ed8da508"), new Guid("5125abb7-0118-4022-a6e4-0995fb42f782"), 15m, new Guid("815c63d4-c21d-46af-8bcb-184a4347db91"), new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 42m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("62de98d6-b280-4f4b-9849-434118e91ebc"), new Guid("4be4f87a-58e2-49c0-8307-f8ad01307a17"), 15m, new Guid("815c63d4-c21d-46af-8bcb-184a4347db91"), new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 21m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f306d139-9e39-4dea-b700-86cf3ba87277"), new Guid("b46822db-4d7d-44fe-b437-d0a928add820"), 15m, new Guid("858ef013-3c26-4e2b-9243-37b720d63b9a"), new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 27m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e9e4efe6-292f-4f6a-88f3-4225170c3ecf"), new Guid("db9a6f01-1c0a-4421-ad65-f942b7716014"), 15m, new Guid("e18956a6-8193-4d6d-9a3a-f78252edefed"), new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 96m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("766f0031-8859-4b8a-bbfe-2b992c5c6ed4"), new Guid("8465fb50-d767-4a95-b668-aef923c3ee48"), 15m, new Guid("a74c1ade-f11e-48dc-a5a6-6e7697a21017"), new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 85m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("417f65b9-f940-4f88-8e33-c0590056d427"), new Guid("7597034d-072e-4dfe-bd61-f834d8725997"), 15m, new Guid("a74c1ade-f11e-48dc-a5a6-6e7697a21017"), new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 77m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("285a3c4f-215f-442b-b8df-9c9c58dbc44f"), new Guid("8dcd0617-05e5-4686-b941-c00377c9011d"), 15m, new Guid("a74c1ade-f11e-48dc-a5a6-6e7697a21017"), new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 73m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("24f60fd1-1226-45e9-bff1-4651dfd8d838"), new Guid("5cdbfec5-5fe0-4466-84f0-b9b8c24c4eb3"), 15m, new Guid("a74c1ade-f11e-48dc-a5a6-6e7697a21017"), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 59m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bd904b52-d862-4d5a-8da9-7b866bad4217"), new Guid("a31407a8-a081-43f3-9886-1141713bf16f"), 15m, new Guid("0b4811f3-6979-490b-beb0-b527c710fbe2"), new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 48m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6cccc1b4-dbbf-4dbf-80c4-66dbcfa03139"), new Guid("f3f6c77c-c132-4f67-84a6-9bda5465bc4a"), 15m, new Guid("bfc183f4-cd97-4388-b726-1c10b9fb215d"), new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 97m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f5ae43af-4dbc-4496-a6a7-ab5dc0fb5ad0"), new Guid("69054514-642a-47e2-8d84-51c3d344b54c"), 15m, new Guid("a746356a-6e4e-4795-b5bc-30ce05201cab"), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 99m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6f6a4b20-69c9-48a6-91c6-07a615e3999a"), new Guid("2a084908-248b-4e00-9c59-fed2c99e8274"), 15m, new Guid("26c490bc-ac0f-44d6-aee5-6067edbb7405"), new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("970c10b5-4acb-4dac-91d5-de1517c93e17"), new Guid("4a1d18c4-70b9-46b2-8bec-45585dce9896"), 15m, new Guid("aa5d3144-8baa-4fbe-985b-3cc5269df5f3"), new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("731b7d97-b2c8-43bb-8aeb-54964d1a5fe9"), new Guid("a31407a8-a081-43f3-9886-1141713bf16f"), 15m, new Guid("aa5d3144-8baa-4fbe-985b-3cc5269df5f3"), new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 26m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("03ad03da-16cd-4b1f-bab5-a32e80ced3db"), new Guid("15f76fc8-143c-4244-ab1c-24f50d504691"), 15m, new Guid("a17797cc-bde3-448e-a4c5-7d51ef42c0e5"), new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 94m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("4f1385ab-9b1c-4386-8d07-884b9e49bbce"), new Guid("45e3b0cf-fa90-46de-91e2-ea7b28039eff"), 15m, new Guid("a17797cc-bde3-448e-a4c5-7d51ef42c0e5"), new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 61m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("3f0e6a32-c4ce-4b5a-af55-782bedfafddf"), new Guid("3dfd747d-bd20-4aa6-bc18-a849f0722b99"), 15m, new Guid("a17797cc-bde3-448e-a4c5-7d51ef42c0e5"), new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0fa99f35-a24a-45cb-8af1-fd774d78bb93"), new Guid("782ac162-f21d-4242-b357-a1ad15ee5790"), 15m, new Guid("7a316b51-b1f1-4905-9128-c87a4ed53726"), new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 64m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("adf5b5f0-887c-424f-99f5-7760cf190a28"), new Guid("b5055002-c3f7-4742-ac19-3cc643f3f6d4"), 15m, new Guid("eac6ee96-767e-4996-973b-efd0ccfcb976"), new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 58m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bd6b9e0a-94b9-4000-8549-16ecd075266f"), new Guid("8465fb50-d767-4a95-b668-aef923c3ee48"), 15m, new Guid("eac6ee96-767e-4996-973b-efd0ccfcb976"), new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("30fbef4e-9263-4f87-8997-fe64537b28ed"), new Guid("5c68e392-e50f-45ec-9d26-9ff9086515be"), 15m, new Guid("f8954afc-49a7-478c-8361-55330449ca58"), new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("eb5e21d9-4e1c-470d-b52e-394435a63774"), new Guid("f0074d7f-b90b-4858-a55b-22e893d40806"), 15m, new Guid("2840484a-697e-42ff-bbd0-856a5647d148"), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 71m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("fce99acb-7805-4c34-9f5a-aa4c27c31726"), new Guid("4dd93ddb-1dfd-4c86-943d-6e109d8130eb"), 15m, new Guid("2840484a-697e-42ff-bbd0-856a5647d148"), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 49m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b4f430f6-99de-41f7-9fad-bb78a048a546"), new Guid("01ab62f1-b21a-41b7-879f-977264b081f9"), 15m, new Guid("2840484a-697e-42ff-bbd0-856a5647d148"), new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 20m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6d9b1ded-f49d-4dd8-9cef-dd1742ff3345"), new Guid("c61e8277-a446-4644-a4ac-a6a4342b222d"), 15m, new Guid("8ef92b86-0661-4deb-b3f7-989c490af32e"), new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 66m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bf27a661-70ac-4bcf-b52d-3ed397713bf6"), new Guid("240b544b-ad54-48f0-a42b-979c7fc3c23c"), 15m, new Guid("8ef92b86-0661-4deb-b3f7-989c490af32e"), new DateTime(2020, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 52m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("34125d64-1066-47b7-902b-20824641c894"), new Guid("82e03e18-4e88-48a8-afa0-385c48ce817d"), 15m, new Guid("8ef92b86-0661-4deb-b3f7-989c490af32e"), new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 16m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bb15400a-25fe-4013-904f-b5aa6199a28e"), new Guid("b0882f81-2b67-43b3-bb20-8577d28069c3"), 15m, new Guid("3ac037b9-b5ab-4e92-8088-b22066a965ac"), new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 53m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1c570a0d-ba08-49a7-b6dc-5d57667f629f"), new Guid("a2ebc5cb-98cb-4cfa-b25a-6da4b43f7b6c"), 15m, new Guid("3ac037b9-b5ab-4e92-8088-b22066a965ac"), new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 46m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0019936e-c468-4f5c-ba03-43f7cf4af90b"), new Guid("0e8f8566-fc15-4428-8eda-1c0961732e49"), 15m, new Guid("04678e00-af6a-49d3-8d84-0c65c85b0a61"), new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("763fc559-d417-4839-aec8-8b2e0e7cdb6d"), new Guid("65c553ab-8428-477f-b628-cba718c4a014"), 15m, new Guid("501bf077-8df0-48be-a58b-ed2ac3efc7a4"), new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 43m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("05808bd5-d8a9-4eaf-96c0-97cd161a21a8"), new Guid("b8fdd0e5-d927-4b0f-94cd-9fae6ea0ed96"), 15m, new Guid("688a8a87-b41d-48af-917b-022e656c448f"), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("699b9830-4d47-46c4-8260-64120998d9fc"), new Guid("ad13dcfd-e754-4032-a78b-2afc5cbd9f85"), 15m, new Guid("ef6f985d-565d-4a10-8acb-bc994d83cdd9"), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("fae1e45c-a1e0-4bbb-b3bb-b87612fb3d78"), new Guid("432de4d6-ce24-4851-8b33-6b00863e463e"), 15m, new Guid("ef6f985d-565d-4a10-8acb-bc994d83cdd9"), new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 39m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f8c73bac-3ab6-490e-b693-ae5c4f1cb452"), new Guid("35050e65-4e5b-43f0-af37-a54f3bb53b5d"), 15m, new Guid("cf3166f4-055e-4e59-b1b3-bcd01e889a5c"), new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 84m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0ff5a5fa-c7b7-4663-95ee-25a77bf52a50"), new Guid("3623e1aa-4a76-49a9-8b8e-1b680087989e"), 15m, new Guid("88190953-45e5-4285-bf54-ec43ba87f2bc"), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 68m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1a7a1ac7-f47c-4b46-948e-1d4c3227aa11"), new Guid("9b89a721-caa7-4584-97c6-4b221421e287"), 15m, new Guid("88190953-45e5-4285-bf54-ec43ba87f2bc"), new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 37m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bf6fdd50-213c-49f2-bb61-84a98e15f920"), new Guid("e8e64597-2629-4921-b2ca-c8ed6bd2b908"), 15m, new Guid("88190953-45e5-4285-bf54-ec43ba87f2bc"), new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 31m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1e1a6054-a221-4292-a8ae-d0dc9b6f42c4"), new Guid("3852760a-7230-49fd-92be-67cadfa7c866"), 15m, new Guid("318e742c-6bc7-42c1-ae25-74c33b4d80fc"), new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 83m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("65f05cfb-305d-4827-aab8-9b4f8d5ecfc5"), new Guid("4be4f87a-58e2-49c0-8307-f8ad01307a17"), 15m, new Guid("7d8cbcb8-2714-43f6-ab5e-aa3178a7e2c9"), new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f37e6e63-5422-4310-93d3-60723f8bff3e"), new Guid("0ec6fe8f-dab3-4c67-9a2f-40b4ca75a7e4"), 15m, new Guid("b7667ffd-4e93-457b-a077-16c4279834d1"), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 87m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8be4a60d-2262-488b-b55f-af53dc3b5258"), new Guid("330152c9-f5de-4ede-8a1c-5a8740158071"), 15m, new Guid("b7667ffd-4e93-457b-a077-16c4279834d1"), new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 74m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("504b78c0-2888-47b1-b6fa-8e035100e65f"), new Guid("833ca613-a8d9-482e-a9bb-45eb4805f4dd"), 15m, new Guid("2cb91aae-08ea-42b0-8415-020e6208b70b"), new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 92m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2adc6350-ee1a-4b5a-962d-d388a617c7ca"), new Guid("f0074d7f-b90b-4858-a55b-22e893d40806"), 15m, new Guid("2cb91aae-08ea-42b0-8415-020e6208b70b"), new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 17m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("76192aa5-1ec6-4257-ba20-7daf0549853c"), new Guid("3dfd747d-bd20-4aa6-bc18-a849f0722b99"), 15m, new Guid("1dca49cb-0ffc-480b-ba48-da8028c0bc6e"), new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 72m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2f47150f-14a0-49f7-8427-4479193818b1"), new Guid("b3bb8d43-4260-4ede-af3a-e6f95be6cfb5"), 15m, new Guid("8ef92b86-0661-4deb-b3f7-989c490af32e"), new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9b5937cc-8c4f-4e66-8ef1-7371c82adc14"), new Guid("782ac162-f21d-4242-b357-a1ad15ee5790"), 15m, new Guid("f3f0f14c-e179-484c-b39f-b09361e0532f"), new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6336f485-8d25-409f-b607-e834b7b5b992"), new Guid("709afd1a-8393-4de4-8ef3-c9a334dd14ef"), 15m, new Guid("0e92d195-7a77-477d-b6a5-8a2b63eb8f0c"), new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("774fd37c-e0b3-4f06-8705-85f741afdfc3"), new Guid("c8f59991-59cd-493c-a108-223bb78edb7d"), 15m, new Guid("0e92d195-7a77-477d-b6a5-8a2b63eb8f0c"), new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("67b6649a-f953-46d0-9220-162e13847bf7"), new Guid("f3f6c77c-c132-4f67-84a6-9bda5465bc4a"), 15m, new Guid("2840484a-697e-42ff-bbd0-856a5647d148"), new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 14m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8b22034e-68d5-4f38-9568-268032127c1f"), new Guid("52f79584-8d03-4c26-8208-91891b6ba1ce"), 15m, new Guid("60d505b4-eb4a-4b83-ab4f-9017ecc96510"), new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 93m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("fcb7790a-a432-4ef0-bda0-f01adff8c82a"), new Guid("15f76fc8-143c-4244-ab1c-24f50d504691"), 15m, new Guid("60d505b4-eb4a-4b83-ab4f-9017ecc96510"), new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a23d7f36-241d-4d98-badd-ac1d65285bc8"), new Guid("2a084908-248b-4e00-9c59-fed2c99e8274"), 15m, new Guid("60d505b4-eb4a-4b83-ab4f-9017ecc96510"), new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 28m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("20f04506-7539-4d93-bceb-647d4ca63742"), new Guid("1def40c3-3647-4e9a-bfa9-79f08f11ac88"), 15m, new Guid("2ec4a35d-1c1b-4536-bbe9-2d510f232b1d"), new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 33m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("17ef9b90-d6d2-4408-8fb4-f9d4217f477c"), new Guid("b8fdd0e5-d927-4b0f-94cd-9fae6ea0ed96"), 15m, new Guid("888b2ee3-58a2-4ee9-b1d7-25274eb1734c"), new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 35m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("c0c0472a-6160-4f09-ac17-96faa425ea5e"), new Guid("e8273be7-3db6-45c2-b159-f8f111bd4bd9"), 15m, new Guid("b20c0a23-6134-4440-908f-62b0482e0119"), new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5febabba-c04f-4eb1-bc1f-7277b01db29d"), new Guid("15f76fc8-143c-4244-ab1c-24f50d504691"), 15m, new Guid("5d46a9f9-e244-47be-b6f6-ed80b38e71d3"), new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 24m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("76d75df5-fc82-4239-808b-88e6adcabc45"), new Guid("ad13dcfd-e754-4032-a78b-2afc5cbd9f85"), 15m, new Guid("5650118f-d2aa-4893-bba9-a19c50a69994"), new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 44m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("689ef69e-f6b4-45bd-adb4-f577245f673e"), new Guid("15f76fc8-143c-4244-ab1c-24f50d504691"), 15m, new Guid("2761ae3e-7ef5-4941-a6c6-e31660e740b7"), new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bd9adb1b-195f-4187-8eff-f581621e6ac9"), new Guid("e5ab61e1-2ae6-47c4-b36b-fee1987fea07"), 15m, new Guid("2b3a7862-c8fc-401a-b7d3-0ae344c10ccb"), new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6c1dc0fd-d842-480f-ac25-316e8da3b49f"), new Guid("432de4d6-ce24-4851-8b33-6b00863e463e"), 15m, new Guid("2761ae3e-7ef5-4941-a6c6-e31660e740b7"), new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 34m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7794f7bc-13b3-4c9a-8dd8-d40b6ffa272e"), new Guid("833ca613-a8d9-482e-a9bb-45eb4805f4dd"), 15m, new Guid("4d80ed53-dad5-4861-a9d7-5080fd6aa377"), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1589d4ce-0b86-4889-b5bf-6837ea2478d9"), new Guid("32bac29e-b649-4f88-b4e5-30f99d6cd80d"), 15m, new Guid("b3d23b0b-dc67-4fca-8127-39734c4c02b6"), new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9fa56b65-fd4d-4c85-84a7-ba2c0c5a361f"), new Guid("ad13dcfd-e754-4032-a78b-2afc5cbd9f85"), 15m, new Guid("4100d829-6736-47d3-9671-26a8a6ea239e"), new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 98m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("1edbd85f-740d-4b0b-a617-f9a8ea2b7bae"), new Guid("729cb4f0-a9e2-4576-a476-f06f1441ff1d"), 15m, new Guid("4100d829-6736-47d3-9671-26a8a6ea239e"), new DateTime(2020, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 86m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("9db02955-a306-4ea0-90ee-f6726cd5805e"), new Guid("82e03e18-4e88-48a8-afa0-385c48ce817d"), 15m, new Guid("4100d829-6736-47d3-9671-26a8a6ea239e"), new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("67ccdf86-74e4-4687-8e67-1ce59012c040"), new Guid("e0264a14-4e41-475d-8b21-20e950ccab0b"), 15m, new Guid("c61978a3-207d-4ac1-aa39-921cba89c62b"), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 79m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("390dbb59-6ca2-4748-ba91-3dbcb4e54c0c"), new Guid("709afd1a-8393-4de4-8ef3-c9a334dd14ef"), 15m, new Guid("c61978a3-207d-4ac1-aa39-921cba89c62b"), new DateTime(2020, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 57m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5eef8210-aecd-4ed5-abaa-8947227b7af4"), new Guid("6567c22d-8a03-466b-8700-f679a0e0393d"), 15m, new Guid("c61978a3-207d-4ac1-aa39-921cba89c62b"), new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 41m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b40edef7-1367-4ac8-859f-cc0ddf595e98"), new Guid("8dcd0617-05e5-4686-b941-c00377c9011d"), 15m, new Guid("c61978a3-207d-4ac1-aa39-921cba89c62b"), new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 18m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("20b28901-ecab-48a7-a5bd-dfd6956230b7"), new Guid("043ed6fc-22d0-47d3-9207-58eba2cb4acf"), 15m, new Guid("0e92d195-7a77-477d-b6a5-8a2b63eb8f0c"), new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 63m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8e79f9bb-af5e-4aff-a36e-76c9e2af6113"), new Guid("0ec6fe8f-dab3-4c67-9a2f-40b4ca75a7e4"), 15m, new Guid("089acea1-311c-4a6b-acd4-2d106e1f0103"), new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 62m, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("45f04d74-e31c-4235-8d11-3a0aec30d83a"), new Guid("a15aaad2-fcec-4c8f-88c3-54274080355f"), 15m, new Guid("2b3a7862-c8fc-401a-b7d3-0ae344c10ccb"), new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 13m, 1 });

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
