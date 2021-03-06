﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class CommentViewModel
    {
        public CommentViewModel(Comment comment, bool isMyPost, string location)
        {
            this.comment = comment;
            this.isMyPost = isMyPost;
            this.location = location;
        }

        public CommentViewModel()
        {

        }

        public Comment comment { get; set; }

        public bool isMyPost { get; set; }
        public string location { get; set; }

        public void acceptCommentFrom(Comment comment)
        {
            comment.Status = (int)CommentStatus.accepted;
        }

        public void declineCommentFrom(Comment comment)
        {
            comment.Status = (int)CommentStatus.denied;
        }
    }
}