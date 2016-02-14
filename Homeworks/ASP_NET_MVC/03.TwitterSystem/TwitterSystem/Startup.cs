using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitterSystem.Startup))]
namespace TwitterSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
