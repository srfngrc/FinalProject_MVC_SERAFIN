using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FinalProject_MVCapp_SERAFIN
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TaxSystemUsers", action = "Manage", id = UrlParameter.Optional }
            );
        }
    }
}
//defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }