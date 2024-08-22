using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovedColumnToBorrowsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "BookBorrowActivities",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "IsApproved", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 15, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6575), false, new DateTime(2024, 8, 21, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6576) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "IsApproved", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 8, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6578), false, new DateTime(2024, 8, 15, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "IsApproved", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 1, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6580), false, new DateTime(2024, 8, 8, 11, 0, 10, 211, DateTimeKind.Utc).AddTicks(6581) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "BookBorrowActivities");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 14, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5763), new DateTime(2024, 8, 20, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 7, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5765), new DateTime(2024, 8, 14, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 31, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5767), new DateTime(2024, 8, 7, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5767) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 13, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 8, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5656));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 15, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 7, 31, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 17, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 27, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5870));
        }
    }
}
