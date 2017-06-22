using BLL.Services;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
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
                ItemName = txtName.Text,
                AwardName = txtAwardName.Text,
                AwardCount = txtAwardCount.Value,
                CurrentCount = txtCurrentCount.Value,
                LotteryId = LotteryId,
                LotteryItemId = 0,
                AwardPercent=txtAwardPercent.Value,         
                BmId = 1,
                ComId = "test"
            };
            LotteryService.InsertLotteryItem(lotteryItem);
            Response.Write("<script>window.close();</script>");
        }
        public int LotteryId
        {
            get
            {
                return CommonHelper.QueryStringInt("LotteryId");
            }
        }
    }
   
}