using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class Friend
    {
       
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public string OtherUserId { get; set; }


        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("OtherUserId")]
        public virtual ApplicationUser OtherUser{ get; set; }


    }
}