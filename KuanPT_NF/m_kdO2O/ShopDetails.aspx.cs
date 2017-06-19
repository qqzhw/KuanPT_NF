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
            CurrentShop = shop;
            imgShop.ImageUrl = CommonHelper.GetStoreLocation() + shop.Img;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
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
            ShopService.UpdateProduct(CurrentShop);
            Response.Redirect("ShopList.aspx");
        }

        protected void btnUploadImg_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemoveIng_Click(object sender, EventArgs e)
        {

        }
    }
}