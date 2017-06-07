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
    public partial class CampaignDetails : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            Campaign campaign = this.CampaignService.GetCampaignById(this.CampaignId);
            //if (campaign != null)
            //{
            //    this.pnlSendCampaign.Visible = true;
            //    StringBuilder allowedTokensString = new StringBuilder();
            //    string[] allowedTokens = this.MessageService.GetListOfCampaignAllowedTokens();
            //    for (int i = 0; i < allowedTokens.Length; i++)
            //    {
            //        string token = allowedTokens[i];
            //        allowedTokensString.Append(token);
            //        if (i != allowedTokens.Length - 1)
            //            allowedTokensString.Append(", ");
            //    }
            //    this.lblAllowedTokens.Text = allowedTokensString.ToString();

            //    this.txtName.Text = campaign.Name;
            //    this.txtSubject.Text = campaign.Subject;
            //    this.txtBody.Value = campaign.Body;

            //    this.pnlCreatedOn.Visible = true;
            //    this.lblCreatedOn.Text = DateTimeHelper.ConvertToUserTime(campaign.CreatedOn, DateTimeKind.Utc).ToString();
            //}
            //else
            //{
            //    this.pnlSendCampaign.Visible = false;

            //    this.pnlCreatedOn.Visible = false;
            //}
        }
        public int CampaignId
        {
            get
            {
                return CommonHelper.QueryStringInt("CampaignId");
            }
        }
    }
}