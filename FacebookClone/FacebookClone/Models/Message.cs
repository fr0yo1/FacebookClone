namespace FacebookClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [Key]
        public int message_id { get; set; }

        [Required]
        [StringLength(128)]
        public string sender_id { get; set; }

        [Required]
        [StringLength(128)]
        public string receiver_id { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(50)]
        public string content { get; set; }

        public int type { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual AspNetUser AspNetUser1 { get; set; }

        public virtual MessageType MessageType { get; set; }
    }
}
