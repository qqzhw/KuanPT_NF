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
    public partial class ChannelDetails : BaseKptPage
    {
        public int ChannelId
        {
            get
            {
                return CommonHelper.QueryStringInt("ChannelId");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
          
        private void BindData()
        {
            var channel = ChannelService.GetChannelById(ChannelId);
            if (channel != null)
            {
                txtChannelCode.Text = channel.ChannelCode;
                txtChannelLable.Text = channel.ChannelLable;
                txtChannelName.Text = channel.ChannelName;
                txtChannelUrl.Text = channel.ChannelUrl;
                txtDisplayOrder.Value = channel.DisplayOrder;
                txtDesc.Text = channel.ChannelDesc;
                chkPublished.Checked = channel.Published; 
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
          var channel = ChannelService.GetChannelById(ChannelId);
            channel.ChannelCode = txtChannelCode.Text;
            channel.ChannelLable=txtChannelLable.Text;
            channel.ChannelName=txtChannelName.Text ;
            channel.ChannelUrl = txtChannelUrl.Text;
            channel.DisplayOrder = txtDisplayOrder.Value;
            channel.ChannelDesc = txtDesc.Text ;
            channel.Published = chkPublished.Checked;
            ChannelService.UpdateChannel(channel);
            Response.Redirect("ChannelList.aspx");
        }
    }
}