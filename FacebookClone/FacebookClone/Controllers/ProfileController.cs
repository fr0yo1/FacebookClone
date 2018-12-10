﻿using FacebookClone.Handlers;
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
        private FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();

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
                    var date = DateTime.Now;

                    var newProfile = new Profile
                    {
                        age = profile.age,
                        firstname = profile.firstname,
                        lastname = profile.lastname,
                        Id = currentUserId,
                        gender = profile.gender.ToString()
                    };
                    databaseEntities.Profiles.Add(newProfile);
                    var album = databaseEntities.Albums.Add(new Album { user_id = currentUserId, name = "ProfileAlbum", date = date });
                    var picture = databaseEntities.Pictures.Add(new Picture {album_id = album.album_id, path = path, date = date, description = "ProfilePicture" });
                    databaseEntities.SaveChanges();
                }

                //everything is good, finally show profile
                return RedirectToAction("Show", "Profile");
            }

            //something went wrong, show again form
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
                var date = DateTime.Now;
                var profileAlbum = databaseEntities.Albums.Where(x => x.name.Equals("ProfileAlbum") && x.user_id==currentUserId).FirstOrDefault();
                Picture profilePicture = new Picture();
                profilePicture.album_id = profileAlbum.album_id;
                profilePicture.path = path;
                profilePicture.date = date;
                profilePicture.description = "ProfilePicture";
                    databaseEntities.Pictures.Add(profilePicture);
                databaseEntities.SaveChanges();
            }

            return RedirectToAction("Show", "Profile");
        }

        [Authorize]
        public ActionResult Show()
        {
            var currentUserId = User.Identity.GetUserId();
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