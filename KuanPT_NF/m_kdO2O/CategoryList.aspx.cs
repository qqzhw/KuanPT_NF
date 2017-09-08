using IMCustSys.Common;
using IMCustSys.Model;
using IMCustSys.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class CategoryList :BaseKptPage
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected List<Category> GetAllCategorys()
        {
            var comId = "0000100001";// BLL.sys_admin.GetUserComid();
            string categoryName = txtCategoryName.Text.Trim();
            var items = CategoryService.GetAllCategories(comId, categoryName).ToList();
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
            var items = GetAllCategorys();
            this.sgvCpList.DataSource = items;
            this.sgvCpList.DataBind();
        }
        protected string GetCategoryFullName(Category category)
        {
            string result = string.Empty;

            while (category != null && !category.Deleted)
            {
                if (String.IsNullOrEmpty(result))
                {
                    result = category.CategoryName;
                }
                else
                {
                    result = category.CategoryName + " >> " + result;
                }
                category = CategoryService.GetCategoryById(category.ParentCategoryId);
            }
            return result;
        }
        protected string GetParentCategoryName(object ParentCategoryId)
        {
            var parentId = Convert.ToInt32(ParentCategoryId);
            var category = CategoryService.GetCategoryById(parentId);
            if (category!=null)
            {
                return category.CategoryName;
            }
            return string.Empty;
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
                    //string fileName = string.Format("产品分类_{0}_{1}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), CommonHelper.GenerateRandomDigitCode(4));
                    //string filePath = string.Format("{0}Files\\{1}", HttpContext.Current.Request.PhysicalApplicationPath, fileName);
                    //var channels = GetChannels();
                    //var bytes = ExportManager.ExportChannelToXlsx(channels);
                    //File.WriteAllBytes(filePath, bytes);
                    //CommonHelper.WriteResponseXls(filePath, fileName);

                }
                catch (Exception exc)
                {
                    //if (!(exc is ThreadAbortException))
                    //    ShowMessage("导出数据失败!");
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
            int categoryId = int.Parse(((Literal)row.FindControl("ltlCategoryId")).Text);
            var category = CategoryService.GetCategoryById(categoryId);
            category.CategoryName = ((SimpleTextBox)row.FindControl("txtCategoryName")).Text;
            category.Published = ((CheckBox)row.FindControl("chkPublished")).Checked;
            //user_DeptInfo.Level= int.Parse(((HiddenField)row.FindControl("hLevel")).Value);
            //if(user_DeptInfo.Level==0)
            //    user_DeptInfo.DeptType = 1;
            //else
            //{
            //    System.Data.DataTable dt = bllUser_Dept.GetByID(user_DeptInfo.Level);
            //    int dtype = int.Parse(dt.Rows[0]["deptType"].ToString());
            //    user_DeptInfo.DeptType = dtype + 1;
            //} 
           CategoryService.UpdateCategory(category);
            Response.Redirect("CategoryList.aspx");
        }

        protected void sgvCpList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int categoryId = 0;

            switch (e.CommandName)
            {
                case "DeleteItem":  // 删除
                    categoryId = int.Parse(e.CommandArgument.ToString());
                    var category = CategoryService.GetCategoryById(categoryId);
                    // CategoryService.MarkCategoryAsDeleted(categoryId);
                    CategoryService.DeleteCategory(category);
                    Response.Redirect("CategoryList.aspx");
                    break;
                default:
                    break;
            }
            
        }
    }
}