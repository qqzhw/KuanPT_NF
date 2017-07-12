using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IMCustSys.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Shop",
               url: "Shop/Detail/{Id}",
               defaults:new { controller = "Shop", action = "Detail"},
               constraints:new { Id = @"\d+" },
               namespaces:new[] { "IMCustSys.Web.Controllers" });
            routes.MapRoute(
              name: "Campaign",
              url: "Campaign/Detail/{Id}",
              defaults: new { controller = "Campaign", action = "Detail" },
              constraints: new { Id = @"\d+" },
              namespaces: new[] { "IMCustSys.Web.Controllers" }); 
        }
    }
}