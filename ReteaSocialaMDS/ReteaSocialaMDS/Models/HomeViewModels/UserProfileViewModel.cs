using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models.HomeViewModels
{
    public class UserProfileViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int numberOfFriends { get; set; }
        public int numberOfImages { get; set; }
        public Boolean friendReq { get; set; }
        public Boolean friend { get; set; }
        public string User { get; set; }

    }
}