using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class MessengerViewModel
    {
        public List<AspNetUser> friends { get; set; }
        public IEnumerable<ChatPreviewViewModel> chatPreviewViewModel { get; set; }
        public List<Message> receivedRequests { get; set; }
        public List<Message> receivedWarnings { get; set; }
        public List<Message> sentRequests { get; set; }
        public List<Message> sentWarnings { get; set; }
        public ConversationViewModel conversation { get; set; }

        public MessengerViewModel(AspNetUser user)
        {
            setUserList(user);
        }

        public MessengerViewModel(string receiver_id, string sender_id,int currentMessageNumber = 0)
        {
            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();
            var user = databaseEntities.AspNetUsers.Find(receiver_id);

            setUserList(user);

            var messages = databaseEntities.Messages.Where(x => (x.sender_id == sender_id && x.receiver_id == receiver_id) || (x.sender_id == receiver_id && x.receiver_id == sender_id)).ToList();
            var userCanSendMessages = friends.Select(x => x.Id == sender_id).Any(x => x == true);
            conversation = new ConversationViewModel(messages, userCanSendMessages, sender_id, receiver_id, currentMessageNumber);
        }

        private void setUserList(AspNetUser user)
        {
            var u = user.AspNetUsers.DefaultIfEmpty();
            friends = user.AspNetUsers.ToList();

            var warnedUsers = user.Messages1.Where(x => x.type == Convert.ToInt32(MessageTypes.adminWarning)).Select(y => y.AspNetUser);
            var warnedBy = user.Messages.Where(x => x.type == Convert.ToInt32(MessageTypes.adminWarning)).Select(y => y.AspNetUser1);
            var receivedRequestsFromUsers = user.Messages.Where(x => x.type == Convert.ToInt32(MessageTypes.friendRequest) || x.type == Convert.ToInt32(MessageTypes.groupRequest)).Select(y => y.AspNetUser1);
            var sentRequestToUsers = user.Messages1.Where(x => x.type == Convert.ToInt32(MessageTypes.friendRequest) || x.type == Convert.ToInt32(MessageTypes.groupRequest)).Select(y => y.AspNetUser);

            friends = friends.Union(warnedUsers).ToList();
            friends = friends.Union(warnedBy).ToList();
            friends = friends.Union(receivedRequestsFromUsers).ToList();
            friends = friends.Union(sentRequestToUsers).ToList();

            chatPreviewViewModel = friends.Select(x => new ChatPreviewViewModel(x.Messages.Where(w => w.sender_id == user.Id).OrderByDescending(y => y.date).FirstOrDefault(), x.Messages1.Where(w => w.receiver_id == user.Id).OrderByDescending(y => y.date).FirstOrDefault(), x));
        }
    }
}