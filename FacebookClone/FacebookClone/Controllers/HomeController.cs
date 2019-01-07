using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace FacebookClone.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) { 
                return RedirectToAction("ShowMyProfile", "Profile");
            }
            //TO-DO on else add a view with a login form like on Filelist.
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchInput)
        {
            return RedirectToAction("Index", "Search", new { searchInput });
        }
    }
}