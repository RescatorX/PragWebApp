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
    [Migration("20191018084516_M03")]
    partial class M03
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

                    b.Property<DateTime>("CreatedBy");

                    b.Property<string>("CustomerEmail");

                    b.Property<Guid?>("CustomerId");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhoneNumber");

                    b.Property<DateTime>("End");

                    b.Property<Guid?>("EventId");

                    b.Property<Guid?>("OwnerId");

                    b.Property<bool>("SendEmail");

                    b.Property<bool>("SendSms");

                    b.Property<DateTime>("Start");

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EventId");

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
                            Id = new Guid("b2a4d267-9259-47d3-af00-46608c80be0c"),
                            ConcurrencyStamp = "06b4f950-0b77-4239-801b-9805fb4bceb9",
                            Description = "Administrators role",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("c25b44fc-c7fd-425d-b794-8577b9e393b8"),
                            ConcurrencyStamp = "05ea6a50-b191-490a-9060-a6fb808b7126",
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
                            Id = new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4fd3a0ac-3fb5-434c-b96d-0c3b2769f24e",
                            Created = new DateTime(2019, 10, 18, 10, 45, 15, 382, DateTimeKind.Local).AddTicks(463),
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
                            Id = new Guid("e24f066e-6275-40c7-b80f-6248f5233515"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "17af2b8c-3108-40c3-9e08-4e092b323538",
                            Created = new DateTime(2019, 10, 18, 10, 45, 15, 383, DateTimeKind.Local).AddTicks(8574),
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
                            UserId = new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"),
                            RoleId = new Guid("b2a4d267-9259-47d3-af00-46608c80be0c"),
                            Added = new DateTime(2019, 10, 18, 10, 45, 15, 384, DateTimeKind.Local).AddTicks(5875)
                        },
                        new
                        {
                            UserId = new Guid("e24f066e-6275-40c7-b80f-6248f5233515"),
                            RoleId = new Guid("b2a4d267-9259-47d3-af00-46608c80be0c"),
                            Added = new DateTime(2019, 10, 18, 10, 45, 15, 384, DateTimeKind.Local).AddTicks(7758)
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
                            UserId = new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"),
                            LoginProvider = "PragWebAppLoginProvider",
                            Name = "Token1",
                            Value = "Token1"
                        },
                        new
                        {
                            UserId = new Guid("e24f066e-6275-40c7-b80f-6248f5233515"),
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
                    b.HasOne("PragWebApp.Data.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("PragWebApp.Data.Entities.CalendarEventType", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

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
