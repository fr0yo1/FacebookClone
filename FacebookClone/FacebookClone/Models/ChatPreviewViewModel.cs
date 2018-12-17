using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class ChatPreviewViewModel
    {
        public string friend_id { get; set; }
        public string name { get; set; }
        public Message lastMessage { get; set; }
        public string profilePath { get; set; }

        public ChatPreviewViewModel(Message lastReceivedMessage, Message lastSentMessage,AspNetUser friend)
        {
            name = friend.Profile.firstname + " " + friend.Profile.lastname;
            friend_id = friend.Id;
            profilePath = friend.Profile.Albums.Where(x => x.name.Equals("ProfileAlbum")).FirstOrDefault().Pictures.OrderByDescending(x => x.date).FirstOrDefault().path;
            if (lastReceivedMessage != null && lastSentMessage != null)
            {
                if (lastReceivedMessage.date > lastSentMessage.date)
                {
                    lastMessage = lastReceivedMessage;
                }
                else
                {
                    lastMessage = lastSentMessage;
                }
            }
            else if (lastSentMessage != null)
            {
                lastMessage = lastSentMessage;
            }
            else if (lastReceivedMessage != null)
            {
                lastMessage = lastReceivedMessage;
            } else
            {
                lastMessage = null;
            }
        }
    }
}