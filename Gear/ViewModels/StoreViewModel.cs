using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gear.Models;

namespace Gear.ViewModels
{
    public class StoreViewModel
    {
        public List<GameViewModel> Showcase { get; set; }
        public List<GameViewModel> Pupular { get; set; }
        public List<GameViewModel> Discounted { get; set; }
        public List<GameViewModel> Newest { get; set; }
        public int Category { get; set; }
    }
}