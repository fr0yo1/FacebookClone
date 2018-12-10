using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

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

            // add all posts from user groups
            foreach (var group in groups) {
                posts.AddRange(group.Posts);
            }

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
            return RedirectToAction("Index");
        }

        public string getUserProfilePicture(ICollection<Album> albums)
        {
             foreach (var album in albums)
             {
                    if (album.name.Equals("ProfileAlbum"))
                    {
                        var profilePictures = album.Pictures;
                        var enumerator = profilePictures.GetEnumerator();
                        enumerator.MoveNext();
                        var profilePicture = enumerator.Current;
                        return profilePicture.path;
                    }
             }
            return "error";
        }
    }
}