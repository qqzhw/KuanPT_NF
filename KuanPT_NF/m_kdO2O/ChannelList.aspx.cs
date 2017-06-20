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
    public partial class ChannelList : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
         
        protected List<Channel> GetChannels()
        { 
            string channelName = txtChannelName.Text.Trim(); 
            var items =ChannelService.GetAllChannels(channelName).ToList();
            return items;
        }
        protected void SgvCpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            sgvCpList.PageIndex = e.NewPageIndex;
            BindData(); //重新绑定GridView数据的函数 
        }

        private void BindData()
        {
            //订单列表 
            var orders = GetChannels();
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
                    string fileName = string.Format("渠道_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    string filePath = string.Format("{0}Files\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                    var channels = GetChannels();
                    var bytes = ExportManager.ExportChannelToXlsx(channels); 
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


    }
}