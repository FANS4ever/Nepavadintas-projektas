using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gear.Models;

namespace Gear.ViewModels
{
    public class SearchViewModel
    {
        public List<Game> View { get; set; }
        public Cart Cart { get; set; }
        public List<Genre> Tags { get; set; }

        public string Selected { get; set; }
        public string Search { get; set; }
    }
}