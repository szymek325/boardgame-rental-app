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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 8, 19, 58, 48, 823, DateTimeKind.Utc).AddTicks(6060))
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 8, 19, 58, 48, 826, DateTimeKind.Utc).AddTicks(4660))
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
                    ClientId = table.Column<int>(nullable: false),
                    BoardGameId = table.Column<int>(nullable: false),
                    ChargedDeposit = table.Column<float>(nullable: false),
                    PaidMoney = table.Column<float>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 8, 19, 58, 48, 826, DateTimeKind.Utc).AddTicks(2930)),
                    BoardGameId1 = table.Column<Guid>(nullable: true),
                    ClientId1 = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRentals_BoardGames_BoardGameId1",
                        column: x => x.BoardGameId1,
                        principalSchema: "r",
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameRentals_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalSchema: "r",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("52543234-6e9b-4483-840c-79750a27c8cb"), "138.886.7742 x681", new DateTime(2019, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "isobel@wittingconnelly.info", "Heidi", "Maggio" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f2a5c33c-1c60-4047-8e56-1ee2c50b12e1"), "(711)118-7026", new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "angus@lefflergusikowski.biz", "Maximilian", "Hegmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c0153681-9312-4f06-ae97-f33d9cca21af"), "(375)353-5464 x601", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "tracy@crooksbatz.com", "Michele", "Homenick" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("3833afb8-16bb-4cdc-9dad-26abc15a2e62"), "(354)737-0080 x77663", new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emmanuel@mayertwisoky.ca", "Gail", "Bartell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("281ea0d8-9943-4dfd-b019-49e311f10e4f"), "1-560-222-0162", new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "judge@lang.us", "Nicole", "Herzog" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("408c8550-f16c-48d3-b76e-6a967c52b4fc"), "088.735.7258 x164", new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jamey@schulist.name", "Yasmine", "Schmidt" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ca9ef73b-d0a6-40ac-bab5-a79a0db433f2"), "1-064-740-7812 x4262", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "markus@wolf.info", "Sally", "Wolf" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9576bc73-27d3-492c-9b58-17b41b87da42"), "(886)182-3767 x107", new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "hanna@kiehn.com", "Ida", "Kovacek" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d1306e26-0100-451e-b3c6-464797f1a627"), "1-568-158-4553 x547", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "lavina_hayes@rutherfordstroman.ca", "Pink", "Reinger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("821b0c0f-6afc-4e44-93e0-b6344708dfe8"), "767.508.8415", new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "helene_windler@johns.name", "Louie", "Jacobi" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("68a2ab88-713b-4e8d-bd65-d5357a95e3fc"), "(635)846-7150", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "emil.prohaska@hagenesjacobson.us", "Elbert", "Sporer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("557fcd48-1605-458d-8dfe-c32fc4352df4"), "(765)013-4552", new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "trenton_corwin@bechtelar.ca", "Clint", "Schroeder" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d9b04964-6755-4d68-b40c-f788b4a4a629"), "134.518.0046", new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "cyril@bayerjones.com", "Kristopher", "Herman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5800e242-3421-4df7-bf2d-630e72b96a38"), "1-012-424-7278 x316", new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "summer@schroedergerhold.info", "Mustafa", "Boyle" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("955033b2-1d38-4e33-9a24-e528631fbe93"), "(663)201-4442", new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ted@dubuquebotsford.co.uk", "Mireya", "Rempel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a3f27cc6-59e2-4c79-8b11-67c44a56f831"), "311-246-0647 x677", new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "arvid.funk@mohr.us", "Jonathon", "Stehr" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5239a3ef-5db7-4139-846d-320912fd5221"), "1-630-545-6770", new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "tanner.hauck@little.name", "Jacinthe", "Bergstrom" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2c76fc93-394d-4748-bf1f-ac8d5fde02ba"), "(022)614-0116 x73206", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "carroll_bechtelar@schuster.biz", "King", "Abshire" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6585c2fb-5a7c-4a24-a9af-831224a12391"), "262-785-3267", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "isobel@schmeler.co.uk", "Maxwell", "Swaniawski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7066c996-9eee-42da-bbeb-057891130673"), "088.887.1724 x78184", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lacey@windler.info", "Ashtyn", "Gibson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ac6ffe40-b7fd-4005-9673-45998ac4901b"), "446-803-1612 x4238", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "kallie@muller.name", "Janelle", "Pfannerstill" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8a4aa94c-459c-493a-9c31-fe2984525330"), "(348)844-6517", new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "annie.schowalter@sengerhuel.name", "Flavio", "Zulauf" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2f60767a-7810-43cd-9b3b-41226e9bafeb"), "301-828-0317 x446", new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "barrett@jakubowski.us", "Haven", "McGlynn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("8b0b174b-d37a-4f95-b0d0-b58fd2501d9a"), "1-645-113-4105", new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "amalia@kling.co.uk", "Emilie", "Koelpin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9a5bd8ce-755c-444c-905f-78339887a8a8"), "(107)173-0355 x2016", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "rubie@bins.ca", "Lulu", "Rohan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e96d977c-e35f-402f-9eab-540874e2e58d"), "(731)822-3110 x13381", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "jewell@dubuque.us", "Arch", "Howe" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("78d43d08-f264-468f-b742-df2f1bac42d8"), "1-162-632-1252 x2134", new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "duncan_leffler@kutch.biz", "Alexane", "Adams" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6cbdc0ed-7525-414f-ac56-cb8d1e2bc980"), "(307)450-3234 x65842", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "maxwell@zulaufkuvalis.name", "Henry", "Hackett" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b904cac1-8e78-443d-9ea7-146836b0ad4e"), "(671)622-8438 x710", new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "izabella_hilpert@stoltenbergbruen.us", "Donnell", "Homenick" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("133f64bb-c5cf-4f5b-9e09-6477679005d8"), "340-143-5834", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "christop.kilback@howeparisian.us", "Kamryn", "Reilly" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("12ad3d27-4256-416d-a2e5-366afa493632"), "370.186.5026 x277", new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "kiel.harvey@wunsch.ca", "Jaeden", "Cartwright" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7f2b9658-82b5-4fed-8431-2b599ba1e217"), "(101)551-2351", new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "julien_smith@kessler.co.uk", "Imani", "Kris" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("70c691e6-8037-48b3-b0cb-7a51749b3da3"), "(627)752-8610 x007", new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "trudie.weber@wunschberge.biz", "Asa", "Heathcote" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("79c1d465-f19c-41b1-b086-be53bb4fd402"), "734-853-7458 x65751", new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "hortense_sauer@emard.co.uk", "Sven", "Pollich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("45dc60d3-090e-47ab-9af1-ee5020008ccf"), "155-834-8416 x653", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "loy_barton@oharalubowitz.info", "Jewel", "Heller" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5e1b746a-f521-4c70-9dac-b37d0d8fad75"), "(083)813-5503 x2878", new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "katarina@wyman.name", "Marlon", "Conroy" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f6c9fb9e-935b-4af4-b1cc-c6eae9843681"), "(364)757-8516", new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "archibald_langworth@buckridge.name", "Shanon", "Dooley" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("e51cb4f4-5ce7-4a82-aba7-acbcdeb52072"), "(126)733-7031 x134", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "bud@botsfordheaney.biz", "Osvaldo", "Haley" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a359a7bd-982d-4f08-8b08-21b20073eed5"), "214.240.6482 x5664", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "darrell.turcotte@hegmann.name", "Joshuah", "Dickens" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9f8d9872-dbc6-493c-88ee-c5502508f30c"), "1-608-075-2650 x0880", new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "garrison_turcotte@feest.biz", "Trey", "Kuhlman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d41aea47-de00-4849-a670-de07b251dac9"), "535-640-0888", new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "devon_pouros@cronaullrich.us", "Tyrel", "Gerlach" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5d58ad55-44f7-4891-99ab-b5830b5a6180"), "881-150-8237 x28763", new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "jessie@osinski.name", "Sven", "Heidenreich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5452af5f-2764-435f-8750-22cf68a34c54"), "(787)373-5026", new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "obie_leffler@hermann.ca", "Lulu", "White" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ec3bd9e1-edfc-4eac-994a-20104659a3b4"), "(414)215-5273 x22636", new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "alek_crooks@waelchi.info", "Retta", "Daniel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0db23b44-b3e1-4b6a-b749-15b6d744be4d"), "(168)682-8713 x63571", new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "dorothea@padbergdoyle.co.uk", "Katrina", "Nienow" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9509bb0a-b1ec-475e-9bb1-87f4205f14b5"), "1-174-248-6158 x0624", new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "juvenal.leannon@hoeger.ca", "Emmett", "Mertz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("37ae5030-7022-4594-b233-29476d69744c"), "522.474.4783 x1732", new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "damien_considine@klein.co.uk", "Ivory", "Jewess" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("568051a2-245e-437e-b96f-957fdb66c5bd"), "583.585.8275", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "alejandra@lind.co.uk", "Destin", "Schmidt" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d09c670d-dd40-44fd-b73c-75a2d9c7aa86"), "1-015-016-5311", new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "larissa@jacobsonheaney.info", "Bethel", "Doyle" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("17efd7fe-c088-4651-b7d6-792361cc36ea"), "1-218-021-0206", new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "emelia.lehner@kozey.ca", "Robbie", "Olson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("58c1855b-9dc4-492b-90a1-fafd62a45662"), "(554)636-3776", new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "melyna_pfannerstill@donnelly.ca", "Mose", "Volkman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("214be500-8b1a-4764-8ad3-6d36d21caf28"), "568-868-1048 x862", new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "adrain@nicolas.ca", "Mayra", "Buckridge" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("2a272a52-4157-4023-a280-67d8c45ff031"), "255.716.7271", new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "gwen@spencer.name", "Queenie", "VonRueden" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a43fb9c8-a152-4fb3-8ff1-e1292bf6faa8"), "081.127.7648 x242", new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmad_lesch@mannsatterfield.info", "Keanu", "Runte" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d0e68616-4363-4988-80b8-7916b43c1a52"), "(228)756-0328 x26477", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "alfredo.haag@armstrong.com", "Tad", "Herzog" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("259d2801-f069-4c9b-9bad-44af7b5533a3"), "681-000-3248", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "emie@padberg.biz", "Cassandre", "Pfannerstill" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d3bc561b-47e3-4adf-8243-abdd34a0bfbc"), "827-541-3363 x300", new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "arvid.runolfsdottir@jacobiryan.com", "Lorenza", "Reynolds" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("747c0d00-b7b2-49c0-8f7e-584737f62e4a"), "(452)830-2025", new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "adele@ohara.info", "Daphney", "Hand" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("541ab43f-df6d-462c-ab93-6bb873151df8"), "158.036.7328", new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "zander_sipes@brekke.info", "Cole", "Grant" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7a0416f1-5c8d-4e82-a8aa-614e065b2d55"), "(872)357-1145", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "willis@kovacek.biz", "Franz", "Swift" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("0c37e43a-2038-4e03-a037-b294bb870676"), "(526)807-5271 x460", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "gabriella.connelly@roberts.ca", "Adele", "Weissnat" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("bfb29133-9ac4-401d-9f63-d7ce0ad9039a"), "1-011-816-6043 x240", new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "lilla.wyman@schroeder.com", "Bethany", "Kuphal" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("81f2e78c-f17b-42c8-abbd-f75dc25e1279"), "670-800-1212", new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "malcolm@kunde.biz", "Nicola", "Hayes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1be61906-1988-4f49-bb5e-1170b3ed3b10"), "136.210.7711 x41162", new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "colton@yostkuphal.biz", "Jordan", "Weber" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("27b2a59f-e69c-4152-86ef-e1edde1b4a42"), "712.405.7784 x8564", new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ervin@hodkiewicz.ca", "Tyrese", "Walsh" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("469c2dab-8763-4b64-b9ea-73e25257e8ea"), "232-278-3806", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexanne@bergnaum.us", "Angelita", "Weissnat" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("9ce68399-3eed-47a6-9518-de0493c02363"), "765-666-8667 x0485", new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "jade.hermann@sanfordcartwright.info", "Cyrus", "Robel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("5e0f897c-6ad9-4c40-a62d-c11a4c35414b"), "(636)850-6772", new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "skylar@little.com", "Lilla", "Kuhic" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f0b3349a-1319-4528-95ec-fecca0e0076e"), "1-813-414-7643", new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "elwyn@wilkinson.biz", "Caesar", "Powlowski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b350a987-7d15-4b1a-9233-febb879cb1c8"), "251-725-3200", new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "kolby@altenwerth.ca", "Ozella", "Pacocha" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b529c3d7-988c-4227-a0cb-d8b31cfc9c2d"), "1-830-483-1737 x50670", new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "lexus.schultz@jerdemonahan.co.uk", "Marion", "Gaylord" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("28286518-2c05-48de-8c29-f894f079a44b"), "451.251.0421 x53708", new DateTime(2019, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "finn.mcglynn@huel.info", "Lawrence", "Doyle" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("19d5381e-41a8-4e30-a821-d74914c02278"), "518-586-5506", new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "edmond@heidenreichmueller.name", "Peggie", "Boyer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("45846dfb-c090-4743-bf41-c62b93ada894"), "227-363-0837 x6454", new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "domingo_smitham@deckowharber.name", "Roger", "Batz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("670913cd-7c11-4344-8089-57632a13947d"), "775.402.1417 x67712", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maximilian.schaefer@durganschamberger.info", "Gerhard", "Volkman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("988f83e7-f1d8-4f77-b236-3159d49d557a"), "047-238-8375 x44354", new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jalon@yost.biz", "Mavis", "Block" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("458a74e7-7620-4d81-8460-708027ae04c4"), "634-571-6272 x40168", new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "reynold@kuhn.biz", "Leila", "Trantow" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("58415266-7c92-4ec4-bc48-ae24ee42ebd4"), "(124)873-3736", new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "theresia@gleason.co.uk", "Loraine", "Kassulke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("99cd8f2b-2423-4349-bf56-62f60028b278"), "476.024.1236 x70428", new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "kim_baumbach@rippinbahringer.biz", "Eldora", "Considine" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1c3ade05-30bc-4ccc-87c6-dff4834c0012"), "(254)684-8037 x0305", new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "richard_rutherford@quigleyrosenbaum.uk", "Reinhold", "Effertz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("fecb7ea8-a538-42c8-b945-014623ab70f9"), "1-184-521-4751 x731", new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "eliseo@gerhold.name", "Jedidiah", "Welch" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("93a1fe98-563c-4abb-a9d7-bf87675886f1"), "1-288-141-3288 x53514", new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "leo@bergstrom.uk", "Anabel", "Howell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("ad055caf-4ca8-47d7-b7bf-213e3db14e8b"), "(301)745-4877", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "seamus@baumbach.ca", "Yvette", "Berge" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("c8522e31-b936-4604-87bb-e1c504a4eb2e"), "1-785-003-6317", new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "lilyan@rice.name", "Cordie", "Von" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("7fdb4aa0-7e49-4ff9-afba-b9743dcd921f"), "1-453-866-2234", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "jaime@zieme.biz", "Victor", "Wolf" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f2a8485c-b8e8-4f67-b02f-46c378b82173"), "045.387.1242", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maurine_ondricka@harris.name", "Dorcas", "McCullough" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("f5d2b88b-2b7d-4a1d-818c-48bb4dbd3004"), "1-363-783-0127 x6570", new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "favian@osinski.co.uk", "Saul", "Hagenes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("dcdc5c65-ef19-4209-88ac-a45cf17a12af"), "1-866-557-4065 x00331", new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "mittie_brakus@padbergmccullough.us", "Ramon", "Glover" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6ca58327-56a7-4e17-b980-a829732efdd4"), "(724)535-7120 x5470", new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jayme.mayer@rowedare.biz", "Carter", "Lockman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("6d2f1b10-7427-4660-a6f1-44a546f6cc3a"), "1-460-824-5530 x4731", new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "freda.barton@feilauer.com", "Austyn", "Fahey" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b8deabc1-b559-4a59-92f3-0c0d0c8b9c55"), "1-730-434-7221 x78528", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "modesta@wolfkuphal.us", "Laura", "VonRueden" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1c593cc7-5edd-4c29-9d93-4e986635cd1e"), "1-146-788-3738", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "olen@parisian.name", "Esperanza", "Zieme" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("b3de9110-d2ab-4fec-b6bb-0ac6458be18d"), "1-025-515-3284 x5855", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "kadin_padberg@lang.com", "Katelin", "Ritchie" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("661c0e1f-9c47-4878-914a-04e50a1a440b"), "(850)843-3754 x243", new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "rusty_orn@treutel.ca", "Orpha", "Friesen" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("17931351-4ec0-4e0b-9fd7-26451491f116"), "301.855.6518 x0478", new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "mathilde_marvin@cummings.name", "Nicola", "Herman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("d861a85b-2e78-4833-bb0f-f8c06b14425a"), "1-521-452-3730", new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mireille@russelbalistreri.com", "Gerard", "Spencer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("aefff944-5970-4f3e-b66b-2e7fd7adf1c8"), "1-065-733-5642", new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "malvina@leffler.com", "Renee", "Dickinson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("a9e828c4-bea0-4337-8a7c-8b7650dc530f"), "754-600-8311 x6674", new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "vergie.hermiston@koepp.com", "Bettye", "Glover" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("25df9c1c-84af-40f8-a0be-98b561f365d0"), "323-862-5423 x1188", new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark@cummerataconnelly.name", "Katelynn", "Ullrich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { new Guid("1533f374-7325-4ed5-97d4-0ee81852b743"), "674-245-3833 x5738", new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "flavio_braun@cole.ca", "Maxine", "Frami" });

            migrationBuilder.CreateIndex(
                name: "IX_GameRentals_BoardGameId1",
                schema: "r",
                table: "GameRentals",
                column: "BoardGameId1");

            migrationBuilder.CreateIndex(
                name: "IX_GameRentals_ClientId1",
                schema: "r",
                table: "GameRentals",
                column: "ClientId1");
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
