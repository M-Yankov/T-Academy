﻿namespace ArtistSystem.WebApi
{
    using System.Web.Http;
    using System.Web.Mvc;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataBaseConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
