using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public string FutureFriendUserId { get; set; }


        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("FutureFriendUserId")]
        public virtual ApplicationUser FutureFriendrUser { get; set; }
    }
}