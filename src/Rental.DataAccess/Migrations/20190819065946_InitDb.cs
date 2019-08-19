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
                    Price = table.Column<float>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 19, 6, 59, 45, 533, DateTimeKind.Utc).AddTicks(6365))
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 19, 6, 59, 45, 538, DateTimeKind.Utc).AddTicks(2836))
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 19, 6, 59, 45, 537, DateTimeKind.Utc).AddTicks(9115)),
                    FinishTime = table.Column<DateTime>(nullable: true),
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
                values: new object[] { new Guid("759b67f2-c1b0-4d9c-bb5b-a0092b9bba3f"), new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 81f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0927c8d0-2504-4b8c-8930-917c3c8bad02"), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 176f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("29a7b295-4174-4c3a-a52a-f913157b0eb3"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 84f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("271f61bf-980d-46c3-8d50-77133cfda189"), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 189f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("663bf7ed-b5e1-4e79-a7ed-c32968ccd523"), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 102f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c9a3fb5d-dafd-4f85-baf8-1a9a0ce47576"), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 74f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f7f75756-43ba-44c4-8e97-0dca8c2b966a"), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 63f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("18b9b42f-2a44-4d11-b4dd-abf6717e651d"), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 126f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c4c02a77-cae0-495d-923d-002491504c65"), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 134f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6d9067cb-3db7-444b-bab4-0bae408fa93f"), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 202f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8be30135-496a-4b2c-b3c1-26f1d1e6fab1"), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 152f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d8d407c7-e89f-4e4b-a40d-3e24e39d3b10"), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 247f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8de45cbe-a3ed-41e1-b46c-05de6842d72f"), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 84f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("cc338bc1-814b-4eef-881e-d65bc1c8a0ec"), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 211f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f872b678-dc86-4c54-93f2-73cad03c38fe"), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 159f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("61b9b069-ea68-464f-afd1-8575723e640a"), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 206f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("000f78eb-ff8e-44fd-bf9d-aaa0c5e67dc6"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 129f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2e4ba96f-17da-4205-b9a3-b6b06411b2fa"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 158f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("937f814e-4e38-4cc6-8970-b00f47630684"), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 77f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2f77b350-2f72-42fb-950a-627784dbc35d"), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 78f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("24ea4dd9-3d5c-4f3e-afeb-5900b0509eda"), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 209f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a0bc55cb-1a28-4483-bcf8-96cfdb422e6e"), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 183f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("10b874ea-ce49-422a-a830-793828b4d4da"), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 108f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("e1e1e750-16de-45cc-bd44-3b09cc42a072"), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 223f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6adcf959-7486-4da9-ab03-55b2a7615816"), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 234f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7e5f5fa1-50c6-4665-b153-fd40249f9b66"), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 192f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("58f7b588-7b8e-4be3-be55-ae59eda7e8cb"), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 188f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2b1dd15a-63a5-4e6b-b944-a190dcd520d1"), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 209f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("72085cc2-634f-481f-a2dd-83aba93d86d0"), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 97f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("df8e65d0-cbe1-4902-b536-f701bebdc636"), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 124f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0c75205f-d107-4f38-abf4-f360c1fed672"), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 170f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3eef0f39-9b2a-4f5b-b57a-d72f13f488c1"), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 208f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("44ab4ca9-a1a1-4a27-ad5c-99df438b06c8"), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 229f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3998d2b8-21e1-4a1c-959c-2f9e3c1324b6"), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 129f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("98f1df2b-daa9-4fa3-9e9a-f2f257511638"), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 60f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1d2d517d-f9c9-4029-9098-dcbbce615505"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 170f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a77f7dc7-c855-46c5-b055-7045a9412465"), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 240f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("a78c3a40-179a-4e4d-9617-6b1711f1ce2e"), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 192f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f88778c6-ece9-4c2f-8bf1-cf2cb97eae89"), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 137f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f02d2f3c-f37a-42f9-ba18-f9c0ab50afdd"), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 171f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f3e32712-2c79-4d73-996b-123698aa2139"), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 120f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("acc85374-67c0-4e3e-a4ef-3f335be4ad15"), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 231f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("7ed6ac7d-fc6d-4d7d-a6ae-4c082481fe84"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 182f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6e9b7465-7290-4021-82b9-dfaf54d5e29e"), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 168f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("08882a51-d98b-44cf-963c-ed0ff871c01e"), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 209f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("db3fc5cc-6f52-4712-bf32-ca697c1b2377"), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 185f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("217a436a-a62a-4dd0-a21d-aad8f6eb70b9"), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 100f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c8f08336-f853-4f21-ac0f-86fefbbafe6f"), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 62f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("dc76a868-f80a-45d1-8cf5-cd3c1367c606"), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 197f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("b31781dd-6b63-4ac3-8ae7-11af78a4eefd"), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 241f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f6956d1a-baac-4958-957b-3c050dc76d5f"), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 58f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("383b29a6-d7e4-48a4-9498-a565f76bcc37"), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 139f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2bc4f63c-7f79-420e-894a-13b1f47144d3"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 53f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1bc4e561-fc8c-4fa3-9c35-80f57a6e7f2a"), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 78f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("20594c10-25e4-4183-9735-a627d27363a1"), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 132f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("88b841b5-6760-4db8-a01f-a8c1b91483cf"), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 191f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1468e85e-205e-4e6a-9263-f6dc65407ee1"), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 244f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0102b600-3309-467c-9455-edf3265544b2"), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 220f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("74a8acf7-40aa-4165-9235-938973709f8d"), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 149f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2046a240-90b7-42f8-a13f-5245764de619"), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 221f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0c5ae44e-683b-4743-b7d2-216c864dfdc4"), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 233f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5384fe18-c4a4-47b2-b44d-5ecd8e6837d5"), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 233f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("764d4177-e693-44eb-9bf6-bb13a53feef5"), new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 154f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f5ae3bc5-ab73-4d7b-934d-a3dfd0ff408f"), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 114f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("5bab3075-b9a7-449c-b427-b5fb57eb6066"), new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 213f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9ba8cca0-c820-4950-8077-9755c0c7c63c"), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 112f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("0b8ba02f-5e23-4c5e-92e5-50253460ad4f"), new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 105f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8cafd90e-84ae-4b22-8dbf-4b18e0475460"), new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 77f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("6e9c7b74-946a-41ff-94e5-584adcc7f42a"), new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 120f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("200d9cac-d6db-4855-821d-028017a8f4b3"), new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 180f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("04d85352-b12b-48dc-913a-734e2284dc01"), new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 72f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("70db1271-fb8a-4024-aa8a-4d40ff20835f"), new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 62f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ae4af7ec-3fc4-4b36-9ffd-a75dac1bf4b7"), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 133f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("d101f0bf-a576-41ba-bd6c-364b3c950445"), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 153f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f96d5518-3418-4a34-8e92-37da6c877d07"), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 193f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("992732af-7083-4cf8-b48c-fa34854c8c29"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 222f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("77bcf389-4541-41ce-ba6c-a5e89ac5ad00"), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 211f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("4192bba0-f6d1-4f57-be9d-ba9bb2a2a4c0"), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 223f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("416ac003-1847-4fbf-88fc-8f8c3386be7f"), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 51f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("99eea78c-acc8-4c9a-9cb6-776d8d29db8c"), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 88f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("9ae1ecd5-f630-479b-abca-1b0f4784e748"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 142f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("1d6f38fd-9455-444f-a9a3-e954630316ea"), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 141f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("38aeeb95-c2e9-4cfb-be40-6cf77131f193"), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 111f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("300fa3a7-7017-4f06-b1b7-5305dffe9e75"), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 94f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("62b1eae5-fe98-41ff-83dc-12273e5641d7"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 132f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("3703f5fa-a316-4ed5-9543-1ae72bfd501d"), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 118f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("2019709b-8ffb-48db-a01d-ffd759d7df21"), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 186f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("54809fcf-04d4-4285-90da-ef6b8482b5a9"), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 209f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("f09a3f0f-6bd4-4177-95cd-dcba54c26203"), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 159f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("cb8ae063-371b-47f4-8023-1b3b25710efd"), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 197f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("512d8ea9-0856-4f3f-9791-f6ca30ec5e85"), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 169f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("78663cd1-1da6-4ad9-abc1-4e5ea472ce62"), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 71f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("8bf83716-ffbc-4b5d-9bee-32686bb7f7a8"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 114f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("12e52f4a-589f-450c-8ec8-d502e8180d70"), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 111f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("c6072459-6cfa-43b4-a4d6-cd16d4625b2f"), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 161f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("48902c82-efd9-48ae-9112-b1717096d70e"), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 116f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ba28df39-cc26-47bf-9e0e-e586a6317f96"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 157f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("63996227-f5ed-4898-a96e-7269967204eb"), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 220f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("ae40078e-00cc-4521-bbcd-6fb5f7321a3c"), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 198f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "BoardGames",
                columns: new[] { "Id", "CreationTime", "Name", "Price" },
                values: new object[] { new Guid("eba74825-fcc1-4e23-9792-e0a7eba0bc5e"), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "alias", 70f });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("db058bd3-9968-4f64-bc53-593ae62b5c84"), "1-335-431-4304 x55232", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "lilian_macejkovic@ledner.name", "Torrance", "Reilly" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ab1754fe-d2a8-46c1-91c2-d85176c19d6b"), "(557)464-4605 x58043", new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "marisa_price@schulistsmith.com", "Declan", "Cummerata" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("12c83d4a-61ec-4f91-939a-154c49778e50"), "462-653-6128 x604", new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "emmy@bergnaum.info", "Gail", "Carter" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("77554a2c-bc11-45ec-8dc1-ef21d7031026"), "(376)121-5766", new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "diego.prosacco@jaskolskimorissette.us", "Hilma", "Sanford" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("648c3d21-79d6-42c7-bc2d-19bd8209398b"), "175.314.2232 x18517", new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos@ullrich.co.uk", "Aurore", "Hudson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ddde7243-5b24-4438-a86b-cbae40d8421d"), "1-658-166-0716 x87563", new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "freddy.kling@nadermedhurst.co.uk", "Cyrus", "Spinka" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d82b9695-2d66-4267-8656-4553379f4778"), "611-181-0378 x820", new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "wilhelmine_dubuque@olson.com", "Drake", "Corwin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ec4563d2-7fde-454b-b1fe-c57293fbfc2b"), "773-636-3547", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "velda@naderhilpert.co.uk", "Carlie", "Ratke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2390c722-ccc8-4902-949a-66ce38f93d19"), "1-158-405-3185 x335", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tre.hettinger@block.us", "Abigayle", "Wunsch" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cc4e9d4c-dc13-4c77-90df-0f7e9ece7d38"), "388-887-4745", new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "melyssa_lebsack@larkin.ca", "Judge", "Bergnaum" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ef41ac83-0ea5-4df0-8de3-1942e1b80214"), "(832)310-2542 x80454", new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcus_renner@hammes.co.uk", "Daphney", "Reichert" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5c7f2231-8414-4fdf-914a-1daa3e0a0da4"), "673-722-0822 x225", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "destiny.lakin@collins.com", "Lavinia", "Quitzon" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7aedb55a-0863-4745-bd3b-33caaaffdedf"), "(524)088-7478", new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "elise.abernathy@fahey.biz", "Blanche", "Brekke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4527a853-8708-4bce-8d31-0ae4014c9beb"), "(433)116-2478 x370", new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "willis_rutherford@rath.com", "Michele", "Orn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bf2b6019-6228-4461-8baf-d10888cdcbe8"), "1-561-803-8550", new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "paige@hintz.us", "Juliana", "Jaskolski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ee064d8e-51a2-4b34-a0ce-817a316b21a1"), "(538)860-1661", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "aniya.klocko@beahanchamplin.com", "Fleta", "Kshlerin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("41478677-5690-43c0-b254-c31efcd00b15"), "802-365-1040", new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "bernadine@wintheiser.ca", "Donato", "Brown" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9c1be3d4-509d-4368-9bad-fa3d92e2a5b8"), "433-430-3520 x46222", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "carolina@kuvalis.ca", "Cristina", "Keebler" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("66e8ee47-c0f7-4a9f-8074-433b2277afa6"), "454.130.4254", new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "eriberto_ebert@simonis.co.uk", "Garrick", "Kris" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("40acfaed-cc67-4c7f-9565-59b007008fd1"), "1-377-156-7532 x42827", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "erika_frami@gibsonbayer.info", "Esperanza", "Swift" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("17a32716-37c7-468e-a1e4-9bcdd593b390"), "(542)031-2861", new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "willis.pollich@fahey.info", "Marjory", "O'Kon" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("17c761b5-e928-4c5f-a1e8-e8ca4455f05f"), "1-614-463-4315", new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "matilde.pfannerstill@kuphalthompson.biz", "Bria", "Parker" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4a4a0c72-40c5-4e88-9d42-4b8ab4194f9b"), "1-525-846-0631", new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "herminio_walker@wisozkgreenfelder.uk", "Buford", "Feeney" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c13f91d9-579a-4ff8-bd1e-a92b719e5310"), "548.237.5006 x487", new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcelle@ruecker.uk", "Emmalee", "Ziemann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("83c5d933-4316-46bc-a2df-d73d0a73e5a1"), "1-157-876-0340 x532", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "delbert_casper@mayerkoss.us", "Adan", "Schulist" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("33d56b76-b5a4-4acb-807e-13728e53e71e"), "826.844.3675 x02147", new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "clementina_rosenbaum@donnelly.co.uk", "Marguerite", "Bartell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cd51e5f1-21fe-4b6d-a0db-f7720a371393"), "1-011-010-6875", new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "arlo.mcclure@sauer.info", "Dean", "Lueilwitz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c7045f14-66a6-45eb-9373-691bdfaf4d55"), "1-071-718-4114", new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "nicolette_dooley@predovic.us", "Gail", "Weber" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("71adf1a5-b503-485a-85bf-8c9448d60ade"), "040.512.3410", new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "connor_kunde@larkin.info", "Zoila", "Klein" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9e16ac8e-2582-48bb-8b80-639026237579"), "(373)755-0205", new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "reuben@gerhold.ca", "Cortez", "Weissnat" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bc112d95-7cac-4b5a-9f8d-9265e842fa1e"), "603-357-5275 x84128", new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "domingo_ohara@hoppe.name", "Wilber", "Dach" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("079f6d83-9a71-4171-9be7-f5f2c3f29480"), "577.810.7447 x51180", new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "grayson@stromanvonrueden.co.uk", "Maria", "Harber" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("335ed577-7e77-4dfc-abc2-2b64d31153a1"), "(381)552-8217 x041", new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "vernie_ferry@effertz.info", "Liza", "Turner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("68a4ffee-3644-48b6-9640-26b4016e61c6"), "815.275.2255", new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "abelardo_carter@schmidt.us", "Eudora", "Kiehn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("668620e1-869c-404b-96b3-4d73b74cab34"), "1-740-044-4233", new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "kelvin@mccullough.uk", "Juston", "Stracke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a0426631-403d-4ee2-b221-ee4222575319"), "1-206-605-5177 x4028", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeanie@oberbrunnermann.info", "Leif", "Dicki" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("757a500d-7329-4f23-b336-5b10036c8430"), "442-523-3613 x76341", new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "tanner@littelmraz.com", "Chauncey", "Erdman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d4e5f11a-1164-40e8-9045-2a2fad9042ae"), "234-312-1524 x21686", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "reyna@hodkiewicz.uk", "Brown", "Wilderman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("661d8c46-df31-46d4-879e-93859b80f61e"), "(311)134-3606", new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "carmelo@sauerfay.uk", "Lexus", "Champlin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0bccca59-c86c-4b4f-bdc1-04a001aef558"), "1-200-782-5188 x2141", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "kolby@white.ca", "Natasha", "Kris" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b67815ce-327a-4755-9514-156cfc96f156"), "313.516.6062", new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "mitchel_hegmann@predovichills.com", "Helmer", "Lesch" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a1a3b4db-4edc-41d5-82d0-7487221e9930"), "668.528.3108 x523", new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "camren.lueilwitz@beerstroman.biz", "Concepcion", "Runolfsson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a0b15085-3865-4aeb-ac07-3d574edef363"), "(724)786-5736 x335", new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "talia@bahringer.com", "Rodger", "Gusikowski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("83c90289-515b-4cc6-ad0b-fe17a55f48ce"), "872.158.4265 x0186", new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "madaline@pfannerstill.ca", "Geovany", "Morar" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0ab65d02-2bc7-4ce8-9ee7-6380c25dfd79"), "336-158-2383", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "stefan_ratke@wolfgleason.co.uk", "Nathaniel", "Howe" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("297ba073-ec9e-40a8-8e84-970d599a8714"), "113.333.1822 x842", new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "kaylie@pollichwatsica.name", "Kenyatta", "Roob" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("17d7b325-d55d-4c07-814c-7dcba0e6e537"), "834.770.3644 x401", new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "neil.schultz@wittingwuckert.biz", "Eden", "Jacobson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("af4d0057-d868-4176-9147-c9ba5831c9c8"), "708.186.7057", new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "tillman_schmidt@ullrich.name", "Joesph", "Mitchell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0171793c-8f12-48c4-878f-3f16e6d56cfd"), "1-470-850-8152", new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "adolfo.schroeder@wolfledner.uk", "Rhianna", "Batz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("66ecb9c7-fd9f-4bd6-a741-675438462691"), "1-247-267-0772", new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "justus.bosco@rogahnweimann.us", "Georgette", "Weimann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("80d5b6d4-4ac9-4304-8b58-145fb06c42ca"), "(653)672-8544", new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "gudrun_schaefer@ebertlegros.com", "Vicente", "Hintz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3f878282-0257-4c68-b54f-b64a54456442"), "1-720-147-2828 x2871", new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "elmira_turner@graham.ca", "Gertrude", "Brekke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("09918721-6487-4000-8406-3eb8b0426e4b"), "485.320.8223 x6128", new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "adaline_willms@christiansen.uk", "Daphney", "Schaefer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2eac0ebc-8eae-4807-a11e-299fdc521c17"), "1-846-141-5240 x1214", new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "jamar_corkery@barrows.co.uk", "Davin", "Farrell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c45492d0-81a1-436b-95f7-5f63ad933d32"), "173.405.0423", new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "jovanny@berge.uk", "Kayden", "Witting" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0c8369fa-0de5-4a89-8d38-d3a0fff25320"), "315.152.5511", new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "rosemarie@luettgen.com", "Ben", "Walker" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f50a5028-c3a6-436a-a1f9-bcf4a0113e24"), "470-470-4172", new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.schumm@langhilll.info", "Litzy", "Stracke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f1c748e7-5653-4e94-b591-182a48bc05ec"), "(645)308-2668", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "teagan@treutel.com", "Mertie", "Weber" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bf198996-5637-4988-98f5-314a9fad6c5d"), "1-281-081-1740 x7525", new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "jackie@stehrhudson.biz", "Mervin", "Cummerata" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("fb8f6014-9d87-47ca-89b8-5f69b3da49a7"), "1-743-171-6076 x36665", new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "leonie_kassulke@zieme.biz", "Rowan", "Cruickshank" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3a3863d1-0284-4f21-b5d4-a2aed5b37a7f"), "526.067.4247", new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "haleigh@paucek.us", "Dovie", "Rippin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e92d136b-5291-47ae-96ed-d067a95790ce"), "040.301.8371 x84624", new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "carmen_marquardt@breitenberghaley.co.uk", "Elda", "Reinger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9b7774ad-1b08-41e8-b0e4-ad995dda2d7b"), "(142)376-7341", new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "carmella.miller@torphy.co.uk", "Ova", "Cole" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ed3a1eac-61e3-412a-a27a-c5b29bf85bf0"), "781-787-6806 x40540", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "christelle@hansen.co.uk", "Jordyn", "Bogan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("716bac35-bae9-4357-a007-2d368a0437c0"), "(473)420-8224 x55686", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "newell_kub@kirlinmorissette.co.uk", "Alice", "Reichert" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2151bae0-1303-4e3f-885e-304ef2b0c2ee"), "767.474.4747 x48634", new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "noemi.barton@strosinbailey.biz", "Tess", "Kovacek" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("25d6d73b-4e5b-4652-8093-d3280e06762e"), "304-325-2303", new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "angeline@johnsstamm.name", "Easton", "Bradtke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1fffca94-e57d-4747-805a-dc98af4af3d5"), "1-637-547-3210 x104", new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "raegan@gleason.uk", "Eusebio", "Abernathy" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("dc66d9fd-f32d-4fe9-ad3f-11782f75ae4c"), "1-715-266-5323 x178", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "savion_treutel@schummcollins.uk", "Annabell", "Lehner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("520239fb-937b-45bb-86eb-2db65dc33061"), "165-883-6610", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mathilde@jonesdeckow.com", "Kendrick", "Wiegand" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c0bc8ce0-b25c-4c93-bc74-91468f325c5d"), "450-151-7070 x666", new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "judson.treutel@ohara.biz", "Athena", "Klein" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("4ef30228-2585-402e-a75f-fe3cf0bd982d"), "(261)268-6832", new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "jaylen@rohanconn.name", "Chyna", "Orn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f084f04b-fe2b-4ed8-aa1b-beedfd12275d"), "418-551-4464", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "sandra.runolfsdottir@heathcotedietrich.name", "Cara", "Hermiston" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cc115b94-4c95-4bee-b4b3-2793a8425519"), "763-724-1731", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "marta@wehner.uk", "Aida", "Lowe" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c2040bd5-d007-41b9-bb0a-4029bbd9e208"), "(631)603-6168 x16178", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "garfield_sipes@nader.biz", "Efrain", "Renner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("fc6869d0-5c5b-46ae-936f-5c0d17214e7c"), "187.688.1175 x6023", new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "evert_tillman@kulas.name", "Elizabeth", "Hackett" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("09c72a91-3112-4377-9a7d-ea627bb07b34"), "781-356-4834 x2266", new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa@cassinbraun.us", "Colleen", "Baumbach" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("fa0e7b0f-c78d-4c3c-ad13-5a1fe3cdb905"), "(421)488-7267 x4161", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cleo@grimes.com", "Joyce", "Stroman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e197dc70-d81d-4ae1-a3d8-bafcf9952748"), "554.738.7085 x54830", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "syble.johnston@huels.ca", "Laverne", "Fadel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ae181790-eaee-4b0d-b260-742d424ee92f"), "1-334-681-1771", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kelsie@koelpin.us", "Nigel", "Von" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8e9c34e6-d6d9-495c-8776-938dacd02c31"), "280.640.7450", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "kennith@swaniawski.com", "Drew", "Herzog" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f00c9570-84c6-46fc-bb4c-2c953e10fbf0"), "(773)503-6846 x48432", new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "sandy@kunze.biz", "Esther", "Barton" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7dcbd706-ac22-49e4-9266-814ee26bd4ee"), "1-814-470-8471 x212", new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "price.white@ward.name", "Alison", "Block" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9e6b6e4a-8288-4698-9b2c-162a1ea51b1b"), "(056)401-3326", new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "hazle_walker@crooks.name", "Delfina", "Rogahn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b5f13e09-c8eb-46ef-ab4c-6f04e93e0b69"), "022-247-8026 x250", new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "pietro@reynolds.us", "Lorine", "Dare" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("68e13b8e-c8e4-476f-981e-614875af432c"), "1-311-152-2026", new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "joseph.willms@lubowitz.ca", "Vernon", "Stehr" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a7158e3f-78a1-4f70-b846-131aea522976"), "(372)406-8007 x6354", new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "deangelo_paucek@jakubowskistiedemann.info", "Vladimir", "Cummings" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8d030c87-5edb-410f-82af-c6fab8660a24"), "231.788.7145 x207", new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "carmel_keebler@robertsdaugherty.name", "Ruby", "Kirlin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c1f3a679-9f67-45c1-905e-ca0e1ed52e34"), "002.252.8605", new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.howe@ankundinglindgren.ca", "Bridget", "Shields" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ba502660-aa0d-4d83-a966-56bb839a266f"), "146-480-3230", new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "grady.harris@fadelbauch.com", "Rodger", "Turner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e4b64cb0-bbf1-431e-bde5-250c9ddec7be"), "(605)815-4832", new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "rhianna@zulauf.name", "Gussie", "McLaughlin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b8343d29-0b2b-476c-8aa5-9bafcd567a72"), "484-806-0874 x05400", new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "martina@kub.uk", "Jillian", "Nolan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f685db70-02db-4f4a-afc3-5c6f7de6b5bb"), "140-086-6825 x8706", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethyl.wyman@huels.biz", "Brennan", "Lakin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("cba4e37a-adae-4cdf-91ca-8b5abe13d365"), "(364)658-7654 x152", new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ethyl@balistreriblock.ca", "Eliezer", "Feest" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("03f6ff47-012f-48c8-9e16-f49625519cd2"), "(381)243-1058 x81515", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "antoinette@gerlach.com", "Adolph", "Stark" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("264024c3-52e1-405d-a923-c6c0007cbafa"), "(748)670-6415", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily@gerlach.name", "Jaclyn", "Willms" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5fef9da5-0186-4613-a825-34e3e69530a2"), "(016)057-0887 x7305", new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "lloyd@quitzon.ca", "Samson", "Schuster" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("173697fe-1065-426d-ac2d-6ec5b4669e81"), "743.146.7322", new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "elyssa_ziemann@legros.co.uk", "Cleta", "Grimes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("886d6073-7bda-4497-96fb-a7e2486ea9e8"), "183.724.6616", new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "ardella.dare@hoegerfahey.us", "Savanah", "Runolfsson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b7d8580b-0149-466c-b2b2-14bcad99cb66"), "1-647-416-8185", new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "taryn@walker.us", "Maida", "Vandervort" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("865eca9e-6662-474c-a77f-f9a12328fb39"), new Guid("08882a51-d98b-44cf-963c-ed0ff871c01e"), 15f, new Guid("520239fb-937b-45bb-86eb-2db65dc33061"), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 79f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d3094657-277c-4a34-ba91-bc2def795b0a"), new Guid("271f61bf-980d-46c3-8d50-77133cfda189"), 15f, new Guid("4a4a0c72-40c5-4e88-9d42-4b8ab4194f9b"), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a8adf366-c922-4df6-8fe4-d3a683356793"), new Guid("2b1dd15a-63a5-4e6b-b944-a190dcd520d1"), 15f, new Guid("4a4a0c72-40c5-4e88-9d42-4b8ab4194f9b"), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 13f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0eafb9cf-fe78-4d2d-8ba3-4f8844d99c1d"), new Guid("88b841b5-6760-4db8-a01f-a8c1b91483cf"), 15f, new Guid("17a32716-37c7-468e-a1e4-9bcdd593b390"), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 63f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6f1acb29-d056-49c6-9182-d66b0fb03c05"), new Guid("f7f75756-43ba-44c4-8e97-0dca8c2b966a"), 15f, new Guid("17a32716-37c7-468e-a1e4-9bcdd593b390"), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 59f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("94fca1c1-d879-48df-84b7-e05ade7b223c"), new Guid("512d8ea9-0856-4f3f-9791-f6ca30ec5e85"), 15f, new Guid("17a32716-37c7-468e-a1e4-9bcdd593b390"), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 24f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7e38feb1-037e-4c08-bae1-4baea7e7eb15"), new Guid("8bf83716-ffbc-4b5d-9bee-32686bb7f7a8"), 15f, new Guid("ab1754fe-d2a8-46c1-91c2-d85176c19d6b"), new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 9f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("26313fae-42e0-4f79-8d9b-509d7f09cd3b"), new Guid("ba28df39-cc26-47bf-9e0e-e586a6317f96"), 15f, new Guid("12c83d4a-61ec-4f91-939a-154c49778e50"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 57f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("27fb1c19-6471-4b6d-9dfe-95c301169c98"), new Guid("a78c3a40-179a-4e4d-9617-6b1711f1ce2e"), 15f, new Guid("77554a2c-bc11-45ec-8dc1-ef21d7031026"), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 64f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d359d42b-dbcd-48c8-9713-f58fe26f8a32"), new Guid("b31781dd-6b63-4ac3-8ae7-11af78a4eefd"), 15f, new Guid("648c3d21-79d6-42c7-bc2d-19bd8209398b"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2e8b4bce-b831-4d31-94da-dda116a354b6"), new Guid("992732af-7083-4cf8-b48c-fa34854c8c29"), 15f, new Guid("ddde7243-5b24-4438-a86b-cbae40d8421d"), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a3de18a6-7f9b-425b-95d1-47159bf5a7fb"), new Guid("f88778c6-ece9-4c2f-8bf1-cf2cb97eae89"), 15f, new Guid("ddde7243-5b24-4438-a86b-cbae40d8421d"), new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("dee39334-d947-468f-965c-a9443175e506"), new Guid("c4c02a77-cae0-495d-923d-002491504c65"), 15f, new Guid("17c761b5-e928-4c5f-a1e8-e8ca4455f05f"), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0030e4ae-f808-4dc6-8432-315aa9b68cce"), new Guid("9ba8cca0-c820-4950-8077-9755c0c7c63c"), 15f, new Guid("5c7f2231-8414-4fdf-914a-1daa3e0a0da4"), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 53f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0a5b4099-6610-4636-8349-84d8b9017255"), new Guid("416ac003-1847-4fbf-88fc-8f8c3386be7f"), 15f, new Guid("5c7f2231-8414-4fdf-914a-1daa3e0a0da4"), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("cfde05f2-b5d6-4588-b89b-61c664d854a9"), new Guid("000f78eb-ff8e-44fd-bf9d-aaa0c5e67dc6"), 15f, new Guid("7aedb55a-0863-4745-bd3b-33caaaffdedf"), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 26f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e6c57ce3-21f4-4c8e-9151-91a81405a1fd"), new Guid("12e52f4a-589f-450c-8ec8-d502e8180d70"), 15f, new Guid("4527a853-8708-4bce-8d31-0ae4014c9beb"), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 67f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8c03e8a3-f60b-429f-b17a-2a67f5e61e39"), new Guid("24ea4dd9-3d5c-4f3e-afeb-5900b0509eda"), 15f, new Guid("41478677-5690-43c0-b254-c31efcd00b15"), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7fa21c7e-5acc-4310-826a-74541647bc08"), new Guid("759b67f2-c1b0-4d9c-bb5b-a0092b9bba3f"), 15f, new Guid("9c1be3d4-509d-4368-9bad-fa3d92e2a5b8"), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 89f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("47ae6e74-5592-4566-bf45-4c441b83c7c9"), new Guid("eba74825-fcc1-4e23-9792-e0a7eba0bc5e"), 15f, new Guid("9c1be3d4-509d-4368-9bad-fa3d92e2a5b8"), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 8f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d9a590bc-1457-4d27-9fe8-f354943953a4"), new Guid("c4c02a77-cae0-495d-923d-002491504c65"), 15f, new Guid("66e8ee47-c0f7-4a9f-8074-433b2277afa6"), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 94f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("949345ad-d0ad-4378-b380-fbfeb0662910"), new Guid("ae4af7ec-3fc4-4b36-9ffd-a75dac1bf4b7"), 15f, new Guid("66e8ee47-c0f7-4a9f-8074-433b2277afa6"), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 36f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2acf9a1c-250a-474e-8747-75e86f9fb5bd"), new Guid("d8d407c7-e89f-4e4b-a40d-3e24e39d3b10"), 15f, new Guid("4a4a0c72-40c5-4e88-9d42-4b8ab4194f9b"), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 48f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("c288c4df-debe-4077-806b-52e829b42b0b"), new Guid("74a8acf7-40aa-4165-9235-938973709f8d"), 15f, new Guid("40acfaed-cc67-4c7f-9565-59b007008fd1"), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 91f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("68925cbb-b60d-4e31-8716-a85020a96d5d"), new Guid("88b841b5-6760-4db8-a01f-a8c1b91483cf"), 15f, new Guid("a0426631-403d-4ee2-b221-ee4222575319"), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 72f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2fdf740b-8766-4798-bc9d-27681e82b4e6"), new Guid("764d4177-e693-44eb-9bf6-bb13a53feef5"), 15f, new Guid("17d7b325-d55d-4c07-814c-7dcba0e6e537"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 58f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e9ea6ab4-54ca-48d2-99f5-e2ed45f5af68"), new Guid("ae40078e-00cc-4521-bbcd-6fb5f7321a3c"), 15f, new Guid("b7d8580b-0149-466c-b2b2-14bcad99cb66"), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 37f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ea37334b-1ec0-4f50-a4ea-e9d702da44e3"), new Guid("b31781dd-6b63-4ac3-8ae7-11af78a4eefd"), 15f, new Guid("b7d8580b-0149-466c-b2b2-14bcad99cb66"), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f32354d5-d13a-4ae2-872b-fc7606f72e58"), new Guid("992732af-7083-4cf8-b48c-fa34854c8c29"), 15f, new Guid("4ef30228-2585-402e-a75f-fe3cf0bd982d"), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("105b786c-0a3f-4084-ab44-e0a5aa6851d1"), new Guid("20594c10-25e4-4183-9735-a627d27363a1"), 15f, new Guid("c13f91d9-579a-4ff8-bd1e-a92b719e5310"), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("754938f8-4d53-4659-9ace-172b25347e5d"), new Guid("f88778c6-ece9-4c2f-8bf1-cf2cb97eae89"), 15f, new Guid("c7045f14-66a6-45eb-9373-691bdfaf4d55"), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 39f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("4a2054ad-286b-4848-ab18-91df5cdb0ee6"), new Guid("04d85352-b12b-48dc-913a-734e2284dc01"), 15f, new Guid("71adf1a5-b503-485a-85bf-8c9448d60ade"), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 46f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b6713ed7-2de0-4530-ab45-69cdd48fdce8"), new Guid("0927c8d0-2504-4b8c-8930-917c3c8bad02"), 15f, new Guid("079f6d83-9a71-4171-9be7-f5f2c3f29480"), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 92f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("700a2016-1ae6-4232-90e5-37d1ebac80c2"), new Guid("78663cd1-1da6-4ad9-abc1-4e5ea472ce62"), 15f, new Guid("079f6d83-9a71-4171-9be7-f5f2c3f29480"), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 62f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f368f8ea-f402-40ba-8b8c-e50dd94e5ea2"), new Guid("271f61bf-980d-46c3-8d50-77133cfda189"), 15f, new Guid("68a4ffee-3644-48b6-9640-26b4016e61c6"), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 86f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("78a891ba-6593-46b1-bd48-8c540f918f4e"), new Guid("f88778c6-ece9-4c2f-8bf1-cf2cb97eae89"), 15f, new Guid("68a4ffee-3644-48b6-9640-26b4016e61c6"), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ba31321c-a44f-4527-bcc7-8221bb277916"), new Guid("764d4177-e693-44eb-9bf6-bb13a53feef5"), 15f, new Guid("68a4ffee-3644-48b6-9640-26b4016e61c6"), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 73f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("c62325f1-e29e-4f04-a6e2-b9c481f5bdda"), new Guid("0c5ae44e-683b-4743-b7d2-216c864dfdc4"), 15f, new Guid("af4d0057-d868-4176-9147-c9ba5831c9c8"), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 88f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("c0f5029f-8ae2-419c-87ef-e809cbd2cbbd"), new Guid("ae40078e-00cc-4521-bbcd-6fb5f7321a3c"), 15f, new Guid("af4d0057-d868-4176-9147-c9ba5831c9c8"), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b700fb33-bdf1-4e25-8f54-4c86b455a397"), new Guid("2046a240-90b7-42f8-a13f-5245764de619"), 15f, new Guid("af4d0057-d868-4176-9147-c9ba5831c9c8"), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 27f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ac2b1784-ba19-4cde-b22f-5495d6631866"), new Guid("38aeeb95-c2e9-4cfb-be40-6cf77131f193"), 15f, new Guid("d4e5f11a-1164-40e8-9045-2a2fad9042ae"), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 87f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7af691df-2001-450c-9c21-af26fb992379"), new Guid("18b9b42f-2a44-4d11-b4dd-abf6717e651d"), 15f, new Guid("0bccca59-c86c-4b4f-bdc1-04a001aef558"), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 42f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("8db7267e-dbb5-44d7-a71d-ca23c0e3cc87"), new Guid("3eef0f39-9b2a-4f5b-b57a-d72f13f488c1"), 15f, new Guid("b67815ce-327a-4755-9514-156cfc96f156"), new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 11f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b3b1d224-42b9-4f53-9a5c-973564dfe46a"), new Guid("7e5f5fa1-50c6-4665-b153-fd40249f9b66"), 15f, new Guid("a0b15085-3865-4aeb-ac07-3d574edef363"), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 28f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("45323d10-67ac-48a9-b6fb-7661978ae3b8"), new Guid("08882a51-d98b-44cf-963c-ed0ff871c01e"), 15f, new Guid("83c90289-515b-4cc6-ad0b-fe17a55f48ce"), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 38f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("0caecf9b-4849-4c20-9ef0-e7f2f575fa4a"), new Guid("58f7b588-7b8e-4be3-be55-ae59eda7e8cb"), 15f, new Guid("83c90289-515b-4cc6-ad0b-fe17a55f48ce"), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 34f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("4f403604-ad7c-473a-9a06-7b7510338195"), new Guid("df8e65d0-cbe1-4902-b536-f701bebdc636"), 15f, new Guid("0ab65d02-2bc7-4ce8-9ee7-6380c25dfd79"), new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a8f6bbd2-9b07-4033-9831-0b86c3299c88"), new Guid("9ba8cca0-c820-4950-8077-9755c0c7c63c"), 15f, new Guid("83c5d933-4316-46bc-a2df-d73d0a73e5a1"), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 78f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a9547c7c-7380-457d-bce4-76e78a640d24"), new Guid("2019709b-8ffb-48db-a01d-ffd759d7df21"), 15f, new Guid("ef41ac83-0ea5-4df0-8de3-1942e1b80214"), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("48dc2e88-9221-4613-bbba-c8cea9ade99f"), new Guid("a77f7dc7-c855-46c5-b055-7045a9412465"), 15f, new Guid("ef41ac83-0ea5-4df0-8de3-1942e1b80214"), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 43f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b54bf7be-f8fb-4370-9aaf-7e2e6a8fb7b7"), new Guid("1d6f38fd-9455-444f-a9a3-e954630316ea"), 15f, new Guid("33d56b76-b5a4-4acb-807e-13728e53e71e"), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 52f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e43fdbc9-1385-4795-aa37-ef56435b983e"), new Guid("12e52f4a-589f-450c-8ec8-d502e8180d70"), 15f, new Guid("cc115b94-4c95-4bee-b4b3-2793a8425519"), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 51f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("af86d481-ec90-4c7f-8cb4-e950a60cabe4"), new Guid("9ae1ecd5-f630-479b-abca-1b0f4784e748"), 15f, new Guid("cc115b94-4c95-4bee-b4b3-2793a8425519"), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2e4385a5-a02f-4b95-9cf6-6a34db8ea0dc"), new Guid("f02d2f3c-f37a-42f9-ba18-f9c0ab50afdd"), 15f, new Guid("2eac0ebc-8eae-4807-a11e-299fdc521c17"), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 68f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("20b41f03-bdfe-409a-8d21-1c9539b5ad0f"), new Guid("383b29a6-d7e4-48a4-9498-a565f76bcc37"), 15f, new Guid("2eac0ebc-8eae-4807-a11e-299fdc521c17"), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 49f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("288541d5-adc4-4dd5-9d9e-4e16ab88fb1b"), new Guid("271f61bf-980d-46c3-8d50-77133cfda189"), 15f, new Guid("c45492d0-81a1-436b-95f7-5f63ad933d32"), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 77f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5d8bf130-46a2-45b9-a522-1e2db3873e24"), new Guid("f09a3f0f-6bd4-4177-95cd-dcba54c26203"), 15f, new Guid("f1c748e7-5653-4e94-b591-182a48bc05ec"), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("68658216-b3af-4b7b-9c2e-9f56d209dd66"), new Guid("2019709b-8ffb-48db-a01d-ffd759d7df21"), 15f, new Guid("bf198996-5637-4988-98f5-314a9fad6c5d"), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 71f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e7661947-3297-43ee-971f-01b9a3776e15"), new Guid("4192bba0-f6d1-4f57-be9d-ba9bb2a2a4c0"), 15f, new Guid("bf198996-5637-4988-98f5-314a9fad6c5d"), new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("bf8f8f74-5be4-4e92-b47c-34ca1e6dd64e"), new Guid("74a8acf7-40aa-4165-9235-938973709f8d"), 15f, new Guid("fb8f6014-9d87-47ca-89b8-5f69b3da49a7"), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 18f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("85f54f5b-8d90-47a4-b415-7ae5ee2241f9"), new Guid("e1e1e750-16de-45cc-bd44-3b09cc42a072"), 15f, new Guid("fb8f6014-9d87-47ca-89b8-5f69b3da49a7"), new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ce464f32-9674-474c-b8d8-4e24ae99bae2"), new Guid("eba74825-fcc1-4e23-9792-e0a7eba0bc5e"), 15f, new Guid("716bac35-bae9-4357-a007-2d368a0437c0"), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 61f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7bcabbc7-e360-4445-a91c-d786d62969e0"), new Guid("2b1dd15a-63a5-4e6b-b944-a190dcd520d1"), 15f, new Guid("2151bae0-1303-4e3f-885e-304ef2b0c2ee"), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("14b8e126-c5dc-4eb0-950e-1f65b0f414b1"), new Guid("88b841b5-6760-4db8-a01f-a8c1b91483cf"), 15f, new Guid("2151bae0-1303-4e3f-885e-304ef2b0c2ee"), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 23f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6b08710c-6ca3-4e7d-bf42-962a5ddfc288"), new Guid("63996227-f5ed-4898-a96e-7269967204eb"), 15f, new Guid("25d6d73b-4e5b-4652-8093-d3280e06762e"), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 96f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("49ac71ee-312e-4bc2-9ab0-91d9b79d05a3"), new Guid("1468e85e-205e-4e6a-9263-f6dc65407ee1"), 15f, new Guid("25d6d73b-4e5b-4652-8093-d3280e06762e"), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 76f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("61daf6bd-fffc-4461-83ac-9eb3099ce605"), new Guid("f872b678-dc86-4c54-93f2-73cad03c38fe"), 15f, new Guid("25d6d73b-4e5b-4652-8093-d3280e06762e"), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 19f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("d03f86a3-621c-4353-b76f-5aff8e349807"), new Guid("08882a51-d98b-44cf-963c-ed0ff871c01e"), 15f, new Guid("25d6d73b-4e5b-4652-8093-d3280e06762e"), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("82dc35a9-bd63-44e9-8152-8273c8bfeaa7"), new Guid("24ea4dd9-3d5c-4f3e-afeb-5900b0509eda"), 15f, new Guid("25d6d73b-4e5b-4652-8093-d3280e06762e"), new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e71426c0-fee7-428a-b81c-2ea592733c00"), new Guid("2e4ba96f-17da-4205-b9a3-b6b06411b2fa"), 15f, new Guid("dc66d9fd-f32d-4fe9-ad3f-11782f75ae4c"), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 83f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2549d86a-0df6-4a45-b138-21d1c4d96ac9"), new Guid("2019709b-8ffb-48db-a01d-ffd759d7df21"), 15f, new Guid("dc66d9fd-f32d-4fe9-ad3f-11782f75ae4c"), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 31f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("552433b2-336d-420b-9c35-8ad9bf8c7f47"), new Guid("e1e1e750-16de-45cc-bd44-3b09cc42a072"), 15f, new Guid("dc66d9fd-f32d-4fe9-ad3f-11782f75ae4c"), new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("479cd003-6c68-407e-8c74-02ce488552e1"), new Guid("f6956d1a-baac-4958-957b-3c050dc76d5f"), 15f, new Guid("cc115b94-4c95-4bee-b4b3-2793a8425519"), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 93f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("41cdde88-77c2-458c-a3d7-827385bf3a49"), new Guid("18b9b42f-2a44-4d11-b4dd-abf6717e651d"), 15f, new Guid("173697fe-1065-426d-ac2d-6ec5b4669e81"), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 74f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("a3f03e9e-a321-4407-81b7-ea4146ea9aae"), new Guid("764d4177-e693-44eb-9bf6-bb13a53feef5"), 15f, new Guid("173697fe-1065-426d-ac2d-6ec5b4669e81"), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 82f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e1c27ac1-1a57-4d4c-ae78-37b33864f6e4"), new Guid("8bf83716-ffbc-4b5d-9bee-32686bb7f7a8"), 15f, new Guid("66ecb9c7-fd9f-4bd6-a741-675438462691"), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 22f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("077eef9f-6340-4529-ac89-06ba3b180316"), new Guid("2046a240-90b7-42f8-a13f-5245764de619"), 15f, new Guid("0171793c-8f12-48c4-878f-3f16e6d56cfd"), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 98f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("b6fcf8b9-dcc5-4641-82c6-057c69108488"), new Guid("20594c10-25e4-4183-9735-a627d27363a1"), 15f, new Guid("0171793c-8f12-48c4-878f-3f16e6d56cfd"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 29f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ee6b9b23-d699-484d-a8dd-e7d9a9506f3a"), new Guid("8cafd90e-84ae-4b22-8dbf-4b18e0475460"), 15f, new Guid("80d5b6d4-4ac9-4304-8b58-145fb06c42ca"), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 56f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("57a93704-65b3-4df9-8e3f-053ab8511479"), new Guid("217a436a-a62a-4dd0-a21d-aad8f6eb70b9"), 15f, new Guid("80d5b6d4-4ac9-4304-8b58-145fb06c42ca"), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("886ed595-24b2-424e-bbbd-2217a9252c96"), new Guid("f6956d1a-baac-4958-957b-3c050dc76d5f"), 15f, new Guid("fa0e7b0f-c78d-4c3c-ad13-5a1fe3cdb905"), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ead6f8c3-9d9a-4d72-ab63-b67e9fe09126"), new Guid("3eef0f39-9b2a-4f5b-b57a-d72f13f488c1"), 15f, new Guid("ae181790-eaee-4b0d-b260-742d424ee92f"), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("6078f919-5d46-42e0-b02b-d72e0380c551"), new Guid("992732af-7083-4cf8-b48c-fa34854c8c29"), 15f, new Guid("8e9c34e6-d6d9-495c-8776-938dacd02c31"), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 54f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ec450f1a-805c-4607-b468-4d5fdccd127b"), new Guid("2bc4f63c-7f79-420e-894a-13b1f47144d3"), 15f, new Guid("9e6b6e4a-8288-4698-9b2c-162a1ea51b1b"), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 32f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("06c0834b-32b5-43cf-98f7-0cec1edb4157"), new Guid("f5ae3bc5-ab73-4d7b-934d-a3dfd0ff408f"), 15f, new Guid("b5f13e09-c8eb-46ef-ab4c-6f04e93e0b69"), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 97f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("2d217746-b1d7-4a18-8b1b-6a41a92c6774"), new Guid("6e9c7b74-946a-41ff-94e5-584adcc7f42a"), 15f, new Guid("b5f13e09-c8eb-46ef-ab4c-6f04e93e0b69"), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e18391a1-0351-4499-a2c0-fc16eb41ce45"), new Guid("2046a240-90b7-42f8-a13f-5245764de619"), 15f, new Guid("b7d8580b-0149-466c-b2b2-14bcad99cb66"), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 66f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("94c51b7d-10f2-4045-b8c4-c31f3f32b5df"), new Guid("54809fcf-04d4-4285-90da-ef6b8482b5a9"), 15f, new Guid("8d030c87-5edb-410f-82af-c6fab8660a24"), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 17f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("3f37a6ae-58b2-4601-bbd3-3c1eae5e80e3"), new Guid("29a7b295-4174-4c3a-a52a-f913157b0eb3"), 15f, new Guid("c1f3a679-9f67-45c1-905e-ca0e1ed52e34"), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 81f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("47a45f42-229e-4883-927b-ece4c6cf0c52"), new Guid("8be30135-496a-4b2c-b3c1-26f1d1e6fab1"), 15f, new Guid("c1f3a679-9f67-45c1-905e-ca0e1ed52e34"), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 33f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("3db3e269-a339-40e1-8678-e3ba9a19da9d"), new Guid("512d8ea9-0856-4f3f-9791-f6ca30ec5e85"), 15f, new Guid("c1f3a679-9f67-45c1-905e-ca0e1ed52e34"), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e3e703df-a9b3-4a5b-927f-5230b5451b00"), new Guid("271f61bf-980d-46c3-8d50-77133cfda189"), 15f, new Guid("c1f3a679-9f67-45c1-905e-ca0e1ed52e34"), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 16f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("04507b72-3da0-495e-8944-3fa5ed471574"), new Guid("937f814e-4e38-4cc6-8970-b00f47630684"), 15f, new Guid("e4b64cb0-bbf1-431e-bde5-250c9ddec7be"), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 84f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("e70e07fb-a693-4add-b9d1-1c6d1c5dea1e"), new Guid("df8e65d0-cbe1-4902-b536-f701bebdc636"), 15f, new Guid("f685db70-02db-4f4a-afc3-5c6f7de6b5bb"), new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f4fd6641-f18d-42cb-a2ae-f7c172a76851"), new Guid("0102b600-3309-467c-9455-edf3265544b2"), 15f, new Guid("cba4e37a-adae-4cdf-91ca-8b5abe13d365"), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 41f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("5a70ed6e-79eb-44e6-b088-312dd97a005a"), new Guid("2046a240-90b7-42f8-a13f-5245764de619"), 15f, new Guid("03f6ff47-012f-48c8-9e16-f49625519cd2"), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 47f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("3c0fd37b-c290-47c3-b5d8-228c68604080"), new Guid("1d2d517d-f9c9-4029-9098-dcbbce615505"), 15f, new Guid("5fef9da5-0186-4613-a825-34e3e69530a2"), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 99f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("f96d4378-d990-44bf-b428-bca94e5e4ba4"), new Guid("44ab4ca9-a1a1-4a27-ad5c-99df438b06c8"), 15f, new Guid("5fef9da5-0186-4613-a825-34e3e69530a2"), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("7cc96007-2f0e-4821-9a2d-939a6f175af2"), new Guid("98f1df2b-daa9-4fa3-9e9a-f2f257511638"), 15f, new Guid("886d6073-7bda-4497-96fb-a7e2486ea9e8"), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 69f, 1 });

            migrationBuilder.InsertData(
                schema: "r",
                table: "GameRentals",
                columns: new[] { "Id", "BoardGameId", "ChargedDeposit", "ClientId", "CreationTime", "FinishTime", "PaidMoney", "Status" },
                values: new object[] { new Guid("ec23b3c4-cf54-4b63-87aa-6a1976177d37"), new Guid("6e9c7b74-946a-41ff-94e5-584adcc7f42a"), 15f, new Guid("b7d8580b-0149-466c-b2b2-14bcad99cb66"), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, 1 });

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
