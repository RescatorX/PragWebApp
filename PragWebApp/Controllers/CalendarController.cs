using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PragWebApp.Controllers
{
    public class CalendarController : Controller
    {
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

        [Authorize(Roles = "Stylist")]
        public IActionResult WorkingDay()
        {
            return View();
        }

        [Authorize(Roles = "Stylist")]
        public IActionResult UserWeek(Guid userId)
        {
            return View();
        }

        [Authorize(Roles = "Stylist")]
        public IActionResult UserMonth(Guid userId)
        {
            return View();
        }
    }
}