using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebHost
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "account",
                url: "{controller}/{action}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "ctrl/{*.}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
