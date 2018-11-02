using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ValidUntil { get; set; }
        public double Modifier { get; set; }
        public string Code { get; set; }
    }
}