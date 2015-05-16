using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
     


        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [DataType(DataType.MultilineText)]
        public string PostMessage { get; set; }

        private DateTime? postDate;

        public DateTime PostDate
        {
            get { return postDate ?? DateTime.Now; }
            set { postDate = value; }
        }

        public virtual ICollection<PostComment> PostComments { get; set; }


    }
}
