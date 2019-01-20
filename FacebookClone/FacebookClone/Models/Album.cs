namespace FacebookClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            Pictures = new HashSet<Picture>();
        }

        [Key]
        public int album_id { get; set; }

        [Required]
        [StringLength(128)]
        public string user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public DateTime date { get; set; }

        public virtual Profile Profile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
