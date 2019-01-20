namespace FacebookClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Picture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Picture()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int picture_id { get; set; }

        public int album_id { get; set; }

        [Required]
        [StringLength(50)]
        public string path { get; set; }

        public DateTime date { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        public virtual Album Album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
