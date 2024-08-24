using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addBookPublishReqTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookPublishRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPublishRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPublishRequests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPublishRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 17, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 8, 23, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 10, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5888), new DateTime(2024, 8, 17, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5888) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 3, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5890), new DateTime(2024, 8, 10, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5890) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 16, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 11, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 18, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 3, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 20, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 30, 13, 6, 22, 972, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishRequests_BookId",
                table: "BookPublishRequests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishRequests_UserId",
                table: "BookPublishRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPublishRequests");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 17, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4178), new DateTime(2024, 8, 23, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4179) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 10, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4183), new DateTime(2024, 8, 17, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 3, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4185), new DateTime(2024, 8, 10, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4186) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 16, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 11, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 18, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 3, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 20, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 30, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4292));
        }
    }
}
