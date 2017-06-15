using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class OrderAdd : BaseKptPage
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
            //绑定所有未下架的产品
            ddlShops.DataTextField = "ShopName";
            ddlShops.DataValueField = "ShopId";   
            ddlShops.DataSource = ShopService.GetAllProducts(1);
            ddlShops.DataBind();
            ddlShops.Items.Insert(0, new ListItem("无", "0")); 
        } 
        public string ShopPrice { get; set; }
      
        protected void  btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}