using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class MessengerViewModel
    {
        public List<AspNetUser> friends { get; set; }
        public List<ChatPreviewViewModel> chatPreviewViewModel { get; set; }
        public List<Message> receivedRequests { get; set; }
        public List<Message> sentRequests { get; set; }
        public ConversationViewModel conversation { get; set; }

        public MessengerViewModel(AspNetUser user)
        {
            setUserList(user);
        }

        public MessengerViewModel(string receiver_id, string sender_id)
        {
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            var user = databaseEntities.AspNetUsers.Find(receiver_id);

            setUserList(user);

            var messages = databaseEntities.Messages.Where(x => (x.sender_id == sender_id && x.receiver_id == receiver_id) || (x.sender_id == receiver_id && x.receiver_id == sender_id)).ToList();
            var userCanSendMessages = friends.Select(x => x.Id == sender_id).Any(x => x == true);
            conversation = new ConversationViewModel(messages, userCanSendMessages, sender_id, receiver_id);
        }

        private void setUserList(AspNetUser user)
        {
            var u = user.AspNetUsers.DefaultIfEmpty();
            friends = user.AspNetUsers.ToList();

            chatPreviewViewModel = friends.Select(x => new ChatPreviewViewModel(x.Messages.Where(w => w.sender_id == user.Id).OrderByDescending(y => y.date).First(), x.Messages1.Where(w => w.receiver_id == user.Id).OrderByDescending(y => y.date).First(),x)).ToList();

            receivedRequests = user.Messages.Where(x => x.type == Convert.ToInt32(MessageTypes.friendRequest) || x.type == Convert.ToInt32(MessageTypes.groupRequest)).ToList();
            //remove friend requests as they are shown in conversation.
            receivedRequests = receivedRequests.Where(x => user.AspNetUsers.Select(y => y.Id == x.sender_id).DefaultIfEmpty().Any(y => y == false)).ToList();
            sentRequests = user.Messages1.Where(x => x.type == Convert.ToInt32(MessageTypes.friendRequest) || x.type == Convert.ToInt32(MessageTypes.groupRequest)).ToList();
            //remove friend requests as they are shown in conversation.
            sentRequests = sentRequests.Where(x => user.AspNetUsers.Select(y => y.Id == x.receiver_id).DefaultIfEmpty().Any(y => y == false)).ToList();
        }
    }
}