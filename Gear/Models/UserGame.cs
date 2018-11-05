using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    // reikia sito nes vienam view naudot keleta modeliu
    public class UserGame
    {
        public User user { get; set; }
        public List<Game> games { get; set; }

        public Country country { get; set; }
    }
}