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
    public partial class LotteryItemInfo : BaseKptUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            BindJQuery();
            BindJQueryIdTabs();

            base.OnPreRender(e);
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
         //   int channelId = int.Parse(((Literal)row.FindControl("ltlChannelId")).Text);
           // var channel = ChannelService.GetChannelById(channelId);
          //  channel.ChannelName = ((SimpleTextBox)row.FindControl("txtChannelName")).Text;
          //  channel.Published = ((CheckBox)row.FindControl("chkPublished")).Checked;
            //user_DeptInfo.Level= int.Parse(((HiddenField)row.FindControl("hLevel")).Value);
            //if(user_DeptInfo.Level==0)
            //    user_DeptInfo.DeptType = 1;
            //else
            //{
            //    System.Data.DataTable dt = bllUser_Dept.GetByID(user_DeptInfo.Level);
            //    int dtype = int.Parse(dt.Rows[0]["deptType"].ToString());
            //    user_DeptInfo.DeptType = dtype + 1;
            //} 
           // ChannelService.UpdateChannel(channel);
           
        }

    }
}