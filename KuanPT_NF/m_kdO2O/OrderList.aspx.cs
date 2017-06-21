using BLL;
using BLL.Services;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Activities;

namespace KuanPT_NF.m_kdO2O
{
    public partial class OrderList : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillDropDowns();
                SetDefaultValues();
                BindData();
            }
        }

        private void FillDropDowns()
        {
            //订单状态
            this.ddlOrderStatus.Items.Clear();
            ListItem itemOrderStatus = new ListItem("全部", "-1");
            this.ddlOrderStatus.Items.Add(itemOrderStatus);
            OrderStatusEnum[] orderStatuses = (OrderStatusEnum[])Enum.GetValues(typeof(OrderStatusEnum));
            foreach (OrderStatusEnum orderStatus in orderStatuses)
            {
                ListItem item2 = new ListItem(orderStatus.GetOrderStatusName(), ((int)orderStatus).ToString());
                this.ddlOrderStatus.Items.Add(item2);
            }

            //付款状态
            this.ddlPaymentStatus.Items.Clear();
            ListItem itemPaymentStatus = new ListItem("全部", "-1");
            this.ddlPaymentStatus.Items.Add(itemPaymentStatus);
            PaymentStatusEnum[] paymentStatuses = (PaymentStatusEnum[])Enum.GetValues(typeof(PaymentStatusEnum));
            foreach (PaymentStatusEnum paymentStatus in paymentStatuses)
            {
                ListItem item2 = new ListItem(paymentStatus.GetPaymentStatusName(), ((int)paymentStatus).ToString());
                this.ddlPaymentStatus.Items.Add(item2);
            } 
        }

        private void SetDefaultValues()
        {
           
        }
        protected List<Order> GetOrders()
        {
            DateTime? startDate = ctrlStartDatePicker.SelectedDate;
            DateTime? endDate = ctrlEndDatePicker.SelectedDate;
            if (startDate.HasValue)
            {
                startDate =startDate.Value;
            }
            if (endDate.HasValue)
            {
                endDate = endDate.Value.AddDays(1);
            }

            OrderStatusEnum? orderStatus = null;
            int orderStatusId = int.Parse(ddlOrderStatus.SelectedItem.Value);
            if (orderStatusId > -1)
                orderStatus = (OrderStatusEnum)Enum.ToObject(typeof(OrderStatusEnum), orderStatusId);

            PaymentStatusEnum? paymentStatus = null;
            int paymentStatusId = int.Parse(ddlPaymentStatus.SelectedItem.Value);
            if (paymentStatusId > -1)
                paymentStatus = (PaymentStatusEnum)Enum.ToObject(typeof(PaymentStatusEnum), paymentStatusId); 
           
            string customerTel = txtCustomerTel.Text.Trim();

            var orders = this.OrderService.SearchOrders(startDate, endDate,
                orderStatus, paymentStatus, customerTel);
            return orders;
        }
        protected void SgvCpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            sgvCpList.PageIndex = e.NewPageIndex;
            BindData(); //重新绑定GridView数据的函数 
        }

        private void BindData()
        {
            //订单列表 
            var orders = GetOrders(); 
            this.sgvCpList.DataSource = orders;
            this.sgvCpList.DataBind();
        }
      
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            { 
               BindData(); 
            }
        }

        protected void btnExportXLS_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string fileName = string.Format("订单_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Files\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                    var orders = GetOrders(); 
                    var bytes = ExportManager.ExportOrdersToXlsx(orders);
                    var folder= HttpContext.Current.Request.PhysicalApplicationPath + "Files";
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    File.WriteAllBytes(filePath,bytes);  
                    CommonHelper.WriteResponseXls(filePath, fileName); 
                   // Response.WriteFile(CommonHelper.GetStoreLocation() + "files/" + fileName);
                }
                catch (Exception exc)
                {
                    if(!(exc is  ThreadAbortException))
                      ShowMessage("导出Excel失败!");
                } 
            }
        }
        protected void sgv_Cancel(object sender, GridViewCancelEditEventArgs e)
        {
            ((GridView)sender).EditIndex = -1;
            BindData();
        } 
        protected void sgv_Edit(object sender, GridViewEditEventArgs e)
        {
            ((GridView)sender).EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void sgv_Update(object sender, GridViewUpdateEventArgs e)
        {
            //User_DeptInfo user_DeptInfo = new User_DeptInfo();

            GridView gv = ((GridView)sender);

            GridViewRow row = gv.Rows[e.RowIndex];
            //user_DeptInfo.DeptId = int.Parse(((Literal)row.FindControl("ltlDeptId")).Text);
            //user_DeptInfo.DeptName = ((TextBox)row.FindControl("tbDeptName")).Text;
            //user_DeptInfo.Level= int.Parse(((HiddenField)row.FindControl("hLevel")).Value);
            //if(user_DeptInfo.Level==0)
            //    user_DeptInfo.DeptType = 1;
            //else
            //{
            //    System.Data.DataTable dt = bllUser_Dept.GetByID(user_DeptInfo.Level);
            //    int dtype = int.Parse(dt.Rows[0]["deptType"].ToString());
            //    user_DeptInfo.DeptType = dtype + 1;
            //}

            //if (user_DeptInfo.DeptName.Length > 30)
            //{
            //    MessageBox.Show("部门名称应小于30字", MessageBoxAction.Redirect, "DeptManage.aspx");
            //    Response.End();
            //}

            //if (bllUser_Dept.CheckDept(user_DeptInfo.DeptName))
            //{
            //    MessageBox.Show("部门名称已存在，请检查！", MessageBoxAction.Redirect, "DeptManage.aspx");
            //    Response.End();
            //}

            //if (user_DeptInfo.DeptName != "")
            //{
            //    lblMessage.Text = "修改" + (bllUser_Dept.Modify(user_DeptInfo) ? "成功" : "失败");
            //    gv.EditIndex = -1;
            //    bindData();
            //}
            //else
            //{
            //    MessageBox.Show("请填写后提交！", MessageBoxAction.Redirect, "DeptManage.aspx");
            //    Response.End();
            //}
        }
       
        public string GetOrderStatusName(object orderStatus)
        {
            int status = Convert.ToInt32(orderStatus);
            var name = ((OrderStatusEnum)status).GetOrderStatusName();
            return name;
        }
        public string GetPaymentStatusName(object paymentStatus)
        {
            int status = Convert.ToInt32(paymentStatus);
            var name = ((PaymentStatusEnum)status).GetPaymentStatusName();
            return name;
        }
    }
}