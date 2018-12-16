using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class MessengerViewModel
    {
        public List<AspNetUser> friends { get; set; }
        public List<Message> requests { get; set; }
        public ConversationViewModel conversation { get; set; }

        public MessengerViewModel(AspNetUser user)
        {
            friends = user.AspNetUsers.ToList();
            requests = user.Messages.Where(x=> x.type == Convert.ToInt32(MessageTypes.friendRequest) || x.type == Convert.ToInt32(MessageTypes.groupRequest)).ToList();
        }

        public MessengerViewModel(string receiver_id, string sender_id)
        {
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            var user = databaseEntities.AspNetUsers.Find(receiver_id);
            friends = user.AspNetUsers.ToList();
            requests = user.Messages.Where(x => x.type == Convert.ToInt32(MessageTypes.friendRequest) || x.type == Convert.ToInt32(MessageTypes.groupRequest)).ToList();

            var messages = user.Messages.Where(x => x.sender_id == sender_id && x.receiver_id == receiver_id).ToList();
            conversation = new ConversationViewModel(messages);
        }
    }
}