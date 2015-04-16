using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class Groups
    {
        public int GroupsId { get; set; }
        public string Description { get; set; }
        public List<User> GroupUsers { get; set; }

    }
}