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
    public partial class LotteryDetails : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected Lottery Save()
        {
            Lottery lottery = null;
            {
                lottery = ctrlLotteryInfo.SaveInfo();
                ctrlLotteryEndInfo.SaveInfo();                
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
                    Response.Redirect("LotteryDetails.aspx?LotteryId=" + lottery.LotteryId);
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


        public int LotteryId
        {
            get
            {
                return CommonHelper.QueryStringInt("LotteryId");
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