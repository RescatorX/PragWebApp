using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PragWebApp.Data;
using PragWebApp.Data.Entities;
using PragWebApp.Models;
using PragWebApp.Services;

namespace PragWebApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public CalendarController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            this._db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Stylist")]
        public IActionResult WorkingDay()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Stylist")]
        public IActionResult UserWeek(Guid userId)
        {
            return View();
        }

        [Authorize(Roles = "Admin,Stylist")]
        public IActionResult UserMonth(Guid userId)
        {
            return View();
        }
    }
}