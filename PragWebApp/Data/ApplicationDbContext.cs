using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using PragWebApp.Data.Entities;
using PragWebApp.Data.Enums;

namespace PragWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
/*
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<Role>().ToTable("Role");
            //modelBuilder.Entity<UserRole>().ToTable("UserRole");
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
/*
        public async Task SeedDatabase()
        {
            Role adminRole = null;
            Role stylistRole = null;
            try
            {
                adminRole = new Role()
                {
                    Name = "Admins",
                    Created = DateTime.Now,
                    Status = RoleStatus.Enabled
                };
                this.Roles.Add(adminRole);

                stylistRole = new Role()
                {
                    Name = "Stylists",
                    Created = DateTime.Now,
                    Status = RoleStatus.Enabled
                };
                this.Roles.Add(stylistRole);

                await this.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("PrefillDatabase - Roles table prefill error: " + e.Message, e);
            }

            User adminUser1 = null;
            User adminUser2 = null;
            try
            {
                adminUser1 = new User()
                {
                    FirstName = "Miroslav",
                    LastName = "Kalina",
                    Login = "xkalinam@email.cz",
                    Password = "PragPrag",
                    Created = DateTime.Now,
                    Status = UserStatus.Verified
                };
                this.Users.Add(adminUser1);

                adminUser2 = new User()
                {
                    FirstName = "Jiří",
                    LastName = "Prágr",
                    Login = "jiri.pragr@seznam.cz",
                    Password = "PragPrag",
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
                UserRole adminUserRole1 = new UserRole()
                {
                    User = adminUser1,
                    Role = adminRole,
                    Added = DateTime.Now
                };
                this.UserRoles.Add(adminUserRole1);

                UserRole adminUserRole2 = new UserRole()
                {
                    User = adminUser2,
                    Role = adminRole,
                    Added = DateTime.Now
                };
                this.UserRoles.Add(adminUserRole2);

                await this.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("PrefillDatabase - UserRoles table prefill error: " + e.Message, e);
            }
        }
*/
    }
}
