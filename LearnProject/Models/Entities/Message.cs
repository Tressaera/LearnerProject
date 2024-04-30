using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnProject.Models.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public String NameSurname { get; set; }
        public String Email { get; set; }
        public String Subject { get; set; }
        public String MessageContent { get; set; }
        public bool IsRead { get; set; }
    }
}