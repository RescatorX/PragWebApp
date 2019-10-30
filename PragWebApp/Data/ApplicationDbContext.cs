using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using PragWebApp.Data.Entities;
using PragWebApp.Data.Enums;
using PragWebApp.Extensions;
using PragWebApp.Models;
using PragWebApp.Utils;

namespace PragWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<CalendarEventType> CalendarEventTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuditTrail>().ToTable("AuditTrail");
            modelBuilder.Entity<CalendarEvent>().ToTable("CalendarEvent");
            modelBuilder.Entity<CalendarEventType>().ToTable("CalendarEventType");
            modelBuilder.Entity<Customer>().ToTable("Customer");

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property(u => u.UserName).HasMaxLength(128);
                b.Property(u => u.NormalizedUserName).HasMaxLength(128);
                b.Property(u => u.Email).HasMaxLength(128);
                b.Property(u => u.NormalizedEmail).HasMaxLength(128);

                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationUserToken>(b =>
            {
                b.Property(t => t.LoginProvider).HasMaxLength(128);
                b.Property(t => t.Name).HasMaxLength(128);
            });

            // Seed initial data

            ApplicationRole adminRole = null;
            ApplicationRole stylistRole = null;
            try
            {
                adminRole = new ApplicationRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "Administrators role",
                    Status = RoleStatus.Enabled
                };
                modelBuilder.Entity<ApplicationRole>().HasData(adminRole);

                stylistRole = new ApplicationRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Stylist",
                    NormalizedName = "STYLIST",
                    Description = "Stylists role",
                    Status = RoleStatus.Enabled
                };
                modelBuilder.Entity<ApplicationRole>().HasData(stylistRole);
            }
            catch (Exception e)
            {
                throw new Exception("PrefillDatabase - Roles table prefill error: " + e.Message, e);
            }

            List<ApplicationUserClaim> adminUserClaims = new List<ApplicationUserClaim>();
            List<ApplicationUserToken> adminUserTokens = new List<ApplicationUserToken>();
            List<ApplicationUserRole> adminUserRoles = new List<ApplicationUserRole>();

            ApplicationUser adminUser1 = null;
            ApplicationUser adminUser2 = null;
            ApplicationUser adminUser3 = null;
            try
            {
                adminUser1 = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Miroslav",
                    LastName = "Kalina",
                    UserName = "RescatorX",
                    NormalizedUserName = "RESCATORX",
                    Email = "xkalinam@email.cz",
                    NormalizedEmail = "XKALINAM@EMAIL.CZ",
                    EmailConfirmed = true,
                    Logins = null,
                    TwoFactorEnabled = false,
                    PhoneNumber = "123456789",
                    PhoneNumberConfirmed = true,
                    AccessFailedCount = 0,
                    Claims = adminUserClaims,
                    UserRoles = adminUserRoles,
                    Tokens = adminUserTokens,
                    PasswordHash = Constants.DefaultAdminPassword.ComputeSHA256Hash(),
                    Created = DateTime.Now,
                    Status = UserStatus.Verified,
                    DefaultColor = "lightgreen"
                };
                modelBuilder.Entity<ApplicationUser>().HasData(adminUser1);

                adminUser2 = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jiří",
                    LastName = "Prágr",
                    UserName = "jpragr",
                    NormalizedUserName = "JPRAGR",
                    Email = "jiri.pragr@seznam.cz",
                    NormalizedEmail = "JIRI.PRAGR@SEZNAM.CZ",
                    EmailConfirmed = true,
                    Logins = null,
                    TwoFactorEnabled = false,
                    PhoneNumber = "987654321",
                    PhoneNumberConfirmed = true,
                    AccessFailedCount = 0,
                    Claims = adminUserClaims,
                    UserRoles = adminUserRoles,
                    Tokens = adminUserTokens,
                    PasswordHash = Constants.DefaultAdminPassword.ComputeSHA256Hash(),
                    Created = DateTime.Now,
                    Status = UserStatus.Verified,
                    DefaultColor = "lightblue"
                };
                modelBuilder.Entity<ApplicationUser>().HasData(adminUser2);

                adminUser3 = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Sandra",
                    LastName = "Nisterová",
                    UserName = "snisterova",
                    NormalizedUserName = "SNISTEROVA",
                    Email = "sandra.nisterova@seznam.cz",
                    NormalizedEmail = "SANDRA.NISTEROVA@SEZNAM.CZ",
                    EmailConfirmed = true,
                    Logins = null,
                    TwoFactorEnabled = false,
                    PhoneNumber = "666555444",
                    PhoneNumberConfirmed = true,
                    AccessFailedCount = 0,
                    Claims = adminUserClaims,
                    UserRoles = adminUserRoles,
                    Tokens = adminUserTokens,
                    PasswordHash = Constants.DefaultAdminPassword.ComputeSHA256Hash(),
                    Created = DateTime.Now,
                    Status = UserStatus.Verified,
                    DefaultColor = "pink"
                };
                modelBuilder.Entity<ApplicationUser>().HasData(adminUser3);
            }
            catch (Exception e)
            {
                throw new Exception("PrefillDatabase - Users table prefill error: " + e.Message, e);
            }

            try
            {
                ApplicationUserRole adminUserRole1 = new ApplicationUserRole()
                {
                    UserId = adminUser1.Id,
                    RoleId = adminRole.Id,
                    Added = DateTime.Now
                };
                modelBuilder.Entity<ApplicationUserRole>().HasData(adminUserRole1);

                ApplicationUserRole adminUserRole2 = new ApplicationUserRole()
                {
                    UserId = adminUser2.Id,
                    RoleId = adminRole.Id,
                    Added = DateTime.Now
                };
                modelBuilder.Entity<ApplicationUserRole>().HasData(adminUserRole2);

                ApplicationUserRole stylistUserRole1 = new ApplicationUserRole()
                {
                    UserId = adminUser2.Id,
                    RoleId = stylistRole.Id,
                    Added = DateTime.Now
                };
                modelBuilder.Entity<ApplicationUserRole>().HasData(stylistUserRole1);

                ApplicationUserRole stylistUserRole2 = new ApplicationUserRole()
                {
                    UserId = adminUser3.Id,
                    RoleId = stylistRole.Id,
                    Added = DateTime.Now
                };
                modelBuilder.Entity<ApplicationUserRole>().HasData(stylistUserRole2);
            }
            catch (Exception e)
            {
                throw new Exception("PrefillDatabase - UserRoles table prefill error: " + e.Message, e);
            }

            try
            {
                ApplicationUserToken adminUserToken1 = new ApplicationUserToken()
                {
                    Name = "Token1",
                    UserId = adminUser1.Id,
                    Value = "Token1",
                    LoginProvider = "PragWebAppLoginProvider"
                };
                modelBuilder.Entity<ApplicationUserToken>().HasData(adminUserToken1);

                ApplicationUserToken adminUserToken2 = new ApplicationUserToken()
                {
                    Name = "Token2",
                    UserId = adminUser2.Id,
                    Value = "Token2",
                    LoginProvider = "PragWebAppLoginProvider"
                };
                modelBuilder.Entity<ApplicationUserToken>().HasData(adminUserToken2);
            }
            catch (Exception e)
            {
                throw new Exception("PrefillDatabase - UserRoles table prefill error: " + e.Message, e);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseLoggerFactory(GetLoggerFactory())
                .UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole().AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information));
            return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
        }
    }
}
