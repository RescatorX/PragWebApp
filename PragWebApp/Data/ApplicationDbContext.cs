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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        public async Task SeedDatabase()
        {
            //this.UserRoles
            ApplicationRole adminRole = null;
            ApplicationRole stylistRole = null;
            try
            {
                adminRole = new ApplicationRole()
                {
                    Name = "Admins",
                    NormalizedName = "ADMINS",
                    Description = "Administrators role",
                    Status = RoleStatus.Enabled
                };
                this.Roles.Add(adminRole);

                stylistRole = new ApplicationRole()
                {
                    Name = "Stylists",
                    NormalizedName = "STYLISTS",
                    Description = "Stylists role",
                    Status = RoleStatus.Enabled
                };
                this.Roles.Add(stylistRole);

                await this.SaveChangesAsync();
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
            try
            {
                adminUser1 = new ApplicationUser()
                {
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
                    Status = UserStatus.Verified
                };
                this.Users.Add(adminUser1);

                adminUser2 = new ApplicationUser()
                {
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
                    Status = UserStatus.Verified
                };
                this.Users.Add(adminUser2);

                await this.SaveChangesAsync();
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
                this.UserRoles.Add(adminUserRole1);

                ApplicationUserRole adminUserRole2 = new ApplicationUserRole()
                {
                    UserId = adminUser2.Id,
                    RoleId = adminRole.Id,
                    Added = DateTime.Now
                };
                this.UserRoles.Add(adminUserRole2);

                await this.SaveChangesAsync();
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
                    User = adminUser1,
                    UserId = adminUser1.Id,
                    Value = "Token1",
                    LoginProvider = "PragWebAppLoginProvider"
                };
                this.UserTokens.Add(adminUserToken1);

                ApplicationUserToken adminUserToken2 = new ApplicationUserToken()
                {
                    Name = "Token2",
                    User = adminUser2,
                    UserId = adminUser2.Id,
                    Value = "Token2",
                    LoginProvider = "PragWebAppLoginProvider"
                };
                this.UserTokens.Add(adminUserToken2);

                await this.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("PrefillDatabase - UserRoles table prefill error: " + e.Message, e);
            }            
        }
    }
}
