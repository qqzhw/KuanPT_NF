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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpPostedFile pictureFile = uploadImg.PostedFile; 
             
            if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
            {
                byte[] categoryPictureBinary = pictureFile.GetPictureBits();
                
                   var categoryPicture = this.PictureService.UploadPicture(categoryPictureBinary, pictureFile.ContentType);
            }
            int categoryPictureId = 0;
            //if (categoryPicture != null)
            //    categoryPictureId = categoryPicture.PictureId;

            //category.Name = txtName.Text.Trim();
            //category.Description = txtDescription.Value;
            //category.TemplateId = int.Parse(this.ddlTemplate.SelectedItem.Value);
            //category.ParentCategoryId = ParentCategory.SelectedCategoryId;
            //category.PictureId = categoryPictureId;
            //category.PriceRanges = txtPriceRanges.Text;
            //category.ShowOnHomePage = cbShowOnHomePage.Checked;
            //category.Published = cbPublished.Checked;
            //category.DisplayOrder = txtDisplayOrder.Value;
            //category.UpdatedOn = DateTime.UtcNow;
        }

       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            HttpPostedFile pictureFile = uploadImg.PostedFile;

            if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
            {
                byte[] categoryPictureBinary = pictureFile.GetPictureBits();

                var imgPath = "";// this.PictureService.UploadPicture(categoryPictureBinary, pictureFile.ContentType);
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
            
        }
    }
}