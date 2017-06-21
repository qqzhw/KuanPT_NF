using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuanPT_NF.Web.Controllers
{
    public class BaseController:Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.HttpContext.Request.Params.Add("mid", "amogh");
            base.OnActionExecuting(filterContext);
            var s = filterContext.RouteData.Route;
          
        }
    }
}