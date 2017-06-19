using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class ShopDetails :BaseKptPage
    {
        public int ShopId
        {
            get
            {
                  return CommonHelper.QueryStringInt("ShopId");
            }
        }
        public Shop CurrentShop { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var shop = ShopService.GetProductById(ShopId);
            if (shop == null)
            {
                Response.Redirect("ShopList.aspx");
                return;
            }
            txtShopType.Text = shop.ShopType;
            txtShopName.Text = shop.ShopName;
            txtPrice.Value =Convert.ToInt32(shop.Price.ToString());
            txtCommission.Value = Convert.ToInt32(shop.Commission.ToString());
            txtDisplayOrder.Value = shop.DisplayOrder;
            txtShortDesc.Text = shop.ShortDescription;
            chkHomepage.Checked = shop.ShowOnHomePage;
            chkHot.Checked = shop.IsHotShop;
            chkPublished.Checked=shop.State>0?true:false;
            ttContent1.Value = shop.Description;
            ttContent2.Value = shop.Remark;
            
            imgShop.ImageUrl = CommonHelper.GetStoreLocation() + shop.Img;
            imgBigPicture.ImageUrl= CommonHelper.GetStoreLocation() + shop.BigImg;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CurrentShop= ShopService.GetProductById(ShopId);
            if (CurrentShop == null)
                return;
            CurrentShop.ShopType = txtShopType.Text;
            CurrentShop.ShopName = txtShopName.Text;
            CurrentShop.Price = txtPrice.Value;
            CurrentShop.Commission = txtCommission.Value;
            CurrentShop.DisplayOrder = txtDisplayOrder.Value;
            CurrentShop.ShortDescription = txtShortDesc.Text ;
            CurrentShop.ShowOnHomePage = chkHomepage.Checked;
            CurrentShop.IsHotShop = chkHot.Checked ;
            CurrentShop.State =Convert.ToInt32(chkPublished.Checked);
            CurrentShop.Description = ttContent1.Value ;
            CurrentShop.Remark = ttContent2.Value ;
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
                CurrentShop.Img = imgPath;
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
                CurrentShop.BigImg = bigImgPath; 
            }

            ShopService.UpdateProduct(CurrentShop);
            Response.Redirect("ShopList.aspx");
        }

        protected void btnUploadImg_Click(object sender, EventArgs e)
        {

        } 

        protected void btnRemoveBigImg_Click(object sender, EventArgs e)
        {
            var imgpath= imgShop.ImageUrl;
            if (File.Exists(imgpath))
                File.Delete(imgpath);
        }

        protected void btnRemoveImg_Click(object sender, EventArgs e)
        {
            var imgpath = imgBigPicture.ImageUrl;
            if (File.Exists(imgpath))
                File.Delete(imgpath);
        }
    }
}