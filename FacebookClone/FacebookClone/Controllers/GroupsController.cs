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
            var currentUserId = User.Identity.GetUserId();
            return View("GroupsView",new GroupsViewModel(id,currentUserId));
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