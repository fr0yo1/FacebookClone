using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace FacebookClone.Controllers
{
    public class NewsFeedController: Controller
    {
        private FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();

        // GET: NewsFeed
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var aspNetUser = databaseEntities.AspNetUsers.Find(userId);
            return View("NewsFeed", new NewsFeedViewModel(aspNetUser));
        }

        [Authorize]
        public ActionResult AddComment(PostViewModel postViewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = databaseEntities.AspNetUsers.Find(userId);
            postViewModel.addCommentFrom(user, databaseEntities);
            return RedirectToAction("Index");
        }
    }
}