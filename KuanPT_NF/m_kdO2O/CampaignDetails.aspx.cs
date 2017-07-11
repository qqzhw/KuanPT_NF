using IMCustSys.BLL;
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
            if (campaign != null)
            {
                tbName.Text = campaign.CampaignName;
                txtDisplayOrder.Value = campaign.DisplayOrder;
                img.ImageUrl = CommonHelper.GetStoreLocation()+ campaign.ImgPath;
                chkBanner.Checked = campaign.IsHomeBanner;
                chkPublished.Checked = campaign.Published;
                txtSubject.Text = campaign.Subject;
                ttContent1.Value = campaign.Body;
                hiddenImg.Value = campaign.ImgPath;
                if (!string.IsNullOrEmpty(hiddenImg.Value))
                {
                    btnRemoveImg.Visible = true;
                }
            }
        }
        public int CampaignId
        {
            get
            {
                return CommonHelper.QueryStringInt("CampaignId");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Campaign campaign = this.CampaignService.GetCampaignById(this.CampaignId);
            if (campaign != null)
            { 
                HttpPostedFile pictureFile = uploadImg.PostedFile;

                if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
                {
                    byte[] pictureBinary = pictureFile.GetPictureBits();

                    hiddenImg.Value = this.PictureService.UploadPicture(pictureBinary, pictureFile.ContentType);
                }
                campaign.CampaignName = tbName.Text;
                
                campaign.DisplayOrder = txtDisplayOrder.Value;
               
                campaign.ImgPath = hiddenImg.Value;
                campaign.IsHomeBanner = chkBanner.Checked;
                campaign.Published = chkPublished.Checked;
                campaign.Subject = txtSubject.Text;
                campaign.Body = ttContent1.Value;
                CampaignService.UpdateCampaign(campaign);
                Response.Redirect("CampaignList.aspx");
            }
        }

        protected void btnRemoveImg_Click(object sender, EventArgs e)
        {
            if (PictureService.DeletePicture(hiddenImg.Value))
           {
                hiddenImg.Value = string.Empty;
                img.ImageUrl = "";
            }
        }
    }
}