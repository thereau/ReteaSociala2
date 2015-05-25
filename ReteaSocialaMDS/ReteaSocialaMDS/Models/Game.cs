using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string GameUrl { get; set; }
    }
}