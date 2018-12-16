using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Handlers
{
    public class MessageHandler
    {
        static public void sendMessage(Message message) { 
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            databaseEntities.Messages.Add(message);
            databaseEntities.SaveChanges();
       }
    }
}
