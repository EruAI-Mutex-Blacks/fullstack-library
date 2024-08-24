using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class removeUserIdPublishReqTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPublishRequests_Users_UserId",
                table: "BookPublishRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookPublishRequests_UserId",
                table: "BookPublishRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookPublishRequests",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishRequests_UserId",
                table: "BookPublishRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPublishRequests_Users_UserId",
                table: "BookPublishRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
