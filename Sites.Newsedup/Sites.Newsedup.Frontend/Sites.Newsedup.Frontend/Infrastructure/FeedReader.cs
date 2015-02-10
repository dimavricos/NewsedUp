using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using Sites.Newsedup.Frontend.Models;

namespace Sites.Newsedup.Frontend.Infrastructure
{
    public class FeedReader
    {
        //private Timer _timer;
        public FeedReader()
        {
            Feeds = new FeedItem[]{};

        }

        public FeedItem[] Queue { get; private set; }

        public FeedItem[] Feeds { get; private set; }

        private static object lockObject = new object();

        public void MergeLists()
        {
        }

        public void Sync()
        {
            lock (lockObject)
            {
                var feeds = GetSiteFeeds(new SiteInfo {Name = "Protothema"}, new[]
                {
                    "http://www.protothema.gr/rss/news/general/",
                    "http://sports.espn.go.com/espn/rss/news",
                    "http://feeds.bbci.co.uk/news/rss.xml"
                });
                Feeds = Feeds.Union(feeds).ToArray();
            }
        }

        private FeedItem[] GetSiteFeeds(SiteInfo siteInfo, string[] feedLinks)
        {
            //feeds.Add("http://feeds2.feedburner.com/WadeWegner");
            //feeds.Add("http://www.nickharris.net/feed/");
            //feeds.Add("http://feeds.feedburner.com/ntotten");
            //feeds.Add("http://michaelwasham.com/feed/");
            //feeds.Add("http://blogs.msdn.com/b/hpctrekker/rss.aspx");

            var mainFeed = new SiteFeed[] { };
            foreach (var feed in feedLinks)
            {
                var feedUri = new Uri(feed);
                SyndicationFeed syndicationFeed;

                using (var reader = XmlReader.Create(feedUri.AbsoluteUri))
                {
                    syndicationFeed = SyndicationFeed.Load(reader);
                    reader.Dispose();
                    reader.Close();
                }

                if (syndicationFeed == null)
                    continue;


                var siteFeed = new SiteFeed
                {
                    FeedUrl = feed,
                    SiteInfo = siteInfo,
                    News = syndicationFeed.Items.Select(x => x.ToFeedItem()).OrderByDescending(x => x.LastUpdatedTime).ToArray()
                };

                mainFeed = mainFeed.Union(new[] { siteFeed }).ToArray();
            }

            return mainFeed.SelectMany(x => x.News).ToArray();
        }
    }


    public static class ExtensionMethods
    {
        public static FeedItem ToFeedItem(this SyndicationItem item)
        {
            return new FeedItem
            {
                Authors = item.Authors.Select(x => new FeedPerson { Email = x.Email, Name = x.Name, Uri = x.Uri }).ToArray(),
                Contributors = item.Contributors.Select(x => new FeedPerson { Email = x.Email, Name = x.Name, Uri = x.Uri }).ToArray(),
                //BaseUri = item.BaseUri,
                Content = item.Content == null ? "" : item.Content.ToString(),
                Summary = item.Summary == null ? "" : item.Summary.Text,
                LastUpdatedTime = item.LastUpdatedTime.LocalDateTime,
                PublishDate = item.PublishDate.LocalDateTime,
                Copyright = item.Copyright == null ? "" : item.Copyright.ToString(),
                Id = item.Id,
                //Links = item.Links.Select(x => new FeedLink { BaseUri = x.BaseUri, Uri = x.Uri, RelationshipType = x.RelationshipType, Title = x.Title }).ToArray(),
                Title = item.Title.ToString(),
                Categories = item.Categories.Select(x => new FeedCategory { Label = x.Label, Name = x.Name }).ToArray()
            };
        }
    }
}