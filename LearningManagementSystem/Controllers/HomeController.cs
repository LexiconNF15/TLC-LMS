using LearningManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Teacher")]
        public ActionResult Administration()
        {
            return View();
        }
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var LoggedInUser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

                if (User.IsInRole("Student"))
                {
                    return RedirectToAction("details", "groups", new { Id = LoggedInUser.GroupId });
                }
                else if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("index", "groups");
                }
                else
                {
                    return RedirectToAction("login", "Account");
                }

            }
            else
            {
                return RedirectToAction("login", "Account");
            }
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