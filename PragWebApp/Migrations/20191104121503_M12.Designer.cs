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
    [Migration("20191104121503_M12")]
    partial class M12
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

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CalendarEventType");
                });

            modelBuilder.Entity("PragWebApp.Data.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

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
                            Id = new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e"),
                            ConcurrencyStamp = "37189b3d-e203-458f-86f0-b998773142b1",
                            Description = "Administrators role",
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2"),
                            ConcurrencyStamp = "d16bf70f-1b81-4c1e-b87f-735381dda6a3",
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
                            Id = new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3aed30a4-1ca3-4e86-a61f-0d28933900b4",
                            Created = new DateTime(2019, 11, 4, 13, 15, 3, 278, DateTimeKind.Local).AddTicks(6575),
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
                            Id = new Guid("63674a6d-940b-4109-91db-19ab465c24ca"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6a8a7d89-4755-4378-b8a0-995f0d8fa80a",
                            Created = new DateTime(2019, 11, 4, 13, 15, 3, 288, DateTimeKind.Local).AddTicks(8726),
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
                            Id = new Guid("d68b8a26-1560-470f-acb7-29ce48eb100e"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "da097a14-8c22-4345-9049-e32cf2b2545b",
                            Created = new DateTime(2019, 11, 4, 13, 15, 3, 288, DateTimeKind.Local).AddTicks(9449),
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
                            UserId = new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"),
                            RoleId = new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e"),
                            Added = new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(4967)
                        },
                        new
                        {
                            UserId = new Guid("63674a6d-940b-4109-91db-19ab465c24ca"),
                            RoleId = new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e"),
                            Added = new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(6420)
                        },
                        new
                        {
                            UserId = new Guid("63674a6d-940b-4109-91db-19ab465c24ca"),
                            RoleId = new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2"),
                            Added = new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(6489)
                        },
                        new
                        {
                            UserId = new Guid("d68b8a26-1560-470f-acb7-29ce48eb100e"),
                            RoleId = new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2"),
                            Added = new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(6515)
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
                            UserId = new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"),
                            LoginProvider = "PragWebAppLoginProvider",
                            Name = "Token1",
                            Value = "Token1"
                        },
                        new
                        {
                            UserId = new Guid("63674a6d-940b-4109-91db-19ab465c24ca"),
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