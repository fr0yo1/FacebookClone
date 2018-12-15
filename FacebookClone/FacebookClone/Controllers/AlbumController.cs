﻿using FacebookClone.Handlers;
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
                userPosts.Add(new PostViewModel(post, "Profile"));
            }
            albumViewModel = new AlbumViewModel(albumViewModel.albumName, albumViewModel.appLocation, albumViewModel.albumID,userPosts);
            return View("PhotoGalleryPartialView", albumViewModel);
        }

        [Authorize]
        public ActionResult ShowPostFromAlbum(PostViewModel postViewModel)
        {
           // postViewModel = new PostViewModel(postViewModel.)
            return View("PostPartialView", postViewModel);
        }
    }
}