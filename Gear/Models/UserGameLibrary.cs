using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class UserGameLibrary
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime LastOpenDate { get; set; }
        //Might change to datetime
        public double TimePlayed { get; set; }
    }
}