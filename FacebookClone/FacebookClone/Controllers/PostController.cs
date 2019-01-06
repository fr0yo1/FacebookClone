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
            if (postViewModel.picture == null || path != null)
            {
                PostViewModel.addPostFrom(userId, databaseEntities, path, postViewModel.content, postViewModel.albumID, postViewModel.group_id);
            }
            else
                ModelState.AddModelError("imageError", "Something went wrong we were unable to save the photo");

            switch (postViewModel.appLocation)
            {
                case "Profile":
                    return RedirectToAction("ShowMyProfile", "Profile");
                case "Newsfeed":
                    return RedirectToAction("Index", "NewsFeed");
                case "Groups":
                    return RedirectToAction("Show", "Groups");
                default:
                    return Index();
            }
        }

        [Authorize]
        public ActionResult AcceptComment(string commentId, string location)
        {
            var thisComm = databaseEntities.Comments.Find(commentId);
            CommentViewModel comment = new CommentViewModel(thisComm, true, location);
            comment.acceptCommentFrom(comment);
            switch (location)
            {
                case "Profile":
                    return RedirectToAction("ShowMyProfile", "Profile");
                case "Newsfeed":
                    return RedirectToAction("Index", "NewsFeed");
                case "Groups":
                    return RedirectToAction("Show", "Groups");
                default:
                    return Index();
            }
        }

        public ActionResult DeclineComment(CommentViewModel comment)
        {
            comment.declineCommentFrom(comment);
            switch (comment.location)
            {
                case "Profile":
                    return RedirectToAction("ShowMyProfile", "Profile");
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