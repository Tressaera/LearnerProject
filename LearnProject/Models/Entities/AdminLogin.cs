using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnProject.Models.Entities
{
    public class AdminLogin
    {
        public int AdminLoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}