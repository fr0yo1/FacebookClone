using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using FacebookClone.Models;

namespace FacebookClone.Handlers
{
    public class RoleHandler
    {
        public static Boolean isAdmin(String userId)
        {
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            var user = databaseEntities.AspNetUsers.Find(userId);
            return user.AspNetRoles.Where(x => x.Name == "Admin").Any();
        }
    }
}