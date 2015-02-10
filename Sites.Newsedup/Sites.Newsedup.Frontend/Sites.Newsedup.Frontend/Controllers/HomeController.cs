using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sites.Newsedup.Frontend.Hubs;
using Sites.Newsedup.Frontend.Infrastructure;
using StructureMap;

namespace Sites.Newsedup.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Chat()
        {
            ObjectFactory.GetInstance<FeedReader>().Sync();
            return View();
        }
	}
}