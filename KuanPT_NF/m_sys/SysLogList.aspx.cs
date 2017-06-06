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
    public partial class SysLogList : System.Web.UI.Page
    {
        //Sys_Log bllSys_Log = new Sys_Log();

        protected void Page_Load(object sender, EventArgs e)
        {
          //  BLL.sys_admin.PageRole(",20,");

            if (!Page.IsPostBack)
            {
                init();
                bindData();
            }
        }

        private void init()
        {
            tbDateS.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void bindData()
        {
            string logger = tbLogger.Text;
            string message = tbMessage.Text;

            DateTime dateStart = new DateTime();
            DateTime dateEnd = new DateTime();
            if (tbDateS.Text != "")
            {
                dateStart = Convert.ToDateTime(tbDateS.Text);
            }
            if (tbDateE.Text != "")
            {
                dateEnd = Convert.ToDateTime(tbDateE.Text);
            }

         //   sgvLogList.DataSource = bllSys_Log.GetList(dateStart, dateEnd, logger, message);
         //   sgvLogList.DataBind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            bindData();
        }

        protected void sgv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ((GridView)sender).PageIndex = e.NewPageIndex;
            bindData();
        }

}
}