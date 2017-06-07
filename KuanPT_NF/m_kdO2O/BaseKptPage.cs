using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BLL.Infrastructure;
using BLL.Services;

namespace KuanPT_NF.m_kdO2O
{
    public partial class BaseKptPage:Page
    {
        public ICampaignService CampaignService
        {
            get { return EngineContext.Current.Resolve<ICampaignService>(); }
        }
        public IUserService UserService
        {
            get { return EngineContext.Current.Resolve<IUserService>(); }
        }
        public IShopService  ShopService
        {
            get { return EngineContext.Current.Resolve<IShopService>(); }
        }
        public ICategoryService ShopService
        {
            get { return EngineContext.Current.Resolve<IShopService>(); }
        }
    }
}