using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Handlers
{
    public class GroupHandler
    {
        static public void addUserToGroup(string user_id,int group_id,int message_id)
        {
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            var user = databaseEntities.AspNetUsers.Find(user_id);
            databaseEntities.Groups.Find(group_id).AspNetUsers.Add(user);

            var message = databaseEntities.Messages.Find(message_id);
            message.type = Convert.ToInt32(MessageTypes.normalMessage);
            message.content = "Group request accepted";

            databaseEntities.SaveChanges();
        }
    }
}