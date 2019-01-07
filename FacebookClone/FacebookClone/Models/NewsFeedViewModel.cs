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

        private class PostComparator : IEqualityComparer<Post>
        {
            public bool Equals(Post x, Post y)
            {
                return x.post_id == y.post_id;
            }

            public int GetHashCode(Post obj)
            {
                return obj.post_id.GetHashCode();
            }
        }

        public NewsFeedViewModel(AspNetUser user)
        {
            var isAdmin = RoleHandler.isAdmin(user.Id);
            var groups = user.Groups;
            ICollection<Post> posts = new List<Post>();
            //TODO TBD posts are shown twice
            foreach (var group in groups)
            {
                posts = posts.Union(group.Posts, new PostComparator()).ToList();
            }
            posts = posts.Union(user.Posts, new PostComparator()).ToList();
            FacebookDatabaseEntities entities = new FacebookDatabaseEntities();
            var friends = user.AspNetUsers;
            foreach (var friend in friends)
            {
                posts = posts.Union(friend.Posts.Where(x => groups.Where(y => y.group_id == x.group_id).Any() || x.group_id == null), new PostComparator()).ToList();
            }
            posts = posts.OrderByDescending(x => x.date).Distinct().ToList();

            this.posts = new List<PostViewModel>();
            foreach (var post in posts)
            {
                this.posts.Add(new PostViewModel(post,"Newsfeed",isAdmin));
            }
        }
    }
}