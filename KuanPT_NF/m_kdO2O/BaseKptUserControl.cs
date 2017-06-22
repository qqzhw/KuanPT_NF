using BLL.Infrastructure;
using BLL.Services;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace KuanPT_NF.m_kdO2O
{
    public class BaseKptUserControl : UserControl
    {
        public ILotteryService LotteryService
        {
            get
            {
                return EngineContext.Current.Resolve<ILotteryService>();
            }
        }
        public IPictureService  PictureService
        {
            get
            {
                return EngineContext.Current.Resolve<IPictureService>();
            }
        }
        protected virtual void BindJQuery()
        {
            CommonHelper.BindJQuery(this.Page);
        }

        protected virtual void BindJQueryIdTabs()
        {
            string jqueryTabs = CommonHelper.GetStoreLocation() + "JavaScripts/jquery.idTabs.min.js";
            Page.ClientScript.RegisterClientScriptInclude(jqueryTabs, jqueryTabs);
        }
        protected void ProcessException(Exception exc)
        {
            ProcessException(exc, true);
        }

        protected void ProcessException(Exception exc, bool showError)
        {

            if (showError)
            {

                ShowError(exc.Message, exc.ToString());

            }
        }

        protected void ShowMessage(string message)
        {
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
            if (masterPage == null)
                return; 
        }

        protected void ShowError(string message)
        {
            ShowError(message, string.Empty);
        }

        protected void ShowError(string message, string completeMessage)
        {
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
            if (masterPage == null)
                return;

        }
    }
}