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

            var iAmaVisitor = true;
            if (User.Identity.GetUserId() == id)
            {
                iAmaVisitor = false;
            }
            var isAdmin = false;
            if (User.Identity.GetUserId() != null)
            {
                isAdmin = RoleHandler.isAdmin(User.Identity.GetUserId());
            }

            var loggedUser = databaseEntities.AspNetUsers.Find(User.Identity.GetUserId());
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
                    userPosts.Add(new PostViewModel(post,"Profile",RoleHandler.isAdmin(User.Identity.GetUserId())));
                }
                List<Album> albums = databaseEntities.Albums.Where(x => x.user_id==id).ToList();
                List<AlbumViewModel> userAlbums = new List<AlbumViewModel>();
                foreach(Album album in albums)
                {
                    userAlbums.Add(new AlbumViewModel(album.name, "Profile",album.album_id,userPosts, id));
                }

                List<AspNetUser> friends = aspNetUser.AspNetUsers.ToList();
                List<Profile> profiles = databaseEntities.Profiles.ToList();
                List<Profile> friendsProfiles = (from aspUser in friends
                              join friendProfile in profiles on aspUser.Id equals friendProfile.Id
                              select friendProfile).ToList();
                List<FriendViewModel> friendsList = new List<FriendViewModel>();
                foreach (Profile friend in friendsProfiles)
                {
                    friendsList.Add(new FriendViewModel(friend.Id, friend.Albums.Where(x=>x.name== "ProfileAlbum").FirstOrDefault().Pictures.OrderByDescending(x=>x.date).FirstOrDefault().path, friend.firstname +friend.lastname));
                }
                var profileViewModel = new ProfileViewModel(profile, userAlbums, userPosts, friendsList);
                profileViewModel.iAmaVisitor = iAmaVisitor;
                profileViewModel.isAdmin = isAdmin;
                if (iAmaVisitor)
                {
                    var myID = User.Identity.GetUserId();
                    profileViewModel.profileVisitorID = myID;
                    if (friendsProfiles.Select(x => x.Id).ToList().Contains(myID))
                        profileViewModel.relationshipStatus = FriendshipStatus.friends;
                    else
                    {
                        profileViewModel.relationshipStatus = MessageHandler.GetFriendRequestStatus(User.Identity.GetUserId(), id);
                    }
                }
                return View("Profile", profileViewModel);
            }
   
        }

        [Authorize]
        public ActionResult ShowMyProfile()
        {
            var id = User.Identity.GetUserId();
            return RedirectToAction("Show", "Profile", new { id = id});
        }
        [Authorize]
        public ActionResult SendFriendRequest(string senderID, string receiverID)
        {
            FacebookDatabaseEntities db = new FacebookDatabaseEntities();
            Message newFriendRequestAsMessage = new Message() { sender_id = senderID, receiver_id = receiverID, date = DateTime.Now, type = (int)MessageTypes.friendRequest, content = "Please add me as a friend." };
            //newFriendRequestAsMessage.AspNetUser = db.AspNetUsers.Find(senderID);
            //newFriendRequestAsMessage.AspNetUser1 = db.AspNetUsers.Find(receiverID);
            //newFriendRequestAsMessage.date = DateTime.Now;
            //newFriendRequestAsMessage.type = (int)MessageTypes.friendRequest;

            MessageHandler.sendMessage(newFriendRequestAsMessage);
            return RedirectToAction("Show", "Profile", new { id = receiverID });
        }
    }
}