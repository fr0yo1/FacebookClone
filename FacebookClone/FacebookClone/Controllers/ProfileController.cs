using FacebookClone.Handlers;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FacebookClone.Controllers
{
    public class ProfileController : Controller
    {
        [HttpPost]
        public ActionResult Add(ProfileViewModel profile)
        {
            if (ModelState.IsValid)
            {
                var path = FilesHandler.saveImage(profile.picture, Server);
                if(path == null)
                {
                   ModelState.AddModelError("imageError", "Something went wrong we were unable to save the photo");
                   return View("AddProfile", profile);
                } else
                {
                    var currentUserId = User.Identity.GetUserId();
                    profile.addProfileToUser(currentUserId,path);
                }
                return RedirectToAction("Show", "Profile");
            }
            return View("AddProfile", profile);
        }

        [HttpPost]
        public ActionResult AddNewProfilePicture(ProfileViewModel profile)
        {
            var path = FilesHandler.saveImage(profile.picture, Server);
            if (path == null)
            {
                ModelState.AddModelError("imageError", "Something went wrong we were unable to save the photo");
            }
            else
            {
                var currentUserId = User.Identity.GetUserId();
                profile.addNewProfileToUser(currentUserId, path);

            }

            return RedirectToAction("Show", "Profile");
        }

        [Authorize]
        public ActionResult Show(string id)
        {
            var databaseEntities = new FacebookDatabaseEntities();

            if (databaseEntities.AspNetUsers.Find(id) == null)
            {
                return View("Profile",null);
            }

            Profile profile = databaseEntities.Profiles.Find(id);
            if (profile == null)
            {
                return View("AddProfile", new ProfileViewModel());
            } else
            {
                //TO-DO: add properties to ProfileViewModel like : albums, posts and personal informations and show them into view.
                var aspNetUser = databaseEntities.AspNetUsers.Find(id);
                var posts = aspNetUser.Posts;
                List<PostViewModel> userPosts = new List<PostViewModel>();
                foreach (var post in posts)
                {
                    userPosts.Add(new PostViewModel(post,"Profile"));
                }
                List<Album> albums = databaseEntities.Albums.Where(x => x.user_id==id).ToList();
                List<AlbumViewModel> userAlbums = new List<AlbumViewModel>();
                foreach(Album album in albums)
                {
                    List<string>picturesPath=album.Pictures.Select(i => i.path).ToList();
                    userAlbums.Add(new AlbumViewModel(picturesPath, album.name, "Profile"));
                }
                return View("Profile", new ProfileViewModel(profile, userAlbums, userPosts));
            }
   
        }

        [Authorize]
        public ActionResult ShowMyProfile()
        {
            var id = User.Identity.GetUserId();
            return RedirectToAction("Show", "Profile", new { id = id});
        }
    }
}