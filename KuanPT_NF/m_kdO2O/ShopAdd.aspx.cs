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
    public partial class ShopAdd : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var imgPath = string.Empty;
                string bigImgPath = string.Empty;
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
                HttpPostedFile bigPicture = uploadBigImg.PostedFile;

                if ((bigPicture != null) && (!String.IsNullOrEmpty(bigPicture.FileName)))
                {
                    byte[] pictureBinary = bigPicture.GetPictureBits();

                    bigImgPath = this.PictureService.UploadPicture(pictureBinary, bigPicture.ContentType);
                    if (string.IsNullOrEmpty(bigImgPath))
                    {
                        ShowMessage("首页推荐图上传失败!");
                        return;
                    }
                }
                var shop = new Shop();
                shop.BmId = 1;
                shop.ComId = "test";
                shop.CreateUserId = 1;
                
                shop.Commission = txtCommission.Value;
                shop.Price = txtPrice.Value;
                shop.Img = imgPath;
                shop.BigImg = bigImgPath;
                shop.ShortDescription = txtShortDesc.Text;
                shop.Description = Server.HtmlEncode(ttContent1.Value);
                shop.Remark = Server.HtmlEncode(ttContent2.Value);
                shop.DisplayOrder = txtDisplayOrder.Value;
                shop.ShopName = txtShopName.Text;
                shop.ShopType = txtShopType.Text;
                shop.State = Convert.ToInt32(chkPublished.Checked);
                shop.CreateDate = DateTime.Now;
                shop.LastDate = DateTime.Now;
                shop.ShowOnHomePage = chkHomepage.Checked;
                ShopService.InsertProduct(shop);
                Response.Redirect("ShopList.aspx");
            }
        }
    }
}