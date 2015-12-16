[assembly: Microsoft.Owin.OwinStartup(typeof(Company.WebApi.Startup))]

namespace Company.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
