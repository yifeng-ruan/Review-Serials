using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MVCReview.Controllers;

namespace MVCReview
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "User", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "Unauthorized",
                url: "Unauthorized",
                defaults: new {controller = "Unauthorized", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "User",
                url: "User/Main",
                defaults: new {controller = "User", action = "Index"}
                );
        }
    }
}