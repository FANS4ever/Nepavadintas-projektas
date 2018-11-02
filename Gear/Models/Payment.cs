using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class Payment
    {
        public string Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public double Amount { get; set; }
    }
}