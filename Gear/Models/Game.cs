using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string TrailerURL { get; set; }
        public double Price { get; set; }
        public DateTime AgeRestriction { get; set; }
        public string DevelopmentBranch { get; set; }
        public int VersionNumber { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}