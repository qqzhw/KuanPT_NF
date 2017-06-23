using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KuanPT_NF.Web.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            ShopInfos = new List<ShopModel>();
            Campaigns = new List<CampaignModel>();
        }
        public List<ShopModel> ShopInfos { get; set; }
        public List<CampaignModel> Campaigns { get; set; }
        public ShopModel HotShopModel { get; set; }
    }
}