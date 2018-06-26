using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetcowsay
{


    public class Blog
    {
        public string key { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public string feed { get; set; }
        public string language { get; set; }
        public DateTime lastPublished { get; set; }
        public Newestfeeditem newestFeedItem { get; set; }
    }

    public class Newestfeeditem
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public DateTime published { get; set; }
        public bool recent { get; set; }
        public Links links { get; set; }
        public object author { get; set; }
    }

    public class Links
    {
    }
}
