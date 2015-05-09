using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class ImageViewModel
    {
        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        [StringLength(140)]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
       
    }
}