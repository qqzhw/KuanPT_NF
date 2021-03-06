﻿using IMCustSys.Common;
using IMCustSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMCustSys
{
    public partial class CategoryAdd : BaseKptPage
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
           // ParentCategory.SelectedCategoryId =0;
            ParentCategory.BindData();
        }

        public int ParentCategoryId
        {
            get
            {
                return CommonHelper.QueryStringInt("ParentCategoryId");
            }
        }

        public int CategoryId
        {
            get
            {
                return CommonHelper.QueryStringInt("CategoryId");
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var comId = "0000100001";//BLL.sys_admin.GetUserComid();
            var category = new Category()
            {
                CategoryName = txtName.Text,
                ParentCategoryId = ParentCategory.SelectedCategoryId,
                ShowOnHomePage=chkHomePage.Checked,
                Published=chkPublished.Checked,
                DisplayOrder=txtDisplayOrder.Value,
                Description=txtDesc.Text, 
                Deleted=false,
                CreatedDate=DateTime.Now, 
                BmId=1,
                ComId=comId
            };
            CategoryService.InsertCategory(category);
            Response.Redirect("CategoryList.aspx");
        }
    }
}