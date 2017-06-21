using Common;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class ChannelDataList : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected List<ChannelData> GetAllChannelDatas()
        {
            DateTime? startDate = ctrlStartDatePicker.SelectedDate;
            DateTime? endDate = ctrlEndDatePicker.SelectedDate;
            string categoryName = txtChannelName.Text.Trim();
            var items = ChannelService.GetAllChannelDatas(categoryName, startDate, endDate).ToList();
            return items;
        }
        protected void SgvCpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            sgvCpList.PageIndex = e.NewPageIndex;
            BindData();
        }

        private void BindData()
        {
            //分类列表 
            var items = GetAllChannelDatas();
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
                    string fileName = string.Format("渠道统计_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Files\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                    var channels = GetAllChannelDatas();
                    var bytes = ExportManager.ExportChannelDataToXlsx(channels);
                    File.WriteAllBytes(filePath, bytes);
                    CommonHelper.WriteResponseXls(filePath, fileName);

                }
                catch (Exception exc)
                {
                    if (!(exc is ThreadAbortException))
                        ShowMessage("导出数据失败!");
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

        }

    }
}