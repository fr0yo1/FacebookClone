using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class ConversationViewModel
    {
        public List<MessageViewModel> messages { get; set; }
        public string sendToUserId { get; set; }
        public string inputText { get; set; }
        public string senderPicture { get; set; }
        public string receiverPicture { get; set; }
        public bool userCanSendMessages { get; set; }

        public ConversationViewModel(List<Message> messages,bool userCanSendMessages,string ToUserId, string fromUserId)
        {
            this.sendToUserId = ToUserId;
            this.userCanSendMessages = userCanSendMessages;
            this.messages = messages.Select(x=> new MessageViewModel(x, ToUserId)).ToList();

            FacebookDatabaseEntities databaseEntities = new FacebookDatabaseEntities();

            this.senderPicture = databaseEntities.AspNetUsers.Find(fromUserId).Profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x => x.date).FirstOrDefault().path;
            this.receiverPicture = databaseEntities.AspNetUsers.Find(ToUserId).Profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x => x.date).FirstOrDefault().path;
        }

        public ConversationViewModel()
        {

        }
    }
}