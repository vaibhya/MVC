using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WelcomeMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Welcome",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Welcome", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Welcome1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Welcome1", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Welcome2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Welcome2", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Form1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Form", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Auth",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Auth", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Json1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Welcome3", id = UrlParameter.Optional }
            );
        }
    }
}
