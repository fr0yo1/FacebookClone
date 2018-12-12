using FacebookClone.Handlers;
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
            var path = FilesHandler.saveImage(postViewModel.picture, Server);
            if(postViewModel.picture==null || path!=null)
            {
                PostViewModel.addPostFrom(userId, databaseEntities, path,postViewModel.content);
            }
            else
                ModelState.AddModelError("imageError", "Something went wrong we were unable to save the photo");

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