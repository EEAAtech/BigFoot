using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BigFoot
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Mirabai",
            url: "Indians-Longest-Laterite-Sculpture/",
            defaults: new { controller = "Home", action = "Mirabai" }
            );

            routes.MapRoute(
            name: "Information",
            url: "Information/",
            defaults: new { controller = "Home", action = "Information" }
            );

            routes.MapRoute(
           name: "Account",
           url: "Account/{action}",
           defaults: new { controller = "Account", action = "Login" }
           );

            routes.MapRoute(
            name: "Legend",
            url: "Legend-of-the-Big-Foot/",
            defaults: new { controller = "Home", action = "Legend" }
            );

            routes.MapRoute(
            name: "Gandhiji",
            url: "Gandhiji/",
            defaults: new { controller = "Home", action = "Gandhiji" }
            );

            routes.MapRoute(
            name: "Blog",
            url: "Blog/",
            defaults: new { controller = "Home", action = "Blog" }
            );

            routes.MapRoute(
            name: "MainSite",
            url: "{id}/",
            defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "MainSiteSubMen",
            url: "{ignorMen}/{id}/",
            defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
