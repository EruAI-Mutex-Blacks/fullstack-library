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
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsBorrowed = table.Column<bool>(type: "boolean", nullable: false)
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
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Gender = table.Column<char>(type: "character(1)", nullable: false),
                    IsPunished = table.Column<bool>(type: "boolean", nullable: false),
                    FineAmount = table.Column<int>(type: "integer", nullable: false)
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
                    BorrowDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "DATE", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    IsReceiverRead = table.Column<bool>(type: "boolean", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "IsBorrowed", "IsPublished", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, false, true, new DateTime(2024, 4, 13, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5644), "Book 1" },
                    { 2, false, true, new DateTime(2024, 8, 8, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5656), "Book 2" },
                    { 3, false, true, new DateTime(2024, 3, 15, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5658), "Book 3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "pendingUser" },
                    { 2, "member" },
                    { 3, "author" },
                    { 4, "staff" },
                    { 5, "manager" }
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
                columns: new[] { "Id", "BirthDate", "FineAmount", "Gender", "IsPunished", "Name", "Password", "RoleId", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1993, 7, 31, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5863), 0, 'M', false, "User 1", "123", 1, "surname1", "sr1" },
                    { 2, new DateTime(1985, 5, 17, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5868), 0, 'W', false, "User 2", "123", 2, "surname2", "sr12" },
                    { 3, new DateTime(1984, 6, 27, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5870), 0, 'W', false, "User 3", "123", 3, "surname3", "sr123" }
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
                    { 1, 1, new DateTime(2024, 8, 14, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5763), new DateTime(2024, 8, 20, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5763), 1 },
                    { 2, 2, new DateTime(2024, 8, 7, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5765), new DateTime(2024, 8, 14, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5766), 2 },
                    { 3, 3, new DateTime(2024, 7, 31, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5767), new DateTime(2024, 8, 7, 17, 53, 48, 4, DateTimeKind.Utc).AddTicks(5767), 3 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Details", "IsReceiverRead", "ReceiverId", "SenderId", "Title" },
                values: new object[,]
                {
                    { 1, "Selam, nasılsın? Bir konu hakkında soru soracaktım", false, 2, 1, "Title test 1" },
                    { 2, "iş nasıl gidiyor", false, 3, 1, "Title test 2" },
                    { 3, "yeni tshirt aldım", false, 1, 2, "Title test 3" },
                    { 4, "çalışın ulan! anca dedikodu", false, 3, 2, "Title test 4" },
                    { 5, "Sakin ol patron", false, 2, 3, "Title test 5" }
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
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

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
                name: "Messages");

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
