using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 7, 28, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 9, 16, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 11, 5, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2023, 12, 25, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2024, 2, 13, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2024, 4, 3, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2024, 5, 23, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2024, 6, 2, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2024, 6, 12, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2024, 6, 22, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2024, 7, 2, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2024, 7, 12, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishDate",
                value: new DateTime(2024, 7, 22, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishDate",
                value: new DateTime(2024, 8, 1, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishDate",
                value: new DateTime(2024, 8, 11, 22, 4, 19, 986, DateTimeKind.Utc).AddTicks(50));

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "fine-per-day", "2" },
                    { 2, "allowed-delay-for-responses", "1" },
                    { 3, "default-borrow-duration", "14" },
                    { 4, "extra-duration-for-returning-fast", "14" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$POzhSO0AgSFtCBbt.XAv0u3bedp5vfAzLzER0aVCRwXmGaw/Zs55q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$jgwmiMZLvujnuR6mQtZBkevOl..Q91YkXKs6gSNJjzibZ/ULA2HGK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$lNnlU40m/2VND6y9w.qZc.mlQlnsP7e8nWRvPSaKHjL6inMM0LMrq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$qwPaiZ00jHDco2xR3XyoA.ofJ3ERK1VCKmHT4r3YmZ1IhFAofParC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$e1ESynkw5MvplfQQXoeQ0u8eRRGR1wed7aGPEj3mePHRwQxfEgXGS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$cz6ESl4fX7GVViwwBXzO0.ZHELRdibnZBj0OTITjQUEWIsHae0UXC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$Mb2BiYLu445eSqEXu7SiOelyVVtwviiGtuBGnOyL7BKTzyrmCo70i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$aZFrwNEhbm76.BJVfs/VZuP/SxBHKLF3vYxRLDcTZaReBNLvTGsOG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$FpitcU2H.2OSA855FCW0SOX0e/1PZo4cssv.nfOldXY.KtXbBs.Ki");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$Ziltp6vJKqWdqOlhOX/U9u.skiKqv.c5wbJD93FTRV4wqqK7vHmwq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$iSGSosCGOJojtG4ylTLiWefdqoRXH9f2K7tS3CBOznLqODrui/IX6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IsStaffOfPreviousMonth", "Password" },
                values: new object[] { true, "$2a$11$Nt1kHZ1xCabyXcvzjcMoEuSPTURNoTjlURXw2CKn3RyE68X17DADa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$oFMwkbVoJPDEVGNrhljvE./soKno4KZIRr7UnfGvNcywBa/YDvFOG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$eJ0ji96aao2muRisUazi9uPZ0/F90q8rcKb.AJU.MSN8mbyaMHNsa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$xXokV3xaf0NripmKY/lL3.ny7vh3FEBLqkjq7SE9mh2r3htg0K/8S");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 7, 28, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 9, 16, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 11, 5, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2023, 12, 25, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2024, 2, 13, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2024, 4, 3, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2024, 5, 23, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2024, 6, 2, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2024, 6, 12, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2024, 6, 22, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2024, 7, 2, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2024, 7, 12, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6687));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishDate",
                value: new DateTime(2024, 7, 22, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishDate",
                value: new DateTime(2024, 8, 1, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishDate",
                value: new DateTime(2024, 8, 11, 15, 14, 3, 714, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zyUI2mEO4DKs138whbkQQOHUgLbfFB14I8zMss2h1l13FFOKWbshO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$.JHsk79AdQjRxUttj60UIOHXkzmr7LB40m76Je1Z6dSqNOXvmBgVa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$V5D1NVr5WPC4IiMtPXso/.sqWCjsRCYT9j1QaOWlVSE7DgFwCagRi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$kn3fRUXJXCt3F7jaHwo3Ae3QZH1tOcnlJPiHKdGUbytO/6JCb4eJC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$2.6fX1hs11WAAuLSChjP8.iOINV/SCZhIaCh.AKCDK7Jsx543/mZS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$pVNAlT1ATXxSfel5DBglf.f52N1OPNlc9kRThw0oS6gRIiHMJ5FVG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$u8vwpqOZq79cO6HfFboS/.Jg2W/G4rr6wK53piCFFJNHUgNz6Qxi2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$cMH0fjVagApgWjQBs6tkDuO8i9MQseRDf4Kh1HXb0Hyyy.Yc7oUCC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$yrjnGFgepaPD1FL4Jeq52OHsNqCAXYyHO/vHwx..K.FdN1A2pPkai");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$Mb87IYyHRNA23k5jeO6ZQ.ie25FCgspTnfAWVkH3wtN0WasH7bxfO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$2CZ7TT20QiqQCVNXjWFiHOOCpUsKPDZn0oi8nYZcb3YLECRW1r3o2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IsStaffOfPreviousMonth", "Password" },
                values: new object[] { false, "$2a$11$1lPys8ILI4LWJ26L.0ghDuYUQ2B6Lpz2BJHeglVuDJfH5TzRIgTBq" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$cUPRRlA4gTt94N0abVW3QubJfj2byzBcXmnKKPeArRvOcSgIvRRRe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$NNnGu4V1FGgyd0Wq9kKeo.yhmsc3W.GhyY4UnD7kGpZLNh8OQmMAK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$vOETkr/9ghc56QsXKty5WegS3slOtNQRv5gNJGMqZjrwvLe1Nxrs6");
        }
    }
}
