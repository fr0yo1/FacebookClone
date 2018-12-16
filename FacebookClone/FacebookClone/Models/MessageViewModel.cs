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

    public class MessageViewModel
    {
        public int message_id { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public AspNetUser sender { get; set; }
        public AspNetUser receiver { get;  set; }
        public MessageTypes type { get; set; }

        public MessageViewModel(Message message)
        {
            message_id = message.message_id;
            content = message.content;
            date = message.date;
            sender = message.AspNetUser1;
            receiver = message.AspNetUser;
            switch (message.type)
            {
                case 1:
                    type = MessageTypes.normalMessage;
                    break;
                case 2:
                    type = MessageTypes.friendRequest;
                    break;
                case 3:
                    type = MessageTypes.groupRequest;
                    break;

            }
        }
    }
}