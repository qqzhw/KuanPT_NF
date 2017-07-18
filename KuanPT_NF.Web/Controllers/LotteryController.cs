using IMCustSys.BLL.Services;
using IMCustSys.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuanPT_NF.Web.Controllers
{
    public class LotteryController : BaseController
    {
        private readonly ILotteryService _lotteryService;
        private readonly IShopService _shopService;
        private readonly IChannelService _channelService;
        public LotteryController(IShopService shopService, IChannelService channelService, ILotteryService lotteryService)
        {
            _shopService = shopService;
            _channelService = channelService;
            _lotteryService = lotteryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetLotteryItem(int? Id)
        {
            if (Id == null)
                return Json(null,JsonRequestBehavior.AllowGet);
            var item = _lotteryService.GetAllLotteryItems(Id.Value);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}