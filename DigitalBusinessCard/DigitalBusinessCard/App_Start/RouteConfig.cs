using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DigitalBusinessCard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
         name: "User",
         url: "Card/{id}",
         defaults: new { controller = "BusinessCard", action = "CardProfile" }
     );

            routes.MapRoute(
    name: "Home",
    url: "Home",
    defaults: new { controller = "Home", action = "Index" }
);

            routes.MapRoute(
   name: "Login",
   url: "Login",
   defaults: new { controller = "User", action = "Login" }
);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


       
        }
    }
}
