using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PragWebApp.Data.Entities;

namespace PragWebApp.Services
{
    public interface IUserService
    {
        Task<User> GetAllowedUser(string login);

        Task<List<UserRole>> GetUserRoles(User user);
    }
}
