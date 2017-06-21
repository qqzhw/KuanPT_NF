using BLL.Infrastructure;
using BLL.Services;
using KuanPT_NF.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuanPT_NF.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IShopService _shopService;
         private readonly IChannelService _channelService;
        public HomeController(IShopService shopService, IChannelService  channelService)
        {
            _shopService = shopService;
            _channelService = channelService;
        }
        public ActionResult Index(string Id="")
        {
            EngineContext.Channel = Id;
            ViewBag.Message = "德阳移动";
            var model = new HomeViewModel()
            {
                ShopInfos = _shopService.GetAllProductsDisplayedOnHomePage().Select(o => new ShopModel()
                {
                   Commission=o.Commission,
                   CreateDate=o.CreateDate,
                   Description=o.Description,
                   DisplayOrder=o.DisplayOrder,
                   Img=o.Img,
                   BigImg=o.BigImg,
                   Price=o.Price,
                   Remark=o.Remark,
                   ShopId=o.ShopId,
                   ShopName=o.ShopName,
                   ShopType=o.ShopType,
                   ShortDescription=o.ShortDescription,
                   ShowOnHomePage=o.ShowOnHomePage, 
                }).ToList()
            };
            var hotModel = _shopService.GetAllHotProducts().Select(o => new ShopModel()
            {
                Commission = o.Commission,
                CreateDate = o.CreateDate,
                Description = o.Description,
                DisplayOrder = o.DisplayOrder,
                Img = o.Img,
                BigImg = o.BigImg,
                Price = o.Price,
                Remark = o.Remark,
                ShopId = o.ShopId,
                ShopName = o.ShopName,
                ShopType = o.ShopType,
                ShortDescription = o.ShortDescription,
                ShowOnHomePage = o.ShowOnHomePage,
            }).FirstOrDefault();
            model.HotShopModel =hotModel;
            return View(model);
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
        public ActionResult PageNotFound()
        {
            return View();
        }
        public ActionResult PageError()
        {
            return View();
        }
    }
}
