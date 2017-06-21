using BLL.Infrastructure;
using BLL.Services;
using KuanPT_NF.Web.Models;
using Model;
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
        public ActionResult Index()
        {
            GetChannel();
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
            if (EngineContext.Channel!=null)
            {
                AddChannelData();
            }
            return View(model);
        }

        private void GetChannel()
        {
            var query = Request.Params["code"];
            if (query != null)
            {
                var channel = _channelService.GetChannelByCode(query.ToString());
                if (channel != null)
                {
                    EngineContext.Channel = channel;
                }
            }
        }

        private void AddChannelData()
        {
            var channelData = new ChannelData();
            channelData.ShopId = 0;
            channelData.ShopName ="首页";
            channelData.CreatedDate = DateTime.Now;
            channelData.ChannelId = EngineContext.Channel.ChannelId;
            channelData.ChannelName = EngineContext.Channel.ChannelName;
            _channelService.InsertChannelData(channelData);
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
