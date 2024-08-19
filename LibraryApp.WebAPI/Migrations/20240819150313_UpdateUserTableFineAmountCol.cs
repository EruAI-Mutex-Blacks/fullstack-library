using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTableFineAmountCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PenaltyAmount",
                table: "Users",
                newName: "FineAmount");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 12, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2730), new DateTime(2024, 8, 18, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 5, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2732), new DateTime(2024, 8, 12, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2732) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 29, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2733), new DateTime(2024, 8, 5, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2734) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 11, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 6, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 13, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 7, 29, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 15, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 25, 15, 3, 12, 922, DateTimeKind.Utc).AddTicks(2844));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FineAmount",
                table: "Users",
                newName: "PenaltyAmount");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 12, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(940), new DateTime(2024, 8, 18, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(941) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 5, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(942), new DateTime(2024, 8, 12, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 29, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(944), new DateTime(2024, 8, 5, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(944) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 11, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 6, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 13, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 7, 29, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 15, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 25, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(1010));
        }
    }
}
