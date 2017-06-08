using BLL;
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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            HttpPostedFile pictureFile = uploadImg.PostedFile;
            if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
            {
                byte[] categoryPictureBinary = pictureFile.GetPictureBits();
                
                   var categoryPicture = this.PictureService.InsertPicture(categoryPictureBinary, pictureFile.ContentType, true);
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
    }
}