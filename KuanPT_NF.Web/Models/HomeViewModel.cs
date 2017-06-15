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
        }
        public List<ShopModel> ShopInfos { get; set; }
        public ShopModel HotShopModel { get; set; }
    }
}