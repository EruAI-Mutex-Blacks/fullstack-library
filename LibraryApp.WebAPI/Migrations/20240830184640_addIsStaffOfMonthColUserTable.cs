using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addIsStaffOfMonthColUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStaffOfPreviousMonth",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2023, 7, 27, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2023, 9, 15, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2023, 11, 4, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2023, 12, 24, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishDate",
                value: new DateTime(2024, 2, 12, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishDate",
                value: new DateTime(2024, 4, 2, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishDate",
                value: new DateTime(2024, 5, 22, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishDate",
                value: new DateTime(2024, 6, 1, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishDate",
                value: new DateTime(2024, 6, 11, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishDate",
                value: new DateTime(2024, 6, 21, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishDate",
                value: new DateTime(2024, 7, 1, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishDate",
                value: new DateTime(2024, 7, 11, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "PublishDate",
                value: new DateTime(2024, 7, 21, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishDate",
                value: new DateTime(2024, 7, 31, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishDate",
                value: new DateTime(2024, 8, 10, 18, 46, 40, 44, DateTimeKind.Utc).AddTicks(6450));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsStaffOfPreviousMonth",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsStaffOfPreviousMonth",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStaffOfPreviousMonth",
                table: "Users");

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
    }
}
