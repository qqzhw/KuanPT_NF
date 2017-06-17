using BLL.Services;
using Common;
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
    }
}