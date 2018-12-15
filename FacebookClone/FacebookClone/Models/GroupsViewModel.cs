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

       public GroupsViewModel(Group selectedGroup, List<Group> myGroups)
        {
            this.myGroups = myGroups;
            this.selectedGroup = selectedGroup;
            if (selectedGroup != null)
            {
                this.newPost = new PostViewModel { appLocation = "Groups", group_id = selectedGroup.group_id };
            }
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