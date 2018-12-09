using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class ProfileController : Controller
    {
        private FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();

        public ActionResult Add(Profile profile)
        {
            var currentUserId = User.Identity.GetUserId();
            profile.gender = "male";
            profile.Id = currentUserId;

            databaseEntities.Profiles.Add(profile);
            databaseEntities.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}