using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;

namespace FacebookClone.Controllers
{
    public class HomeController : Controller
    {

        private FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) { 
                return RedirectToAction("Show", "Profile");
            }
            //TO-DO on else add a view with a login form like on Filelist.
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}