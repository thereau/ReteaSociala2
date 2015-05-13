using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReteaSocialaMDS.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int ConversationId { get; set; }
        public string Text { get; set; }
        public Boolean userTurn { get; set; }

        [ForeignKey("ConversationId")]
        public virtual Conversation Conversation { get; set; }
    }
}