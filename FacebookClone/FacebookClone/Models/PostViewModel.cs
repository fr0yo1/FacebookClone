using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class PostViewModel
    {
        public Post post { get; set; }

        [Required]
        public string inputComment { get; set; }

        public PostViewModel(Post post)
        {
            this.post = post;
        }

        public PostViewModel()
        {
        }

        public void addCommentFrom(AspNetUser user, FacebookDatabaseEntities toDataBase)
        {
            user.Comments.Add(new Comment {post_id = post.post_id, user_id = user.Id, date = DateTime.Now, content = inputComment});
            toDataBase.SaveChanges();
        }
    }
}