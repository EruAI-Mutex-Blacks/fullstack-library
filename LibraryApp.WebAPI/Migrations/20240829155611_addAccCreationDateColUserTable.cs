using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addAccCreationDateColUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 7, 26, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 9, 14, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 11, 3, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2023, 12, 23, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2024, 2, 11, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2024, 4, 1, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2024, 5, 21, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(718));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2024, 5, 31, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2024, 6, 10, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2024, 6, 20, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2024, 6, 30, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2024, 7, 10, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishDate",
                value: new DateTime(2024, 7, 20, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishDate",
                value: new DateTime(2024, 7, 30, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(732));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishDate",
                value: new DateTime(2024, 8, 9, 15, 56, 10, 823, DateTimeKind.Utc).AddTicks(733));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 7, 26, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 9, 14, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 11, 3, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2023, 12, 23, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2024, 2, 11, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2024, 4, 1, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2024, 5, 21, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2024, 5, 31, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2024, 6, 10, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2024, 6, 20, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2024, 6, 30, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2024, 7, 10, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishDate",
                value: new DateTime(2024, 7, 20, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishDate",
                value: new DateTime(2024, 7, 30, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishDate",
                value: new DateTime(2024, 8, 9, 12, 32, 10, 679, DateTimeKind.Utc).AddTicks(5907));
        }
    }
}
