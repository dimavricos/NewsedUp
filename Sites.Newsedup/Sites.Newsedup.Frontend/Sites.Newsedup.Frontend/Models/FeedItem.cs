using System;

namespace Sites.Newsedup.Frontend.Models
{
    public class FeedItem : FeedBase
    {
        public static bool operator ==(FeedItem item1, FeedItem item2)
        {
            if (item1 == null && item2 == null)
                return false;
            return (item1 == null ? "" : item1.Id) == (item2 == null ? "" : item2.Id);
        }

        public static bool operator !=(FeedItem item1, FeedItem item2)
        {
            if (item1 == null && item2 == null)
                return false;
            return (item1 == null ? "" : item1.Id) != (item2 == null ? "" : item2.Id);
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public FeedPerson[] Authors { get; set; }
        public FeedCategory[] Categories { get; set; }
        public Uri BaseUri { get; set; }
        public FeedPerson[] Contributors { get; set; }
        public string Copyright { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public FeedLink[] Links { get; set; }
        public DateTime PublishDate { get; set; }
    }
}