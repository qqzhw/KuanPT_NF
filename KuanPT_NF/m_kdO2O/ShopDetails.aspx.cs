using Common;
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
            txtShopType.Text = shop.ShopType;
            txtShopName.Text = shop.ShopName;
            txtPrice.Value =Convert.ToInt32(shop.Price.ToString());
            txtCommission.Value = Convert.ToInt32(shop.Commission.ToString());
            txtDisplayOrder.Value = shop.DisplayOrder;
            txtShortDesc.Text = shop.ShortDescription;
            chkHomepage.Checked = shop.ShowOnHomePage;
            chkHot.Checked = shop.IsHotShop;
            chkPublished.Checked=shop.State>0?true:false;
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}