using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace KuanPT_NF.m_kdO2O
{
    public partial class CampaignAdd : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            HttpPostedFile pictureFile = uploadImg.PostedFile; 
             
            if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
            {
                byte[] categoryPictureBinary = pictureFile.GetPictureBits();
                
                   var categoryPicture = this.PictureService.UploadPicture(categoryPictureBinary, pictureFile.ContentType);
            }
        }

       
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var imgPath = string.Empty;
                HttpPostedFile pictureFile = uploadImg.PostedFile;

                if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
                {
                    byte[] pictureBinary = pictureFile.GetPictureBits();

                    imgPath = this.PictureService.UploadPicture(pictureBinary, pictureFile.ContentType);
                    if (string.IsNullOrEmpty(imgPath))
                    {
                        ShowMessage("图片上传失败!");
                        return;
                    }
                }

                Campaign campaign = new Campaign();
                campaign.BmId = 1;
                campaign.ComId = "kpt";
                campaign.CampaignName = tbName.Text;
                campaign.CreatedDate = DateTime.Now;
                campaign.DisplayOrder = txtDisplayOrder.Value;
                campaign.ImgPath = imgPath;
                campaign.IsHomeBanner = chkBanner.Checked;
                campaign.Published = chkPublished.Checked;
                campaign.Subject = txtSubject.Text;
                campaign.Body = ttContent1.Value;
                CampaignService.InsertCampaign(campaign);
                Response.Redirect("CampaignList.aspx");
            }
        }
    }
}