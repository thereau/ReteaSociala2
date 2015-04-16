using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class User
    {
        public int UserId { get; set; }
        public List<Groups> UserGroups { get; set; } 
    }
}