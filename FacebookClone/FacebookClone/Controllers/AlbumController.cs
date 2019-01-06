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
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ShowAlbum(AlbumViewModel albumViewModel)
        {
            var databaseEntities = new FacebookDatabaseEntities();
            var aspNetUser = databaseEntities.AspNetUsers.Find(albumViewModel.userID);
            var posts = aspNetUser.Posts;
            List<PostViewModel> userPosts = new List<PostViewModel>();
            foreach (var post in posts)
            {
                userPosts.Add(new PostViewModel(post, "Profile", User.IsInRole("Admin")));
            }
            albumViewModel = new AlbumViewModel(albumViewModel.albumName, albumViewModel.appLocation, albumViewModel.albumID,userPosts, albumViewModel.userID);
            return View("PhotoGalleryPartialView", albumViewModel);
        }

        [Authorize]
        public ActionResult ShowPostFromAlbum(PostViewModel postViewModel)
        {
            var databaseEntities = new FacebookDatabaseEntities();
            var aspNetUser = databaseEntities.AspNetUsers.Find(postViewModel.userID);
            var posts = aspNetUser.Posts;
            var thisPost = posts.Where(x => x.post_id == postViewModel.post_id).FirstOrDefault();
            postViewModel = new PostViewModel(thisPost, "Gallery", User.IsInRole("Admin"));
            
            // postViewModel = new PostViewModel(postViewModel.)
            return View("PostPartialView", postViewModel);
        }

        [Authorize]
        public ActionResult SaveAlbum(CreateAlbumViewModel newAlbum)
        {
            string currentUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                FacebookDatabaseEntities db = new FacebookDatabaseEntities();
                newAlbum.saveToDatabase(currentUserId, Server, db);
            }
            char[] idArgument = currentUserId.ToCharArray();
            return RedirectToAction("Show", "Profile", new { id = currentUserId });
        }
    }
}