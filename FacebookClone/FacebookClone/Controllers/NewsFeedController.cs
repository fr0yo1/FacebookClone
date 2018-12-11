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
            var newsFeedViewModel = new NewsFeedViewModel();

            var userId = User.Identity.GetUserId();
            var aspNetUser = databaseEntities.AspNetUsers.Find(userId);
            var groups = aspNetUser.Groups;
            List<Post> posts = new List<Post>();

            //TO-DO Create a method
            // add all posts from user groups
            foreach (var group in groups) {
                posts.AddRange(group.Posts);
            }
            //add own posts
            posts.AddRange(aspNetUser.Posts);
            //TO-DO add post from friends and sort them all by date

            List<PostViewModel> postViewModel = new List<PostViewModel>();

            foreach (var post in posts)
            {
                postViewModel.Add(new PostViewModel(post));
            }

            return View("NewsFeed", new NewsFeedViewModel { posts = postViewModel });
        }

        [Authorize]
        public ActionResult AddComment(PostViewModel postViewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = databaseEntities.AspNetUsers.Find(userId);
            postViewModel.addCommentFrom(user, databaseEntities);
            return RedirectToAction("Index");
        }

        [Authorize]
        public string getProfilePictureFor(AspNetUser user)
        {
            return user.Profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x => x.date).FirstOrDefault().path;
        }
    }
}