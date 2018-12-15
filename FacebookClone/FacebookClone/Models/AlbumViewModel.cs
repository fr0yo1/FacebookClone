using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public AlbumViewModel( string albumName, string appLocation, int albumID, List<PostViewModel> userPosts)
        {
            var databaseEntities = new FacebookDatabaseEntities();
            List<PostViewModel> myPosts = userPosts.Where(x => x.albumID == albumID).ToList();
            this.posts = myPosts;
            this.picturesRelativePath = this.posts.Select(x => x.postPictureRelativePath).ToList();
            this.userID = myPosts[0].userID;
            this.albumName = albumName;
            this.appLocation = appLocation;
            this.albumID = albumID;
        }
        public AlbumViewModel()
        {

        }

    }
}