namespace BugLogger.RestApi
{
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using BugLogger.RestApi.App_Start;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            MapperConfig.RegisterMappings(Assembly.Load("BugLogger.RestApi"));
        }
    }
}
