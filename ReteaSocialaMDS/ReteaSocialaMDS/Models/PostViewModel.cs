using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class PostViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string PostText;
    }
}