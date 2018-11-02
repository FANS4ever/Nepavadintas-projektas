using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime SendDate { get; set; }
        public string Contents { get; set; }
        public bool Seen { get; set; }
    }
}