using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using IMCustSys.BLL.Infrastructure;
using IMCustSys.BLL.Services;
using AjaxControlToolkit;

namespace IMCustSys
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
      
        public IPictureService PictureService
        {
            get
            {
                return EngineContext.Current.Resolve<IPictureService>();
            }
        }
        public ICategoryService  CategoryService
        {
            get
            {
                return EngineContext.Current.Resolve<ICategoryService>();
            }
        }
        public IOrderService  OrderService
        {
            get
            {
                return EngineContext.Current.Resolve<IOrderService>();
            }
        }
        public IChannelService  ChannelService
        {
            get
            {
                return EngineContext.Current.Resolve<IChannelService>();
            }
        }
        public ILotteryService LotteryService
        {
            get
            {
                return EngineContext.Current.Resolve<ILotteryService>();
            }
        }
        
        protected IExportManager  ExportManager
        {
            get
            {
                return EngineContext.Current.Resolve<IExportManager>();
            }
        }
        protected void SelectTab(TabContainer tabContainer, string tabId)
        {
            if (tabContainer == null)
                throw new ArgumentNullException("tabContainer");

            if (!String.IsNullOrEmpty(tabId))
            {
                TabPanel tab = tabContainer.FindControl(tabId) as TabPanel;
                if (tab != null)
                {
                    tabContainer.ActiveTab = tab;
                }
            }
        }

        protected string GetActiveTabId(TabContainer tabContainer)
        {
            if (tabContainer == null)
                throw new ArgumentNullException("tabContainer");

            if (tabContainer.ActiveTab != null)
                return tabContainer.ActiveTab.ID;

            return string.Empty;
        }
        public  void ShowMessage(string msg)
        {
            //  ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('"+msg+"');", true);
        }
    }
}