namespace FacebookClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int post_id { get; set; }

        [Required]
        [StringLength(128)]
        public string sender_id { get; set; }

        public int? group_id { get; set; }

        public int? picture_id { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(50)]
        public string content { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Group Group { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
