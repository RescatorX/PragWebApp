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
    [Migration("20191030003442_M10")]
    partial class M10
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

                    b.Property<DateTime>("Modified");

                    b.Property<Guid?>("ModifiedById");

                    b.Property<string>("Note");

                    b.Property<Guid?>("OwnerId");

                    b.Property<bool>("SendEmail");

                    b.Property<bool>("SendSms");

                    b.Property<DateTime>("Start");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("ModifiedById");

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
                            Id = new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199"),
                            ConcurrencyStamp = "1ae5c636-8ba7-46cf-82c4-196553d6ee01",
                            Description = "Administrators role",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("6743d304-b2f4-440e-928e-628536edf88e"),
                            ConcurrencyStamp = "fe9c5b96-6303-4137-8451-24487aa1a773",
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

                    b.Property<string>("DefaultColor");

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
                            Id = new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9c9c9b80-7db6-4f45-b959-9b5adcb3c8ff",
                            Created = new DateTime(2019, 10, 30, 1, 34, 41, 890, DateTimeKind.Local).AddTicks(7411),
                            DefaultColor = "lightgreen",
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
                            Id = new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6e31e28a-ae3a-4b53-be3e-c53197f845b4",
                            Created = new DateTime(2019, 10, 30, 1, 34, 41, 894, DateTimeKind.Local).AddTicks(8166),
                            DefaultColor = "lightblue",
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
                        },
                        new
                        {
                            Id = new Guid("4b852fd0-5de0-4c5b-9a3a-48627a5dcb7a"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f9281591-f041-47d3-a297-877c7b8745d0",
                            Created = new DateTime(2019, 10, 30, 1, 34, 41, 894, DateTimeKind.Local).AddTicks(8478),
                            DefaultColor = "pink",
                            Email = "sandra.nisterova@seznam.cz",
                            EmailConfirmed = true,
                            FirstName = "Sandra",
                            LastName = "Nisterová",
                            LockoutEnabled = false,
                            NormalizedEmail = "SANDRA.NISTEROVA@SEZNAM.CZ",
                            NormalizedUserName = "SNISTEROVA",
                            PasswordHash = "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892",
                            PhoneNumber = "666555444",
                            PhoneNumberConfirmed = true,
                            Status = 2,
                            TwoFactorEnabled = false,
                            UserName = "snisterova"
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
                            UserId = new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"),
                            RoleId = new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199"),
                            Added = new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(5181)
                        },
                        new
                        {
                            UserId = new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"),
                            RoleId = new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199"),
                            Added = new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(6756)
                        },
                        new
                        {
                            UserId = new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"),
                            RoleId = new Guid("6743d304-b2f4-440e-928e-628536edf88e"),
                            Added = new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(6847)
                        },
                        new
                        {
                            UserId = new Guid("4b852fd0-5de0-4c5b-9a3a-48627a5dcb7a"),
                            RoleId = new Guid("6743d304-b2f4-440e-928e-628536edf88e"),
                            Added = new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(6887)
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
                            UserId = new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"),
                            LoginProvider = "PragWebAppLoginProvider",
                            Name = "Token1",
                            Value = "Token1"
                        },
                        new
                        {
                            UserId = new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"),
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

                    b.HasOne("PragWebApp.Models.ApplicationUser", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById");

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
