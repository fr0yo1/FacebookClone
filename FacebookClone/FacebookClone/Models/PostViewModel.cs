using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class PostViewModel
    {
        public Post post { get; set; }

        [Required]
        public string inputComment { get; set; }

        public PostViewModel(Post post)
        {
            this.post = post;
        }

        public PostViewModel()
        {
        }
    }
}