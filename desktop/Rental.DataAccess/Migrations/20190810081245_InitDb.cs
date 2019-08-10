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
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 10, 8, 12, 45, 152, DateTimeKind.Utc).AddTicks(5828))
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
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 10, 8, 12, 45, 156, DateTimeKind.Utc).AddTicks(6863))
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
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    BoardGameId = table.Column<Guid>(nullable: false),
                    ChargedDeposit = table.Column<float>(nullable: false),
                    PaidMoney = table.Column<float>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 10, 8, 12, 45, 156, DateTimeKind.Utc).AddTicks(3919)),
                    Status = table.Column<int>(nullable: false)
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
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0b520c0d-e617-4177-819a-f207df11b8d2"), new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 171f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ea861bc4-3ad7-4b07-ae0c-8ef352dc4b55"), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 214f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e0512599-ab0a-4eea-9906-f2efb847e723"), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 226f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ae0bd5a1-4542-413e-bbcc-13ee1c02b901"), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 186f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("58545c0d-d84a-413f-98dd-749d37f958c0"), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 88f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("aabf02b8-ca9b-471d-96c3-d34ca069cef8"), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 149f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("de3dbb5a-4b79-4c3c-a0a9-9d05f773ac88"), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 204f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("23e5b31f-3285-4d8c-89e7-c9d8a93f32d1"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 71f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("056846eb-1a7c-4155-8c58-f2ce6d1dbb2a"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 179f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f0b75d26-ff8e-497f-8c97-d64b04563763"), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 202f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c32f5bad-2a92-4588-bc9c-1bacdcb679f4"), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 159f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a662e707-e767-4313-be42-30c0166b3eb4"), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 197f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e7d964e7-f45c-4b53-97f3-a7bccba7ce7e"), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 109f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4bbf2329-ac15-4903-b035-77640ac0ba89"), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 69f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("11705fe5-da6c-4861-bff0-984927133995"), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 217f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ed42836f-78b4-4bc7-8cfc-60a96c14290b"), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 154f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a0780bb9-6f11-46a0-a629-bd365cd374c1"), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 146f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("92f0f9f0-712b-42b0-9067-695d7173ff64"), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 140f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c4d7eab1-e7e8-494c-b2ba-0e211c5fb89a"), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 220f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("660b9043-906e-4c9b-92a4-7795e520798a"), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 226f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("718732dd-f3f7-45ae-99b4-d8b71c7c7d88"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 243f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5cdc4db4-1633-4744-a2d9-f95109453f40"), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 135f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f82412db-4533-48c7-bc77-ff224f1c8459"), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 240f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("040f56c0-fa46-481b-a705-6b212483473a"), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 248f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("bc0b137f-38eb-40de-a562-53d10d09417a"), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 138f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("69ea40af-07a7-4634-ad33-fd9542c6a486"), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 99f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d5f34d20-a807-4216-84fc-2ce2d2aad501"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 220f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d3ae3b54-1d25-4623-9fb1-1f661bb483d3"), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 241f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d9848079-6682-45b8-976e-a2b383efa2ac"), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 157f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5983ccc6-5814-4b4e-93e0-9030e0261f4a"), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 137f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5d1c7e2d-a756-4831-b031-cf972e14502e"), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 166f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("171108b6-1ad0-4e76-8a7a-647206528c95"), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 249f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ceca74b1-093e-4c24-91e1-49033590f2fb"), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 55f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a5c4e918-52fa-416b-b444-697cef39ee05"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 59f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("aafcf2a7-c930-49fd-9521-9f1266e9af1c"), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 187f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c95c7c33-5ef5-4fa7-9839-1765e9d9c9ff"), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 99f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b7866594-a9a0-4c2d-adcf-2747f8e5757d"), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 248f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a3a0171c-22dd-4003-877e-2f5fc5bad132"), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 160f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e621424e-9463-4e1b-b7ff-db7f8d78e0eb"), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 139f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("217eed19-6630-4df4-928b-6f0e0b03b25d"), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 130f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0da4e6bb-6433-46c3-9e96-b958b78e52ca"), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 221f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6d88432c-45b0-46c5-bcf4-2ce5849cfc7a"), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 118f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f960d86a-a2e6-49ef-ac90-532cfe1d2a50"), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 180f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5026e78f-5e4d-44a9-9015-8346ee76ef56"), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 130f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5bff8334-0677-4fde-87f0-994b328e6590"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 50f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e7f52fe8-ef7c-4685-9adf-f01db995c5a6"), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 106f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4974c94c-e09c-4d38-b4b8-46b541f4d81f"), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 232f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("65a8e051-dca0-4521-91ac-3c551690d4dd"), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 111f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7636539e-3ef4-4c7c-b12e-c07d81c0ad4c"), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 158f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("778692cb-2711-4bbe-baf5-558d9b67935f"), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 134f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("56fd6cd4-def5-4e4f-9cdf-8309594acac8"), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 130f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2d0be64a-913c-4295-b5dc-b24bbdd016c1"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 229f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("035f216a-2a02-4afa-a97b-8755b1c91dd3"), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 200f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3a8a9442-dd2a-4bf3-8f1d-c9fe90fc7625"), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("722f6671-c4fd-4e4c-b0d9-936df4cc2b05"), new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 194f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d1dd49bb-167e-4285-b7db-93c5838fa88e"), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 175f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("22633af9-1b38-4247-931c-1000c9e2f6a0"), new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 181f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ff3d42f8-01b9-477c-8a00-6edf1ce68151"), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 136f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("cb15dff5-5897-490b-8a5c-2652ccc19979"), new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 92f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("beec1f8c-3c3d-4880-a13b-2e60b3ccc0c7"), new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 116f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ba295d35-db43-4bc3-9bb4-e510f5563dc0"), new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 90f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a1dfe9d3-4d83-46e5-a91e-ed6c3ac877c6"), new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 174f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0ab80e9d-9b85-492c-a937-b216436edbdb"), new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 154f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("14339d1a-90ad-40b9-a281-b6398e9a6ae9"), new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 82f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f59e1fff-8156-48f4-a99d-dd119ac49bce"), new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 215f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("75997922-06ba-4b7f-a13d-d9a73583e826"), new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 61f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8ac2d142-a41f-490f-8f9d-95528dac370c"), new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 219f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("397ebf00-6913-4c73-9363-2d7d4721eb08"), new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 136f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8d6591f6-22a6-4a2a-b12e-047771d05381"), new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 185f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("cec32491-c16c-4348-a640-88151d52186c"), new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 149f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b62d9e4a-1941-46a0-aa13-8a3866b3f222"), new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 139f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9b7d3051-a14c-4bf2-9d5e-0ba507d6e922"), new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 126f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("55c03535-8f90-4b36-9981-d546b6bf1131"), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 246f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("edfc0278-2283-45fa-8577-3240d6c8aeee"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 235f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4118cce1-e003-4e1c-b9b5-ff00efce3794"), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 242f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("63fa3100-8b42-4f3d-aae0-e9c1f62f46e2"), new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 169f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ab56a09b-9da4-4c71-ab93-04011442d98f"), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 217f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("880db061-2419-487a-8f80-b987589dafd7"), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 245f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f4bdee88-ad9b-4356-ac13-06feee71affe"), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 216f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("fcb91a87-70ec-4b92-bf4b-8a3d8af13eab"), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 188f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3da1f12f-b728-4080-ad40-52a4a1575157"), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 60f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d082d6dc-e131-47e5-a3a8-aec03d9d0b84"), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 173f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("32939fdb-e2ee-42e7-bba5-27ec1363d77f"), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 151f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f0cd7d30-f102-4e60-9e99-b231908abaa3"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 104f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("bcecf1e4-643c-4b04-8ad3-e290f07353f2"), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 185f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("eb9b245e-00aa-48be-b3a0-cabdc70dac80"), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 217f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d5aaf428-8b06-43bb-b7d2-85f1fd43af3f"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 160f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d6caeeb8-9b60-49fa-81da-c7f9b38a61c5"), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 156f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("59c13895-4e20-484b-8eb7-93d2610e6bbd"), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 196f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("892bf472-3b8d-4cbd-acf7-4362e0acc582"), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 236f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d0e9bc02-0188-4817-b740-0407c6f090bc"), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 78f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("62b73688-717f-4123-939a-dc26a606bfd5"), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 160f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f2ac557f-9402-4809-8571-3b426e0051a5"), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 114f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1ef30a64-c609-46ab-9b68-ff73938cb6d7"), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 105f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("eb2896d5-3b1e-4b6b-bebc-adbdfaeb96fc"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 129f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("10524936-9449-4f81-af67-9ef4274b08fb"), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 117f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("43c8ad8f-a40e-44ce-b5a0-e765e4579dde"), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 152f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d9eb39d0-e0a2-4d2d-81c0-0e81de5ce746"), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 136f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("aa5e626a-0acb-4bd0-aaf8-e766421c7a7e"), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 70f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3a542649-bd35-4080-b8bd-f79967102f8e"), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 224f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4ca6abe3-1199-4eca-91c7-cbc020eccd21"), "(052)425-6268 x10725", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "nia_wisoky@yost.info", "Bettye", "Wiza" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9b613f52-d42a-4393-8811-c3e662f7bb3b"), "1-622-511-6143 x8666", new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "einar_cruickshank@cummings.biz", "Ruby", "Willms" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ac010db4-e8d4-48dc-a3ed-61f475d7159a"), "768-811-8230 x4185", new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "fredy_kuhn@emard.ca", "Eino", "Padberg" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b3a5abe0-24aa-4eca-b620-c2b448fee435"), "631-868-8758 x242", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "rubie@vandervortpadberg.co.uk", "Dan", "Kuhn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a8955230-4e8f-40f6-9db4-cce321f16166"), "(285)506-2435 x0667", new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "dock@legros.us", "Jennifer", "Kulas" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("85857fb7-23b5-4068-b1a9-60b9cf89c98b"), "853.055.3867 x11148", new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "everette_murazik@franecki.biz", "Nannie", "Cremin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f0461a84-4a11-42c2-9a8d-8ca04ba8fb28"), "1-342-237-2361 x436", new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jermain@jerde.name", "Molly", "Witting" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b55b04bd-ba49-4e01-bd7f-faf2d6639c9e"), "(755)671-1170 x034", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "cyril@cremin.info", "Rosario", "Ortiz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("417c73f0-614b-4c4f-a804-c002dce67198"), "815.532.7713", new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "maya@weimannratke.ca", "Winnifred", "Feeney" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7b18e4a0-a8a9-4e1e-af2e-d6d7542e8e60"), "(677)580-1602", new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "patience.nienow@cronin.co.uk", "Malcolm", "Kling" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b40b8f78-3430-492a-8f77-c9a4259deb6e"), "065-613-2050 x663", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "darrel.casper@bernier.co.uk", "Vena", "Leuschke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d70c967b-79fb-4874-a8c5-60fd72c5ccee"), "1-040-201-4730", new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "troy.stark@bergnaum.ca", "Freddy", "Quitzon" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c882305f-a826-45be-97d8-1231ae5eac73"), "(818)357-4666 x52747", new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "winston@brekkedibbert.uk", "Brionna", "Larson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6ab7aa28-4590-4932-8abc-0bbb28ad250b"), "224-088-7011 x37332", new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alyce.douglas@lindgren.name", "Mozell", "Becker" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("907bf85d-1e29-4236-85df-77e16835c1c8"), "1-881-516-2831", new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "wilfrid_schultz@orncummerata.uk", "Everardo", "Stoltenberg" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f6c92de4-81a8-479b-9d1f-c6b6dfe39d96"), "663.205.5824 x5281", new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mary@schummcrist.info", "Eva", "Balistreri" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6cc62d3b-e0af-4b83-938c-f1c9346acea9"), "(616)621-7671 x63275", new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "britney@mills.name", "Everardo", "Rolfson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ea5c473f-056a-4892-bae8-d7c0a174fde8"), "467.374.5880", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "manley@little.us", "Amelia", "Hills" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("23095a85-6a48-4c1b-8710-171f2769339a"), "008-437-4287", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "gracie.sanford@hermistontrantow.us", "Gunner", "Prosacco" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bd97706d-75ee-44b2-a91b-005be744d73e"), "305-566-7530 x1456", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "linda@cristbartell.name", "Abby", "Wolf" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("68d173d8-dfb6-415a-b51c-b0c766cbd4e3"), "544-010-0445 x0682", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "nickolas@gutmann.co.uk", "Karen", "Turcotte" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("428a21c4-db81-404f-a99e-645ca8716433"), "1-346-804-0335", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "santino@blick.com", "Dereck", "Kris" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0979fcb8-aacd-4a92-b1d3-619f9a50d773"), "(723)874-4466", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorna@okon.com", "Myrtice", "Ziemann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a74c4210-3618-41f9-8a76-e4bf7e4af775"), "(703)377-8560", new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "patience_grimes@marvinwilliamson.com", "Alanna", "Connelly" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("39647112-d919-4eff-9ef1-c790f2aab5e5"), "801-384-5006", new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "laury@kertzmann.name", "Moises", "DuBuque" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4fd50fd2-ea42-41fa-b47c-bb76c9bc9072"), "224-486-1500", new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "linda@hartmann.ca", "Tara", "Kihn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c0a5db37-f954-46de-8178-546f361a65f6"), "167-847-6163 x587", new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "guiseppe@ullrich.name", "Marshall", "Macejkovic" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e3918dd6-968a-4160-af95-6526c74bc4b8"), "1-168-443-0108 x641", new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@langworth.us", "Annalise", "Rutherford" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7f84a054-6318-4e3b-8473-7c6468d55a78"), "1-243-406-3636 x0111", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "keely_olson@watsica.ca", "Sofia", "O'Hara" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("29de96d1-2c26-4f66-a97e-6735cadcb7ca"), "876.117.5384 x230", new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "nelson_haley@keeling.com", "Travon", "Turner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0d14bde0-40e2-4570-b92e-02d5baf22c0e"), "220-083-6310 x0468", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "joaquin@senger.com", "Newell", "Nikolaus" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7d49d2b6-8277-4348-866c-b15fab3f8469"), "1-175-366-4687 x5181", new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "coy@torphyschneider.name", "Jameson", "Gleason" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("54db9857-1cf8-40a5-8fd4-8c6205660a26"), "1-655-542-0361", new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "juvenal_stokes@doyle.biz", "Caleigh", "Olson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("409552d9-1a31-42d7-b06f-58d131cb4319"), "482-457-0611 x723", new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "hershel_bailey@wilkinson.ca", "Merritt", "Nikolaus" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("23a1daf0-a056-48d9-b7ba-84ba0ac2701e"), "806.672.4621 x8724", new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexa@kemmer.ca", "Van", "Smitham" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d83755b0-258b-4fb2-9a03-e87263bcca45"), "(222)716-7303", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "shanny@marks.info", "Rocio", "Rice" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("31fcfb97-47d1-410a-b1f2-810f9829b868"), "618.514.4152 x36384", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "woodrow@torp.name", "Joshuah", "Kreiger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c1986b0a-12fc-41a2-ba56-7ef64ab718e2"), "286.638.6757 x84523", new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "leola@dach.biz", "Pete", "Fahey" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6c442966-fda5-47e1-bc88-796f1e9e1e6e"), "1-857-473-2261 x5717", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "nathen@shieldsritchie.info", "Russel", "McKenzie" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("fec49192-58be-499a-a0db-9c85746d836b"), "632-087-0146 x535", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily@windler.info", "Lauriane", "Kuhlman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("56a028ef-0ca7-43b3-a527-ca7f6648d70d"), "(822)726-6728", new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "lenore_bauch@koss.us", "Oren", "Collier" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8fb6522c-75d7-416e-97cf-e7c2c711a8f3"), "(814)378-4540 x723", new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "rosemary@schimmeldenesik.co.uk", "Providenci", "Jacobs" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7e11c979-6b10-404d-b8f8-66089d2af99a"), "042-586-3018", new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilie_lehner@reichel.biz", "Ubaldo", "Ruecker" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("38b02f39-b566-4a19-9e7a-7fb0e15d1991"), "(828)524-5016 x73721", new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "kasandra_hintz@johnston.info", "Chaya", "Friesen" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("803cc211-4438-4ca1-b11e-cc62bcf80010"), "(168)604-7654", new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "darian@bradtke.com", "Laurence", "Ward" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("89e5dee5-d805-4740-8041-9d5c7ecb4120"), "(760)632-2453 x72034", new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "dasia_morissette@reynolds.info", "Cooper", "Corkery" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("861feefd-61b1-4b0e-bb50-d9a780e68dfe"), "280-305-7501", new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "leonardo@murphylakin.us", "Leanne", "Keeling" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("18fde38c-bf54-45ae-bc23-c585ed856b60"), "1-012-817-8665 x405", new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "guido.hayes@abshire.us", "Ora", "Boyer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5ced122c-dd7d-43e3-88b8-81585c35bf12"), "(774)656-0725 x0676", new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "yoshiko@goodwin.ca", "Isac", "Gorczany" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d60781f0-d107-467c-a45e-0cde8f9de567"), "1-125-172-5340 x873", new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "yesenia_price@collinsschmeler.biz", "Sophie", "Oberbrunner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9020f076-a014-45e6-abb1-44dba7f047c2"), "(817)734-5521", new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "audie_beier@nolanblick.uk", "Birdie", "Krajcik" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("55b885c9-896d-4653-b236-69f716f35c12"), "375-125-3800 x68657", new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alan@gusikowski.name", "Carroll", "Spinka" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("39d73b1a-ecf5-44cb-b8ae-7c4627836e00"), "748-025-1312", new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "donavon@kessler.name", "Hazel", "Koss" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ceb50a3f-89a1-4f12-b102-21b7f3495bf2"), "048-354-4056", new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "leland.reichert@conroy.com", "Christopher", "Beahan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7de13653-8ec2-4eb7-9fdd-622ac9e6d4e1"), "1-246-854-3872", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "vincent.mclaughlin@bode.co.uk", "Gertrude", "Kertzmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b6eeb74b-f3a1-4520-a71e-0e094bd2b27c"), "700-663-1038", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "santino@emard.us", "Thora", "Klein" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("feafd2a0-fad3-41a1-ac92-4aa40a5a0e04"), "872-278-3108", new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "martin_stanton@murazik.co.uk", "Antonette", "Bruen" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("453800ed-aeab-4e88-a32b-2efa31262e26"), "820-751-3645 x662", new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "claudine@langoshcorkery.co.uk", "Henderson", "Wintheiser" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d084913b-3a9c-4075-951e-180216512d7d"), "1-372-370-4174 x52458", new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "julia_harvey@wilkinson.com", "Llewellyn", "Lueilwitz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4733eaf7-d724-4120-94a3-6d3ad4354ae0"), "1-271-534-2486", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "kenton@willms.co.uk", "Neva", "Grant" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("afa9708c-f0b6-4b5c-97bd-4a2413fb4881"), "077-165-3622 x45764", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "seamus@koss.us", "Elisha", "Jacobs" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7efff820-4e51-4424-b11d-ea5887d21263"), "353.351.4042 x7184", new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "camren@gerholdhand.com", "Rasheed", "Lehner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c6cf1dfc-17ee-4a92-a690-0037b82c2fe9"), "417-605-4354", new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "amalia@auer.ca", "Quinn", "Gaylord" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bbe3fffc-2563-4db3-ae3d-b52dd08b9d3e"), "453.283.7773", new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "dejuan_wunsch@weber.co.uk", "Rosie", "Wolff" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("48e679fc-c85b-4c5f-86eb-5fe09489b7a9"), "125-515-1351 x805", new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "candida@wuckert.ca", "Carmine", "Huels" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("76994781-ea13-4e2e-9f96-5a00e525d628"), "(344)721-7132", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "casimer@walter.com", "Marley", "Bednar" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ea423887-21da-49cf-8e5d-1ec550de5e5a"), "1-150-243-5424 x01060", new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.marks@hahn.co.uk", "Nikki", "Corkery" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("317cadd6-6e7a-49fa-a32a-2f891d811604"), "635.826.3026 x55503", new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jayson_ebert@muller.info", "Dina", "Feest" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7cecd19e-cdbf-45ea-b16e-88fc737d1e15"), "1-552-500-4600 x7471", new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "evangeline@donnellykuvalis.us", "Kiera", "Mann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e20b7edf-9a74-417d-9fd0-a18481892789"), "220-650-8050", new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "khalid@kutch.info", "Ernest", "Howell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("adedfe27-7c7e-4632-a054-fcae697360c4"), "355.380.3225", new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "moises.waters@abshire.info", "Mylene", "Schneider" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c3be23b4-f787-419d-9ecf-f702f391d9d6"), "271-416-2006", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "eileen_stracke@langworth.name", "Isai", "Shanahan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7a9c67ff-a4a6-4023-8076-908f23b5b13d"), "433-827-1335 x131", new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "lori@strackenitzsche.co.uk", "Grayson", "Reilly" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ed882c0f-c9ad-4568-b7b7-67e4bdd4fba8"), "463.118.7488", new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "daphney@thompson.biz", "Dawn", "Koelpin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ead2e251-9927-4403-bf75-388931ddc076"), "1-414-315-3742", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jazmyne@bode.ca", "Elda", "Towne" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("db1c3374-c7cf-450e-beb8-b469ac39c3e1"), "1-485-128-6623", new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "octavia.connelly@hahn.co.uk", "Boyd", "Mayert" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6d329a58-dcb5-4a83-871a-6ea7e05191e0"), "623-404-1420 x780", new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "louvenia.okuneva@price.biz", "Meredith", "Ebert" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b3a773de-ebc6-4729-84ff-b2c6e2cc7b90"), "1-754-128-7520", new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "elody@johnsonskiles.us", "Kurtis", "McClure" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("62e69a1e-e851-4491-9266-7075a2ff4ff3"), "281.248.1580 x285", new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "giles@grady.uk", "Clara", "Hickle" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ed2ac69c-faee-4afa-b045-a6c784c113b0"), "(544)085-3062", new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ines_robel@greenholtmills.co.uk", "Hulda", "Hodkiewicz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("405af629-cd56-44ca-84db-80b10cd5b630"), "836.626.7823 x88762", new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "kimberly.carroll@skiles.biz", "Madison", "Senger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7d13749a-b1d7-4bb4-9394-5cf1e4bfc81d"), "046-344-5800", new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "dixie@nitzschepouros.com", "Elvera", "Wuckert" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d1775212-6148-4bd1-90c4-4d2e61256b8c"), "(606)442-7364", new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "felicita.corkery@gulgowski.uk", "Bertha", "O'Conner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("53c81c7c-96cc-4eb7-8838-88cb301449b7"), "287-360-1226 x642", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "antonette_batz@nitzschekshlerin.us", "Lambert", "Lebsack" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e68693de-c6d9-4cd0-a680-2092dfde3721"), "788.287.2848 x26656", new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "julien_morissette@kundekuvalis.co.uk", "Gianni", "Wiza" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("48f51e8a-7a1a-4345-ac90-abef45d64f3e"), "(055)626-3844", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "cory.pouros@armstrongfeest.info", "Golden", "Conn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bf392237-85e8-434f-9f75-79b569252110"), "045.711.2036", new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "orlando.mccullough@okuneva.info", "Jeramy", "Kovacek" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("19be79b6-e7d8-4f48-9591-4f667363702e"), "046-785-3320 x27305", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "mya_witting@stehr.ca", "Peggie", "Legros" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7fa5b36e-5932-415e-bafb-b5f01ee521fa"), "(554)876-6255 x1752", new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "dion.jakubowski@volkman.name", "Owen", "Sauer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7a60f705-a153-439c-a90a-819ec1d6de2f"), "(376)828-4644 x54167", new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "bertha@bruencummings.name", "Susie", "Schaefer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("91516c5b-6fa2-416e-a5aa-b96d3828b52f"), "456-222-2514 x333", new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "roma@spinkamcglynn.us", "Allene", "Considine" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9df8abe3-d38e-40d0-a1d2-ef7f18d995bc"), "(785)243-3636 x021", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adell@huels.us", "Graciela", "Senger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7a8ddcda-acc7-47ed-b029-250b2e95d9de"), "713.810.1802", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "taya_zulauf@weber.name", "Katlyn", "Langworth" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b497b0a1-8597-420b-81a4-f0b3e3bdf053"), "1-681-374-4821 x383", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "margarete@daugherty.ca", "Trystan", "Gottlieb" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("01a83346-affb-4773-ab2e-29f197ed88d2"), "411-744-8838 x8421", new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "clay_abshire@corwin.co.uk", "Ruthie", "Crona" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d0d5fa72-20c8-448f-adf3-e19cd476e2aa"), "1-736-473-5677 x5843", new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "angeline_kunze@hanehaley.name", "Janet", "Konopelski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("238bbd1e-8557-4a12-a98d-9b4dd69bbf27"), "(621)788-7675", new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "freda.kshlerin@hayesheaney.com", "Jaeden", "Hettinger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e18409a1-65af-45a2-9294-1764d40a879e"), "(865)525-8585", new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "krystina_oberbrunner@hahnbeier.com", "Kory", "Kuphal" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f3309f44-3454-4386-85e5-030106caf1f1"), "1-747-758-5003 x6347", new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "onie.stamm@kuhnzemlak.uk", "Colin", "Crona" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cc2739a3-3e3e-469d-8ca0-a31c2dd877dc"), "1-480-405-2275 x2042", new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ruby@beckerpouros.ca", "Constance", "Barrows" });

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
