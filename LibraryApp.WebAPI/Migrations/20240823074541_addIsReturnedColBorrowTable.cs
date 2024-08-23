using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addIsReturnedColBorrowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReturned",
                table: "BookBorrowActivities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "IsReturned", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 16, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5342), false, new DateTime(2024, 8, 22, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "IsReturned", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 9, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5345), false, new DateTime(2024, 8, 16, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5345) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "IsReturned", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 2, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5347), false, new DateTime(2024, 8, 9, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5348) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 15, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 10, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 17, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 2, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 19, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 29, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5424));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReturned",
                table: "BookBorrowActivities");

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
    }
}
