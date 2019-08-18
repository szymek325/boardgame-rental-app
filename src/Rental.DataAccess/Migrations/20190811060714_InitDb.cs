using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "r");

            migrationBuilder.CreateTable(
                "BoardGames",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Name = table.Column<string>(),
                    Price = table.Column<float>(),
                    CreationTime = table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2019, 8, 11, 6, 7, 13, 727, DateTimeKind.Utc).AddTicks(8863))
                },
                constraints: table => { table.PrimaryKey("PK_BoardGames", x => x.Id); });

            migrationBuilder.CreateTable(
                "Clients",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    FirstName = table.Column<string>(),
                    LastName = table.Column<string>(),
                    ContactNumber = table.Column<string>(),
                    EmailAddress = table.Column<string>(),
                    CreationTime = table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2019, 8, 11, 6, 7, 13, 733, DateTimeKind.Utc).AddTicks(8225))
                },
                constraints: table => { table.PrimaryKey("PK_Clients", x => x.Id); });

            migrationBuilder.CreateTable(
                "GameRentals",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    ClientId = table.Column<Guid>(),
                    BoardGameId = table.Column<Guid>(),
                    ChargedDeposit = table.Column<float>(),
                    PaidMoney = table.Column<float>(),
                    CreationTime = table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2019, 8, 11, 6, 7, 13, 733, DateTimeKind.Utc).AddTicks(2484)),
                    FinishTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRentals", x => x.Id);
                    table.ForeignKey(
                        "FK_GameRentals_BoardGames_BoardGameId",
                        x => x.BoardGameId,
                        principalSchema: "r",
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_GameRentals_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "r",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f776435f-52ba-45d7-8f77-450695189488"),
                    new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 182f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("85e5d3c3-885c-46f2-8c0a-30e47cabb70e"),
                    new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 184f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("d9bac877-3e42-47b7-ac09-23338bf7b128"),
                    new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 169f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("531c2a70-6513-4816-a347-1843e500c5b2"),
                    new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 155f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("91bceaa8-fbf9-4b41-81fd-c25a526dc3a5"),
                    new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 92f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("fdf3433a-10fa-49b2-bb29-d4878252414f"),
                    new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 185f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("cd43b8db-af67-45dc-8bed-ce1dc3d91782"),
                    new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 168f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b960d38e-6423-4dfd-8f02-141113b9aa07"),
                    new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 144f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("73a4be53-0021-4ece-bffd-28db8ec01bf9"),
                    new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 156f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("134ff0d9-1f2c-494e-a6b6-09c353f0c01f"),
                    new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 186f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f40379aa-8f9a-496c-aff5-af3bf60ca884"),
                    new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 230f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a41827d0-7636-49e2-8080-5d00d35b1206"),
                    new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 58f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b59fcbc9-c344-48e0-ac72-6bc55065cd12"),
                    new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 245f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b0c8d5ba-3882-4c20-ae2d-7bead2d25d39"),
                    new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 245f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("109e83cf-8e8b-4bab-bfe2-1d13cf8e7ed6"),
                    new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 186f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("56a72c55-947c-4b17-bada-d2deb7cf7a1c"),
                    new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 70f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("4f22ce42-ee2a-4d35-9355-0f55d83a29db"),
                    new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1bbbeb14-21cb-443d-9e5e-b83ac0c7598f"),
                    new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 135f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("d7aac946-9a59-4c00-a6be-1e2b99037b31"),
                    new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 66f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("8feb0198-5669-4cc7-94a4-350f3fec4da7"),
                    new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 151f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("47c34665-8033-45f5-9017-a9c8d7601ddc"),
                    new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 157f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("bf2a4d27-a28b-4f5d-a9b8-27d086f10f55"),
                    new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 93f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("c175e2ac-e542-4fd9-a01d-74506adc9a6b"),
                    new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 86f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("82370fd7-c528-4215-b2ff-5ad3d75cdbe7"),
                    new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 130f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("40053388-1ec1-4853-bc62-6115cf13513e"),
                    new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 79f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e4682c9e-b589-401f-97c1-afdffe4fccd2"),
                    new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 143f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e9673244-1bd0-4c0c-9866-b38f509c5856"),
                    new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 69f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("851d0083-5e1e-447e-99fd-ce6b8c2f0fe3"),
                    new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 92f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("3d1bcdc5-36c6-4ebc-a455-9b01a6abfd60"),
                    new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 103f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("bc0f87f0-549c-431e-b938-f13dcb35a9b9"),
                    new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 196f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("65294eea-73fa-4964-82bb-220ed628bf76"),
                    new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 198f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("4b942334-2bdc-48a9-a049-598e75b2a75a"),
                    new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 137f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("021b95cb-e28b-4d2c-ae1d-8c70b25436aa"),
                    new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 108f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ebf0351e-a427-483d-8224-b358095ee755"),
                    new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 105f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("be3f33fc-87fb-4b11-86f8-cade16ac2881"),
                    new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 129f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("64b65da1-3403-40ae-b72f-209998e64d4c"),
                    new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 180f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("fd10b04b-e87a-4f24-9490-459aa3974fd9"),
                    new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 98f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("2dbc8ca3-e85f-4ef9-a5f8-b9a521b37353"),
                    new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 242f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e964b20f-5847-452f-8ae0-143b56e9c5f9"),
                    new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 104f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("6dc2ed53-ad97-4832-87d6-4007b3451eb3"),
                    new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 96f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("960a7013-b318-4098-b398-642e7938c079"),
                    new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 109f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("64877867-7dd1-4981-b210-1b6273ba6f0a"),
                    new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 65f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("306728c7-4615-4383-9bb4-a057f6446587"),
                    new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 210f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b4ff55ab-bb48-44aa-a117-49bf811064be"),
                    new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 209f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f8523918-5f92-40d5-ac8c-52272274a77b"),
                    new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 235f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7ecbf069-3fea-4e80-b0df-b091ba76585d"),
                    new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 186f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("dbb975cd-e418-4bc5-877a-affb8174b6f4"),
                    new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 170f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("d7a14f1c-3376-4052-83fa-891749cc1557"),
                    new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 123f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("161a053a-bf76-4b32-a574-d0133bf9bb81"),
                    new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 84f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("dd3d3ccb-d098-4665-acf7-ae2298a4cd18"),
                    new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 89f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("8f110aff-b801-44c3-b87a-0d2c4869404e"),
                    new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 52f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("adfa8356-bcf4-4d01-81ca-27cc7e9af247"),
                    new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 87f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("00462b00-90ee-48bc-8af4-c2e6912c765c"),
                    new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 165f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("36221789-a567-4e05-9cfd-befa1c89f220"),
                    new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 141f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("03ad766a-4570-42aa-ae4d-6b73af391527"),
                    new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 72f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("8a313dc1-5a02-4e8a-b377-a299768f98b6"),
                    new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 230f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("3821dbfe-3188-4abe-a8f5-38d60cac2228"),
                    new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 207f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("874a2e82-91e2-4801-af16-b22aa9ef9c38"),
                    new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 248f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("11efb3b0-fc49-414b-945b-cdcbe0a86da8"),
                    new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 154f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f3d8fba1-5679-4fb6-8d4d-f0c05ac7a6af"),
                    new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 57f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("0d168485-3d1e-44d0-be49-35550ea47814"),
                    new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 62f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("fc0fcf5f-cb25-4649-b533-60f6eb3f5909"),
                    new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 85f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7300b8ad-2f2c-4005-8384-97883109ba7a"),
                    new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 54f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("6ead2c39-74f9-4603-959d-2501712f6f69"),
                    new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 81f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f381144e-1ad6-4e2a-b0dc-326a6f79b4c7"),
                    new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 129f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("bf42a1e6-4d8b-4d2b-8531-e9d394340278"),
                    new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 141f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e5ae84a2-605e-431d-bb17-523324192bd9"),
                    new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 243f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("341fe361-49cf-4720-85d8-36087bd36e79"),
                    new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 106f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("4cd8864d-da8c-447c-b92f-f8523b1a47f2"),
                    new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 198f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a184ecda-ded7-4b3f-a083-8f8360114d18"),
                    new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 198f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("47ff77a6-a27d-4387-9880-0f281dd49d4d"),
                    new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 222f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1b7f60df-2e75-488e-b0e8-f3ef8d113903"),
                    new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 164f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("4e4e18ac-df41-422e-9753-b0d7a6c57042"),
                    new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 118f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("6ee097bc-cef5-4c38-9a41-63d0e2977486"),
                    new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 79f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("9e41cfa2-b903-475c-834a-46c5c6c38665"),
                    new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 79f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7ece71b5-8760-4f5c-bd9e-6e69844c8416"),
                    new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 133f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("6f9201df-99d6-468f-81fc-be59ee4f9286"),
                    new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 62f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f74c472b-139e-4bbd-9c7c-aa1c7fb6cee3"),
                    new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 177f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("6194ed35-1684-4177-8684-af80b1c4aa46"),
                    new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 76f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("fa21672b-860e-4c24-986b-98549f6ddd87"),
                    new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 241f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e6da9750-8490-453d-9f0e-4591f12a8cf2"),
                    new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 158f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("193398ed-8bc8-473c-ade2-a9d6eb19d2be"),
                    new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 205f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a4a7b644-6025-4845-9178-bcb807c867fa"),
                    new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 72f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b9ba7b67-8923-455a-b022-915bd61a7481"),
                    new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 112f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("d5ebd11b-4165-4f60-ac26-62523ee211ce"),
                    new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7d54a858-6932-45cb-9b3f-2bd707ddec8e"),
                    new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 73f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("bc02e975-11f1-47bd-b82c-7e2d21ebf5e3"),
                    new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 129f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("09622a47-32c8-4225-a73e-61009efb5d03"),
                    new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 248f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("443b9b36-19bc-4027-b160-5ff9dd9e7a39"),
                    new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 192f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("93b29ce1-56f6-40bd-baed-ac2deef833e4"),
                    new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 152f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("6ec0213e-f8bc-4b79-9864-372007818bb1"),
                    new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 214f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a5f39d3a-b716-4cd2-bd10-00dd3a995b65"),
                    new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 248f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("8e07df45-ba33-4526-bd07-458cf282308e"),
                    new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 133f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("d9f931f7-31e8-490a-97e7-7bc54b6a9363"),
                    new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 148f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("105601c3-3468-4ef7-a393-6cf6668cecbb"),
                    new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 145f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("2c80dd98-649f-4ca2-98df-7513481d8d26"),
                    new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 111f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("dbd38fbf-0583-4d48-b81e-f3bdcbf60f4c"),
                    new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 191f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1c1cb5b7-362a-4278-9eb8-752c1ed7e202"),
                    new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 144f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f162ad17-7f88-465b-ac3b-dda3a0a34e60"),
                    new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 197f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7e0d89d8-ed3e-4772-974b-ca9e0b553e68"),
                    new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 147f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("1510533e-6e1e-40a6-98cf-9bce52e5842b"), "(780)520-7462 x0605",
                    new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "nya_okuneva@smithklein.us",
                    "Pearline", "Daugherty"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("ffac5957-2e3c-4e80-915f-4ae4395987e5"), "(556)272-8817",
                    new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "terrill@collins.ca", "Rocky",
                    "DuBuque"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("fae389ba-9dff-496e-963b-e3caec311b7a"), "104-814-0062 x5001",
                    new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "hipolito_russel@runolfsdottirhoppe.co.uk", "Elton", "Gleason"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("122e3b29-6775-48e0-83a9-19e4bac28d8d"), "642.178.2322 x6578",
                    new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "garth_becker@waters.us",
                    "Hilton", "Pfeffer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("384da756-3670-4f70-a68c-8816afc3cc15"), "867.377.1712 x7001",
                    new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "cecilia@hills.biz", "Ana",
                    "McClure"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("303f2e9f-7f19-411b-b013-93479615743a"), "(523)277-8137",
                    new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "jaylan@schultzconsidine.us",
                    "Alice", "Pfannerstill"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5ebdbfe4-39b5-4ebf-824f-ed73bef73722"), "1-270-756-2773 x43715",
                    new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "myra_miller@parker.info", "Gust",
                    "Goyette"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("c921e6d3-6389-4904-9f92-cb68331061a0"), "056-332-5318",
                    new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "elisabeth.luettgen@wisoky.co.uk",
                    "Rickey", "Gislason"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("f2efa964-4c8b-40a2-b1b3-d0583c6f09d2"), "1-275-872-2001 x4737",
                    new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "wilfred@lowe.name", "Jonathon",
                    "Weissnat"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("bf645981-14e9-4c51-98f8-73bf736075f9"), "(603)880-3732",
                    new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "catalina_watsica@anderson.uk",
                    "Marta", "Bechtelar"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("13c4dd80-59e4-4511-b2cb-48a0fd2027e8"), "(176)837-4033 x588",
                    new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "loraine@bins.name", "Ruthe",
                    "Welch"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("4430c8d1-dd2c-4d4e-9266-bf5976bbf9f2"), "1-412-614-2474 x25705",
                    new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jordy_wilkinson@weimann.biz",
                    "George", "Collier"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6ef135d7-f058-48da-9dfe-d76f34525cad"), "885-643-7817",
                    new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "taya@pacocha.ca", "Richie",
                    "Labadie"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("af48b2e5-743e-43ec-8d1e-fb8f35812f58"), "1-570-244-7372",
                    new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "napoleon_reynolds@cole.ca",
                    "Gregorio", "Herzog"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7249191d-78f4-4f40-8fc8-fea9174d392d"), "(028)377-6688",
                    new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaylee_fisher@moen.info",
                    "Manley", "Schuster"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("93ce18e1-3cc9-4acf-8504-716c7391ccb9"), "(850)780-4044 x1084",
                    new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "madison@greenfelder.info",
                    "Dejon", "Gusikowski"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("eab11ea0-6b92-43c6-9a7d-1d3fc4a54ac5"), "(815)418-0853 x728",
                    new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "hector_hilpert@weissnat.info",
                    "Preston", "Cronin"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6c63fc1d-f9a3-4b23-8d84-8e21b540afa2"), "307-581-2502 x57202",
                    new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "zetta_stanton@schowalterhammes.ca", "Samara", "Hoppe"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("62c3abc4-a3b5-4827-bada-176d00618701"), "346.468.4688 x66134",
                    new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "casandra.hand@haagwatsica.us",
                    "Dorian", "Schmitt"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5445933e-85e4-4ea2-9b2b-d95cf83c063c"), "1-547-230-0728",
                    new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "kristy.wisozk@boyer.ca", "Kiley",
                    "Kemmer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("06512c71-41d1-4a11-aff3-547ca5fbedd0"), "650-581-0484",
                    new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "carley@gleason.ca", "Oceane",
                    "Effertz"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("9d745909-664a-4a2f-88ee-922d59a18236"), "808-752-6567 x67500",
                    new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "chloe@mcculloughstark.co.uk",
                    "Isobel", "Hoppe"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a7e40221-f703-4d06-bb81-6c27afdce27b"), "706.073.5445 x1157",
                    new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "jadyn.marquardt@rosenbaum.info",
                    "Roselyn", "Frami"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("54548b85-e4f0-4088-a31d-9916d1c1a7db"), "1-551-666-5226 x041",
                    new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "madie_larkin@larkin.co.uk",
                    "Josie", "Stroman"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7f4bb0d1-4287-4e11-9744-32e336049a76"), "247-387-4603 x5586",
                    new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sage@altenwerth.info", "Moses",
                    "Halvorson"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("9bb9a8d0-9559-403c-99a3-6dcc4f01590b"), "(606)541-7551",
                    new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "everett_emmerich@lemke.biz",
                    "Carmelo", "Von"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("97724559-aff2-4bd5-90ef-09fd62b7597b"), "435.666.8488 x7401",
                    new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "raegan_corwin@keeling.info",
                    "Jedidiah", "Schultz"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("fb0b2ba7-b09c-4980-9d76-91ce53bc544b"), "418.334.8840",
                    new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "audie@gerhold.name", "Andy",
                    "Buckridge"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("e668ac7f-b51d-4ad0-b5e6-c3ba49debcc4"), "085.538.5708",
                    new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "marilyne.kirlin@smitham.com",
                    "Kurt", "Cassin"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("84abdaca-da09-4aed-abfe-4eed66826102"), "(647)632-3543",
                    new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "francesca@schmelerpollich.co.uk",
                    "Cody", "Hartmann"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5109c947-4203-4ddd-abbb-9c50226effe3"), "724-207-4486 x3747",
                    new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "nicole@bosco.com", "Liam",
                    "Treutel"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("57d1b103-5274-4d8b-879b-c0889875ff4d"), "512-616-2803 x5785",
                    new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "frankie_runolfsson@mante.co.uk",
                    "Jan", "Thiel"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("2f327e5c-00b2-4c1e-8bb8-107b575ec94c"), "1-402-810-1127",
                    new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "eliseo@parker.ca", "Fred", "Lesch"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("472f9a86-50a0-43cd-96df-5e72cedf31ed"), "1-843-062-5317 x660",
                    new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "cyril@rosenbaum.name", "Mable",
                    "DuBuque"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("486bf75f-5719-4b67-9fe6-9a5d5bed5890"), "1-277-227-2648 x780",
                    new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "davion@lowe.biz", "Verner",
                    "Ullrich"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("307fd51a-e9f9-4614-9250-30402bb092d6"), "751-535-3383 x104",
                    new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "dallas@moenlarson.name",
                    "Modesto", "Beatty"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("206f9163-486e-46a8-8d19-b41057c27152"), "325.162.8803 x45568",
                    new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "beverly_bergstrom@feest.com",
                    "Janice", "Russel"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("e231eb38-0186-48ea-b569-33995acadfb2"), "(126)862-1766 x00230",
                    new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "antonietta@spinkaheathcote.com",
                    "Holden", "Koss"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("74ccc071-6dbd-445d-b83a-d3ed50d76012"), "460-354-5786 x7401",
                    new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "boris.greenholt@smitham.name",
                    "Lourdes", "Jones"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("abcc8367-1ed5-45fb-a690-858dfd67c97e"), "424.037.7618 x368",
                    new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "abner@wiegand.ca", "Elda",
                    "Turner"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("25b1af46-4282-4da8-a48a-e67bd3b959d0"), "224.165.5321",
                    new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bernardo@kohler.name", "Brook",
                    "Larson"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("97694fd3-b46b-4958-8447-67bcf7e1f419"), "(340)634-1463 x81801",
                    new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "mittie_cole@thompsonabernathy.info", "Samanta", "Ritchie"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5b58b32e-f48c-40af-82c7-29c2bf3ba024"), "(553)758-7402",
                    new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "maida.lakin@cummings.ca", "Hoyt",
                    "Hamill"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("98947815-61fa-4a17-a267-b8c9c17414e9"), "341-561-5203 x3006",
                    new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaylee@kovacek.com", "Darrick",
                    "Kertzmann"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6bc4008a-616a-41d7-86d6-fb8f4b002226"), "121-821-6812",
                    new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "jermey@volkman.biz", "Ivah",
                    "Streich"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("1f2e5aa0-04b7-4fd7-b346-0936f911f8bd"), "(863)784-0703 x348",
                    new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "carroll@lebsack.info", "Scottie",
                    "Crona"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5f832539-20f2-492d-b7d8-732d53dc596a"), "1-383-734-2721 x225",
                    new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "vesta_mohr@haley.uk", "Lorenz",
                    "Koelpin"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("cb88d6c8-1944-4ba6-89ab-d7c81c6fb5e3"), "827-520-7586 x23188",
                    new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "gianni.hermann@bailey.co.uk",
                    "Shad", "Heller"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("e72eda1b-127c-4be5-93ad-b7dd3b8d0653"), "670-164-6527 x20217",
                    new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "kasandra@lindgrenbins.uk",
                    "Lisette", "Keeling"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("239622b3-9641-4a66-97cb-628395f926b8"), "555-384-6811 x03312",
                    new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "kari.lang@murray.co.uk", "Keshaun",
                    "Lang"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8dac56da-1365-4b50-8d81-98d2113df192"), "1-248-882-5762",
                    new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "rachel_dooley@heathcotedonnelly.ca", "Maryam", "Larson"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("310a1e8a-63c8-4faf-97e1-10a754eb3bb1"), "370.678.7108 x41760",
                    new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ines_murphy@considine.name",
                    "Maverick", "Kemmer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7e07a52d-1b87-405e-bbb9-7fc33664761c"), "184-186-2711",
                    new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "bessie@douglas.biz", "Lolita",
                    "Spencer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("21d586b7-3d4b-41b0-ae21-ef7af98c19f0"), "342.832.7175 x75453",
                    new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "amina@bernier.info", "Aliza",
                    "Kuvalis"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("e6c1252b-d4a2-4f9e-a29d-0f752c1a5140"), "(853)160-4570",
                    new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "marco.kozey@abshire.co.uk",
                    "Tierra", "Reinger"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("42db85a7-0b50-45b3-8bcb-160a357d9b7c"), "254.841.6143 x4887",
                    new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "zoila@wizawolf.us", "Robb",
                    "Watsica"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("e36a4b3c-42fc-46e4-bbb6-1ca40fefd3a5"), "(603)868-1447 x1828",
                    new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "cristian@kilback.co.uk", "Freddy",
                    "Prosacco"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("d5eed847-8bd7-4c88-af34-6e0f7491f055"), "1-410-183-7785 x44106",
                    new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "quentin@mante.com", "Ashleigh",
                    "Eichmann"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7d54f999-a097-4d0b-8ff6-134d646d07f6"), "(225)675-1203 x4622",
                    new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "lavern.bergnaum@bartoletti.co.uk",
                    "Elisha", "Bartoletti"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("bf613030-0739-425b-b583-0b5c12426a11"), "841-711-8676 x7316",
                    new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "lowell@gerholdwisozk.co.uk",
                    "Boris", "Ankunding"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("ebd89e66-5613-4e72-b63f-8fe177ee873d"), "751.315.6456 x4858",
                    new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "camylle.doyle@howe.us", "Kyra",
                    "D'Amore"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("d232b3a2-28aa-47d6-ae77-d07643061450"), "1-860-462-0722 x111",
                    new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassie.veum@hackett.info",
                    "Pasquale", "Muller"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("d1f5408d-68d0-4b8e-b984-4832f565834f"), "510.158.1241",
                    new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "destin_feil@bernierlittle.info",
                    "Judy", "Buckridge"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("d4a2be61-09eb-4dc2-8043-f4cbd97e46fc"), "623-551-0425 x8266",
                    new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "monroe@rau.uk", "Doug", "Barrows"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("92b4cd79-e57a-417b-bcbc-ff3149c7f23f"), "472.427.1153 x024",
                    new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "janet@mckenzie.info", "Adaline",
                    "West"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("c7202156-faac-4ca8-ad62-3f39b481e9a3"), "524-474-8485 x75364",
                    new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "mallory@okuneva.co.uk", "Dewayne",
                    "Altenwerth"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("40f06a83-83dd-46a1-b380-2e8e0d0bacf5"), "600-871-3658",
                    new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "garland@mayert.uk", "Heaven",
                    "Waelchi"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("132066eb-77b8-400e-93e2-66f9b8409345"), "276.570.6856 x73654",
                    new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "cara_block@hane.com", "Lizzie",
                    "Doyle"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("db5659cf-746a-4fdd-93ed-26612156dcf4"), "265-677-1006 x6486",
                    new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "aileen_breitenberg@rodriguez.ca",
                    "Adonis", "Skiles"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("f0e7cb03-6acb-4b25-8177-5b460713287e"), "(720)504-3201 x4687",
                    new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "theodore@weimann.info", "Adrain",
                    "Wuckert"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("24a9ce44-2534-4c54-9d53-b40319a575d9"), "053-216-2044 x2770",
                    new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "bryon@mante.ca", "Kellen",
                    "Abbott"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("1ac8af88-3fdd-4d82-8139-1a479d98dee5"), "1-473-315-8720 x066",
                    new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "darrion@gottlieb.ca", "Makenzie",
                    "Murazik"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("b2bd44b1-3e65-4266-a146-d6546c388711"), "1-117-522-3533",
                    new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "darrin@gibsoncassin.ca", "Geo",
                    "Heidenreich"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8a6bdf05-cc7d-4e58-94f6-eef1d5f59743"), "(863)838-8027 x0763",
                    new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "marlon_hermiston@nikolausfranecki.info", "Christopher", "Von"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("13d5f28d-345e-470b-b5b2-7886f9e5d523"), "1-511-305-2063 x3713",
                    new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "gage.blanda@hettinger.name",
                    "Carissa", "Gorczany"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("83f54ed1-f58c-4eb4-ab39-e8cbd01f3cae"), "172-414-1166 x762",
                    new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "quinn@abbott.name", "Sabina",
                    "Mayer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("17e29685-c7b1-4c9e-98fe-8bfca505f475"), "336.632.1240",
                    new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "shane.ullrich@beahan.info",
                    "Jacques", "Farrell"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("e537be85-9d8a-4452-ab0a-d0165d4354c8"), "210.350.0771 x4243",
                    new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jamal_renner@sawayn.name",
                    "Marques", "Medhurst"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7c972ba9-0af8-4171-8daa-49c6531f0000"), "(358)541-0667",
                    new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "jackson_welch@jaskolskimedhurst.co.uk", "Selina", "Smitham"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a421269a-8757-41dd-a429-3f8d316748c3"), "1-312-276-6327",
                    new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "fay@bodeweimann.us", "Norene",
                    "Swaniawski"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("4a5e5e76-5999-4e82-be10-4cd9def2cd0c"), "787.728.4404 x228",
                    new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "hayley@schinner.com", "Federico",
                    "Mohr"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7afb4d78-d131-4046-b962-1f16cf354f03"), "766.727.3117",
                    new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "jerrod@nitzschekozey.uk", "Rita",
                    "Cummerata"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("60a1d5e7-0552-447a-a9a0-413490459d6b"), "1-774-114-5245 x066",
                    new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hazel@roob.uk", "Margret",
                    "Reilly"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("9efac78b-40e9-46b9-842f-7d6e4c259912"), "(405)401-1437",
                    new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "marina@williamson.info", "Carrie",
                    "Barton"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("68026d92-8099-40b0-ae56-b30dc85c143b"), "1-776-713-0482 x715",
                    new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeramie.rowe@herzogauer.uk",
                    "Rasheed", "Mayer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("96776636-6760-4579-84fb-8b1b619abbd2"), "(028)384-4735 x816",
                    new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "lacy.buckridge@okon.name",
                    "Celestine", "Raynor"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("b56a1418-d5aa-43ca-993d-030f266ac910"), "(031)537-0621",
                    new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "melody.champlin@ratke.co.uk",
                    "Sandrine", "Graham"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("0d2730c5-445d-43fd-9e44-b0e3a6767b30"), "430-185-8658",
                    new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "valentina_stracke@thompson.ca",
                    "Tressa", "Gibson"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("925815e3-0da9-422a-b7b2-2ed365132d70"), "(461)070-3804",
                    new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "luciano.cartwright@okeefe.com",
                    "Bobby", "Altenwerth"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3a776a95-0896-4815-95be-e262999c8f75"), "1-048-037-2153",
                    new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "anika@schroeder.com", "Nedra",
                    "Reichel"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("61b9500e-ac1d-4ffd-bfe5-796ed8ea9df9"), "1-426-847-6466",
                    new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "murl@hellerosinski.us",
                    "Daniella", "Funk"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6ecb66fc-f520-4d0f-9e3a-34b50c1f2181"), "885.235.7421",
                    new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "harold@spinka.info", "Myra",
                    "Brakus"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8f8a55a4-3091-4a1c-89a7-2b90463d7840"), "(162)340-7458",
                    new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "karson_grady@tremblaybode.co.uk",
                    "Delaney", "Kirlin"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a15dd62e-e2d4-4e25-b762-b73fc2afbeb5"), "(115)613-6382",
                    new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "jay@hickle.info", "Sammy",
                    "Daugherty"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8a196d12-d7b0-484b-bf3a-3cda261b6f0e"), "1-383-606-7831 x388",
                    new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "tanner.cronin@nitzsche.biz",
                    "Elroy", "Torphy"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("d335500d-be89-47b6-9439-ab9908a030fe"), "015.051.7146",
                    new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "belle@kohlerweissnat.ca",
                    "Raymundo", "Rohan"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("55d55b7f-f9eb-4536-95e3-e28abf953827"), "242-564-8635 x736",
                    new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "marion@gibson.info", "Noemie",
                    "Reichert"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("fbd4923b-1c62-4f9d-9e30-73c776ba2f43"), "206-382-2227 x5436",
                    new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "darby@mosciski.co.uk", "Jennings",
                    "Waters"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("fc59a3e9-668b-4a9c-bb29-8389c46d441b"), "510-453-8874",
                    new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "myron@mannhintz.us", "Hyman",
                    "Corkery"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3376a073-81e8-4a93-a997-09f84cf1ec63"), "337-170-6648 x511",
                    new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniella_dicki@carter.name",
                    "Lenna", "Herzog"
                });

            migrationBuilder.CreateIndex(
                "IX_GameRentals_BoardGameId",
                schema: "r",
                table: "GameRentals",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                "IX_GameRentals_ClientId",
                schema: "r",
                table: "GameRentals",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "GameRentals",
                "r");

            migrationBuilder.DropTable(
                "BoardGames",
                "r");

            migrationBuilder.DropTable(
                "Clients",
                "r");
        }
    }
}