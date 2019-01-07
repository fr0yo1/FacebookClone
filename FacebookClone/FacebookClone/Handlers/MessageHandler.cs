using FacebookClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Handlers
{
    public enum FriendshipStatus
    {
        pendingSentByMe,
        pendingSentByHim,
        notSent,
        friends
    }
    public class MessageHandler
    {
        static public void sendMessage(Message message) { 
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            databaseEntities.Messages.Add(message);
            databaseEntities.SaveChanges();
       }

        static public FriendshipStatus GetFriendRequestStatus(string myID, string hisID)
        {
            //todo search in db to see if there is a friendreauest from you to the person or reverse
            FacebookDatabaseEntities db = new FacebookDatabaseEntities();
            Message friendRequestFromMe = db.Messages.Where(x => x.sender_id== myID && x.receiver_id == hisID && x.type ==(int)MessageTypes.friendRequest).FirstOrDefault();
            Message friendRequestToMe = db.Messages.Where(x => x.sender_id == hisID && x.receiver_id == myID && x.type == (int)MessageTypes.friendRequest).FirstOrDefault();
            if (friendRequestFromMe != null)
                return FriendshipStatus.pendingSentByMe;
            else if (friendRequestToMe != null)
                return FriendshipStatus.pendingSentByHim;
            else return FriendshipStatus.notSent;


        }
    }
}
