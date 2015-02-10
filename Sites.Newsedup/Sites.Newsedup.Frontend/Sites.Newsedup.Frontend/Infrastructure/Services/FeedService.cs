using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sites.Newsedup.Frontend.Infrastructure.Services
{
    public class FeedService
    {
        public static event EventHandler<FeedEventArgs> FeedUpdated;

        protected static void OnFeedUpdated(FeedEventArgs eventArgs)
        {
            EventHandler<FeedEventArgs> handler = FeedUpdated;
            if (handler != null) handler(null, eventArgs);
        }
    }
}