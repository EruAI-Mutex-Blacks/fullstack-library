using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addReadColumnMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsReceiverRead",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Details", "IsReceiverRead", "Title" },
                values: new object[] { "Selam, nasılsın? Bir konu hakkında soru soracaktım", false, "Title test 1" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Details", "IsReceiverRead", "Title" },
                values: new object[] { "iş nasıl gidiyor", false, "Title test 2" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Details", "IsReceiverRead", "Title" },
                values: new object[] { "yeni tshirt aldım", false, "Title test 3" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Details", "IsReceiverRead", "Title" },
                values: new object[] { "çalışın ulan! anca dedikodu", false, "Title test 4" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Details", "IsReceiverRead", "Title" },
                values: new object[] { "Sakin ol patron", false, "Title test 5" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsReceiverRead",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Messages",
                newName: "Content");

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 8, 7, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6225), new DateTime(2024, 8, 13, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6226) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 31, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6228), new DateTime(2024, 8, 7, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6229) });

            migrationBuilder.UpdateData(
                table: "BookBorrowActivities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 7, 24, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6231), new DateTime(2024, 7, 31, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6231) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2024, 4, 6, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 8, 1, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 8, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Selam, nasılsın? Bir konu hakkında soru soracaktım");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "iş nasıl gidiyor");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "yeni tshirt aldım");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "çalışın ulan! anca dedikodu");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "Sakin ol patron");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1993, 7, 24, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1985, 5, 10, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1984, 6, 20, 21, 10, 57, 343, DateTimeKind.Utc).AddTicks(6343));
        }
    }
}
