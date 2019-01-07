using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class DeletePostViewModel
    {
        public PostViewModel postViewModel {get; set;}
        [Required(ErrorMessage = "The field is mandatory")]
        public string messageToUser {get; set;}

        public DeletePostViewModel(Post post)
        {
            this.postViewModel = new PostViewModel(post, "PostController") { canAddComments = false};
        }

        public DeletePostViewModel() { }
    }
}