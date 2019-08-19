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
                        defaultValue: new DateTime(2019, 8, 19, 11, 21, 49, 944, DateTimeKind.Utc).AddTicks(6671))
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
                        defaultValue: new DateTime(2019, 8, 19, 11, 21, 49, 949, DateTimeKind.Utc).AddTicks(6536))
                },
                constraints: table => { table.PrimaryKey("PK_Clients", x => x.Id); });

            migrationBuilder.CreateTable(
                "Rentals",
                schema: "r",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    ClientId = table.Column<Guid>(),
                    BoardGameId = table.Column<Guid>(),
                    ChargedDeposit = table.Column<float>(),
                    PaidMoney = table.Column<float>(),
                    CreationTime = table.Column<DateTime>(nullable: false,
                        defaultValue: new DateTime(2019, 8, 19, 11, 21, 49, 949, DateTimeKind.Utc).AddTicks(4247)),
                    FinishTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        "FK_Rentals_BoardGames_BoardGameId",
                        x => x.BoardGameId,
                        principalSchema: "r",
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Rentals_Clients_ClientId",
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
                    new Guid("aaa7d069-0334-4dfc-9acc-ee44a920da7b"), new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 126f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e8528c31-5c47-4fc6-af6a-cc4e5684cf96"), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 120f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7ee64dbb-dec5-48ae-8533-1145e51bf77c"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 203f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e8dc6c89-2346-4bc0-893e-d98250778d50"), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 103f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a44a232d-c986-4fbb-9d90-5a9695dfce91"), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 239f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("76ae89b0-7394-426b-810f-20981c4a7180"), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 110f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a6dfbb9c-a399-451e-9783-d13b81d6f37c"), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 208f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("cca72e38-d932-4451-ba26-ef5cf9cdea06"), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 162f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("88ecd5e6-8276-49d8-9404-8aad8bf7bbad"), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 161f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("05a349ab-c804-4c33-b9dc-a32412d7752b"), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 59f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("4a53eaa5-57f2-4005-a4e4-9ec2eb96d260"), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 100f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("751941a2-31ff-4215-8d6c-2fec3a71119f"), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 238f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a90595f6-0eb5-4e98-92a2-7cc7dc318fd2"), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 211f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b295d075-c787-46f4-a97f-8b917b179e6a"), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 195f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("36d90aac-4085-4d1c-97c2-37186538058b"), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 81f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("5ffccd36-5f4f-4507-b7c4-05d2d2b992f9"), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 124f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("04dead0e-72dd-449a-b7de-d425ce36d49f"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 240f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("75dcbaa7-b81e-4408-8e7f-a87ff8df645a"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 190f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e9f49248-c91f-43ea-af4a-9d8200fb6c60"), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 198f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b6de4ddf-33c7-499e-b99c-e33e7b6f60c1"), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 76f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ba3eaa30-6411-40c0-9654-2bf4900f56a7"), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 58f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ce4438d7-89bb-41d6-82b8-1bb3f196c62f"), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 199f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("79e20d58-cddb-4f83-ae8f-91f8343a7ae3"), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 113f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("bdd462e6-87e7-4037-940c-ecab29888b15"), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 137f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e0020ba8-d4e6-44b3-91d6-db20279ffbe8"), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 236f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e4106904-1f90-48ab-9516-bef562ac799c"), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 177f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("fc997395-c6f4-482c-9590-fee8053cf42e"), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 149f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("060d3859-41ad-46cf-914d-cb01f2abffc3"), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 199f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("5f919830-7710-4df9-8084-ac85a99bf67c"), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 200f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("c9876d97-3f59-4089-aae2-7a16f53d4704"), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 109f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7f108ebb-a227-4e7e-8b70-e10aa4521111"), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 166f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e5143b1d-3972-4b32-ab30-53d6a2acd926"), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 188f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("aa2db8c2-8032-4975-b269-5715ac831baf"), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 226f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("51614053-c32d-4116-85e2-fcf1c5cff12b"), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 50f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ef623efc-0f1c-4d0e-be98-76dd335269ce"), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 63f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("00583341-e1e0-47eb-b2b8-ac45be6dfab9"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 218f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1c90ec1c-c083-44f8-ba2d-c0cb2d14c032"), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 88f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("75cfd38e-1013-4581-87c9-8eb41ac04d49"), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 243f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("24f17fd6-82db-421e-9813-018298b00f4d"), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 59f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("572dcb2a-601c-4303-aa5a-d4022465d6ad"), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 166f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("5137b75c-632e-4842-b03c-ede929bd76b7"), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 125f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a15e5ce0-30cb-45bf-8b58-51ca2116759c"), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 126f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b3a6ceb2-0f25-45bb-a5a4-a9accdbfd190"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 102f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f43d07f2-e196-4db3-b52f-5cd1ab8fdc92"), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 210f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1dbf4179-753c-4328-ac60-1b01ebf5128f"), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 226f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("9c11e171-b4f3-45c7-90f5-6166a18f253b"), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 202f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("eab45408-8228-4dbf-8aea-db780964a7e7"), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 197f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("237e29b2-53e3-407f-8388-c58215cc39ac"), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 108f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("8029509b-b579-4453-a21e-f7cb1fc8a9de"), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 147f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("9787b1c3-d5f4-4dc1-bfff-2e307758d681"), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 177f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("101c82b8-49c2-45c5-845f-e79810ae6302"), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 105f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b0c2afef-b795-4964-828c-8383ea8c8d1f"), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 172f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("27f5ec4a-48f2-4044-9a87-2bfbfc4a271f"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 177f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ddfb597c-9292-41d9-9fe6-9f35312a7f79"), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 175f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e99b3afc-1075-41a0-aa09-446456f8f105"), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 158f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("e3dd8b13-5cf3-4ad6-97f0-3947fa0d3c05"), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 175f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1665863a-8e1f-4f3c-b259-ea05b0d3fc1e"), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 91f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("c6fc23e0-1289-4f5a-8b25-56ed105686ba"), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 54f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a2afc6ec-7075-469f-a406-a748b5d5dbf9"), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 94f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("be6dadce-a817-435f-b783-4c942505e90d"), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 193f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("bbb5d313-3365-48a5-8b98-73843af2dfb4"), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 228f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("04848b25-3067-445a-9d9d-c83d6ec8cc6c"), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 68f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("dd790f44-0367-4e5c-a348-1593df6ad5a3"), new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 119f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1b89d89a-7648-4fc5-a7ea-294ca1d5640e"), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 214f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("65e1e47e-978d-4fb6-b70c-c21606c46201"), new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 103f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("32174ffc-6ea1-4b43-a31e-b531d44f724b"), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 94f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("99ee3390-1cb5-4829-9201-441bdb8b6e01"), new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 186f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("92d656ac-0ce0-47cd-bee5-7ef609d83b64"), new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 168f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("8229750b-934a-485d-b956-5b61b15f3842"), new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 74f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("79842127-ff0c-4d4f-834e-f406d6ee5803"), new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 98f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("66468e74-c92f-4d4f-85af-9ea0e3b722c7"), new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 154f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("2fd92079-a427-4c9d-941a-6206ac35ea7d"), new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 158f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("02905ffd-718c-432d-84be-290433bdcd2e"), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 229f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ef8dec4a-e8f7-42ea-9cb9-29e60e2fd366"), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 217f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("b20423b9-4b11-4bb3-9196-68bdc1909bbf"), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 164f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("d8259e4d-ed60-4dd1-a62b-95c241a1e2cb"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 227f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("af2a97f9-4d1b-4e3f-8fe9-0370250a05b8"), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 243f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("f8cde434-4a64-42f2-9a6d-c2edc6b6874a"), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 223f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("d32af213-530c-434f-a73c-ec273262239b"), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 66f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("4d138266-e097-40a2-9fc6-8818ad7a01a4"), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 71f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("35de9418-09dd-4a17-9bb8-f1284b9d5f44"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 216f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("7bce8a6c-a541-45d2-80c1-88d322f6f24f"), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 159f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("1957c61c-4a46-40aa-9799-b2243b174686"), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 50f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ad3890ed-651a-4458-88e7-d2ad6339fb01"), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 188f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("363a68fd-ca88-4ad9-9d39-f373b3d6f724"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 111f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("4292b728-9c3c-4f0a-ae1b-92e4a16809ea"), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 220f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("31cf44a3-a7bf-4080-8cb8-8941a31488d3"), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 101f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ad5719bc-4e38-4e06-8066-fa4fc9495619"), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 241f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ae369793-8eeb-4476-9251-d5c0cdb8466a"), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 71f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("6ec3fbd1-1e8a-4c3f-8f74-aff2bf9c3760"), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 61f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a5135e31-991f-48f2-b140-34dcc4818882"), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 203f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("3d63c1aa-154b-4e44-9b35-14f77ee9d2a1"), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 224f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("ddc0bede-2493-4286-89b1-c28c29ee1f20"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 106f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("87f84401-b5ec-49a4-acd2-f8210f97c786"), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 52f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("af9e9914-bb6e-410b-a761-7fcec453ada1"), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 204f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("142193c6-222c-4bf0-9f7d-3478c21c876e"), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 222f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("09b9c2bc-a7f1-44e4-98a2-b3e5aa4570d6"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 156f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("a805a319-f362-4db7-bc45-a508b265b4e7"), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 70f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("526ac937-c3a7-4a2f-a9bd-760f874f9a76"), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 167f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] {"Id", "CreationTime", "Name", "Price"},
                values: new object[]
                {
                    new Guid("9dc08e89-d59d-4263-84fa-7a93d9742c8b"), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    "alias", 208f
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5df25895-718c-4d3f-ba8e-48b1a4f88501"), "158-107-8675",
                    new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "katelin.thiel@mckenzieaufderhar.ca", "Zaria",
                    "Dibbert"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("aca1ef67-9e8f-45de-ba4c-cc644771caba"), "(080)613-1320 x46682",
                    new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "pauline@gleichner.name", "Leola", "Wehner"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("68822c17-fa38-4591-b440-8ec19434d52e"), "(757)053-8213 x0645",
                    new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "bradford@champlinromaguera.com", "Caesar", "Marks"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("b1f55bec-8192-4d30-b941-4e1117d19726"), "(735)114-2217",
                    new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alia@hammes.us", "Casimir", "Lang"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("169adca6-6012-4b0d-9e70-2f6263fb0ccf"), "(351)786-6831 x212",
                    new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "destiny_gleichner@marks.ca", "Odie", "Abshire"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("f468b6d4-9555-4231-b16a-d92b845506cc"), "(617)172-0008",
                    new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "audie_block@simonis.co.uk", "Justine", "Bogisich"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8b021ebd-deb4-4cab-b27f-4248d8c9360b"), "(227)534-8808 x10664",
                    new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "virgil_abshire@denesik.uk", "Owen", "Swift"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6afe2847-f804-48dc-9d25-0eb6edfe3724"), "618.236.4318 x78030",
                    new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "markus@turner.info", "Arielle", "Keebler"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("1c420c74-45c7-4abc-806d-255c1cd1c9ed"), "587.230.1883",
                    new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "novella@leschwuckert.biz", "Thaddeus", "Schuster"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("cc1522be-c5cb-4355-9068-45d1f65a3b4d"), "738.755.5247 x5878",
                    new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ebony_hahn@mayerschroeder.uk", "Nathanial", "Krajcik"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("496972a1-561a-4ddd-ac72-43041006c123"), "864-888-3181 x1554",
                    new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "halie.bayer@schamberger.uk", "Mabelle", "Wyman"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3adef72b-190e-47d0-bb5a-3f9f60eea494"), "440.767.5614",
                    new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "lincoln.metz@rueckerschaefer.com", "Trystan",
                    "Hackett"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("b4a6bc8a-a52b-4b4b-af2c-db3f82474f3c"), "628-373-8132 x8205",
                    new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "delilah@hauck.ca", "Garrison", "McDermott"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("77a02936-b453-4ba5-b17a-6c4d0eccf0ee"), "1-364-051-0304",
                    new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "rubye.blick@ryan.ca", "Jennifer", "Bartoletti"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("70757a37-f666-4737-aa41-6b8baf78c90a"), "734.333.8872 x82523",
                    new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "xavier.cassin@beatty.us", "Abe", "Farrell"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("67ab3a46-9f6d-4eb1-87b4-4ad6175b1674"), "530-148-8140 x15545",
                    new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "trever@zboncak.info", "Mateo", "Kovacek"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("cbb37f57-03e0-47f1-97b7-38c9dde502f0"), "215.564.7585 x672",
                    new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "lilyan@boyer.ca", "Michele", "Klocko"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("fcd7cf90-3dec-4baa-9935-41d0c3b3b187"), "247-770-1830 x57360",
                    new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "yasmeen@durgan.biz", "Carmela", "Jaskolski"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("40c331a4-4853-4a26-9df2-eef37aa82f33"), "003.721.6422",
                    new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "emile@doyleconsidine.uk", "Gregoria", "Waters"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("2e090f0f-dd07-413f-8be8-9a2e2228684f"), "541.830.7730 x8538",
                    new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "seamus@hintzsanford.us", "Gerson", "Cronin"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7db22681-a84b-4b50-81f4-f0d7faf90d8e"), "351.013.3086 x7146",
                    new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "reanna.auer@parisian.biz", "Claud", "Bruen"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("4e9d6377-0393-4ddf-9567-fd1b4dfcd366"), "(540)404-0128",
                    new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "hugh.kuhic@streich.us", "Carmel", "Pouros"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("54084bb4-6dae-474a-b4a8-56dfbe22e860"), "(883)787-7224",
                    new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "arch@vonrueden.uk", "Brandy", "Bradtke"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("1c0364b3-1ca5-4c7b-b16a-819f53464326"), "026-413-6367 x37158",
                    new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "eliezer.rodriguez@hagenes.uk", "Amiya", "Roob"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("ad86e1ee-3ede-482f-a0fb-745cb7574946"), "(683)232-5877",
                    new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "kacey@raynor.co.uk", "Henderson", "Reichert"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("55b9ccbb-882e-4294-9a5b-65fb5344718f"), "1-388-470-8502 x70262",
                    new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "juvenal.mayert@purdy.name", "Christian", "Hackett"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("0f436b8c-a3ac-49bd-9095-82f0c34443c3"), "780-154-4655",
                    new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "samanta@bernhard.us", "Jaiden", "Hartmann"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("326db534-c474-4c23-9ed1-abd8590c7b26"), "247-683-3267 x603",
                    new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafael_mcdermott@ullrich.co.uk", "Loraine",
                    "Vandervort"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("9407bfe2-edfa-4706-a380-86e4b99cb460"), "1-124-843-5784 x5345",
                    new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "eleonore.jacobi@breitenberg.biz", "Bret", "Ortiz"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("1e3c3c44-e136-4fe7-a597-2ffc2d5888ec"), "074-848-0433 x12314",
                    new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "irma_weber@carter.uk", "Jaclyn", "Simonis"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("f2aaa5c1-63d7-44af-b465-2f1b23b2656e"), "735.831.3847 x7461",
                    new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "mae@block.com", "Claude", "Stroman"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8cdcc350-a823-46ba-8a77-dfb74634bab4"), "1-060-178-7747",
                    new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "madisen.heathcote@hudson.uk", "Meghan", "Gusikowski"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("06aa7ff8-041a-4fbc-970d-0242f35ab79f"), "1-508-561-8566",
                    new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "shaniya@stark.uk", "Susana", "Franecki"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("68d92b62-414b-4d54-8bb0-99ac7c02b7af"), "(827)476-0354",
                    new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "helene@kassulke.info", "Larissa", "Feest"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("ba8b9299-7d23-41b1-abc2-a00c6fd2994f"), "(287)647-0773 x730",
                    new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "marlen@bernhard.com", "Christelle", "Greenholt"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("b2b5a93c-3dd6-4188-ac50-004866a12ab6"), "040.440.8437",
                    new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "saul@witting.uk", "Oren", "Bartell"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("edf9bdbb-207d-49ba-8cf7-72c4636ab280"), "774-662-8068 x0807",
                    new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "marge@schoen.com", "Khalid", "Schimmel"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("dabb040d-21f0-4843-9521-c59234ce0ca4"), "1-534-144-2710 x66330",
                    new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "amanda@hermannbatz.us", "Emmitt", "Bosco"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("efd35e91-a859-4793-a173-389561e5b3e3"), "150.522.1627 x553",
                    new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "clifton@doyleromaguera.name", "Cary", "Hermann"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("b6adce7d-6f18-4db7-92db-607449e8b8f0"), "311.240.1128 x47448",
                    new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "greyson@jenkins.com", "Tyrique", "Kunze"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a17ad36d-3772-4b84-b644-5b128c1ca9c0"), "502.116.6661 x7207",
                    new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "sigmund.conn@murphyleffler.us", "Hal", "Grady"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8df0245f-529f-4f08-8ac9-0f305656eab2"), "045-066-6704 x504",
                    new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "amari@kub.info", "Rebecca", "Marks"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3755bbe4-62c0-471c-ad4d-f2abf09d02c1"), "481.803.5755",
                    new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kayli@hahn.co.uk", "Myron", "Daugherty"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("51c71bd7-7ee0-435b-955c-b6d83440fcfc"), "(413)353-6646 x3367",
                    new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "oma_zboncak@rempelbatz.uk", "Kip", "Goldner"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6b2ba41d-6012-4b85-9693-b3753ceeaf35"), "(211)205-8582 x6401",
                    new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "terry.swift@lindgrennolan.info", "Joelle", "King"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("87f95e13-cd92-4c3a-ba04-7aa06e300ac2"), "1-321-118-5587 x2658",
                    new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "izaiah_jewess@predovic.info", "Ashton", "Borer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("d9412ea2-b6f0-460d-9bb6-90f45f994dc9"), "(760)334-8610 x142",
                    new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "maverick.flatley@hahn.info", "Jettie", "Stoltenberg"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("eb0bdb99-436c-403f-9829-a2e31b3b6879"), "051.583.1041 x051",
                    new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "pat@kutchjewess.biz", "Marie", "Hilll"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("311351e3-f38f-489f-8848-a6056859a799"), "022.581.6463 x2448",
                    new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "armand@predovic.info", "Anastacio", "Cummings"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("60b2f62a-5fc0-46bd-ad79-c25c0ef2b186"), "(471)610-0424 x71831",
                    new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "gilbert.walter@wehner.us", "Kylie", "Kiehn"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("25c53223-9d13-4a2c-9778-65c9b5ab1fc7"), "(713)008-6476 x60748",
                    new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "imogene@tremblayhaag.name", "Daniela", "Swaniawski"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5b36aaf6-8308-46ac-80e4-98ba210467c1"), "332.604.6533",
                    new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "olin.lakin@homenickbernier.biz", "Jamal", "Hauck"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("eb05e4ea-d6a2-4fef-9899-fbc5c0154b41"), "863.516.8317",
                    new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "myrtis.marvin@townelynch.us", "Natalie", "Spencer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("c75fb3d1-44bd-4e92-b238-ddb4c1d1c6fc"), "665-441-6674 x5614",
                    new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "susana.goldner@schowaltergoldner.us", "Brenden",
                    "Konopelski"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6dd1db4d-a628-4dd1-9088-0d587d2e4e5c"), "(077)553-7065 x208",
                    new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "anita_strosin@nicolas.biz", "Davion", "Kris"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("6e64c121-7f43-4fdb-bc63-1625f98bc369"), "282.864.0142 x1213",
                    new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "hanna_smitham@mccullough.ca", "Oda", "Bernhard"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7718ee5b-5349-49c0-bf0a-540cb1abc679"), "1-386-550-5840",
                    new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "stuart@denesik.uk", "Kennedi", "Terry"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("0f97fb05-16f0-4ec8-8aa7-04c58555ceb0"), "1-575-471-5118",
                    new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gerhard_wisozk@zulauf.com", "Jaeden", "Sanford"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("4f0fb6fe-040f-4087-8d56-d50f9cccaf9f"), "241.178.0852 x33024",
                    new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "darien@wyman.info", "Zoe", "Brown"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a7cd7445-7cab-4fba-95e3-00905f4d4b03"), "752-020-4867 x0723",
                    new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "dustin.morar@sauerschmitt.ca", "Alverta", "Haley"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a1158464-2596-4b1e-98fa-346458bcde95"), "(753)022-0861 x45516",
                    new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "jerome_batz@reynolds.uk", "Elroy", "Homenick"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("345bbd5a-8b14-4610-9748-76dfe95eedfb"), "1-443-631-0044 x88200",
                    new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "wanda@schaefermoen.info", "Gilbert", "Strosin"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("aa8695c1-9c9c-4451-a9a5-73099dcf6d4c"), "723.400.0881 x85843",
                    new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaitlin.kreiger@pfeffer.com", "Roger", "Corkery"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("61be376e-b8ea-4bd9-973a-b3812276bcd3"), "027-243-0027",
                    new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "nadia.ruecker@rodriguez.info", "Deion", "Abernathy"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3d9e8df5-8171-41d1-9c95-e60d49618722"), "870-710-0451 x046",
                    new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "aniya@hessel.co.uk", "Rosie", "Zemlak"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3501aab9-b6b9-46d7-93be-69533dca35c0"), "758-433-3202",
                    new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "johann@quigleyhilll.com", "Aaliyah", "Powlowski"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("2aecbcf3-a7f7-46b9-8b20-22c87557621b"), "704.004.4534 x0577",
                    new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "ardith@hamilldaniel.name", "Christy", "Hickle"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3eea9266-618a-4052-834f-b7615b1f4c31"), "167.261.3323 x0331",
                    new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "abdullah@buckridge.uk", "Viviane", "Kihn"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("e7aeca24-0086-46f5-bd34-ffebdfc666f5"), "857-223-5172 x75420",
                    new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "germaine@crona.uk", "Christina", "Abshire"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("f3734ff9-65ed-4a4f-b93a-bf1c8b3d9f34"), "526.376.0877",
                    new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "madelynn@schinner.uk", "Fanny", "Connelly"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3317e787-3af3-4ab4-9b92-d62a51d7a812"), "1-730-565-2020 x53373",
                    new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "rosanna.moore@crona.ca", "Douglas", "Huels"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("672b75ea-7129-4421-b77f-3a8a3536bf0c"), "1-841-670-6414 x24816",
                    new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "trycia@doyle.com", "Shaylee", "Murazik"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("bdaff858-eff9-498c-b0e8-9b275d52a4f2"), "1-050-186-7860",
                    new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "jimmie@marvin.info", "Micaela", "Rogahn"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7573f9d2-5256-4d3c-974f-884a2149bb86"), "674-780-0044",
                    new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "nestor_batz@sauerfahey.ca", "Brad", "Hahn"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("15ce5cac-7ee7-4b5f-88cf-c4bdae2b56bc"), "653-624-8121 x43452",
                    new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "charley@stiedemann.info", "Brandi", "Romaguera"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a85dbc26-190d-409a-ae6b-e0732c74caf8"), "487-147-2853 x810",
                    new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mavis@colewillms.com", "Hanna", "Fadel"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("1a7e74eb-4c62-42a8-89f2-b80008b1e7ca"), "(837)228-5457",
                    new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "frieda_lowe@conn.info", "Rosendo", "D'Amore"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8de74b06-4b10-441c-9b14-653f1d1ead42"), "(268)774-3256",
                    new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cleve@ernser.com", "Velda", "Kreiger"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("71c37770-7737-4afe-a2fe-971026996ec3"), "244.033.2706 x3248",
                    new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "christop.wiza@hoppe.com", "Ella", "Beahan"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("7ebb92f6-ef08-4bd0-b15b-17e237f264b1"), "1-373-730-8252 x55707",
                    new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jensen.tillman@cummings.ca", "Carmella", "Cassin"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("723b627a-eb38-475e-b6fd-e27d7380de30"), "(422)712-6581 x735",
                    new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "danika@jewess.biz", "Titus", "Rodriguez"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("b22f6632-ea05-4d54-9427-2aaa3aa2ab4f"), "481.112.6168 x47223",
                    new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcus@rice.biz", "Rhoda", "Pollich"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("bcb8bb35-9374-4145-9549-86e783d675d6"), "335.132.6431 x0215",
                    new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "tyrell.runolfsdottir@mccullough.biz", "Westley",
                    "Sanford"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("a8978385-f65a-4723-a127-88b66ef928eb"), "258-428-4365 x7158",
                    new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "soledad.hirthe@klocko.name", "Dejah", "McDermott"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("8c7030dc-d83a-4fd3-baf9-9b07f9c48e3d"), "(836)168-4363",
                    new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "humberto_hamill@leffler.us", "Major", "Wilkinson"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("24a05ea7-6668-42f2-bdf0-11e2dc9f4b48"), "507.267.2371",
                    new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "melany@cruickshank.co.uk", "Deion", "Metz"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("3f1a5b1c-5c67-4bec-98e6-86967b72a4a4"), "(355)208-3521 x11422",
                    new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sherwood.schamberger@bergnaum.biz", "Mitchell", "Lang"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("ff7fc02c-ceff-44a3-86f4-9078fa415589"), "1-184-583-7641",
                    new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "adelia.morar@rathhansen.info", "Tess", "VonRueden"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("325208fe-c2fe-4883-a26d-e265bb2d80c4"), "822.566.4472",
                    new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "dena.swaniawski@mertzwhite.uk", "Enrique", "Nicolas"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("d6ad6cfa-5308-45b4-84a6-36e5ed20f3bf"), "050-833-7863 x58108",
                    new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "emanuel@gislason.ca", "Florencio", "Nikolaus"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5ef34921-9a16-4dc6-9a98-8b0d93adca78"), "(472)770-6308",
                    new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "diana.marquardt@bernhard.co.uk", "Ralph", "Kovacek"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("c907b00a-7527-49d4-a2f3-104f2acc2d11"), "(283)324-6410 x2183",
                    new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "donald.hilll@thiel.ca", "Dedric", "Pagac"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("37393e43-06eb-4b09-8beb-ff4db70c605f"), "282-621-8580",
                    new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "piper_hills@graham.info", "Demetrius", "Kassulke"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("21b51626-c0a3-4cb9-aa2a-07f77ec17836"), "1-506-447-6872 x453",
                    new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "samanta@baumbach.ca", "Adolf", "Moen"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("cdb6696b-aa64-4e92-9692-d55b44334584"), "360.678.4148",
                    new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "justyn_ratke@keebler.co.uk", "Verona", "Predovic"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("ed32e66a-5371-400c-bbad-0cbe46d04aeb"), "425.558.7370 x38013",
                    new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "hazel@lockmanromaguera.biz", "Jerry", "Mitchell"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("034ee867-342d-4b06-a3c3-efa67732a078"), "1-837-336-3548",
                    new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "vito_bartoletti@wolf.com", "Lewis", "Pfeffer"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("5c0ab4a6-b737-43c4-9411-dce8cb5f1908"), "1-030-503-2102",
                    new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "trever@herzog.biz", "Edmund", "Braun"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("f2799e79-faeb-4cee-8266-ec834fc14899"), "1-274-274-7022",
                    new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "twila_ankunding@crist.com", "Francesco", "Muller"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] {"Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName"},
                values: new object[]
                {
                    new Guid("40acd428-cdd9-4d26-bc87-69c2bf304edd"), "(824)488-7823 x11882",
                    new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "makenzie@hintzmcdermott.info", "Catherine", "Carroll"
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("14507ced-2b23-4961-98ab-e5fa59d3564a"), new Guid("75cfd38e-1013-4581-87c9-8eb41ac04d49"), 15f,
                    new Guid("3317e787-3af3-4ab4-9b92-d62a51d7a812"), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 76f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("6bae6189-1c00-4b51-9dee-cc7a2b69c1af"), new Guid("363a68fd-ca88-4ad9-9d39-f373b3d6f724"), 15f,
                    new Guid("70757a37-f666-4737-aa41-6b8baf78c90a"), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 92f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("dfbbb9d6-5e4c-4ddc-bbb6-6946b3dd8c58"), new Guid("1665863a-8e1f-4f3c-b259-ea05b0d3fc1e"), 15f,
                    new Guid("67ab3a46-9f6d-4eb1-87b4-4ad6175b1674"), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 91f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("f76f9a7f-0f97-4c85-858f-010bff5f2edc"), new Guid("ef8dec4a-e8f7-42ea-9cb9-29e60e2fd366"), 15f,
                    new Guid("67ab3a46-9f6d-4eb1-87b4-4ad6175b1674"), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 79f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("9e14c174-cbe4-41a1-b6aa-3598a7faaffb"), new Guid("e0020ba8-d4e6-44b3-91d6-db20279ffbe8"), 15f,
                    new Guid("67ab3a46-9f6d-4eb1-87b4-4ad6175b1674"), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 48f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("b3d0a6c2-3e46-4203-87b3-3e569365a477"), new Guid("1dbf4179-753c-4328-ac60-1b01ebf5128f"), 15f,
                    new Guid("cbb37f57-03e0-47f1-97b7-38c9dde502f0"), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 49f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("1300c919-5c2f-4e5c-8180-c94223c3bb07"), new Guid("ce4438d7-89bb-41d6-82b8-1bb3f196c62f"), 15f,
                    new Guid("fcd7cf90-3dec-4baa-9935-41d0c3b3b187"), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("38026373-db75-4d00-bf20-e9a759adb4fc"), new Guid("e4106904-1f90-48ab-9516-bef562ac799c"), 15f,
                    new Guid("40c331a4-4853-4a26-9df2-eef37aa82f33"), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 86f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("9f497241-0313-4ed2-a042-a77e7c23df60"), new Guid("a90595f6-0eb5-4e98-92a2-7cc7dc318fd2"), 15f,
                    new Guid("2e090f0f-dd07-413f-8be8-9a2e2228684f"), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("c819f182-bc5a-404b-94c8-2032ed865a89"), new Guid("142193c6-222c-4bf0-9f7d-3478c21c876e"), 15f,
                    new Guid("2e090f0f-dd07-413f-8be8-9a2e2228684f"), new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 9f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("119f4485-528d-42ca-b5c1-a259a5477c97"), new Guid("09b9c2bc-a7f1-44e4-98a2-b3e5aa4570d6"), 15f,
                    new Guid("496972a1-561a-4ddd-ac72-43041006c123"), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 99f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("5814b21b-c357-48b0-95e3-c8e1eb906f07"), new Guid("142193c6-222c-4bf0-9f7d-3478c21c876e"), 15f,
                    new Guid("496972a1-561a-4ddd-ac72-43041006c123"), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 63f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("f73e5769-50de-4d0f-a106-ecee76a10bb4"), new Guid("572dcb2a-601c-4303-aa5a-d4022465d6ad"), 15f,
                    new Guid("55b9ccbb-882e-4294-9a5b-65fb5344718f"), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 96f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("430b2b7b-5dbe-41f6-b763-c9b54e574bd8"), new Guid("5137b75c-632e-4842-b03c-ede929bd76b7"), 15f,
                    new Guid("311351e3-f38f-489f-8848-a6056859a799"), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 74f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("4b72dd2a-7750-4632-a9c4-6ea22b71fd22"), new Guid("31cf44a3-a7bf-4080-8cb8-8941a31488d3"), 15f,
                    new Guid("311351e3-f38f-489f-8848-a6056859a799"), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("9ae68be5-f1a5-4329-842b-cd44b1052782"), new Guid("5137b75c-632e-4842-b03c-ede929bd76b7"), 15f,
                    new Guid("3f1a5b1c-5c67-4bec-98e6-86967b72a4a4"), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 98f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("1ced32d0-cb60-48f4-b694-463dd0dfcf84"), new Guid("e3dd8b13-5cf3-4ad6-97f0-3947fa0d3c05"), 15f,
                    new Guid("71c37770-7737-4afe-a2fe-971026996ec3"), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 97f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("459095f0-91c8-4f77-84ac-2d92823da9b6"), new Guid("060d3859-41ad-46cf-914d-cb01f2abffc3"), 15f,
                    new Guid("71c37770-7737-4afe-a2fe-971026996ec3"), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 88f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("18f3631b-ed9d-4c79-9b90-a6a829ef5bf9"), new Guid("e9f49248-c91f-43ea-af4a-9d8200fb6c60"), 15f,
                    new Guid("71c37770-7737-4afe-a2fe-971026996ec3"), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 66f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("063f237f-2d2d-4f55-9e2e-44fae18f68c0"), new Guid("4d138266-e097-40a2-9fc6-8818ad7a01a4"), 15f,
                    new Guid("71c37770-7737-4afe-a2fe-971026996ec3"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("01f38d57-dccb-4ef9-9d14-d83704ef8e6c"), new Guid("92d656ac-0ce0-47cd-bee5-7ef609d83b64"), 15f,
                    new Guid("71c37770-7737-4afe-a2fe-971026996ec3"), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 26f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("b64ef642-a422-45fb-92bf-1dda4a83b319"), new Guid("f43d07f2-e196-4db3-b52f-5cd1ab8fdc92"), 15f,
                    new Guid("71c37770-7737-4afe-a2fe-971026996ec3"), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("3d5640d9-2696-4c26-b8aa-b9b33ca83a4b"), new Guid("1b89d89a-7648-4fc5-a7ea-294ca1d5640e"), 15f,
                    new Guid("b4a6bc8a-a52b-4b4b-af2c-db3f82474f3c"), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 62f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("f7f31e65-ee5f-4ccd-b125-7a800dd9394e"), new Guid("7bce8a6c-a541-45d2-80c1-88d322f6f24f"), 15f,
                    new Guid("7ebb92f6-ef08-4bd0-b15b-17e237f264b1"), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 94f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("e417fbd3-8cbd-42c6-b73a-0aa5fd2f02d5"), new Guid("a2afc6ec-7075-469f-a406-a748b5d5dbf9"), 15f,
                    new Guid("3adef72b-190e-47d0-bb5a-3f9f60eea494"), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("1878c01f-f29a-4ade-aa9f-b31e31fd4cec"), new Guid("572dcb2a-601c-4303-aa5a-d4022465d6ad"), 15f,
                    new Guid("cc1522be-c5cb-4355-9068-45d1f65a3b4d"), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 68f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("ec3249ff-a5b7-431b-a5c8-557ba1ec54c6"), new Guid("e4106904-1f90-48ab-9516-bef562ac799c"), 15f,
                    new Guid("672b75ea-7129-4421-b77f-3a8a3536bf0c"), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 52f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("1dd10cb1-0907-40c5-85d5-6393670e2b77"), new Guid("79842127-ff0c-4d4f-834e-f406d6ee5803"), 15f,
                    new Guid("672b75ea-7129-4421-b77f-3a8a3536bf0c"), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 37f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("90ece3a7-cff1-421c-9077-3ec9f5ea0221"), new Guid("f8cde434-4a64-42f2-9a6d-c2edc6b6874a"), 15f,
                    new Guid("0f436b8c-a3ac-49bd-9095-82f0c34443c3"), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 51f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("9d9260ac-cbd8-4ee6-91cb-78e1c4a20252"), new Guid("b0c2afef-b795-4964-828c-8383ea8c8d1f"), 15f,
                    new Guid("0f436b8c-a3ac-49bd-9095-82f0c34443c3"), new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("18f3011f-2c89-4d48-93f6-281b8cd3f564"), new Guid("35de9418-09dd-4a17-9bb8-f1284b9d5f44"), 15f,
                    new Guid("326db534-c474-4c23-9ed1-abd8590c7b26"), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 89f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("68e1880d-0d1a-43dd-b442-f173d2c2ce96"), new Guid("8229750b-934a-485d-b956-5b61b15f3842"), 15f,
                    new Guid("9407bfe2-edfa-4706-a380-86e4b99cb460"), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 71f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("451468c9-16c0-4b12-9567-292873b504da"), new Guid("a90595f6-0eb5-4e98-92a2-7cc7dc318fd2"), 15f,
                    new Guid("8cdcc350-a823-46ba-8a77-dfb74634bab4"), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a2ba8292-1943-4621-881b-d4fb24f81637"), new Guid("751941a2-31ff-4215-8d6c-2fec3a71119f"), 15f,
                    new Guid("51c71bd7-7ee0-435b-955c-b6d83440fcfc"), new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("26768819-72c0-4c17-9faf-c3b58a4125b9"), new Guid("65e1e47e-978d-4fb6-b70c-c21606c46201"), 15f,
                    new Guid("6b2ba41d-6012-4b85-9693-b3753ceeaf35"), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 31f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("e9d0aa80-0c96-45af-ad48-892b59621a2c"), new Guid("87f84401-b5ec-49a4-acd2-f8210f97c786"), 15f,
                    new Guid("ad86e1ee-3ede-482f-a0fb-745cb7574946"), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 47f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("4bce0c29-d6f5-46e4-bfe3-ba2c06029322"), new Guid("75dcbaa7-b81e-4408-8e7f-a87ff8df645a"), 15f,
                    new Guid("54084bb4-6dae-474a-b4a8-56dfbe22e860"), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 39f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("b9adb25a-3294-48af-b3c9-f7aae6a22874"), new Guid("aa2db8c2-8032-4975-b269-5715ac831baf"), 15f,
                    new Guid("7db22681-a84b-4b50-81f4-f0d7faf90d8e"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 33f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("e2c72187-236b-4000-bbe7-5e69fd269fe7"), new Guid("ddfb597c-9292-41d9-9fe6-9f35312a7f79"), 15f,
                    new Guid("68822c17-fa38-4591-b440-8ec19434d52e"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 72f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("5e04f83c-7207-44aa-9fb5-fd0a7ed787f6"), new Guid("9c11e171-b4f3-45c7-90f5-6166a18f253b"), 15f,
                    new Guid("b1f55bec-8192-4d30-b941-4e1117d19726"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 57f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("c5eefa20-ed56-4e6d-9772-65b23103e6b4"), new Guid("1957c61c-4a46-40aa-9799-b2243b174686"), 15f,
                    new Guid("b1f55bec-8192-4d30-b941-4e1117d19726"), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 32f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a14b25d9-3644-4275-a7ea-e0e881ea56f8"), new Guid("00583341-e1e0-47eb-b2b8-ac45be6dfab9"), 15f,
                    new Guid("169adca6-6012-4b0d-9e70-2f6263fb0ccf"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 83f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("82505f23-d966-4086-b991-e43ba121d74b"), new Guid("31cf44a3-a7bf-4080-8cb8-8941a31488d3"), 15f,
                    new Guid("169adca6-6012-4b0d-9e70-2f6263fb0ccf"), new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 11f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("3bb37dbb-edb6-46ad-a687-f9cc524935b7"), new Guid("ad3890ed-651a-4458-88e7-d2ad6339fb01"), 15f,
                    new Guid("f468b6d4-9555-4231-b16a-d92b845506cc"), new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("b7c945ff-0c4b-4e27-8f3e-1440b5660d0c"), new Guid("4d138266-e097-40a2-9fc6-8818ad7a01a4"), 15f,
                    new Guid("8b021ebd-deb4-4cab-b27f-4248d8c9360b"), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("52b3986e-771e-4c4b-99df-36e0b7976bd4"), new Guid("87f84401-b5ec-49a4-acd2-f8210f97c786"), 15f,
                    new Guid("cc1522be-c5cb-4355-9068-45d1f65a3b4d"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("1c15bf78-27d0-4563-8103-881f52af68d3"), new Guid("4a53eaa5-57f2-4005-a4e4-9ec2eb96d260"), 15f,
                    new Guid("cc1522be-c5cb-4355-9068-45d1f65a3b4d"), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 73f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a039f726-76a7-45aa-849d-379a4df9d336"), new Guid("7ee64dbb-dec5-48ae-8533-1145e51bf77c"), 15f,
                    new Guid("cc1522be-c5cb-4355-9068-45d1f65a3b4d"), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 64f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("835d2ee4-fe74-4ff1-aaa5-4b8eef5712b2"), new Guid("a805a319-f362-4db7-bc45-a508b265b4e7"), 15f,
                    new Guid("7ebb92f6-ef08-4bd0-b15b-17e237f264b1"), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("2e40662b-df8d-460b-b188-aaeb3c7e2f77"), new Guid("1665863a-8e1f-4f3c-b259-ea05b0d3fc1e"), 15f,
                    new Guid("bcb8bb35-9374-4145-9549-86e783d675d6"), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 69f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("ad447add-a6f8-42ba-be1a-e1fafe2d831c"), new Guid("ef623efc-0f1c-4d0e-be98-76dd335269ce"), 15f,
                    new Guid("a8978385-f65a-4723-a127-88b66ef928eb"), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("08095124-482d-4db8-b41f-5837b36925d4"), new Guid("a2afc6ec-7075-469f-a406-a748b5d5dbf9"), 15f,
                    new Guid("7718ee5b-5349-49c0-bf0a-540cb1abc679"), new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("3ab3b3e3-eb47-4a5d-952d-46ff250b77e7"), new Guid("ddc0bede-2493-4286-89b1-c28c29ee1f20"), 15f,
                    new Guid("0f97fb05-16f0-4ec8-8aa7-04c58555ceb0"), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 84f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("df2ef8b1-0e30-40e6-96ce-008684c11335"), new Guid("51614053-c32d-4116-85e2-fcf1c5cff12b"), 15f,
                    new Guid("a7cd7445-7cab-4fba-95e3-00905f4d4b03"), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a94f05a7-e2be-4e6d-a384-d5a81686107e"), new Guid("e4106904-1f90-48ab-9516-bef562ac799c"), 15f,
                    new Guid("a7cd7445-7cab-4fba-95e3-00905f4d4b03"), new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("199b7a03-c071-4915-98ac-05eaa7640df2"), new Guid("35de9418-09dd-4a17-9bb8-f1284b9d5f44"), 15f,
                    new Guid("a1158464-2596-4b1e-98fa-346458bcde95"), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a2976e9a-3829-42cc-89c0-84eb7148aa88"), new Guid("87f84401-b5ec-49a4-acd2-f8210f97c786"), 15f,
                    new Guid("a1158464-2596-4b1e-98fa-346458bcde95"), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 78f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("fde600af-efde-4b78-8f3d-9aca7432ac69"), new Guid("1957c61c-4a46-40aa-9799-b2243b174686"), 15f,
                    new Guid("345bbd5a-8b14-4610-9748-76dfe95eedfb"), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 82f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a264e76a-c22e-4dfb-ad3c-fd307684881a"), new Guid("f43d07f2-e196-4db3-b52f-5cd1ab8fdc92"), 15f,
                    new Guid("345bbd5a-8b14-4610-9748-76dfe95eedfb"), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("40e379e0-23f3-421b-af7c-20f3fa395862"), new Guid("b295d075-c787-46f4-a97f-8b917b179e6a"), 15f,
                    new Guid("345bbd5a-8b14-4610-9748-76dfe95eedfb"), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 43f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("e2f2a99e-0876-4764-bc41-a8f484a02f1f"), new Guid("02905ffd-718c-432d-84be-290433bdcd2e"), 15f,
                    new Guid("345bbd5a-8b14-4610-9748-76dfe95eedfb"), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("8df61052-e4de-4faf-be4f-0c15ab9a97c9"), new Guid("1c90ec1c-c083-44f8-ba2d-c0cb2d14c032"), 15f,
                    new Guid("aa8695c1-9c9c-4451-a9a5-73099dcf6d4c"), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 56f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("784b330d-d3fc-4e34-b717-82053bfcad61"), new Guid("e4106904-1f90-48ab-9516-bef562ac799c"), 15f,
                    new Guid("aa8695c1-9c9c-4451-a9a5-73099dcf6d4c"), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 38f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a9d3aaba-1b2a-47ba-8750-1226c3cb1c67"), new Guid("5f919830-7710-4df9-8084-ac85a99bf67c"), 15f,
                    new Guid("3d9e8df5-8171-41d1-9c95-e60d49618722"), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("ba7b01fb-b411-4f2e-9a66-ea2d90c1fd52"), new Guid("af2a97f9-4d1b-4e3f-8fe9-0370250a05b8"), 15f,
                    new Guid("3d9e8df5-8171-41d1-9c95-e60d49618722"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 22f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("5bdda7aa-09c9-4752-9912-d98be7dbacce"), new Guid("4292b728-9c3c-4f0a-ae1b-92e4a16809ea"), 15f,
                    new Guid("2aecbcf3-a7f7-46b9-8b20-22c87557621b"), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("469845aa-2aec-44e7-bc35-661418292934"), new Guid("ae369793-8eeb-4476-9251-d5c0cdb8466a"), 15f,
                    new Guid("3eea9266-618a-4052-834f-b7615b1f4c31"), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 24f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("58e27c7e-d023-4c33-939d-819f29426659"), new Guid("af2a97f9-4d1b-4e3f-8fe9-0370250a05b8"), 15f,
                    new Guid("e7aeca24-0086-46f5-bd34-ffebdfc666f5"), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 67f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a7dce24b-442a-4e37-9594-a072e7e786dd"), new Guid("142193c6-222c-4bf0-9f7d-3478c21c876e"), 15f,
                    new Guid("e7aeca24-0086-46f5-bd34-ffebdfc666f5"), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 17f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("13e5cb2d-ba83-410e-b0c3-5d3322e4140a"), new Guid("9dc08e89-d59d-4263-84fa-7a93d9742c8b"), 15f,
                    new Guid("e7aeca24-0086-46f5-bd34-ffebdfc666f5"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("138761b0-be1f-4bba-abae-d1640775d3d4"), new Guid("a805a319-f362-4db7-bc45-a508b265b4e7"), 15f,
                    new Guid("f3734ff9-65ed-4a4f-b93a-bf1c8b3d9f34"), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 61f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("cac3504b-c3e2-40e6-90bd-d76fa99cbebd"), new Guid("a6dfbb9c-a399-451e-9783-d13b81d6f37c"), 15f,
                    new Guid("f3734ff9-65ed-4a4f-b93a-bf1c8b3d9f34"), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 46f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("8d2a1fb6-35fd-45c7-a71c-36f9a962f06b"), new Guid("5137b75c-632e-4842-b03c-ede929bd76b7"), 15f,
                    new Guid("7718ee5b-5349-49c0-bf0a-540cb1abc679"), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 8f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("39118355-508f-4fdf-bb9a-8b47cba19e82"), new Guid("a5135e31-991f-48f2-b140-34dcc4818882"), 15f,
                    new Guid("7718ee5b-5349-49c0-bf0a-540cb1abc679"), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 16f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("ff3c4735-f465-4f4a-9e8a-519eb7f528ab"), new Guid("99ee3390-1cb5-4829-9201-441bdb8b6e01"), 15f,
                    new Guid("7718ee5b-5349-49c0-bf0a-540cb1abc679"), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("f83ad3e2-c2a0-4804-bdae-6fe6a2b7a5e7"), new Guid("99ee3390-1cb5-4829-9201-441bdb8b6e01"), 15f,
                    new Guid("6e64c121-7f43-4fdb-bc63-1625f98bc369"), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 34f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("adfc2f61-6465-425f-94c4-9e757e5b39de"), new Guid("5137b75c-632e-4842-b03c-ede929bd76b7"), 15f,
                    new Guid("8c7030dc-d83a-4fd3-baf9-9b07f9c48e3d"), new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("1e60aabd-60a7-49f3-9994-fd861cb02bcd"), new Guid("e5143b1d-3972-4b32-ab30-53d6a2acd926"), 15f,
                    new Guid("ff7fc02c-ceff-44a3-86f4-9078fa415589"), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 13f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("db5a0d0f-7018-4559-8398-904f7c1a49ea"), new Guid("51614053-c32d-4116-85e2-fcf1c5cff12b"), 15f,
                    new Guid("f2799e79-faeb-4cee-8266-ec834fc14899"), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 28f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("e224abb0-ca1e-4c0f-991d-2de4dad47659"), new Guid("76ae89b0-7394-426b-810f-20981c4a7180"), 15f,
                    new Guid("37393e43-06eb-4b09-8beb-ff4db70c605f"), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 36f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("2a8792cf-d1e6-44cf-8ea0-a391274749b7"), new Guid("e5143b1d-3972-4b32-ab30-53d6a2acd926"), 15f,
                    new Guid("37393e43-06eb-4b09-8beb-ff4db70c605f"), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 18f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("da3378a8-9fe1-4278-af87-76c975e61387"), new Guid("a805a319-f362-4db7-bc45-a508b265b4e7"), 15f,
                    new Guid("21b51626-c0a3-4cb9-aa2a-07f77ec17836"), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("07224d73-0f3e-4c91-b4a0-df8757d8b898"), new Guid("3d63c1aa-154b-4e44-9b35-14f77ee9d2a1"), 15f,
                    new Guid("ed32e66a-5371-400c-bbad-0cbe46d04aeb"), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 27f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("3eae755a-0f5d-4bbd-a355-202421eb51a4"), new Guid("99ee3390-1cb5-4829-9201-441bdb8b6e01"), 15f,
                    new Guid("60b2f62a-5fc0-46bd-ad79-c25c0ef2b186"), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 53f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("e74ed8be-815c-4694-91d3-5048936d45e2"), new Guid("b295d075-c787-46f4-a97f-8b917b179e6a"), 15f,
                    new Guid("5c0ab4a6-b737-43c4-9411-dce8cb5f1908"), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 54f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("16cf9ab8-d371-4d7e-8770-90f5acc17192"), new Guid("b295d075-c787-46f4-a97f-8b917b179e6a"), 15f,
                    new Guid("5c0ab4a6-b737-43c4-9411-dce8cb5f1908"), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 41f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("7be8076f-d4ad-40bd-8f38-f13ed06412ac"), new Guid("e0020ba8-d4e6-44b3-91d6-db20279ffbe8"), 15f,
                    new Guid("40acd428-cdd9-4d26-bc87-69c2bf304edd"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("86d054b9-5308-405c-af02-f5d9c2968674"), new Guid("4292b728-9c3c-4f0a-ae1b-92e4a16809ea"), 15f,
                    new Guid("5c0ab4a6-b737-43c4-9411-dce8cb5f1908"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 29f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("9a1aa81e-fd9e-48e0-8f66-63bea15212c3"), new Guid("2fd92079-a427-4c9d-941a-6206ac35ea7d"), 15f,
                    new Guid("5c0ab4a6-b737-43c4-9411-dce8cb5f1908"), new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("6191f410-1c58-4072-8807-f7c643a42565"), new Guid("e4106904-1f90-48ab-9516-bef562ac799c"), 15f,
                    new Guid("a85dbc26-190d-409a-ae6b-e0732c74caf8"), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 87f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("da9b4dfb-ad22-441f-b623-1dbaae74e247"), new Guid("d8259e4d-ed60-4dd1-a62b-95c241a1e2cb"), 15f,
                    new Guid("a85dbc26-190d-409a-ae6b-e0732c74caf8"), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 23f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("a84d6381-d533-4dc9-b32f-aa7c1a7222ee"), new Guid("526ac937-c3a7-4a2f-a9bd-760f874f9a76"), 15f,
                    new Guid("eb05e4ea-d6a2-4fef-9899-fbc5c0154b41"), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("8c0807c0-a840-47f9-b5e0-08653e0f8e9e"), new Guid("4d138266-e097-40a2-9fc6-8818ad7a01a4"), 15f,
                    new Guid("c75fb3d1-44bd-4e92-b238-ddb4c1d1c6fc"), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 42f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("27760a31-43a8-4498-8271-5560690604c5"), new Guid("51614053-c32d-4116-85e2-fcf1c5cff12b"), 15f,
                    new Guid("6dd1db4d-a628-4dd1-9088-0d587d2e4e5c"), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 93f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("c7aefa44-79ad-4021-8594-c8c294049fcf"), new Guid("3d63c1aa-154b-4e44-9b35-14f77ee9d2a1"), 15f,
                    new Guid("6dd1db4d-a628-4dd1-9088-0d587d2e4e5c"), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 81f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("57e98433-176b-4bfa-8170-3f3bec814e62"), new Guid("79e20d58-cddb-4f83-ae8f-91f8343a7ae3"), 15f,
                    new Guid("6dd1db4d-a628-4dd1-9088-0d587d2e4e5c"), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("af82dbd7-8403-45e3-a36f-b54821b84988"), new Guid("32174ffc-6ea1-4b43-a31e-b531d44f724b"), 15f,
                    new Guid("6e64c121-7f43-4fdb-bc63-1625f98bc369"), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 77f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("b45db5c2-ddde-4c6f-8459-3ad38aafa63b"), new Guid("b20423b9-4b11-4bb3-9196-68bdc1909bbf"), 15f,
                    new Guid("6e64c121-7f43-4fdb-bc63-1625f98bc369"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 58f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("520ed688-dd19-44ca-9ff4-9ee50626b822"), new Guid("af2a97f9-4d1b-4e3f-8fe9-0370250a05b8"), 15f,
                    new Guid("5c0ab4a6-b737-43c4-9411-dce8cb5f1908"), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 19f, 1
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Rentals",
                columns: new[] {"Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status"},
                values: new object[]
                {
                    new Guid("3449ce6b-8929-4c7b-9c30-c56d0c31c650"), new Guid("87f84401-b5ec-49a4-acd2-f8210f97c786"), 15f,
                    new Guid("40acd428-cdd9-4d26-bc87-69c2bf304edd"), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 59f, 1
                });

            migrationBuilder.CreateIndex(
                "IX_Rentals_BoardGameId",
                schema: "r",
                table: "Rentals",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                "IX_Rentals_ClientId",
                schema: "r",
                table: "Rentals",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Rentals",
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