using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TaxCalculator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //        "Edit", // Route name
            //        "{controller}/{action}/{id}/{name}", // URL with parameters
            //        new
            //        {
            //            controller = "Home",
            //            action = "Edit",
            //            id = UrlParameter.Optional,
            //            name = UrlParameter.Optional
            //        } // Parameter defaults
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
