using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gear.Models;

namespace Gear.ViewModels
{
    public class StoreViewModel
    {
        public List<Game> Showcase { get; set; }
        public List<Visit> Popular { get; set; }
        public List<Discount> Discounted { get; set; }
        public List<Game> Newest { get; set; }
        public int Category { get; set; }
    }
}