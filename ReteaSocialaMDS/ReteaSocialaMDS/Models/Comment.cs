using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
       // [Required]

        //public string Comment { get; set; }
    }
}