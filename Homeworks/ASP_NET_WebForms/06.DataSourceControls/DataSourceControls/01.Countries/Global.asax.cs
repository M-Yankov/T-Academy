using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.Web.Security;
using System.Web.SessionState;
using CountriesDataBase.Migrations;
using CountriesDataBase;

namespace Countries
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Configuration>());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}