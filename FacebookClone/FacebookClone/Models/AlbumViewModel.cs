using FacebookClone.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FacebookClone.Models
{
    public class AlbumViewModel
    {

        public List<PostViewModel> posts { get; set; }
        public string albumName { get; set; }
        public string appLocation { get; set; }
        public int albumID { get; set; }
        public string userID { get; set; }
        public List<string> picturesRelativePath { get; set; }

        public AlbumViewModel( string albumName, string appLocation, int albumID, List<PostViewModel> userPosts,string userID)
        {
            var databaseEntities = new FacebookDatabaseEntities();
            List<PostViewModel> myPosts = userPosts.Where(x => x.albumID == albumID).ToList();
            this.posts = myPosts;
            this.picturesRelativePath = this.posts.Select(x => x.postPictureRelativePath).ToList();
            this.userID = userID;
            this.albumName = albumName;
            this.appLocation = appLocation;
            this.albumID = albumID;
        }
        public AlbumViewModel()
        {

        }
    }

    public class CreateAlbumViewModel
    {
        [Required]
        public string name { get; set; }

        public void saveToDatabase(string administrator, HttpServerUtilityBase server,FacebookDatabaseEntities toDataBase)
        {
            Album newAlbum = new Album();
            newAlbum.date = DateTime.Now;
            newAlbum.name = name; 
            newAlbum.user_id = administrator;
            toDataBase.Albums.Add(newAlbum);
            toDataBase.SaveChanges();
        }
    }
}