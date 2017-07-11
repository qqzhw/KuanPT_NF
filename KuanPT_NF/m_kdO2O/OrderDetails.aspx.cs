using IMCustSys.BLL;
using IMCustSys.BLL.Services;
using IMCustSys.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class OrderDetails : BaseKptPage
    {
        public int OrderId
        {
            get {
                return CommonHelper.QueryStringInt("OrderId");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Page.IsPostBack)
            {
                BindData(); 
            }
        }
        private void FillDropDowns(int orderenum=0,int paymentenum=0)
        {
            //订单状态
            this.ddlOrderStatus.Items.Clear(); 
        
            OrderStatusEnum[] orderStatuses = (OrderStatusEnum[])Enum.GetValues(typeof(OrderStatusEnum));
            foreach (OrderStatusEnum orderStatus in orderStatuses)
            {
                ListItem item2 = new ListItem(orderStatus.GetOrderStatusName(), ((int)orderStatus).ToString());
                this.ddlOrderStatus.Items.Add(item2);
            }
            this.ddlOrderStatus.SelectedValue = orderenum.ToString();
            //付款状态
            this.ddlPaymentStatus.Items.Clear(); 
         
            PaymentStatusEnum[] paymentStatuses = (PaymentStatusEnum[])Enum.GetValues(typeof(PaymentStatusEnum));
            foreach (PaymentStatusEnum paymentStatus in paymentStatuses)
            {
                ListItem item2 = new ListItem(paymentStatus.GetPaymentStatusName(), ((int)paymentStatus).ToString());
                this.ddlPaymentStatus.Items.Add(item2);
            }
            ddlPaymentStatus.SelectedValue = paymentenum.ToString();
        }

        private void BindData()
        {
            var order = OrderService.GetOrderById(OrderId);
            if (order!=null)
            {
                txtAliAccount.Text = order.AliAccount;
                txtCommission.Value =Convert.ToInt32(order.Commission);
                txtCustomerAddress.Text = order.CustomerAddress;
                txtCustomerID.Text = order.IdCard;
                txtCustomerName.Text = order.CustomerName;
                txtCustomerTel.Text = order.CustomerTel;
                txtDesc.Text = order.Remark;
                FillDropDowns(order.OrderState,order.PaymentStatus);

                //绑定订购的产品
                ddlShops.DataTextField = "ShopName";
                ddlShops.DataValueField = "ShopId";
                ddlShops.DataSource = ShopService.GetAllProducts(showHidden:1);
                ddlShops.DataBind();
                ddlShops.SelectedValue=order.ShopId.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var productId = Convert.ToInt32(ddlShops.SelectedValue);
            var shop = ShopService.GetProductById(productId);

            var order = OrderService.GetOrderById(OrderId); 
           
            order.Commission = shop.Commission;
            order.AliAccount = txtAliAccount.Text; 
            order.CustomerAddress = txtCustomerAddress.Text;
            order.CustomerName = txtCustomerName.Text;
            order.CustomerTel = txtCustomerTel.Text;
            order.IdCard = txtCustomerID.Text;
            order.Remark = txtDesc.Text;
            order.Img = shop.Img; 
            order.OrderState = Convert.ToInt32(ddlOrderStatus.SelectedValue);
            order.PaymentStatus = Convert.ToInt32(ddlPaymentStatus.SelectedValue);
            order.Price = shop.Price; 
            order.ShopId = shop.ShopId;
            order.ShopName = shop.ShopName;
            order.ShopType = shop.ShopType;
            order.PayPrice = Convert.ToDouble(txtPayPrice.Value);
            if (order.PayPrice>0)
            {
                order.PayTime = DateTime.Now;
                order.PaymentDate = DateTime.Now.Date;
            }
            order.PayCommission = txtPayComission.Value;
            order.UserId = 1;
            order.PayType = txtPayType.Text; 
            OrderService.UpdateOrder(order);
            Response.Redirect("OrderList.aspx");
        }
    }
}