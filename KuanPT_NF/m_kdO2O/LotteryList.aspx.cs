using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class LotteryList : BaseKptPage
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                BindData();
            }
        } 
        protected List<Lottery> GetLotterys()
        {
            var comId = BLL.sys_admin.GetUserComid();
            string lotteryName = txtName.Text.Trim();

            var lotteryItems = this.LotteryService.GetAllLotterys(comId,lotteryName).ToList();
            return lotteryItems;
        }
        protected void SgvCpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            sgvCpList.PageIndex = e.NewPageIndex;
            BindData(); //重新绑定GridView数据的函数 
        }

        private void BindData()
        { 
            var items = GetLotterys();
            this.sgvCpList.DataSource = items;
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
                    //string fileName = string.Format("订单_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    //string filePath = string.Format("{0}Files\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                    //var orders = GetOrders();
                    //var bytes = ExportManager.ExportOrdersToXlsx(orders);
                    //var folder = HttpContext.Current.Request.PhysicalApplicationPath + "Files";
                    //if (!Directory.Exists(folder))
                    //{
                    //    Directory.CreateDirectory(folder);
                    //}
                    //File.WriteAllBytes(filePath, bytes);
                    //CommonHelper.WriteResponseXls(filePath, fileName);
                    // Response.WriteFile(CommonHelper.GetStoreLocation() + "files/" + fileName);
                }
                catch (Exception exc)
                {
                    if (!(exc is ThreadAbortException))
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
            GridView gv = ((GridView)sender);

            GridViewRow row = gv.Rows[e.RowIndex];
          
        } 
    }
}