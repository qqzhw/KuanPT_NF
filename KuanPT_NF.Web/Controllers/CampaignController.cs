using IMCustSys.BLL.Services;
using IMCustSys.Common;
using KuanPT_NF.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuanPT_NF.Web.Controllers
{
    public class CampaignController : BaseController
    { 
        private readonly ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService)
        { 
            _campaignService = campaignService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int Id)
        {
            var model = new CampaignModel();
            var item = _campaignService.GetCampaignById(Id);
            model.BeginTime = item.BeginTime;
                 model.BmId = item.BmId;
            model.Body = item.Body;
            model.CampaignId = item.CampaignId;
            model.CampaignName = item.CampaignName;
            model.ComId = item.ComId;
            model.DisplayOrder = item.DisplayOrder;
            model.EndTime = item.EndTime;
            model.ImgPath = CommonHelper.GetStoreLocation() + item.ImgPath;
            model.IsHomeBanner = item.IsHomeBanner;
            model.Published = item.Published;
            model.Subject = item.Subject;
            return View(model);
        }
        
    }
}
