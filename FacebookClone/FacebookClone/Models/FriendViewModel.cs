using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class FriendViewModel
    {
        public string friendID { get; set; }
        public string picture { get; set; }
        public string fullName { get; set; }

        public FriendViewModel(string friendID, string picture, string fullName)
        {
            this.friendID = friendID;
            this.picture = picture;
            this.fullName = fullName;
        }
    }
    
}