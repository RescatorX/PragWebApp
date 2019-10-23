﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PragWebApp.Data;

namespace PragWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191023101213_M05")]
    partial class M05
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PragWebApp.Data.Entities.AuditTrail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Detail");

                    b.Property<string>("Operation");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AuditTrail");
                });

            modelBuilder.Entity("PragWebApp.Data.Entities.CalendarEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllDay");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedById");

                    b.Property<string>("CustomerEmail");

                    b.Property<Guid?>("CustomerId");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhoneNumber");

                    b.Property<DateTime>("End");

                    b.Property<Guid?>("EventTypeId");

                    b.Property<string>("Note");

                    b.Property<Guid?>("OwnerId");

                    b.Property<bool>("SendEmail");

                    b.Property<bool>("SendSms");

                    b.Property<DateTime>("Start");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("OwnerId");

                    b.ToTable("CalendarEvent");
                });

            modelBuilder.Entity("PragWebApp.Data.Entities.CalendarEventType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CalendarEventType");
                });

            modelBuilder.Entity("PragWebApp.Data.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("SendEmails");

                    b.Property<bool>("SendSmss");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5"),
                            ConcurrencyStamp = "fb45648d-c0d3-45b2-b6bb-2b2d4521c59b",
                            Description = "Administrators role",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("07a9fd5b-4aa6-48c2-b048-989b821d1eb2"),
                            ConcurrencyStamp = "fd10a151-ad05-4ab8-9499-8ede30600d8a",
                            Description = "Stylists role",
                            Name = "Stylist",
                            NormalizedName = "STYLIST",
                            Status = 1
                        });
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(128);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(128);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6d99e130-7333-4be2-a513-45c42b48566f",
                            Created = new DateTime(2019, 10, 23, 12, 12, 12, 565, DateTimeKind.Local).AddTicks(5462),
                            Email = "xkalinam@email.cz",
                            EmailConfirmed = true,
                            FirstName = "Miroslav",
                            LastName = "Kalina",
                            LockoutEnabled = false,
                            NormalizedEmail = "XKALINAM@EMAIL.CZ",
                            NormalizedUserName = "RESCATORX",
                            PasswordHash = "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = true,
                            Status = 2,
                            TwoFactorEnabled = false,
                            UserName = "RescatorX"
                        },
                        new
                        {
                            Id = new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ca8496da-bf46-4554-a6b1-7095f5f70135",
                            Created = new DateTime(2019, 10, 23, 12, 12, 12, 567, DateTimeKind.Local).AddTicks(3336),
                            Email = "jiri.pragr@seznam.cz",
                            EmailConfirmed = true,
                            FirstName = "Jiří",
                            LastName = "Prágr",
                            LockoutEnabled = false,
                            NormalizedEmail = "JIRI.PRAGR@SEZNAM.CZ",
                            NormalizedUserName = "JPRAGR",
                            PasswordHash = "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892",
                            PhoneNumber = "987654321",
                            PhoneNumberConfirmed = true,
                            Status = 2,
                            TwoFactorEnabled = false,
                            UserName = "jpragr"
                        });
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime>("Added");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"),
                            RoleId = new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5"),
                            Added = new DateTime(2019, 10, 23, 12, 12, 12, 567, DateTimeKind.Local).AddTicks(9437)
                        },
                        new
                        {
                            UserId = new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"),
                            RoleId = new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5"),
                            Added = new DateTime(2019, 10, 23, 12, 12, 12, 568, DateTimeKind.Local).AddTicks(1228)
                        });
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"),
                            LoginProvider = "PragWebAppLoginProvider",
                            Name = "Token1",
                            Value = "Token1"
                        },
                        new
                        {
                            UserId = new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"),
                            LoginProvider = "PragWebAppLoginProvider",
                            Name = "Token2",
                            Value = "Token2"
                        });
                });

            modelBuilder.Entity("PragWebApp.Data.Entities.AuditTrail", b =>
                {
                    b.HasOne("PragWebApp.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PragWebApp.Data.Entities.CalendarEvent", b =>
                {
                    b.HasOne("PragWebApp.Models.ApplicationUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("PragWebApp.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("PragWebApp.Data.Entities.CalendarEventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId");

                    b.HasOne("PragWebApp.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationRoleClaim", b =>
                {
                    b.HasOne("PragWebApp.Models.ApplicationRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserClaim", b =>
                {
                    b.HasOne("PragWebApp.Models.ApplicationUser", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserLogin", b =>
                {
                    b.HasOne("PragWebApp.Models.ApplicationUser", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("PragWebApp.Models.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PragWebApp.Models.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PragWebApp.Models.ApplicationUserToken", b =>
                {
                    b.HasOne("PragWebApp.Models.ApplicationUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
