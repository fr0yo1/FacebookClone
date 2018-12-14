using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class CommentController : Controller
    {
        private FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddComment(PostViewModel postViewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = databaseEntities.AspNetUsers.Find(userId);
            postViewModel.addCommentFrom(user, databaseEntities);
            var aspNetUser = databaseEntities.AspNetUsers.Find(userId);
            switch (postViewModel.appLocation)
            {
                case "Profile":
                    return RedirectToAction("Show", "Profile",new { id = user.Profile.Id });
                case "Newsfeed":
                    return RedirectToAction("Index", "NewsFeed");
                case "Groups":
                    return RedirectToAction("Show", "Groups");
                default:
                    return Index();
            }

        }
    }
}