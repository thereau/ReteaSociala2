using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }


        [ForeignKey("FirstUserId")]
        public virtual ApplicationUser FirstUser { get; set; }
        [ForeignKey("SecondUserId ")]
        public virtual ApplicationUser SecondUser { get; set; }

        public virtual ICollection<Message> Messages { get; set; } 
    }
}