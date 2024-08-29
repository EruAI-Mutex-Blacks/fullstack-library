using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class addLastResetDateAndAccountCreationDateColumnUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AccountCreationDate",
                table: "Users",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ScoreLastResetDate",
                table: "Users",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AccountCreationDate", "ScoreLastResetDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountCreationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ScoreLastResetDate",
                table: "Users");

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
        }
    }
}
