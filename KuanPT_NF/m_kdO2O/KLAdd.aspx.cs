using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data; 
//using IMCustSys.BLL;
//using IMCustSys.Model;
//using IMCustSys.Common;

namespace KuanPT_NF
{
    public partial class KLAdd : System.Web.UI.Page
    {
      //  KL_Contents bllKL_Contents = new KL_Contents();

        protected void Page_Load(object sender, EventArgs e)
        {
            //BLL.sys_admin.PageRole("KL@default");

            //if (!Page.IsPostBack)
            //{
            //    init();
            //}
        }

        private void init()
        {
            // 角色下拉
            //ddlClass.DataSource = new KL_Classes().GetAll();
            //ddlClass.DataTextField = "ClassName";
            //ddlClass.DataValueField = "ClassID";
            //ddlClass.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (tbTitle.Text != "" &&
            //        ttContent1.Value != "" &&
            //        ttContent2.Value != "")
            //{
            //    KL_ContentsInfo kL_ContentsInfo = new KL_ContentsInfo();
            //    kL_ContentsInfo.UserId = User_Users.GetUserID();
            //    kL_ContentsInfo.ClassId = int.Parse(ddlClass.SelectedValue);
            //    kL_ContentsInfo.Title = tbTitle.Text;
            //    kL_ContentsInfo.ProductType = tbProductType.Text;
            //    kL_ContentsInfo.SysVer = tbSysVer.Text;
            //    kL_ContentsInfo.KeyWords = tbKeyWords.Text;
            //    kL_ContentsInfo.Content = ttContent1.Value;
            //    kL_ContentsInfo.Solution = ttContent2.Value;
            //    kL_ContentsInfo.Remark = tbRemark.Text;

            //    if (bllKL_Contents.Add(kL_ContentsInfo))
            //    {
            //        MessageBox.Show("提交成功！", MessageBoxAction.Redirect, "KLManage.aspx");
            //        Response.End();
            //    }
            //    else
            //    {
            //        MessageBox.Show("提交失败！", MessageBoxAction.Redirect, "KLManage.aspx");
            //        Response.End();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("提交失败！", MessageBoxAction.Redirect, "KLManage.aspx");
            //    Response.End();
            //}
        }
    }
}