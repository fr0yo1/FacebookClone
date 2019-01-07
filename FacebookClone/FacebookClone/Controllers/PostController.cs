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

        [HttpGet]
        public ActionResult showDeletePage(string id)
        {
            var post = databaseEntities.Posts.Find(int.Parse(id));
            return View("DeletePage", new DeletePostViewModel(post));
        }

        [HttpDelete]
        public ActionResult deletePost(string post_id, string receiver_id, DeletePostViewModel deletePostViewModel)
        {
            if (ModelState.IsValid)
            {
                var message = new Message() { sender_id = User.Identity.GetUserId(), receiver_id = receiver_id, content = deletePostViewModel.messageToUser, date = DateTime.Now, type = Convert.ToInt32(MessageTypes.normalMessage) };
                FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
                Post post = new Post() { post_id = int.Parse(post_id) };
                databaseEntities.Posts.Attach(post);
                databaseEntities.Posts.Remove(post);
                databaseEntities.SaveChanges();
                MessageHandler.sendMessage(message);
                return RedirectToAction("ShowMyProfile", "Profile");
            } else
            {
                var post = databaseEntities.Posts.Find(int.Parse(post_id));
                return View("DeletePage", new DeletePostViewModel(post));
            }
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
            var thisComm = databaseEntities.Comments.Find(Int32.Parse(commentId));
            CommentViewModel comment = new CommentViewModel(thisComm, true, location);
            comment.acceptCommentFrom(thisComm);
            databaseEntities.SaveChanges();
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

        public ActionResult DeclineComment(string commentId, string location)
        {
            var thisComm = databaseEntities.Comments.Find(Int32.Parse(commentId));
            CommentViewModel comment = new CommentViewModel(thisComm, true, location);
            comment.declineCommentFrom(thisComm);
            databaseEntities.SaveChanges();
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