using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 1, "Selam, nasılsın? Bir konu hakkında soru soracaktım", 2, 1 },
                    { 2, "iş nasıl gidiyor", 3, 1 },
                    { 3, "yeni tshirt aldım", 1, 2 },
                    { 4, "çalışın ulan! anca dedikodu", 3, 2 },
                    { 5, "Sakin ol patron", 2, 3 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

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
                column: "PublishDate",
                value: new DateTime(2024, 4, 2, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2024, 7, 28, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2024, 3, 4, 21, 9, 47, 230, DateTimeKind.Utc).AddTicks(889));

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
    }
}
