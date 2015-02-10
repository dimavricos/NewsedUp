using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sites.Newsedup.Frontend.Models
{
    public class FeedPerson : FeedBase
    {
        public string Email { get; set; }
        public string Name { get; set; } 
        public string Uri { get; set; }
    }
}