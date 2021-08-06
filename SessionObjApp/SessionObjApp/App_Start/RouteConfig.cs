using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SessionObjApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "session",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Session", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "application",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Application", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "summary",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Summary", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
