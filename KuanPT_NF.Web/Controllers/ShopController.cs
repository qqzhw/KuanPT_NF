using IMCustSys.BLL.Infrastructure;
using IMCustSys.BLL.Services;
using IMCustSys.Model;
using IMCustSys.Web.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMCustSys.Web.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/
        private readonly IShopService _shopService;
        private readonly IChannelService _channelService;
        public ShopController(IShopService  shopService, IChannelService channelService)
        {
            _shopService = shopService;
            _channelService = channelService;
        }
        public ActionResult Index()
        {
            var items = _shopService.GetAllProducts(state:1).Select(o => new ShopModel()
            {
                Commission = o.Commission,
                CreateDate = o.CreateDate,
                Description = o.Description,
                DisplayOrder = o.DisplayOrder,
                Img = o.Img,
                Price = o.Price,
                Remark = o.Remark,
                ShopId = o.ShopId,
                ShopName = o.ShopName,
                ShopType = o.ShopType,
                ShortDescription = o.ShortDescription,
                ShowOnHomePage = o.ShowOnHomePage,
            }).OrderBy(o=>o.ShopName).ThenBy(o=>o.Price).ToList();
            return View(items); 
        }
        public ActionResult List()
        {
            var items = _shopService.GetAllProducts(showHidden:1).Select(o => new ShopModel()
            {
                Commission = o.Commission,
                CreateDate = o.CreateDate,
                Description = o.Description,
                DisplayOrder = o.DisplayOrder,
                Img = o.Img,
                Price = o.Price,
                Remark = o.Remark,
                ShopId = o.ShopId,
                ShopName = o.ShopName,
                ShopType = o.ShopType,
                ShortDescription = o.ShortDescription,
                ShowOnHomePage = o.ShowOnHomePage,
            }).OrderBy(o => o.ShopName).ToList(); 
            return View(items);
        }
        public ActionResult Detail(int Id)
        {
            var model = new ShopModel();
            var item = _shopService.GetProductById(Id);
            if (item == null)
                return View(model);
            model.Commission = item.Commission;
            model.Description = item.Description;
            model.Img = item.Img;
            model.Price = item.Price;
            model.Remark = item.Remark;
            model.ShopId = item.ShopId;
            model.ShopName = item.ShopName;
            model.ShortDescription = item.ShortDescription;
            model.ShopType = item.ShopType;
            //渠道数据加入
            if (EngineContext.Channel!=null)
            {
                AddChannelData(item);
            }
          
            return View(model);
        }
        private void AddChannelData(Shop item)
        {
            var channelData = new ChannelData();
            channelData.ShopId = item.ShopId;
            channelData.ShopName = item.ShopName;
            channelData.CreatedDate = DateTime.Now;
            channelData.ChannelId = EngineContext.Channel.ChannelId;
            channelData.ChannelName = EngineContext.Channel.ChannelName;
            _channelService.InsertChannelData(channelData);
        }
    }
}
