using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using PragWebApp.Data;
using PragWebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace PragWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        protected ApplicationDbContext dbContext;

        public UserService(IServiceScopeFactory serviceScopeFactory)
            : base()
        {
            this.serviceScopeFactory = serviceScopeFactory;
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                this.dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            }
        }

        public async Task<IdentityUser> GetAllowedUser(string userName)
        {
            return await this.dbContext.Users.FirstOrDefaultAsync(u => u.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<IdentityUserRole<string>>> GetUserRoles(string userId)
        {
            return await this.dbContext.UserRoles.Where(ur => ur.UserId.Equals(userId)).ToListAsync();
        }
    }
}
