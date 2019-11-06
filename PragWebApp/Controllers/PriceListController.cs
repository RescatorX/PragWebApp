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
    public class PriceListController : Controller
    {
        private readonly IStringLocalizer<PriceListController> _localizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public PriceListController(
            IStringLocalizer<PriceListController> localizer,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext db,
            ILogger<CustomerController> logger)
        {
            _localizer = localizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}