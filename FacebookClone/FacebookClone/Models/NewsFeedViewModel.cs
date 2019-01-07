using FacebookClone.Handlers;
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
            var isAdmin = RoleHandler.isAdmin(user.Id);
            var groups = user.Groups;
            ICollection<Post> posts = new List<Post>();
            //TODO TBD posts are shown twice
            foreach (var group in groups)
            {
                posts = posts.Union(group.Posts).ToList();
            }
            posts = posts.Union(user.Posts).ToList();
            FacebookDatabaseEntities entities = new FacebookDatabaseEntities();
            var friends = user.AspNetUsers;
            foreach (var friend in friends)
            {
                posts = posts.Union(friend.Posts).ToList();
            }
            posts = posts.OrderByDescending(x => x.date).ToList();

            this.posts = new List<PostViewModel>();
            foreach (var post in posts)
            {
                this.posts.Add(new PostViewModel(post,"Newsfeed",isAdmin));
            }
        }
    }
}