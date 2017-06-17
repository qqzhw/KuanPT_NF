using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class OrderDetails : BaseKptPage
    {
        public int OrderId
        {
            get {
                return CommonHelper.QueryStringInt("orderId");
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
            }
        }
    }
}