namespace ArtistSystem.WebApi
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataBaseConfig.Initialize();
            MapperConfig.RegisterMappings(Assembly.Load("ArtistSystem.WebApi"));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
