using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using IMCustSys.BLL;
//using IMCustSys.Model;
//using IMCustSys.Common;

namespace IMCustSys
{
    public partial class KLAuditList : System.Web.UI.Page
    {
      //  KL_Contents bllKL_Contents = new KL_Contents();

        protected void Page_Load(object sender, EventArgs e)
        {
        //    BLL.sys_admin.PageRole("KLAudit@default");

            if (!Page.IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            // 模块列表
         //   sgvKLContentList.DataSource = bllKL_Contents.GetNoAudit();
         //   sgvKLContentList.DataBind();
        }
    }
}