using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using PragWebApp.Data.Entities;

namespace PragWebApp.Services
{
    public interface IUserService
    {
        Task<IdentityUser> GetAllowedUser(string userName);

        Task<List<IdentityUserRole<string>>> GetUserRoles(string userId);
    }
}
