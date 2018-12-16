using FacebookClone.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class GroupsViewModel
    {
        public List<Group> myGroups { get; set; }
        public Group selectedGroup { get; set; }
        public PostViewModel newPost { get; set; }
        public AccesPermision accesPermision { get; set; }

        private class GroupComparator : IEqualityComparer<Group>
        {
            public bool Equals(Group x, Group y)
            {
                return x.group_id == y.group_id;
            }

            public int GetHashCode(Group obj)
            {
                return obj.group_id.GetHashCode();
            }
        }

        public GroupsViewModel(string selectedId, string userId)
        {
            var databaseEntities = new FacebookDatabaseEntities();
            var user = databaseEntities.AspNetUsers.Find(userId);
            var groups = user.Groups;
            myGroups = groups.Union(user.Groups1,new GroupComparator()).ToList();

            if (selectedId != null)
            {
                selectedGroup = databaseEntities.Groups.Find(int.Parse(selectedId));
            }
            else
            {
                selectedGroup = myGroups.FirstOrDefault();
            }

            //TO-DO add administrator permission
            if (selectedGroup != null)
            {
                newPost = new PostViewModel { appLocation = "Groups", group_id = selectedGroup.group_id };
                if (selectedGroup.AspNetUsers.Contains(user))
                {
                    accesPermision = AccesPermision.readPermissions;
                }
                else
                {
                    accesPermision = AccesPermision.noPermission;
                }
            }
        }

        public GroupsViewModel()
        {

        }
    }

    public class CreateGroupViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public HttpPostedFileBase picture { get; set; }

        public int saveToDatabase(string administrator,HttpServerUtilityBase server)
        {
            var databaseEntities = new FacebookDatabaseEntities();
            var relativePath = FilesHandler.saveImage(picture, server);

            var group = databaseEntities.Groups.Add(new Group { name = name, administrator = administrator, picture_path = relativePath });
            var user = databaseEntities.AspNetUsers.Find(administrator);
            group.AspNetUsers.Add(user);

            databaseEntities.SaveChanges();
            return group.group_id;
        }
    }
}