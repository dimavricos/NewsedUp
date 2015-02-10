using Owin;
using Microsoft.Owin;
using Sites.Newsedup.Frontend.Infrastructure;
using StructureMap;

[assembly: OwinStartup(typeof(Sites.Newsedup.Frontend.Startup))]
namespace Sites.Newsedup.Frontend
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ObjectFactory.Configure(config => config.For<FeedReader>().Singleton().Use<FeedReader>());

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}