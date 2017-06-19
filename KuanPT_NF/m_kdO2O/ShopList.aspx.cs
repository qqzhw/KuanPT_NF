using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YYControls;
namespace KuanPT_NF.m_kdO2O
{
    public partial class ShopList : BaseKptPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
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
            //产品列表
            sgvCpList.DataSource = ShopService.GetAllProducts();
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
            }
        }

     
         
    }
}