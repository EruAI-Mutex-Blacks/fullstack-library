using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class removeAuthorIdPublishReqTAble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublishRequests_Users_UserId",
                table: "BookPublishRequests");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BookPublishRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookPublishRequests",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 17, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7981), new DateTime(2024, 8, 23, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7982) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 10, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7983), new DateTime(2024, 8, 17, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7984) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 3, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7985), new DateTime(2024, 8, 10, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7985) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 16, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 11, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 18, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 8, 3, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 20, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 30, 13, 13, 15, 694, DateTimeKind.Utc).AddTicks(8085));

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublishRequests_Users_UserId",
                table: "BookPublishRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublishRequests_Users_UserId",
                table: "BookPublishRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookPublishRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "BookPublishRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublishRequests_Users_UserId",
                table: "BookPublishRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
