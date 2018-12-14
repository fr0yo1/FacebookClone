using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public enum SearchType
    {
        all,
        friends,
        groups
    }

    public class SearchViewModel
    {
        public string searchInput { get; set; }
        public SearchType searchType { get; set; }
        public IEnumerable<GenericItemViewModel> usersResult { get; set; }
        public IEnumerable<GenericItemViewModel> groupsResult { get; set; }

        public void getResult(String userId)
        {
            var dataBase = new FacebookDatabaseEntities();
            var currentUser = dataBase.AspNetUsers.Find(userId);

            var userGroups = currentUser.Groups.Where(x=>x.name.ToLower().Contains(searchInput.ToLower())).Take(5);
            var otherGroups = dataBase.Groups.Where(x => x.name.ToLower().Contains(searchInput.ToLower()) && !x.AspNetUsers.Where(y => y.Id == userId).Any()).Take(5);

            groupsResult = userGroups.Select(x => new GenericItemViewModel { content = x.name,
                                                                             id= x.group_id.ToString(),
                                                                             myController = "Groups",
                                                                             clickOption = "Show"})
                                                                             .ToList();
            groupsResult = groupsResult.Union(otherGroups.Select(x => new GenericItemViewModel { content = x.name,
                                                                                                 id = x.group_id.ToString(),
                                                                                                 myController = "Groups",
                                                                                                 clickOption = "Show"})
                                                                                                 .ToList());

            var userFriends = currentUser.AspNetUsers1.Where(x=>(x.Profile.firstname +" " + x.Profile.lastname).ToLower().Contains(searchInput.ToLower())).Take(5);
            var otherFriends = dataBase.AspNetUsers.Where(x => !x.AspNetUsers1.Where(y => y.Id == userId).Any() && x.Id != userId && (x.Profile.firstname + " " + x.Profile.lastname).ToLower().Contains(searchInput.ToLower())).Take(5);

            usersResult = userFriends.Select(x => new GenericItemViewModel {    content = x.Profile.firstname + " " + x.Profile.lastname ,
                                                                                imagePath = x.Profile.Albums.Where(y => y.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(y => y.date).FirstOrDefault().path,
                                                                                id = x.Id,
                                                                                myController = "Profile",
                                                                                clickOption = "Show" })
                                                                                .ToList();
            usersResult = usersResult.Union(otherFriends.Select(x => new GenericItemViewModel { content = x.Profile.firstname + " " + x.Profile.lastname,
                                                                                                imagePath = x.Profile.Albums.Where(y => y.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(y => y.date).FirstOrDefault().path,
                                                                                                id = x.Id,
                                                                                                myController = "Profile",
                                                                                                clickOption = "Show"})
                                                                                                .ToList());
        }
    }
}