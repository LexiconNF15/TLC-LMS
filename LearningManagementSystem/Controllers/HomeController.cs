using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Teacher")]
        public ActionResult Administration()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Om Applikationen";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontaktuppgifter";

            return View();
        }
    }
}