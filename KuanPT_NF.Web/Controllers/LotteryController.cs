using IMCustSys.BLL.Services;
using IMCustSys.Web.Controllers;
using IMCustSys.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMCustSys.Web.Controllers
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
        public ActionResult Index(int? Id)
        {
            if (Id == null)
                Id = 0;             
            var item = _lotteryService.GetLotteryById(Id.Value);
            if (item!=null)
            {
                var model = new LotteryModel()
                {
                    Description=item.Description,                     
                    BeginDate = item.BeginDate,
                    EndDate=item.EndDate,
                    ExchangeInfo=item.ExchangeInfo,
                    Introduction=item.Introduction,
                    KeyWord=item.KeyWord,
                    LotteryEndImg=item.LotteryEndImg,
                    LotteryEndInfo=item.LotteryEndInfo,
                    LotteryEndNotice=item.LotteryEndNotice,
                    LotteryId=item.LotteryId,
                    LotteryImg=item.LotteryImg,
                    LotteryName=item.LotteryName,
                    LotteryTips=item.LotteryTips,
                    MaxLotteryCount=item.MaxLotteryCount,
                    PersonCount=item.PersonCount,
                    RepeatLotteryInfo=item.RepeatLotteryInfo,
                    TodayLotteryCount=item.TodayLotteryCount
                };
                return View(model);
            } 
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public JsonResult GetLotteryItem(int? Id)
        {
            if (Id == null)
                return Json(null);
            var rewardNames = _lotteryService.GetAllLotteryItems(Id.Value);
            List<string> colors = new List<string>();
            for (int i = 0; i < rewardNames.Count; i++)
            {
                if (i%2==0)
                {
                    colors.Add("#FFFFFF");
                }
                else
                {
                    colors.Add("#FFF4D"+i+"");
                }
            }
            JsonResult json = new JsonResult
            {
                Data = new { rewardNames, colors } 
            };
            return Json(json);
        }
    }
}