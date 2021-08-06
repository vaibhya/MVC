using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BankMvcApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Bank", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Bank", action = "Home", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Bank", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DoTransaction",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Activity", action = "DoTransaction", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Passbook",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Activity", action = "Passwook", id = UrlParameter.Optional }
            );

        }
    }
}
