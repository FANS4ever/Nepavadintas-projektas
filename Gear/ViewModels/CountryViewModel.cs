using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gear.Models;

namespace Gear.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> Countries { get; set; }
        public User user { get; set; }
        public List<Mark> marks { get; set; }

    }
}