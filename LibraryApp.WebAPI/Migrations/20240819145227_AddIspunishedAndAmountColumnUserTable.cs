using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class AddIspunishedAndAmountColumnUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPunished",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PenaltyAmount",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "BirthDate", "IsPunished", "PenaltyAmount" },
                values: new object[] { new DateTime(1993, 7, 29, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(1006), false, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "IsPunished", "PenaltyAmount" },
                values: new object[] { new DateTime(1985, 5, 15, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(1008), false, 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "IsPunished", "PenaltyAmount" },
                values: new object[] { new DateTime(1984, 6, 25, 14, 52, 27, 40, DateTimeKind.Utc).AddTicks(1010), false, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPunished",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PenaltyAmount",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 7, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9466), new DateTime(2024, 8, 13, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 31, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9469), new DateTime(2024, 8, 7, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9469) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 24, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9471), new DateTime(2024, 7, 31, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9471) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 6, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 1, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9305));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 8, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 7, 24, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 10, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 20, 21, 27, 49, 667, DateTimeKind.Utc).AddTicks(9546));
        }
    }
}
