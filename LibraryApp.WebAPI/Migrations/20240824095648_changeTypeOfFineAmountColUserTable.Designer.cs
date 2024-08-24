﻿// <auto-generated />
using System;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fullstack_library.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240824095648_changeTypeOfFineAmountColUserTable")]
    partial class changeTypeOfFineAmountColUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibraryApp.Data.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsBorrowed = false,
                            IsPublished = true,
                            PublishDate = new DateTime(2024, 4, 16, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4046),
                            Title = "Book 1"
                        },
                        new
                        {
                            Id = 2,
                            IsBorrowed = false,
                            IsPublished = true,
                            PublishDate = new DateTime(2024, 8, 11, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4059),
                            Title = "Book 2"
                        },
                        new
                        {
                            Id = 3,
                            IsBorrowed = false,
                            IsPublished = true,
                            PublishDate = new DateTime(2024, 3, 18, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4060),
                            Title = "Book 3"
                        });
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.BookBorrowActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("DATE");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("DATE");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookBorrowActivities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            BorrowDate = new DateTime(2024, 8, 17, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4178),
                            IsApproved = false,
                            IsReturned = false,
                            ReturnDate = new DateTime(2024, 8, 23, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4179),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            BorrowDate = new DateTime(2024, 8, 10, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4183),
                            IsApproved = false,
                            IsReturned = false,
                            ReturnDate = new DateTime(2024, 8, 17, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4184),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            BorrowDate = new DateTime(2024, 8, 3, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4185),
                            IsApproved = false,
                            IsReturned = false,
                            ReturnDate = new DateTime(2024, 8, 10, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4186),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsReceiverRead")
                        .HasColumnType("boolean");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("integer");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Details = "Selam, nasılsın? Bir konu hakkında soru soracaktım",
                            IsReceiverRead = false,
                            ReceiverId = 2,
                            SenderId = 1,
                            Title = "Title test 1"
                        },
                        new
                        {
                            Id = 2,
                            Details = "iş nasıl gidiyor",
                            IsReceiverRead = false,
                            ReceiverId = 3,
                            SenderId = 1,
                            Title = "Title test 2"
                        },
                        new
                        {
                            Id = 3,
                            Details = "yeni tshirt aldım",
                            IsReceiverRead = false,
                            ReceiverId = 1,
                            SenderId = 2,
                            Title = "Title test 3"
                        },
                        new
                        {
                            Id = 4,
                            Details = "çalışın ulan! anca dedikodu",
                            IsReceiverRead = false,
                            ReceiverId = 3,
                            SenderId = 2,
                            Title = "Title test 4"
                        },
                        new
                        {
                            Id = 5,
                            Details = "Sakin ol patron",
                            IsReceiverRead = false,
                            ReceiverId = 2,
                            SenderId = 3,
                            Title = "Title test 5"
                        });
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PageNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Pages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Content = "Page 1 Content",
                            PageNumber = 0
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Content = "Page 2 Content",
                            PageNumber = 0
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            Content = "Page 1 Content",
                            PageNumber = 0
                        });
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "pendingUser"
                        },
                        new
                        {
                            Id = 2,
                            Name = "member"
                        },
                        new
                        {
                            Id = 3,
                            Name = "author"
                        },
                        new
                        {
                            Id = 4,
                            Name = "staff"
                        },
                        new
                        {
                            Id = 5,
                            Name = "manager"
                        });
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<float>("FineAmount")
                        .HasColumnType("real");

                    b.Property<char>("Gender")
                        .HasColumnType("character(1)");

                    b.Property<bool>("IsPunished")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1993, 8, 3, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4286),
                            FineAmount = 0f,
                            Gender = 'M',
                            IsPunished = false,
                            Name = "User 1",
                            Password = "123",
                            RoleId = 1,
                            Surname = "surname1",
                            Username = "sr1"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1985, 5, 20, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4290),
                            FineAmount = 0f,
                            Gender = 'W',
                            IsPunished = false,
                            Name = "User 2",
                            Password = "123",
                            RoleId = 2,
                            Surname = "surname2",
                            Username = "sr12"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1984, 6, 30, 9, 56, 47, 988, DateTimeKind.Utc).AddTicks(4292),
                            FineAmount = 0f,
                            Gender = 'W',
                            IsPunished = false,
                            Name = "User 3",
                            Password = "123",
                            RoleId = 3,
                            Surname = "surname3",
                            Username = "sr123"
                        });
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.BookAuthor", b =>
                {
                    b.HasOne("LibraryApp.Data.Entity.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp.Data.Entity.User", "User")
                        .WithMany("BookAuthors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.BookBorrowActivity", b =>
                {
                    b.HasOne("LibraryApp.Data.Entity.Book", "Book")
                        .WithMany("BookBorrowActivities")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp.Data.Entity.User", "User")
                        .WithMany("BookActivities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.Message", b =>
                {
                    b.HasOne("LibraryApp.Data.Entity.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryApp.Data.Entity.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.Page", b =>
                {
                    b.HasOne("LibraryApp.Data.Entity.Book", "Book")
                        .WithMany("Pages")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.User", b =>
                {
                    b.HasOne("LibraryApp.Data.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookBorrowActivities");

                    b.Navigation("Pages");
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LibraryApp.Data.Entity.User", b =>
                {
                    b.Navigation("BookActivities");

                    b.Navigation("BookAuthors");
                });
#pragma warning restore 612, 618
        }
    }
}
