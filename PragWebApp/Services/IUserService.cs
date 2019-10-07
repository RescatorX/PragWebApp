using System.Collections.Generic;
using System.Threading.Tasks;

using PragWebApp.Models;

namespace PragWebApp.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> GetAllowedUser(string userName);

        Task<List<ApplicationUserRole>> GetUserRoles(string userId);
    }
}
