using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuanPT_NF.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult List()
        {
            ViewBag.Message = "宽带产品列表";

            return View();
        }
        public ActionResult ProductDetail()
        {
            ViewBag.Message = "产品详细";

            return View();
        }
        public ActionResult ProductDetail108()
        {
            ViewBag.Message = "产品详细";

            return View();
        }
        public ActionResult ProductDetail138()
        {
            ViewBag.Message = "产品详细";

            return View();
        }
        public ActionResult ProductDetail168()
        {
            ViewBag.Message = "产品详细";

            return View();
        }
        public ActionResult ProductDetailAj()
        {
            ViewBag.Message = "产品详细";

            return View();
        }
        public ActionResult ProductDetailAj168()
        {
            ViewBag.Message = "产品详细";

            return View();
        }
        public ActionResult OnlineOrder()
        {
            ViewBag.Message = "在线办理";

            return View();
        }
    }
}
