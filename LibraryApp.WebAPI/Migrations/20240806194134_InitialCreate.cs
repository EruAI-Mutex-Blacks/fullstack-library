using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fullstack_library.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrowActivities_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowActivities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "IsAvailable", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2024, 3, 29, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3396), "Book 1" },
                    { 2, true, new DateTime(2024, 7, 24, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3404), "Book 2" },
                    { 3, true, new DateTime(2024, 2, 29, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3405), "Book 3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Author" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "BookId", "Content" },
                values: new object[,]
                {
                    { 1, 1, "Page 1 Content" },
                    { 2, 1, "Page 2 Content" },
                    { 3, 2, "Page 1 Content" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Gender", "Name", "Password", "RoleId", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1993, 7, 16, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3542), 'M', "User 1", "123", 1, "surname1", "sr1" },
                    { 2, new DateTime(1985, 5, 2, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3545), 'W', "User 2", "123", 2, "surname2", "sr12" },
                    { 3, new DateTime(1984, 6, 12, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3547), 'W', "User 3", "123", 3, "surname3", "sr123" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "Id", "BookId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 3 },
                    { 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowActivities",
                columns: new[] { "Id", "BookId", "BorrowDate", "ReturnDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 30, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3488), new DateTime(2024, 8, 5, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3489), 1 },
                    { 2, 2, new DateTime(2024, 7, 23, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3491), new DateTime(2024, 7, 30, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3492), 2 },
                    { 3, 3, new DateTime(2024, 7, 16, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3493), new DateTime(2024, 7, 23, 19, 41, 34, 298, DateTimeKind.Utc).AddTicks(3494), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_UserId",
                table: "BookAuthors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowActivities_BookId",
                table: "BookBorrowActivities",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowActivities_UserId",
                table: "BookBorrowActivities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_BookId",
                table: "Pages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookBorrowActivities");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
