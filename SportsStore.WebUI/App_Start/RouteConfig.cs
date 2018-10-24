﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        /*

        URL             Leads To
        /               Lists the first page of products from all categories
        /Page2          Lists the specified page (in this case, page 2), showing items from all categories
        /Soccer         Shows the first page of items from a specific category (in this case, the Soccer category)
        /Soccer/Page2   Shows the specified page (in this case, page 2) of items from the specified category (in thiscase, Soccer) 

        */
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(null, "Page{Page}", new { controller = "Product", action = "List", page = 1 });
            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Product", action = "List", category = (string)null },
                new { page = @"\d+" }
            );
            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
