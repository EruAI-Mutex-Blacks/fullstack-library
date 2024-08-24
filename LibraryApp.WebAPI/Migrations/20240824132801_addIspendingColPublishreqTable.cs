using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addIspendingColPublishreqTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "BookPublishRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 17, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7253), new DateTime(2024, 8, 23, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 10, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7255), new DateTime(2024, 8, 17, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7256) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 3, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7258), new DateTime(2024, 8, 10, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7258) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 16, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 11, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 18, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 3, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 20, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 30, 13, 28, 1, 312, DateTimeKind.Utc).AddTicks(7341));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "BookPublishRequests");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 17, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7596), new DateTime(2024, 8, 23, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7597) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 10, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7598), new DateTime(2024, 8, 17, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7599) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 3, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7600), new DateTime(2024, 8, 10, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7601) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 16, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 11, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 18, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 3, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 20, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 30, 13, 15, 1, 165, DateTimeKind.Utc).AddTicks(7657));
        }
    }
}
