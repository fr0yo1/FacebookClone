using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class PostViewModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string userName { get; set; }
        public string content { get; set; }
        public string profilePath { get; set; }
        public string appLocation { get; set; }
        public ICollection<Comment> comments { get; set; }

        [Required]
        public string inputComment { get; set; }

        public PostViewModel(Post post, string location)
        {
            id = post.post_id;
            date = post.date;
            userName = post.AspNetUser.Profile.firstname + " " + post.AspNetUser.Profile.lastname;
            content = post.content;
            profilePath = post.AspNetUser.Profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x => x.date).FirstOrDefault().path;
            comments = post.Comments;
            appLocation = location;
        }

        public PostViewModel()
        {
        }

        public void addCommentFrom(AspNetUser user, FacebookDatabaseEntities toDataBase)
        {
            user.Comments.Add(new Comment {post_id = id, user_id = user.Id, date = DateTime.Now, content = inputComment});
            toDataBase.SaveChanges();
        }

        static public void addPostFrom(string user_id, FacebookDatabaseEntities toDataBase, String picturePath, bool isProfilePicture=false)
        {
            Album profileAlbum = null;
            if(isProfilePicture)
                profileAlbum = toDataBase.Albums.Where(x => x.name.Equals("ProfileAlbum") && x.user_id == user_id).FirstOrDefault();
            else
            {
                //todo
            }
            var aspNetUser = toDataBase.AspNetUsers.Find(user_id);
            Picture profilePicture = new Picture();
            profilePicture.album_id = profileAlbum.album_id;
            profilePicture.path = picturePath;
            profilePicture.date = DateTime.Now;
            profilePicture.description = "ProfilePicture";

            toDataBase.Pictures.Add(profilePicture);

            Post newPost = new Post();
            newPost.content = "I changed my profile picture!";
            newPost.AspNetUser = aspNetUser;
            newPost.Picture = profilePicture;
            newPost.date = DateTime.Now;
            toDataBase.Posts.Add(newPost);
            toDataBase.SaveChanges();
        }
    }
}