using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Models
{
    public enum CommentStatus
    {
        pending,
        accepted,
        denied
    }
    public class PostViewModel
    {
        public Boolean canBeDeletedByAdmin { get; set; }
        public int post_id { get; set; }
        public Nullable<int> group_id { get; set; }
        public DateTime date { get; set; }
        public string userName { get; set; }
        public string content { get; set; }
        public string profilePath { get; set; }
        public string appLocation { get; set; }
        public List<CommentViewModel> comments { get; set; }
        public String postPictureRelativePath { get; set; }
        public int albumID { get; set; }
        public string userID { get; set; }
        public Post post { get; set; }

        [Required]
        public string inputComment { get; set; }

        public HttpPostedFileBase picture { get; set; }

        public PostViewModel(Post post, string location,Boolean canBeDeletedByAdmin = false)
        {
            this.canBeDeletedByAdmin = canBeDeletedByAdmin;
            string userId = HttpContext.Current.User.Identity.GetUserId();
            this.post = post;
            post_id = post.post_id;
            group_id = post.group_id;
            date = post.date;
            userName = post.AspNetUser.Profile.firstname + " " + post.AspNetUser.Profile.lastname;
            content = post.content;
            profilePath = post.AspNetUser.Profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x => x.date).FirstOrDefault().path;
            postPictureRelativePath = post.Picture != null ? post.Picture.path : String.Empty;
            if (userId == post.sender_id)
                comments = post.Comments.Select(x => new CommentViewModel(x,true, location)).ToList();

            else if (post.Comments.Where(x => x.user_id == userId).Any())
            {
                comments = post.Comments.Where(x => x.Status == 1 && x.user_id != userId).ToList().Union(post.Comments.Where(x => x.user_id == userId).ToList()).ToList().Select(x => new CommentViewModel(x, false, location)).ToList(); ;
            }
            else
            {
                comments = post.Comments.Where(x => x.Status == 1).ToList().Select(x => new CommentViewModel(x, false, location)).ToList(); ;
            }
            appLocation = location;
            if(post.Picture!=null)
                 albumID = post.Picture.album_id;
            userID = post.sender_id;
        }

        public PostViewModel()
        {
        }

        public void addCommentFrom(AspNetUser user, FacebookDatabaseEntities toDataBase, string actualUserID)
        {
            var actualPost = toDataBase.Posts.Where(x => x.post_id == post_id).FirstOrDefault();
            var status = CommentStatus.pending;
             if (actualPost.sender_id == actualUserID)
                status = CommentStatus.accepted;
            user.Comments.Add(new Comment {post_id = post_id, user_id = user.Id, date = DateTime.Now, content = inputComment, Status = (int)status});
            toDataBase.SaveChanges();
        }

        static public void addPostFrom(string user_id, FacebookDatabaseEntities toDataBase, String picturePath,string content, int albumID, Nullable<int> group_id = null, bool isProfilePicture=false)
        {
            Album album = null;
            if(isProfilePicture)
                album = toDataBase.Albums.Where(x => x.name.Equals("ProfileAlbum") && x.user_id == user_id).FirstOrDefault();
            else
            {
                if(albumID!=-1) //if we have an album to add the post to
                    album = toDataBase.Albums.Where(x => x.album_id==albumID).FirstOrDefault();
                if(album==null) //if we have not specified the id put it to posted pictures
                    album = toDataBase.Albums.Where(x => x.name.Equals("PostedPicturesAlbum") && x.user_id == user_id).FirstOrDefault();
                if(album==null) //if we have not specified the album and we also do not have the posted picture album created
                    album = toDataBase.Albums.Add(new Album { user_id = user_id, name = "PostedPicturesAlbum", date = DateTime.Now });
            }
            var aspNetUser = toDataBase.AspNetUsers.Find(user_id);
            Picture profilePicture = new Picture();
            profilePicture.album_id = album.album_id;
            profilePicture.path = picturePath;
            profilePicture.date = DateTime.Now;
            profilePicture.description = "ProfilePicture";

            toDataBase.Pictures.Add(profilePicture);

            Post newPost = new Post();
            newPost.group_id = group_id;
            newPost.content = content;
            newPost.AspNetUser = aspNetUser;
            newPost.Picture = profilePicture;
            newPost.date = DateTime.Now;
            toDataBase.Posts.Add(newPost);
            toDataBase.SaveChanges();
        }
        
        public IEnumerable<SelectListItem> GetAlbumNames(string id)
        {
            var selectList = new List<SelectListItem>();
            var databaseEntities = new FacebookDatabaseEntities();
            List<Album> albums = databaseEntities.Albums.Where(x => x.user_id.Equals(id)).ToList();
            foreach (var album in albums)
            {
                selectList.Add(new SelectListItem
                {
                    Value = album.album_id.ToString(),
                    Text = album.name
                });
            }
            return selectList;
        }
    }
}