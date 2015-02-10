using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sites.Newsedup.Frontend.Infrastructure.Services
{
    public class FeedEventArgs : EventArgs
    {
        private string EventInfo;
        public FeedEventArgs(string Text)
        {
            EventInfo = Text;
        }
        public string GetInfo()
        {
            return EventInfo;
        }
    }
}