using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class ChannelAdd : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            var comId = "0000100001";//BLL.sys_admin.GetUserComid();
            var channel = new Channel();
            channel.BmId = 1;
            channel.ComId = comId;
            channel.ChannelCode = txtChannelCode.Text;
            channel.ChannelDesc = txtDesc.Text;
            channel.ChannelLable = txtChannelLable.Text;
            channel.ChannelName = txtChannelName.Text;
            channel.ChannelUrl = txtChannelUrl.Text;
            channel.DisplayOrder = txtDisplayOrder.Value; 
            channel.Published = chkPublished.Checked;
            channel.CreatedDate = DateTime.Now;
            ChannelService.InsertChannel(channel);
            Response.Redirect("ChannelList.aspx");
        }
    }
}