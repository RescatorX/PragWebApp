using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using PragWebApp.Data;
using PragWebApp.Extensions;
using PragWebApp.Models;
using PragWebApp.Models.AuditTrailViewModels;
using PragWebApp.Services;

namespace PragWebApp.Controllers
{
    public class AuditTrailController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuditTrailService _auditTrailService;

        public AuditTrailController(ILogger<AuditTrailController> logger, ApplicationDbContext db, UserManager<ApplicationUser> userManager, IAuditTrailService auditTrailService)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
            _auditTrailService = auditTrailService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            AuditTrailListViewModel model = new AuditTrailListViewModel() { Items = null };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> List(AuditTrailListViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Items = await _db.AuditTrails.Where(at => (
                    (model.ListFrom.HasValue ? (at.Created >= model.ListFrom) : true) &&
                    (model.ListTo.HasValue ? (at.Created <= model.ListTo) : true)))
                    .ToListAsync();

                ApplicationUser currentUser = await _userManager.GetUserAsync(User);
                await _auditTrailService.CreateAuditTrailAsync(_db, currentUser, "AuditTrail list", "AuditTrailController.List");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListByUser()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            AuditTrailListByUserViewModel model = new AuditTrailListByUserViewModel() { ListUser = currentUser, Items = null };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ListByUser(AuditTrailListByUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Items = await _db.AuditTrails.Where(at => (
                    (at.User.Id == model.ListUser.Id) && 
                    (model.ListFrom.HasValue ? (at.Created >= model.ListFrom) : true) && 
                    (model.ListTo.HasValue ? (at.Created <= model.ListTo) : true)))
                    .ToListAsync();

                await _auditTrailService.CreateAuditTrailAsync(_db, model.ListUser, "AuditTrail list by user", "AuditTrailController.ListByUser", $"List by user {model.ListUser.GetUserFullName()}");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete()
        {
            AuditTrailDeleteItemsViewModel model = new AuditTrailDeleteItemsViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AuditTrailDeleteItemsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.DeleteAllItems)
                {
                    _db.AuditTrails.Clear();
                }
                else
                {
                    _db.AuditTrails.RemoveRange(model.ItemsToDelete);
                }

                int count = await _db.SaveChangesAsync();

                ApplicationUser currentUser = await _userManager.GetUserAsync(User);
                await _auditTrailService.CreateAuditTrailAsync(_db, currentUser, "AuditTrail delete", "AuditTrailController.Delete", (model.DeleteAllItems ? $"All items ({count}) deleted" : $"{count} items deleted"));
            }

            return View(model);
        }
    }
}