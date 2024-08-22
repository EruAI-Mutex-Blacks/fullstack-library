using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addPageNumColPageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "Pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 15, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7084), new DateTime(2024, 8, 21, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 8, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7087), new DateTime(2024, 8, 15, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7088) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 1, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7089), new DateTime(2024, 8, 8, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 14, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 9, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 16, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 1,
                column: "PageNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 2,
                column: "PageNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 3,
                column: "PageNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 1, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 18, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7235));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 28, 20, 43, 23, 117, DateTimeKind.Utc).AddTicks(7238));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "Pages");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 15, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6575), new DateTime(2024, 8, 21, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 8, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6578), new DateTime(2024, 8, 15, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6580), new DateTime(2024, 8, 8, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6581) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 14, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 9, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6474));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 16, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 1, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 18, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 28, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6652));
        }
    }
}
