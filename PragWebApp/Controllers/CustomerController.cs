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
    public class CustomerController : Controller
    {
        private readonly IStringLocalizer<CustomerController> _localizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public CustomerController (
            IStringLocalizer<CustomerController> localizer,
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

        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _db.Customers.ToListAsync();

            //ViewData["MyTitle"] = _localizer["The localised title of my app!"];
            var requestCulture = this.Request.HttpContext.Features.Get<IRequestCultureFeature>();

            this.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("cs-CZ")),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return View(customers);
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            Customer customer = await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Employee/Create
        public IActionResult AddOrEdit(Guid? id = null)
        {
            if (!id.HasValue)
                return View(new Customer());
            else
                return View(_db.Customers.Find(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FirstName,LastName,Email,PhoneNumber,SendEmails,SendSmss,Description")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Id == Guid.Empty)
                {
                    customer.Created = DateTime.Now;
                    customer.Status = CustomerStatus.Created;
                    _db.Add(customer);
                }
                else
                {
                    customer.Status = CustomerStatus.Modified;
                    _db.Update(customer);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var customer = await _db.Customers.FindAsync(id);
            _db.Customers.Remove(customer);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}