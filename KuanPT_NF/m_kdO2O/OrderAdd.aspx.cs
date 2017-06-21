using Model;
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
            var productId = Convert.ToInt32(ddlShops.SelectedValue);
            var shop = ShopService.GetProductById(productId);
            if (shop == null)
                return; 
            var order = new Order();
            order.BmId = 1;
            order.ComId = "test";
            order.Commission = shop.Commission;
            order.AliAccount = txtAliAccount.Text;
            order.CreateDate = DateTime.Now;
            order.CreateUserId = 1;
            order.CustomerAddress = txtCustomerAddress.Text;
            order.CustomerName = txtCustomerName.Text;
            order.CustomerTel = txtCustomerTel.Text;
            order.IdCard = txtCustomerID.Text;
            order.Remark = txtDesc.Text;
            order.Img = shop.Img;
            order.OrderNo = "KD" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            order.OrderState = 0;
            order.PaymentStatus = 0;
            order.Price = shop.Price;
            order.RealName = "张三";
            order.ShopId = shop.ShopId;
            order.ShopName = shop.ShopName;
            order.ShopType = shop.ShopType;
            order.UserId = 1;
            order.PayType = txtPayType.Text;
            order.UserName = "admin";
            order.UserPhone = "10086";
            OrderService.InsertOrder(order);
            Response.Redirect("OrderList.aspx");
        }
    }
}