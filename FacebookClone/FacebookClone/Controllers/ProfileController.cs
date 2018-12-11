using FacebookClone.Handlers;
using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Linq;

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
        public ActionResult Show()
        {
            var currentUserId = User.Identity.GetUserId();

            var databaseEntities = new FacebookDatabaseEntities();
            Profile profile = databaseEntities.Profiles.Find(currentUserId);
            if (profile == null)
            {
                return View("AddProfile", new ProfileViewModel());
            } else
            {
                //TO-DO: add properties to ProfileViewModel like : albums, posts and personal informations and show them into view.
                var profilePicture = profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x=>x.date).FirstOrDefault();
                Enum.TryParse(profile.gender, out Gender userGender);
                return View("Profile", new ProfileViewModel { firstname = profile.firstname, profilePictureRelativePath = profilePicture.path, age=profile.age, gender= userGender, lastname=profile.lastname});
            }
   
        }
    }
}