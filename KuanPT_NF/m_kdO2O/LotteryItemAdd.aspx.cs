using IMCustSys.BLL.Services;
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
    public partial class LotteryItemAdd : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
            }
           
        } 
        private void BindData()
        {
             
        }
         
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (LotteryId == 0)
                return;

            var lotteryItem = new LotteryItem()
            {
                ItemName = txtItemName.Text,
                AwardName = txtAwardName.Text,
                AwardCount = txtAwardCount.Value,
                CurrentCount = txtCurrentCount.Value,
                LotteryId = LotteryId,                
                AwardPercent=txtAwardPercent.Value,         
                BmId = 1,
                ComId = "0000100001"
            };           
            LotteryService.InsertLotteryItem(lotteryItem);
           // Response.Write("<script>window.close();</script>");

            // Response.Redirect(string.Format("LotteryDetails.aspx?LotteryId={0}&LotteryName={1}", LotteryId, LotteryName));
            this.Page.ClientScript.RegisterStartupScript(typeof(LotteryDetails), "closerefresh", "<script language=javascript>try {window.opener.document.forms[0]." + this.BtnId + ".click();}catch (e){} window.close();</script>");
        }
        public int LotteryId
        {
            get
            {
                return CommonHelper.QueryStringInt("LotteryId");
            }
        }
        public string LotteryName
        {
            get
            {
                return CommonHelper.QueryString("LotteryName");
            }            
        }
        private string BtnId
        {
            get
            {
                return CommonHelper.QueryString("BtnId");
            }
        }
    }
   
}