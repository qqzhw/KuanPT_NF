using IMCustSys.BLL;
using IMCustSys.Common;
using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
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
            hiddenImgPath.Value = shop.Img;
            HiddenBigImg.Value = shop.BigImg;
            imgShop.ImageUrl = CommonHelper.GetStoreLocation() + shop.Img;
            imgBigPicture.ImageUrl= CommonHelper.GetStoreLocation() + shop.BigImg;
            if (!string.IsNullOrEmpty(hiddenImgPath.Value))
            {
                btnRemoveImg.Visible = true;
            }
            if (!string.IsNullOrEmpty(HiddenBigImg.Value))
            {
                btnRemoveBigImg.Visible = true;
            }
            //绑定分类
            var category = CategoryService.GetCategoryById(shop.CategoryId);
            if (category != null)
            {
                ShopCategory.SelectedCategoryId = category.CategoryId;

                ShopCategory.BindData();
            }
            else
            {
                ShopCategory.BindData();
            }
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
            CurrentShop.CategoryId = ShopCategory.SelectedCategoryId;
            HttpPostedFile pictureFile = uploadImg.PostedFile;

            if ((pictureFile != null) && (!String.IsNullOrEmpty(pictureFile.FileName)))
            {
                byte[] pictureBinary = pictureFile.GetPictureBits();

                hiddenImgPath.Value = this.PictureService.UploadPicture(pictureBinary, pictureFile.ContentType);
                if (string.IsNullOrEmpty(hiddenImgPath.Value))
                {
                    ShowMessage("图片上传失败!");
                    return;
                }
               
            }
            CurrentShop.Img = hiddenImgPath.Value;
            HttpPostedFile bigPicture = uploadBigImg.PostedFile;

            if ((bigPicture != null) && (!String.IsNullOrEmpty(bigPicture.FileName)))
            {
                byte[] pictureBinary = bigPicture.GetPictureBits();

                HiddenBigImg.Value = this.PictureService.UploadPicture(pictureBinary, bigPicture.ContentType);
                if (string.IsNullOrEmpty(HiddenBigImg.Value))
                {
                    ShowMessage("首页推荐图上传失败!");
                    return;
                } 
            }
            CurrentShop.BigImg = HiddenBigImg.Value; 
            ShopService.UpdateProduct(CurrentShop);
            Response.Redirect("ShopList.aspx");
        } 
     
        protected void btnRemoveBigImg_Click(object sender, EventArgs e)
        {
            if (PictureService.DeletePicture(HiddenBigImg.Value))
            {
                imgBigPicture.ImageUrl = string.Empty;
                HiddenBigImg.Value = string.Empty;
            }
        }

        protected void btnRemoveImg_Click(object sender, EventArgs e)
        {
            //删除图片成功就更新
            if (PictureService.DeletePicture(hiddenImgPath.Value))
            {
                //var currentShop = ShopService.GetProductById(ShopId);
                //if (currentShop == null)
                //    return;
                //currentShop.Img = string.Empty;
                //ShopService.UpdateProduct(currentShop);
                hiddenImgPath.Value = string.Empty;
                imgShop.ImageUrl = string.Empty;
            }   
        }
    }
}