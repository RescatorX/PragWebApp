using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PragWebApp.Data;
using PragWebApp.Data.Entities;
using PragWebApp.Models;
using PragWebApp.Models.CalendarViewModels;
using PragWebApp.Services;

namespace PragWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/events")]
    public class CalendarEventController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public CalendarEventController(
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

        // GET: api/Events
        [HttpPost("initData")]
        public CalendarInitViewModel GetInitData([FromBody] SelectorDateParams selectorParams)
        {
            DateTime today = DateTime.Today;
            int year = today.Year;
            int month = today.Month;

            if (selectorParams != null)
            {
                year = selectorParams.Year;
                month = selectorParams.Month;
            }

            SelectorWeek[] weeks = GetMonthWeeks(year, month);

            CalendarInitViewModel model = new CalendarInitViewModel();
            model.User = User.Identity.Name;
            model.IsAdmin = User.IsInRole("Admin");
            model.Year = year;
            model.Month = month;
            model.MonthName = GetMonthName(month);
            model.Weeks = weeks;
            model.ViewRange = "DAY";

            return model;
        }

        private SelectorWeek[] GetMonthWeeks(int year, int month)
        {
            List<SelectorWeek> weeks = new List<SelectorWeek>();

            DateTime today = DateTime.Today;
            DateTime firstDay = new DateTime(year, month, 1);
            DateTime previousMonthLastDay = firstDay.AddDays(-1);

            int weekMondayIndex = DateTime.DaysInMonth(previousMonthLastDay.Year, previousMonthLastDay.Month) - (int)previousMonthLastDay.DayOfWeek;
            int weekIndex = 1;
            DateTime day = new DateTime(previousMonthLastDay.Year, previousMonthLastDay.Month, weekMondayIndex);
            if ((int)previousMonthLastDay.DayOfWeek < 2)
            {
                day = day.AddDays(-7);
                weeks.Add(GetWeek(day, month, weekIndex++));
            }
            while (weeks.Count < 7)
            {
                day = day.AddDays(7);
                weeks.Add(GetWeek(day, month, weekIndex++));
            }

            return weeks.ToArray();
        }

        private SelectorWeek GetWeek(DateTime monday, int selectedMonth, int weekIndex)
        {
            List<SelectorDay> days = new List<SelectorDay>();
            DateTime today = DateTime.Today;
            for (int i = 1; i <= 7; i++)
            {
                DateTime day = monday.AddDays(i);
                days.Add(new SelectorDay() { Day = day.Day, IsCurrentDay = (day.Equals(today)), IsInMonth = (day.Month == selectedMonth), IsSelected = (day.Equals(today)) });
            }
            return (new SelectorWeek() { Days = days.ToArray(), Week = weekIndex });
        }

        private string GetMonthName(int month)
        {
            string monthName = "";
            switch (month)
            {
                case 1: monthName = "Leden"; break;
                case 2: monthName = "Únor"; break;
                case 3: monthName = "Březen"; break;
                case 4: monthName = "Duben"; break;
                case 5: monthName = "Květen"; break;
                case 6: monthName = "Červen"; break;
                case 7: monthName = "Červenec"; break;
                case 8: monthName = "Srpen"; break;
                case 9: monthName = "Září"; break;
                case 10: monthName = "Říjen"; break;
                case 11: monthName = "Listopad"; break;
                case 12: monthName = "Prosinec"; break;
            }
            return monthName;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<CalendarEvent> GetEvents([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return _db.CalendarEvents.Where(e => !((e.End <= start) || (e.Start >= end)));
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.CalendarEvents.SingleOrDefaultAsync(m => m.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] Guid id, [FromBody] CalendarEvent @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            _db.Entry(@event).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] CalendarEvent @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.CalendarEvents.Add(@event);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.CalendarEvents.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            _db.CalendarEvents.Remove(@event);
            await _db.SaveChangesAsync();

            return Ok(@event);
        }

        private bool EventExists(Guid id)
        {
            return _db.CalendarEvents.Any(e => e.Id == id);
        }

        // PUT: api/Events/5/move
        [HttpPut("{id}/move")]
        public async Task<IActionResult> MoveEvent([FromRoute] Guid id, [FromBody] EventMoveParams param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.CalendarEvents.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            @event.Start = param.Start;
            @event.End = param.End;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Events/5/color
        [HttpPut("{id}/color")]
        public async Task<IActionResult> SetEvent([FromRoute] Guid id, [FromBody] CalendarEventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _db.CalendarEvents.SingleOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            @event.Event = eventType;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }

    public class EventMoveParams
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}