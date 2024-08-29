using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addMonthlyScoreColumnUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonthlyScore",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 7, 26, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 9, 14, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 11, 3, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2023, 12, 23, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2024, 2, 11, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2024, 4, 1, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2024, 5, 21, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2024, 5, 31, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2024, 6, 10, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2024, 6, 20, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2024, 6, 30, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2024, 7, 10, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishDate",
                value: new DateTime(2024, 7, 20, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishDate",
                value: new DateTime(2024, 7, 30, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishDate",
                value: new DateTime(2024, 8, 9, 12, 6, 8, 462, DateTimeKind.Utc).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "MonthlyScore",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "MonthlyScore",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyScore",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 7, 22, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 9, 10, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 10, 30, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2023, 12, 19, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2024, 2, 7, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2024, 3, 28, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2024, 5, 17, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2024, 5, 27, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2024, 6, 6, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2024, 6, 16, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2024, 6, 26, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2024, 7, 6, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishDate",
                value: new DateTime(2024, 7, 16, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishDate",
                value: new DateTime(2024, 7, 26, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishDate",
                value: new DateTime(2024, 8, 5, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6426));
        }
    }
}
