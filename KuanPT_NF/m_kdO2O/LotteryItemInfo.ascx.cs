using IMCustSys.Common;
using IMCustSys.Model;
using IMCustSys.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class LotteryItemInfo : BaseKptUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
          // btnAdd.OnClientClick = string.Format("javascript:OpenWindow('LotteryItemAdd.aspx?LotteryId={0}&LotteryName={1}', 800, 600, true); return false;", LotteryId,LotteryName);
           btnAdd.OnClientClick = string.Format("javascript:OpenWindow('LotteryItemAdd.aspx?LotteryId={0}&BtnId={1}', 800, 600, true); return false;", LotteryId, btnRefesh.ClientID);

        }
        

        public void SaveInfo()
        {
            SaveInfo(this.LotteryId);
        }

        public void SaveInfo(int lotteryId)
        {
             
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
        protected List<LotteryItem> GetLottertItems()
        {          
             var items = LotteryService.GetAllLotteryItems(LotteryId).ToList();
              return items;            
        }
        protected void SgvCpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            sgvCpList.PageIndex = e.NewPageIndex;
            BindData(); //重新绑定GridView数据的函数 
        }

        private void BindData()
        { 
            var lotteryItems = GetLottertItems();
            this.sgvCpList.DataSource = lotteryItems;
            this.sgvCpList.DataBind();
        }
         
        protected void sgv_Cancel(object sender, GridViewCancelEditEventArgs e)
        {
            ((GridView)sender).EditIndex = -1;
            BindData();
        }
        protected void sgv_Edit(object sender, GridViewEditEventArgs e)
        {
            ((GridView)sender).EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void sgv_Update(object sender, GridViewUpdateEventArgs e)
        {

            GridView gv = ((GridView)sender);

            GridViewRow row = gv.Rows[e.RowIndex];
            int Id = int.Parse(((Literal)row.FindControl("ltllotteryItemId")).Text);
            var item = LotteryService.GetLotteryItemById(Id);
            item.ItemName = ((SimpleTextBox)row.FindControl("tbItemName")).Text.Trim();
            item.AwardName = ((SimpleTextBox)row.FindControl("tbAwardName")).Text.Trim();
            item.AwardCount = ((NumericTextBox)row.FindControl("txtAwardCount")).Value;
            item.CurrentCount = ((NumericTextBox)row.FindControl("txtCurrentCount")).Value;
            item.AwardPercent = ((NumericTextBox)row.FindControl("txtAwardPercent")).Value;
            LotteryService.UpdateLotteryItem(item);
            ((GridView)sender).EditIndex = -1;
            BindData();
        }

        protected void sgv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
              int Id = 0;

            switch (e.CommandName)
            {
                case "DeleteItem":  // 删除
                    Id = int.Parse(e.CommandArgument.ToString());
                    var item = LotteryService.GetLotteryItemById(Id);
                    LotteryService.DeleteLotteryItem(item);
                    BindData();
                    break;
                  case "Edit":
                  //this.Page.RegisterStartupScript("OpenWindow", "LotteryItemAdd.aspx?LotteryId="+ LotteryId + "&BtnId="+btnRefesh.ClientID+", 800, 600, true); return false;");
                    break;
            }
         
          //  Response.Redirect(CommonHelper.GetThisPageUrl(true));
        }

        protected void btnRefesh_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}