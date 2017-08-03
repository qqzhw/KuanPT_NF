using IMCustSys.Common;
using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class LotteryAdd : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SelectTab(this.LotteryTabs, this.TabId);
            }
        }
        protected Lottery Save()
        {
            Lottery lottery = null;
            {
                lottery = ctrlLotteryInfo.SaveInfo();
                ctrlLotteryEndInfo.SaveInfo(lottery.LotteryId);
                ctrlLotteryItemInfo.SaveInfo(lottery.LotteryId);
            }
            return lottery;
        }
        protected void SaveAndEdit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                { 
                    Lottery lottery = Save();
                    Response.Redirect(string.Format("LotteryDetails.aspx?LotteryId={0}&LotteryName={1}&TabID={2}", lottery.LotteryId,lottery.LotteryName, this.GetActiveTabId(this.LotteryTabs)));
                }
                catch (Exception exc)
                {
                    
                }
            }
        }
     
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Lottery lottery = Save();
                    Response.Redirect("LotteryList.aspx");
                }
                catch (Exception exc)
                {

                }
            }
        }
        protected string TabId
        {
            get
            {
                return CommonHelper.QueryString("TabId");
            }
        }
    }
}