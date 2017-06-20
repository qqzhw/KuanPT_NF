using BLL;
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
            if (campaign != null)
            {
                tbName.Text = campaign.CampaignName;
                txtDisplayOrder.Value = campaign.DisplayOrder;
                img.ImageUrl = CommonHelper.GetStoreLocation() + "\\" + campaign.ImgPath;
                chkBanner.Checked = campaign.IsHomeBanner;
                chkPublished.Checked = campaign.Published;
                txtSubject.Text = campaign.Subject;
                ttContent1.Value = campaign.Body;
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
                var imgPath = string.Empty;
                HttpPostedFile pictureFile = uploadImg.PostedFile;

                if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
                {
                    byte[] pictureBinary = pictureFile.GetPictureBits();

                    imgPath = this.PictureService.UploadPicture(pictureBinary, pictureFile.ContentType);
                    //if (string.IsNullOrEmpty(imgPath))
                    //{
                    //    ShowMessage("图片上传失败!");
                    //    return;
                    //}
                }
                campaign.CampaignName = tbName.Text;
                
                campaign.DisplayOrder = txtDisplayOrder.Value;
                if (!string.IsNullOrEmpty(imgPath))
                {
                    campaign.ImgPath = imgPath;//更新图片地址
                } 
                campaign.IsHomeBanner = chkBanner.Checked;
                campaign.Published = chkPublished.Checked;
                campaign.Subject = txtSubject.Text;
                campaign.Body = ttContent1.Value;
                CampaignService.UpdateCampaign(campaign);
                Response.Redirect("CampaignList.aspx");
            }
        }
    }
}