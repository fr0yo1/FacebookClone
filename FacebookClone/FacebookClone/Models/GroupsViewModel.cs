using System;
using System.Collections.Generic;
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
            this.newPost = new PostViewModel { appLocation = "Groups", group_id = selectedGroup.group_id };
        }
    }
}