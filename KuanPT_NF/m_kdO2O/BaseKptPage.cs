﻿using System;
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
        public  void ShowMessage(string msg)
        {
            //  ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "opennewwindow", "alert('"+msg+"');", true);
        }
    }
}