using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using PragWebApp.Data;
using PragWebApp.Data.Entities;
using PragWebApp.Data.Enums;
using PragWebApp.Models;
using PragWebApp.Services;

namespace PragWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public UserController(
            IStringLocalizer<UserController> localizer,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext db,
            ILogger<UserController> logger)
        {
            _localizer = localizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> users = await _db.Users.Include(u => u.UserRoles).ThenInclude(r => r.Role).ToListAsync();
            users.ForEach(u =>
            {
                u.IsAdmin = u.UserRoles.Any(r => ((r.User == u) && (r.Role.Name.Equals("Admin", StringComparison.InvariantCultureIgnoreCase))));
                u.IsStylist = u.UserRoles.Any(r => ((r.User == u) && (r.Role.Name.Equals("Stylist", StringComparison.InvariantCultureIgnoreCase))));
            });

            return View(users);
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            ApplicationUser user = await _db.Users.Include(u => u.UserRoles).ThenInclude(r => r.Role).FirstOrDefaultAsync(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsAdmin = user.UserRoles.Any(r => ((r.User == user) && (r.Role.Name.Equals("Admin", StringComparison.InvariantCultureIgnoreCase))));
            user.IsStylist = user.UserRoles.Any(r => ((r.User == user) && (r.Role.Name.Equals("Stylist", StringComparison.InvariantCultureIgnoreCase))));

            return View(user);
        }

        // GET: Employee/Create
        public async Task<IActionResult> AddOrEdit(Guid? id = null)
        {
            if (!id.HasValue)
                return View(new ApplicationUser());
            else
            {
                ApplicationUser user = await _db.Users.Include(u => u.UserRoles).ThenInclude(r => r.Role).FirstOrDefaultAsync(c => c.Id == id.Value);
                user.IsAdmin = user.UserRoles.Any(r => ((r.User == user) && (r.Role.Name.Equals("Admin", StringComparison.InvariantCultureIgnoreCase))));
                user.IsStylist = user.UserRoles.Any(r => ((r.User == user) && (r.Role.Name.Equals("Stylist", StringComparison.InvariantCultureIgnoreCase))));

                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FirstName,LastName,Email,PhoneNumber,UserName,PasswordHash,DefaultColor")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id == Guid.Empty)
                {
                    user.Created = DateTime.Now;
                    user.Status = UserStatus.Created;
                    _db.Add(user);
                }
                else
                {
                    user.Status = UserStatus.Modified;
                    _db.Update(user);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var user = await _db.Users.FindAsync(id);
            _db.Users.Remove(user);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}