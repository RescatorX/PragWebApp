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
    [Migration("20191008124108_M01")]
    partial class M01
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

                    b.Property<string>("CustomerEmail");

                    b.Property<Guid?>("CustomerId");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhoneNumber");

                    b.Property<Guid?>("EventId");

                    b.Property<Guid?>("OwnerId");

                    b.Property<bool>("SendEmail");

                    b.Property<bool>("SendSms");

                    b.Property<int>("Status");

                    b.Property<DateTime>("Term");

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
                            Id = new Guid("cb39dd53-3840-4dab-8c6a-de169087c800"),
                            ConcurrencyStamp = "967065a1-4099-472a-9456-0fdfeb14e339",
                            Description = "Administrators role",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("d4166487-42b9-44ae-b2c1-1736d9c1d8ce"),
                            ConcurrencyStamp = "e743ec0f-eac4-473e-8236-b9d45a6e6d16",
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
                            Id = new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f3a86153-1767-441e-928a-b051a3f3ecb1",
                            Created = new DateTime(2019, 10, 8, 14, 41, 7, 969, DateTimeKind.Local).AddTicks(980),
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
                            Id = new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dab430ad-c901-4254-9ac0-17a335023cf8",
                            Created = new DateTime(2019, 10, 8, 14, 41, 7, 970, DateTimeKind.Local).AddTicks(6449),
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
                            UserId = new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"),
                            RoleId = new Guid("cb39dd53-3840-4dab-8c6a-de169087c800"),
                            Added = new DateTime(2019, 10, 8, 14, 41, 7, 971, DateTimeKind.Local).AddTicks(1201)
                        },
                        new
                        {
                            UserId = new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"),
                            RoleId = new Guid("cb39dd53-3840-4dab-8c6a-de169087c800"),
                            Added = new DateTime(2019, 10, 8, 14, 41, 7, 971, DateTimeKind.Local).AddTicks(2553)
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
                            UserId = new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"),
                            LoginProvider = "PragWebAppLoginProvider",
                            Name = "Token1",
                            Value = "Token1"
                        },
                        new
                        {
                            UserId = new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"),
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
