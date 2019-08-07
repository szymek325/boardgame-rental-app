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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 7, 7, 50, 13, 757, DateTimeKind.Utc).AddTicks(7655)),
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 7, 7, 50, 13, 761, DateTimeKind.Utc).AddTicks(9923)),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
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
                    CreationTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 8, 7, 7, 50, 13, 762, DateTimeKind.Utc).AddTicks(241)),
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
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 1, "1-872-404-5102 x150", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "frank@oreilly.com", "Loma", "Brown" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 73, "(158)275-4786 x022", new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "lysanne_okon@nikolaus.com", "Ross", "Herman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 72, "1-103-027-0505 x324", new DateTime(2019, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "jaylon.wiza@halvorson.name", "Mason", "Langosh" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 71, "1-542-225-8736 x6615", new DateTime(2019, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "connor@zemlak.us", "Ben", "Paucek" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 70, "(266)386-6178 x7061", new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanita.bernhard@shieldsstokes.com", "Joshua", "Beer" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 69, "833-441-8072", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "elwin.pagac@pfeffer.uk", "Hannah", "Weimann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 68, "(028)610-8056 x7803", new DateTime(2019, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "anahi_cole@walterstanton.co.uk", "Carroll", "Becker" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 67, "(207)154-0175", new DateTime(2019, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "arvid@johnsonstark.name", "Isaiah", "Glover" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 66, "688.458.2884 x43057", new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "elena.sauer@hintz.co.uk", "Mauricio", "Wehner" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 65, "(248)874-7626 x7765", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "beulah@russel.ca", "Ethel", "Gleason" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 64, "177-045-1010", new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "clemmie_sipes@kub.co.uk", "Gavin", "Haag" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 63, "1-073-813-3346", new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "liliane.oconnell@okuneva.co.uk", "Grady", "Christiansen" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 62, "1-472-860-3543 x67300", new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "kenyatta@effertzrowe.biz", "Filiberto", "Stanton" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 61, "(345)735-2345 x46355", new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "annette.lowe@williamson.com", "Heber", "Heidenreich" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 60, "280-041-0345 x108", new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "elizabeth@wiegand.co.uk", "Augustine", "Cartwright" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 59, "651.545.8515 x24722", new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "vincent@lang.ca", "Randy", "Dickinson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 58, "1-816-586-1675 x772", new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "marina.emard@will.info", "Alex", "Nikolaus" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 57, "826-441-3204 x601", new DateTime(2019, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "enrique.brekke@medhurst.info", "Cletus", "Rempel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 56, "1-034-850-6004 x25508", new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "al_wintheiser@hammes.us", "Chelsea", "Larson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 55, "1-385-523-3343", new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "rodrick@adams.info", "Monte", "Hoeger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 54, "203.345.5116 x42535", new DateTime(2019, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "torey@gerlachgulgowski.biz", "Donnie", "Rodriguez" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 53, "1-622-371-3614 x36556", new DateTime(2019, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "desmond@heller.ca", "Kurtis", "Blick" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 74, "401-130-5267", new DateTime(2019, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "leola_schmitt@kohler.us", "Aric", "Parker" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 52, "251.587.3431 x3603", new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "torey@bayer.info", "Jacinthe", "Jast" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 75, "804.677.1720", new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "timmy_schamberger@hackettkuhlman.name", "Pete", "Schulist" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 77, "(680)007-0460 x54040", new DateTime(2019, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "loyce.koelpin@harrisbechtelar.biz", "Rosemarie", "Mitchell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 98, "(383)628-4802 x0761", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jaren_lebsack@steuber.ca", "Sadye", "Botsford" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 97, "582.713.3136 x278", new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "jed@gislason.ca", "Schuyler", "Trantow" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 96, "218.320.8278 x1014", new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "peter.gislason@skiles.us", "Caleigh", "Hoeger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 95, "518.463.5415 x248", new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "rogelio@sanford.ca", "Dianna", "Welch" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 94, "086-524-3568 x784", new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "felipa_paucek@schultzbergnaum.co.uk", "Sandrine", "Balistreri" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 93, "103-366-1317 x638", new DateTime(2019, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "domenic@lubowitz.biz", "Jermain", "Gusikowski" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 92, "(111)114-7653 x512", new DateTime(2019, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "zella.lakin@jewess.ca", "Nedra", "Fay" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 91, "688.514.6623 x420", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ellsworth@gleichner.ca", "Destiney", "VonRueden" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 90, "(468)788-5314 x3004", new DateTime(2019, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ima@kassulke.name", "Giles", "Kessler" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 89, "(716)711-8278 x8671", new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "nasir@mcculloughschinner.us", "Katelynn", "Zboncak" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 88, "712-254-3861", new DateTime(2019, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "elenor_collier@hirthe.co.uk", "Miguel", "Koelpin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 87, "388-226-2172", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "isaias@ziemann.ca", "Catalina", "Treutel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 86, "(431)436-2768 x000", new DateTime(2019, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "lydia.wuckert@gutmannkihn.biz", "Alta", "O'Connell" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 85, "1-747-146-1741 x072", new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "candelario@metz.ca", "Salma", "Fadel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 84, "(772)573-4243 x4213", new DateTime(2019, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "tate_hackett@larkin.co.uk", "Patricia", "Shields" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 83, "385-187-1715 x7778", new DateTime(2019, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sydney_schmidt@blickcole.biz", "Damion", "Erdman" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 82, "026.640.7383 x27044", new DateTime(2019, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ernest_wilderman@rippin.us", "Ofelia", "O'Hara" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 81, "418.324.3868 x7811", new DateTime(2019, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "major@keebler.uk", "Phyllis", "Mohr" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 80, "(803)138-8717 x5623", new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "gerhard@gibsonmcdermott.uk", "Gregoria", "Schoen" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 79, "420-030-4515", new DateTime(2019, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "marlee@champlin.us", "Joaquin", "Wilkinson" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 78, "585.356.7136", new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "cleta.lakin@erdman.biz", "Harmon", "Rohan" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 76, "380-672-1366 x7120", new DateTime(2019, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "maddison@franeckirodriguez.co.uk", "Beth", "Rosenbaum" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 51, "1-482-571-8272 x00570", new DateTime(2019, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "marjorie.bednar@bergstrom.ca", "Fidel", "Corkery" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 50, "1-305-232-6317", new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "halle@mante.info", "Germaine", "Wisozk" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 49, "060.203.0853", new DateTime(2019, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "cleta.dare@hesselhackett.name", "Waylon", "Schimmel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 22, "555-632-3101", new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "tate@balistreri.biz", "Marguerite", "Lindgren" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 21, "686-638-2312 x05674", new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "bryana@champlintrantow.ca", "Kiel", "Aufderhar" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 20, "774-605-8226", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "ivy_boyle@johnsonhayes.name", "Muhammad", "Champlin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 19, "775.358.3677 x8260", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "meagan@runolfsson.us", "Rasheed", "O'Kon" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 18, "(313)222-6782 x328", new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "mattie.kemmer@kub.co.uk", "Jovany", "Gutmann" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 17, "320-602-3406", new DateTime(2019, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "neha.bailey@marks.ca", "Jeanne", "Tromp" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 16, "346.232.8604 x17147", new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "gunner_schowalter@feestkuvalis.uk", "Alysha", "Sipes" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 15, "503-263-1363", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "vita@schamberger.co.uk", "Jalyn", "Hoeger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 14, "(232)025-5712", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "elmer_swaniawski@cormierhickle.com", "Liza", "Torp" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 13, "1-023-105-8284", new DateTime(2019, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "kamron.oconner@monahankuphal.co.uk", "Austin", "Stark" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 12, "651-787-4420 x344", new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "denis_cormier@reichert.uk", "Felton", "Russel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 11, "324-625-4082", new DateTime(2019, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "delphine_schneider@kozey.ca", "Carmella", "Harvey" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 10, "(616)477-6445 x101", new DateTime(2019, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "nya.towne@gaylord.uk", "Bernadine", "Hahn" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 9, "035.340.7806 x71371", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "rodolfo_jenkins@gerholdritchie.info", "Luz", "Skiles" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 8, "(444)486-4565 x08500", new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "don@stoltenberg.name", "Kelsie", "Hills" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 7, "526-721-2221 x026", new DateTime(2019, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "carissa@shanahan.ca", "Gladys", "Langosh" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 6, "1-605-312-6154 x11277", new DateTime(2019, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "minerva@ratke.name", "Isac", "Fay" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 5, "1-427-070-4300 x5865", new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "dario@raynoremard.biz", "Kane", "Stark" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 4, "1-127-645-7162 x1724", new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "cleveland@prosacco.ca", "Nikita", "Trantow" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 3, "(425)727-8850", new DateTime(2019, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "damon@rowehayes.info", "Modesta", "Price" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 2, "025-623-2334 x72540", new DateTime(2019, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorenza@haleydonnelly.name", "Kattie", "Heller" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 23, "(476)282-1541 x203", new DateTime(2019, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "berenice@hoppe.name", "Tillman", "Bradtke" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 24, "1-455-316-4155 x077", new DateTime(2019, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "elinor_bayer@reinger.name", "Stone", "Trantow" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 25, "1-286-208-1552 x262", new DateTime(2019, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "arnoldo_watsica@mertz.biz", "Verner", "Braun" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 26, "(787)115-5400", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "viola@braun.uk", "Dorian", "Bins" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 48, "(862)247-7853", new DateTime(2019, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "hildegard@morarhoeger.name", "Joany", "Mraz" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 47, "875-281-6412 x825", new DateTime(2019, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "mellie.yost@stiedemannhettinger.com", "Clinton", "Cruickshank" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 46, "287-315-2425", new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "unique@becker.com", "Remington", "Rosenbaum" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 45, "778-040-8625", new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "evan@romaguerabarton.com", "Tracey", "Weber" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 44, "1-816-011-8862 x4510", new DateTime(2019, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "tito@braun.uk", "Jace", "Harris" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 43, "1-862-740-2851 x8238", new DateTime(2019, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "maia@kovacekmorissette.info", "Kaylah", "Krajcik" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 42, "(271)583-8333 x000", new DateTime(2019, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "esteban.spencer@osinski.ca", "Rosario", "Schuster" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 41, "1-774-520-5420 x38814", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "richard@kuphal.uk", "Elwyn", "Kozey" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 40, "1-528-228-4613 x735", new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "eloise.lebsack@franecki.com", "Jana", "Treutel" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 39, "655-724-4850 x872", new DateTime(2019, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "joyce@treutel.uk", "Keeley", "Bergstrom" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 99, "(655)730-4843 x33145", new DateTime(2019, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "mallory@reilly.us", "Zora", "Greenfelder" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 38, "1-282-616-2122", new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "buster@hickle.co.uk", "Stacy", "Schuster" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 36, "1-420-418-1216 x5512", new DateTime(2019, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassan.conn@murphy.co.uk", "D'angelo", "Hoeger" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 35, "535.251.5337", new DateTime(2019, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "roberto.corkery@rempelmertz.co.uk", "Filomena", "West" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 34, "(054)880-5612 x81770", new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "rozella@boyerhermiston.com", "Evans", "Kshlerin" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 33, "026.868.3602 x7273", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "mollie_botsford@lindgren.biz", "Jaeden", "Schulist" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 32, "134-341-4604 x6468", new DateTime(2019, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "stephany_auer@mante.uk", "Ola", "Conroy" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 31, "564.226.3535 x13655", new DateTime(2019, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sabrina@jacobson.name", "Maggie", "Witting" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 30, "160.140.8142 x23364", new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "barrett@smith.info", "Duane", "Collier" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 29, "(421)760-0787 x422", new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "rick@frami.ca", "Stan", "Welch" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 28, "778.577.0746", new DateTime(2019, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jacynthe.sporer@hoeger.com", "Margot", "Connelly" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 27, "454.187.7035 x155", new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "caesar.wisozk@jasthoeger.biz", "Jake", "Ernser" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 37, "(603)601-5511 x57413", new DateTime(2019, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "elda@gottlieb.name", "Roy", "Feest" });

            migrationBuilder.InsertData(
                schema: "r",
                table: "Clients",
                columns: new[] { "Id", "ContactNumber", "CreationTime", "EmailAddress", "FirstName", "LastName" },
                values: new object[] { 100, "812-752-3431 x82180", new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "nicola@gottlieb.us", "Joe", "Schiller" });

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
