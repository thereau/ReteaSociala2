using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class PostViewModel
    {

        
        public int Id { get; set; }

        public DateTime PostDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PostMessage { get; set; }


    }
}