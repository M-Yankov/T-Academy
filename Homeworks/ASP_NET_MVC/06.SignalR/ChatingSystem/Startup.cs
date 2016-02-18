using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatingSystem.Startup))]
namespace ChatingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
