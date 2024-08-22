using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class AddBookTablePublishedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Books",
                newName: "IsPublished");

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Books",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 3, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(984), new DateTime(2024, 8, 9, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(985) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 27, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(987), new DateTime(2024, 8, 3, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(988) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 20, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(990), new DateTime(2024, 7, 27, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsBorrowed", "PublishDate" },
                values: new object[] { false, new DateTime(2024, 4, 2, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsBorrowed", "PublishDate" },
                values: new object[] { false, new DateTime(2024, 7, 28, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(887) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsBorrowed", "PublishDate" },
                values: new object[] { false, new DateTime(2024, 3, 4, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 7, 20, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 6, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 16, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(1058));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "Books",
                newName: "IsAvailable");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3488), new DateTime(2024, 8, 5, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3489) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 23, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3491), new DateTime(2024, 7, 30, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3492) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 16, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3493), new DateTime(2024, 7, 23, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3494) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 3, 29, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 7, 24, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 2, 29, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 7, 16, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 2, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 12, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3547));
        }
    }
}
