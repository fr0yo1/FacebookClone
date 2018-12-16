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
        public bool userCanSendMessages { get; set; }

        public ConversationViewModel(List<Message> messages,bool userCanSendMessages,string sendToUserId)
        {
            this.sendToUserId = sendToUserId;
            this.userCanSendMessages = userCanSendMessages;
            this.messages = messages.Select(x=> new MessageViewModel(x, sendToUserId)).ToList();
        }

        public ConversationViewModel()
        {

        }
    }
}