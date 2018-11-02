using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}