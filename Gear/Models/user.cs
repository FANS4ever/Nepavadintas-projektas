using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime BlockedUntilDate { get; set; }
    }
}