using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public int CommentRating { get; set; }
        public bool Visible { get; set; }
        public bool Important { get; set; }
    }
}