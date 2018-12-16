using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public enum MessageTypes:int
    {
        normalMessage = 1,
        friendRequest = 2,
        groupRequest = 3
    }

    public enum State
    {
        received,
        sent
    }

    public class MessageViewModel
    {
        public int message_id { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public AspNetUser sender { get; set; }
        public AspNetUser receiver { get;  set; }
        public MessageTypes type { get; set; }
        public string actionId { get; set; }
        public State state { get; set; }

        public MessageViewModel(Message message,string sendToUserId)
        {
            message_id = message.message_id;
            date = message.date;
            sender = message.AspNetUser1;
            receiver = message.AspNetUser;
            switch (message.type)
            {
                case 1:
                    type = MessageTypes.normalMessage;
                    content = message.content;
                    break;
                case 2:
                    type = MessageTypes.friendRequest;
                    actionId = message.content;
                    content = " sent a friend request";
                    break;
                case 3:
                    type = MessageTypes.groupRequest;
                    actionId = message.content;
                    FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
                    var group = databaseEntities.Groups.Find(int.Parse(actionId));
                    content = " sent a group request for " + group.name;
                    break;

            }

            if (sender.Id == sendToUserId)
            {
                content = sender.Profile.firstname + " " + sender.Profile.lastname + " : " + content;
                state = State.received;
            } else
            {
                content = " me : " + content;
                state = State.sent;
            }
        }
    }
}