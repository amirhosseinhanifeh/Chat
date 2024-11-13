﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mozer.ServiceContext.DatabaseContext;

namespace Mozer.Migrations
{
    [DbContext(typeof(MozerContext))]
    [Migration("20230903112946_AddIsRead")]
    partial class AddIsRead
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mozer.Models.Accounts.Entities.ProfileModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Profiles", "Identites");
                });

            modelBuilder.Entity("Mozer.Models.Accounts.Entities.RoleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "Identites");
                });

            modelBuilder.Entity("Mozer.Models.Accounts.Entities.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Users", "Identites");
                });

            modelBuilder.Entity("Mozer.Models.Invoices.Entities.InvoiceItemModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("InvoiceId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ItemAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceItems", "Invoices");
                });

            modelBuilder.Entity("Mozer.Models.Invoices.Entities.InvoiceModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices", "Invoices");
                });

            modelBuilder.Entity("Mozer.Models.Locations.Entities.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses", "Locations");
                });

            modelBuilder.Entity("Mozer.Models.Locations.Entities.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities", "Locations");
                });

            modelBuilder.Entity("Mozer.Models.Locations.Entities.ProvinceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces", "Locations");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageActionModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MessageAction")
                        .HasColumnType("int");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId", "MessageId", "MessageAction");

                    b.ToTable("MessageActions", "Messages");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageItemActionModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MessageAction")
                        .HasColumnType("int");

                    b.Property<Guid>("MessageItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MessageItemId");

                    b.HasIndex("UserId", "MessageAction");

                    b.ToTable("MessageItemActions", "Messages");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageItemModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MessageType")
                        .HasColumnType("int");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("SenderId");

                    b.ToTable("MessageItems", "Messages");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ReciverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReciverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages", "Messages");
                });

            modelBuilder.Entity("Mozer.Models.Relation.Entities.RelationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RelationType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId");

                    b.ToTable("Relations", "Relations");
                });

            modelBuilder.Entity("Mozer.Models.Accounts.Entities.ProfileModel", b =>
                {
                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Mozer.Models.Accounts.Entities.ProfileModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mozer.Models.Accounts.Entities.UserModel", b =>
                {
                    b.HasOne("Mozer.Models.Accounts.Entities.RoleModel", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Mozer.Models.Invoices.Entities.InvoiceItemModel", b =>
                {
                    b.HasOne("Mozer.Models.Invoices.Entities.InvoiceModel", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Mozer.Models.Invoices.Entities.InvoiceModel", b =>
                {
                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mozer.Models.Locations.Entities.AddressModel", b =>
                {
                    b.HasOne("Mozer.Models.Locations.Entities.CityModel", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "User")
                        .WithMany("Address")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mozer.Models.Locations.Entities.CityModel", b =>
                {
                    b.HasOne("Mozer.Models.Locations.Entities.ProvinceModel", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageActionModel", b =>
                {
                    b.HasOne("Mozer.Models.Messages.Entities.MessageModel", "Message")
                        .WithMany("MessageActions")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageItemActionModel", b =>
                {
                    b.HasOne("Mozer.Models.Messages.Entities.MessageItemModel", "MessageItem")
                        .WithMany("MessageItemActions")
                        .HasForeignKey("MessageItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("MessageItem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageItemModel", b =>
                {
                    b.HasOne("Mozer.Models.Messages.Entities.MessageModel", "Message")
                        .WithMany("MessageItems")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Message");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageModel", b =>
                {
                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "Reciver")
                        .WithMany()
                        .HasForeignKey("ReciverId");

                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reciver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Mozer.Models.Relation.Entities.RelationModel", b =>
                {
                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "Friend")
                        .WithMany("FriendRelations")
                        .HasForeignKey("FriendId");

                    b.HasOne("Mozer.Models.Accounts.Entities.UserModel", "User")
                        .WithMany("UserRelations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mozer.Models.Accounts.Entities.RoleModel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mozer.Models.Accounts.Entities.UserModel", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("FriendRelations");

                    b.Navigation("Messages");

                    b.Navigation("Profile");

                    b.Navigation("UserRelations");
                });

            modelBuilder.Entity("Mozer.Models.Invoices.Entities.InvoiceModel", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("Mozer.Models.Locations.Entities.ProvinceModel", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageItemModel", b =>
                {
                    b.Navigation("MessageItemActions");
                });

            modelBuilder.Entity("Mozer.Models.Messages.Entities.MessageModel", b =>
                {
                    b.Navigation("MessageActions");

                    b.Navigation("MessageItems");
                });
#pragma warning restore 612, 618
        }
    }
}
