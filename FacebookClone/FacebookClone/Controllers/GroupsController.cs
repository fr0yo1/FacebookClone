using FacebookClone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookClone.Controllers
{
    public class GroupsController : Controller
    {
 
        [Authorize]
        public ActionResult Show(string id = null)
        {
            bool hasViewAcces = false;
            var databaseEntities = new FacebookDatabaseEntities();
            var currentUserId = User.Identity.GetUserId();
            var user = databaseEntities.AspNetUsers.Find(currentUserId);
            var myGroups = user.Groups;

            Group selectedGroup = new Group();
            if (id != null)
            {
                var group = databaseEntities.Groups.Find(int.Parse(id));
                if (group.AspNetUsers.Contains(user))
                {
                    hasViewAcces = true;
                }
            } else
            {
                selectedGroup = databaseEntities.AspNetUsers.Find(currentUserId).Groups.FirstOrDefault();
                hasViewAcces = true;
            }
           
           
            return View("GroupsView",new GroupsViewModel(selectedGroup, myGroups.ToList()) { hasViewAcces = hasViewAcces});
        }

        [Authorize]
        public ActionResult CreateGroupForm()
        {
            return View(new CreateGroupViewModel());
        }

        [Authorize]
        public ActionResult SaveGroup(CreateGroupViewModel newGroup)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var group_id = newGroup.saveToDatabase(currentUserId, Server);
                return RedirectToAction("Show", "Groups", group_id);
            }
            return View("CreateGroupForm",new CreateGroupViewModel());
        }
        
    }
}