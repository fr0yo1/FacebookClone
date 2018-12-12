using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class PostController : Controller
    {
        public FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddPost(PostViewModel postViewModel)
        {
            var userId = User.Identity.GetUserId();
            PostViewModel.addPostFrom(userId, databaseEntities,postViewModel.profilePath);
            var aspNetUser = databaseEntities.AspNetUsers.Find(userId);
            switch (postViewModel.appLocation)
            {
                case "Profile":
                    return RedirectToAction("Show", "Profile");
                case "Newsfeed":
                    return RedirectToAction("Index", "NewsFeed");
                default:
                    return Index();
            }

        }
    }
}