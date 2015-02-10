using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sites.Newsedup.Frontend.Models
{
    public class FeedLink : FeedBase
    {
        public Uri BaseUri { get; set; }
        public long Length { get; set; }
        public MediaType MediaType { get; set; }
        public string RelationshipType { get; set; }
        public string Title { get; set; }
        public Uri Uri { get; set; }
    }

    public enum MediaType
    {
        Video = 0,
        Image = 1
    }
}