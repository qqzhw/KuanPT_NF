using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class CategoryDetails : BaseKptPage
    {
        public int CategoryId
        {
            get
            {
                return CommonHelper.QueryStringInt("CategoryId");
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
            var category = CategoryService.GetCategoryById(CategoryId);
            if (category != null)
            {
                txtName.Text = category.CategoryName; 
                txtDisplayOrder.Value = category.DisplayOrder;
                txtDesc.Text = category.Description;
                chkHomePage.Checked = category.ShowOnHomePage;
                chkPublished.Checked = category.Published;
                ParentCategory.SelectedCategoryId = category.ParentCategoryId;
               
                ParentCategory.BindData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var category = this.CategoryService.GetCategoryById(this.CategoryId);

                if (category != null)
                { 
                    category.CategoryName = txtName.Text.Trim();
                    category.Description = txtDesc.Text; 
                    category.ParentCategoryId = ParentCategory.SelectedCategoryId; 
                    category.ShowOnHomePage = chkHomePage.Checked;
                    category.Published = chkPublished.Checked;
                    category.DisplayOrder = txtDisplayOrder.Value; 

                    this.CategoryService.UpdateCategory(category);
                }
                Response.Redirect("CategoryList.aspx");
            }
        }
    }
}