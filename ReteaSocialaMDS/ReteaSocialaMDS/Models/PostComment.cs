using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class PostComment
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ParentPostId { get; set; }



        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ParentPostId")]
        public virtual Post ParentPost { get; set; }
        [DataType(DataType.MultilineText)]
        public string PostCommentMessage { get; set; }

        private DateTime? commentPostDate;

        public DateTime CommentPostDate
        {
            get { return commentPostDate ?? DateTime.Now; }
            set { commentPostDate = value; }
        }
    }
}