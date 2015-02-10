using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sites.Newsedup.Frontend.Models
{
    public class SiteInfo
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class SiteFeed
    {
        public SiteInfo SiteInfo { get; set; }
        public string FeedUrl { get; set; }
        public FeedItem[] News { get; set; }
    }
}