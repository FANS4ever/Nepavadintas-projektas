using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gear.Models
{
    public class TwitchStreamers
    {
        public string _id { get; set; }
        public string game { get; set; }
        public int viewers { get; set; }
        public int video_height { get; set; }
        public double average_fps { get; set; }
        public double delay { get; set; }
        public string created_at { get; set; }
        public string is_playlist { get; set; }
        public string stream_type { get; set; }
        public TwitchChannel channel { get; set; }
    }
}