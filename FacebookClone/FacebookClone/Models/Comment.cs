namespace FacebookClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Key]
        public int comment_id { get; set; }

        public int post_id { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(50)]
        public string content { get; set; }

        [Required]
        [StringLength(128)]
        public string user_id { get; set; }

        public int? Status { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Post Post { get; set; }
    }
}
