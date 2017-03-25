using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persets.Frontend.Models
{
    public class User
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompleteName { get; set; }
        public System.DateTime BirthdayDate { get; set; }
        public string Password { get; set; }
    }
}