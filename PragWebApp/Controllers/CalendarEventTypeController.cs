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
using PragWebApp.Models;
using PragWebApp.Services;

namespace PragWebApp.Controllers
{
    public class CalendarEventTypeController : Controller
    {
        private readonly IStringLocalizer<CalendarEventTypeController> _localizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public CalendarEventTypeController(
            IStringLocalizer<CalendarEventTypeController> localizer,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext db,
            ILogger<CalendarEventTypeController> logger)
        {
            _localizer = localizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<CalendarEventType> calendarEventTypes = await _db.CalendarEventTypes.ToListAsync();

            return View(calendarEventTypes);
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            CalendarEventType calendarEventType = await _db.CalendarEventTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (calendarEventType == null)
            {
                return NotFound();
            }

            return View(calendarEventType);
        }

        public IActionResult AddOrEdit(Guid? id = null)
        {
            if (!id.HasValue)
                return View(new CalendarEventType());
            else
                return View(_db.CalendarEventTypes.Find(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Color")] CalendarEventType calendarEventType)
        {
            if (ModelState.IsValid)
            {
                if (calendarEventType.Id == Guid.Empty)
                {
                    _db.Add(calendarEventType);
                }
                else
                {
                    _db.Update(calendarEventType);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(calendarEventType);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var calendarEventType = await _db.CalendarEventTypes.FindAsync(id);
            _db.CalendarEventTypes.Remove(calendarEventType);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}