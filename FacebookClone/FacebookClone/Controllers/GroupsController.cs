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
            var databaseEntities = new FacebookDatabaseEntities();
            var currentUserId = User.Identity.GetUserId();
            Group selectedGroup = new Group();
            if (id != null)
            {
                selectedGroup = databaseEntities.Groups.Find(int.Parse(id));
            } else
            {
                selectedGroup = databaseEntities.AspNetUsers.Find(currentUserId).Groups.FirstOrDefault();
            }
           
            var myGroups = databaseEntities.AspNetUsers.Find(currentUserId).Groups;
            return View("GroupsView",new GroupsViewModel(selectedGroup,myGroups.ToList()));
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