using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoadMore.Models
{
    public class Youtube
    {
        public string id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string avatar_image { get; set; }
        public string youtube_image { get; set; }
    }

    public class YoutubeBean
    {
        public List<Youtube> youtubes { get; set; }
        public bool error { get; set; }
        public string error_msg { get; set; }
    }
}
