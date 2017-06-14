using BLL.Services;
using KuanPT_NF.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuanPT_NF.Web.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/
        private readonly IShopService _shopService;
        public ShopController(IShopService  shopService)
        {
            _shopService = shopService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int Id)
        {
            var model = new ShopModel();
            var item = _shopService.GetProductById(Id);
            model.Commission = item.Commission;
            model.Description = item.Description;
            model.Img = item.Img;
            model.Price = item.Price;
            model.Remark = item.Remark;
            model.ShopId = item.ShopId;
            model.ShopName = item.ShopName;
            model.ShortDescription = item.ShortDescription;
            model.ShopType = item.ShopType;
            return View(model);
        }
    }
}
