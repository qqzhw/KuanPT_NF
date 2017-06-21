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
            base.OnActionExecuting(filterContext); 
        }
    }
}