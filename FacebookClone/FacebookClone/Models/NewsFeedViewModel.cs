using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class NewsFeedViewModel
    {
        public List<PostViewModel> posts { get; set;}

        public NewsFeedViewModel(AspNetUser user)
        {
            var groups = user.Groups;
            List<Post> posts = new List<Post>();

            foreach (var group in groups)
            {
                posts.AddRange(group.Posts);
            }
            posts.AddRange(user.Posts);
            //TO-DO add post from friends and sort them all by date

            this.posts = new List<PostViewModel>();
            foreach (var post in posts)
            {
                this.posts.Add(new PostViewModel(post,"Newsfeed"));
            }
        }
    }
}