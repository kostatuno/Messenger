﻿// <auto-generated />
using System;
using Messenger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230210180756_AddedManyToManyForMessangerTable")]
    partial class AddedManyToManyForMessangerTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Cyrillic_General_CI_AS_KS")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GroupChatMessageUser", b =>
                {
                    b.Property<int>("GroupChatsId")
                        .HasColumnType("int");

                    b.Property<int>("MessagesId")
                        .HasColumnType("int");

                    b.HasKey("GroupChatsId", "MessagesId");

                    b.HasIndex("MessagesId");

                    b.ToTable("GroupChats_Messages", (string)null);
                });

            modelBuilder.Entity("GroupChatUser", b =>
                {
                    b.Property<int>("GroupChatsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersLogin")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GroupChatsId", "UsersLogin");

                    b.HasIndex("UsersLogin");

                    b.ToTable("Users_GroupChats", (string)null);
                });

            modelBuilder.Entity("MessageUserPersonalChat", b =>
                {
                    b.Property<int>("MessagesId")
                        .HasColumnType("int");

                    b.Property<int>("PersonalChatsId")
                        .HasColumnType("int");

                    b.HasKey("MessagesId", "PersonalChatsId");

                    b.HasIndex("PersonalChatsId");

                    b.ToTable("PersonalChats_Messages", (string)null);
                });

            modelBuilder.Entity("Messenger.Entities.ChatEntity.GroupChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("ModeratorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModeratorId")
                        .IsUnique()
                        .HasFilter("[ModeratorId] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.ToTable("GroupChats");
                });

            modelBuilder.Entity("Messenger.Entities.ChatEntity.GroupChatStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Status");

                    b.ToTable("GroupChatStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Сlosed"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Open"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Full"
                        });
                });

            modelBuilder.Entity("Messenger.Entities.ChatEntity.PersonalChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstUserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecondUserLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FirstUserLogin");

                    b.HasIndex("SecondUserLogin");

                    b.ToTable("PersonalChats");
                });

            modelBuilder.Entity("Messenger.Entities.MessageEntity.MessageStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Status");

                    b.ToTable("StatusMessege");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "NotRead"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Read"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Changed"
                        });
                });

            modelBuilder.Entity("Messenger.Entities.MessageEntity.MessageUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserName");

                    b.ToTable("MessageUser");
                });

            modelBuilder.Entity("Messenger.Entities.UserEnity.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Login");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Messenger.Entities.UserEnity.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Status");

                    b.ToTable("UserStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Offline"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Busy"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Invisible"
                        },
                        new
                        {
                            Id = 4,
                            Status = "Available"
                        });
                });

            modelBuilder.Entity("Messenger.Entities.UserEnity.Moderator", b =>
                {
                    b.HasBaseType("Messenger.Entities.UserEnity.User");

                    b.HasDiscriminator().HasValue("Moderator");
                });

            modelBuilder.Entity("GroupChatMessageUser", b =>
                {
                    b.HasOne("Messenger.Entities.ChatEntity.GroupChat", null)
                        .WithMany()
                        .HasForeignKey("GroupChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Entities.MessageEntity.MessageUser", null)
                        .WithMany()
                        .HasForeignKey("MessagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupChatUser", b =>
                {
                    b.HasOne("Messenger.Entities.ChatEntity.GroupChat", null)
                        .WithMany()
                        .HasForeignKey("GroupChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Entities.UserEnity.User", null)
                        .WithMany()
                        .HasForeignKey("UsersLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MessageUserPersonalChat", b =>
                {
                    b.HasOne("Messenger.Entities.MessageEntity.MessageUser", null)
                        .WithMany()
                        .HasForeignKey("MessagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Entities.ChatEntity.PersonalChat", null)
                        .WithMany()
                        .HasForeignKey("PersonalChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Messenger.Entities.ChatEntity.GroupChat", b =>
                {
                    b.HasOne("Messenger.Entities.UserEnity.Moderator", "Moderator")
                        .WithOne("GroupChat")
                        .HasForeignKey("Messenger.Entities.ChatEntity.GroupChat", "ModeratorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Messenger.Entities.ChatEntity.GroupChatStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moderator");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Messenger.Entities.ChatEntity.PersonalChat", b =>
                {
                    b.HasOne("Messenger.Entities.UserEnity.User", "FirstUser")
                        .WithMany("PersonalChatsFromSelf")
                        .HasForeignKey("FirstUserLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Entities.UserEnity.User", "SecondUser")
                        .WithMany("PersonalChatsFromInterlocutor")
                        .HasForeignKey("SecondUserLogin")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FirstUser");

                    b.Navigation("SecondUser");
                });

            modelBuilder.Entity("Messenger.Entities.MessageEntity.MessageUser", b =>
                {
                    b.HasOne("Messenger.Entities.MessageEntity.MessageStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Entities.UserEnity.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Entities.UserEnity.User", b =>
                {
                    b.HasOne("Messenger.Entities.UserEnity.UserStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Messenger.Entities.UserEnity.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("PersonalChatsFromInterlocutor");

                    b.Navigation("PersonalChatsFromSelf");
                });

            modelBuilder.Entity("Messenger.Entities.UserEnity.Moderator", b =>
                {
                    b.Navigation("GroupChat");
                });
#pragma warning restore 612, 618
        }
    }
}
