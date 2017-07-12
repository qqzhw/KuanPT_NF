using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YYControls;
namespace IMCustSys
{
    public partial class ShopList : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShopCategory.BindData();
                BindData(); 
            }
        }

        protected void SgvCpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            sgvCpList.PageIndex = e.NewPageIndex;
            BindData(); //重新绑定GridView数据的函数 
        }

      

        private void BindData()
        {
            var comId = "0000100001";//BLL.sys_admin.GetUserComid(); 
            //产品列表
            string keyword = tbName.Text.Trim();
            sgvCpList.DataSource = ShopService.GetAllProducts(ShopCategory.SelectedCategoryId,comId, keyword,1);
            sgvCpList.DataBind(); 
        } 
        protected void sgv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             int shopID = 0;

            switch (e.CommandName)
            {
                case "DeleteItem":  // 删除
                    shopID = int.Parse(e.CommandArgument.ToString()); 
                    break;
                default:
                    break;
            }
            if (shopID>0)
            {
                //下架产品
                ShopService.MarkProductAsDeleted(shopID);
                BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}