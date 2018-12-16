using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class ConversationViewModel
    {
        public List<MessageViewModel> messages { get; set; }
        public string inputText { get; set; }

        public ConversationViewModel(List<Message> messages)
        {
            this.messages = messages.Select(x=> new MessageViewModel(x)).ToList();
        }
    }
}