using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PragWebApp.Areas.Web.Controllers
{
    [Area("Web")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contacts
        public ActionResult Contacts()
        {
            return View();
        }

        // GET: References
        public ActionResult References()
        {
            return View();
        }
    }
}