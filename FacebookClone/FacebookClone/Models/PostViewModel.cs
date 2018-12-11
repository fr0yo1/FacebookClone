using System;
using System.Collections.Generic;
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
        public ICollection<Comment> comments { get; set; }

        [Required]
        public string inputComment { get; set; }

        public PostViewModel(Post post)
        {
            id = post.post_id;
            date = post.date;
            userName = post.AspNetUser.Profile.firstname + " " + post.AspNetUser.Profile.lastname;
            content = post.content;
            profilePath = post.AspNetUser.Profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x => x.date).FirstOrDefault().path;
            comments = post.Comments;
        }

        public PostViewModel()
        {
        }

        public void addCommentFrom(AspNetUser user, FacebookDatabaseEntities toDataBase)
        {
            user.Comments.Add(new Comment {post_id = id, user_id = user.Id, date = DateTime.Now, content = inputComment});
            toDataBase.SaveChanges();
        }
    }
}