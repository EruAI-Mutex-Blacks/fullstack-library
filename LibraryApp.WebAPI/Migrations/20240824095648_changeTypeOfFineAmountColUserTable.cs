using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class changeTypeOfFineAmountColUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "FineAmount",
                table: "Users",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

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
                columns: new[] { "BirthDate", "FineAmount" },
                values: new object[] { new DateTime(1993, 8, 3, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4286), 0f });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "FineAmount" },
                values: new object[] { new DateTime(1985, 5, 20, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4290), 0f });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "FineAmount" },
                values: new object[] { new DateTime(1984, 6, 30, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4292), 0f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FineAmount",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 16, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5342), new DateTime(2024, 8, 22, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 9, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5345), new DateTime(2024, 8, 16, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5345) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 2, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5347), new DateTime(2024, 8, 9, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5348) });

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
                columns: new[] { "BirthDate", "FineAmount" },
                values: new object[] { new DateTime(1993, 8, 2, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5418), 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "FineAmount" },
                values: new object[] { new DateTime(1985, 5, 19, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5421), 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "FineAmount" },
                values: new object[] { new DateTime(1984, 6, 29, 7, 45, 40, 962, DateTimeKind.Utc).AddTicks(5424), 0 });
        }
    }
}
