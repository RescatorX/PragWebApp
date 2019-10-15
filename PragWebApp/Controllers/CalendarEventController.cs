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
        [HttpGet("initData")]
        public CalendarInitViewModel GetInitData()
        {
            DateTime now = DateTime.Now;

            SelectorWeek[] weeks = GetMonthWeeks(now.Year, now.Month);

            CalendarInitViewModel model = new CalendarInitViewModel();
            model.User = User.Identity.Name;
            model.IsAdmin = User.IsInRole("Admin");
            model.Year = DateTime.Now.Year.ToString();
            model.MonthName = GetMonthName(now.Month);
            model.Weeks = weeks;
            model.ViewRange = "DAY";

            return model;
        }

        private SelectorWeek[] GetMonthWeeks(int year, int month)
        {
            List<SelectorWeek> weeks = new List<SelectorWeek>();

            DateTime firstDay = new DateTime(year, month, 1);
            DateTime previousMonthLastDay = firstDay.AddDays(-1);
            bool addPreviousMonthLastWeek = (firstDay.DayOfWeek < DayOfWeek.Wednesday);
            int previousMonthFirstVisibleDay = 0;

            int weekIndex = 0;
            if (addPreviousMonthLastWeek)
            {
                List<SelectorDay> days = new List<SelectorDay>();
                for (int i = 0; i < ((int)firstDay.DayOfWeek); i++)
                {
                    days.Add(new SelectorDay() { });
                }
                SelectorWeek week = new SelectorWeek() { Week = weekIndex++, Days = days.ToArray() };
            }
            for (int i = 0; i < ((int)firstDay.DayOfWeek); i++)
            {
            }

/*
            new SelectorWeek[] {
                            new StateItem() { State = "Processing", Final = false, TypeStateRelation = new TypeStateRelationItem() { Default = true, Order = 1, Users = new UserItem[] { new UserItem() { Id=1, Name="Kalina", Type="U"}, new UserItem() { Id=2, Name="Kalinovi", Type="G"} }, Editors = new UserItem[] {}, Readers = new UserItem[] {}}},
                            new StateItem() { State = "Final", Final = true, TypeStateRelation = new TypeStateRelationItem() { Default = false, Order = 2, Users = new UserItem[] {}, Editors = new UserItem[] {}, Readers = new UserItem[] {}}},
                            new StateItem() { State = "Added", Final = false, TypeStateRelation = new TypeStateRelationItem() { Default = false, Order = 3, Users = new UserItem[] {}, Editors = new UserItem[] {}, Readers = new UserItem[] {}}},
                            new StateItem() { State = "Deleted", Final = true, TypeStateRelation = new TypeStateRelationItem() { Default = false, Order = 4, Users = new UserItem[] {}, Editors = new UserItem[] {}, Readers = new UserItem[] {}}}
                        },
*/
            return weeks.ToArray();
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