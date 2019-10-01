using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using PragWebApp.Data;
using PragWebApp.Data.Entities;

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

        public async Task<User> GetAllowedUser(string login)
        {
            return await this.dbContext.Users.FirstOrDefaultAsync(u => u.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<UserRole>> GetUserRoles(User user)
        {
            return await this.dbContext.UserRoles.Where(ur => ur.User.Id.Equals(user.Id)).ToListAsync();
        }
    }
}
