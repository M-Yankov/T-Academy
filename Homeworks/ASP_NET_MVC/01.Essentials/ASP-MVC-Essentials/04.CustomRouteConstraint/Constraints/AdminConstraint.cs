using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace CustomRouteConstraint.Constraints
{
    public class AdminConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
           bool isAdminRoute = httpContext
                .Request
                .Url
                .AbsolutePath
                .StartsWith("/Admin", StringComparison.InvariantCultureIgnoreCase);

            return isAdminRoute;

        }
    }
}