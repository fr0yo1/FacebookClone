//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FacebookClone.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int comment_id { get; set; }
        public int post_id { get; set; }
        public System.DateTime date { get; set; }
        public string content { get; set; }
        public string user_id { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Post Post { get; set; }
    }
}
