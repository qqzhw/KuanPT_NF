using IMCustSys.BLL.Infrastructure;
using IMCustSys.BLL.Services;
using IMCustSys.Model;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMCustSys.BLL;
 
namespace IMCustSys.Modules
{
    public partial class SelectCategoryControl : UserControl
    {
        private int selectedCategoryId;

        public void BindData()
        {
            ddlCategories.Items.Clear();
            ddlCategories.Items.Add(new ListItem("нч", "0"));
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var categories =categoryService.GetAllCategories();
            foreach (var category in categories)
            {
                string catName = GetCategoryFullName(category);
                ListItem item = new ListItem(catName, category.CategoryId.ToString());
                this.ddlCategories.Items.Add(item);

                if (category.CategoryId == this.selectedCategoryId)
                    item.Selected = true;
            }

            this.ddlCategories.DataBind();
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
                    result = "--" + result;
                }
                category = category.GetParentCategory(category.ParentCategoryId);
            }
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
        
        public string CssClass
        {
            get
            {
                return ddlCategories.CssClass;
            }
            set
            {
                ddlCategories.CssClass = value;
            }
        }

        public int SelectedCategoryId
        {
            get
            {
                return int.Parse(this.ddlCategories.SelectedItem.Value);
            }
            set
            {
                this.selectedCategoryId = value;
            }
        }
        
        public string EmptyItemText
        {
            get
            {
                if (ViewState["EmptyItemText"] == null)
                    return "[ --- ]";
                else
                    return (string)ViewState["EmptyItemText"];
            }
            set { ViewState["EmptyItemText"] = value; }
        }
    }
}