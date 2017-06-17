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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // if (tbDeptName.Text != "")
            {
                //    User_DeptInfo user_DeptInfo = new User_DeptInfo();
                //    User_DeptInfo user_DeptInfop = new User_DeptInfo();
                //    user_DeptInfo.DeptName = tbDeptName.Text;
                //    int parentID = int.Parse(ddlDeptTop.SelectedValue);
                //    user_DeptInfo.Level = parentID;
                //    if (parentID == 0)
                //        user_DeptInfo.DeptType = 1;
                //    else
                //    {
                //        System.Data.DataTable dt = bllUser_Dept.GetByID(parentID);
                //        int dtype = int.Parse(dt.Rows[0]["deptType"].ToString());
                //        user_DeptInfo.DeptType = dtype + 1;
                //    }
                //    user_DeptInfo.ComId = BLL.sys_admin.GetUserComid();

                //    if (user_DeptInfo.DeptName.Length > 30)
                //    {
                //        MessageBox.Show("部门名称应小于30字", MessageBoxAction.Redirect, "DeptManage.aspx");
                //        Response.End();
                //    }

                //    if (bllUser_Dept.CheckDept(user_DeptInfo.DeptName))
                //    {
                //        MessageBox.Show("部门名称已存在，请检查！", MessageBoxAction.Redirect, "DeptManage.aspx");
                //        Response.End();
                //    }

                //    if (bllUser_Dept.Add(user_DeptInfo))
                //    {
                //        MessageBox.Show("提交成功！", MessageBoxAction.Redirect, "DeptManage.aspx");
                //        Response.End();
                //    }
                //    else
                //    {
                //        MessageBox.Show("提交失败！", MessageBoxAction.Redirect, "DeptManage.aspx");
                //        Response.End();
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("请填写后提交！", MessageBoxAction.Redirect, "DeptManage.aspx");
                //    Response.End();
            }
        }
         

        protected void sgv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // int deptID = 0;

            //switch (e.CommandName)
            //{
            //    case "DeleteItem":  // 删除
            //        deptID = int.Parse(e.CommandArgument.ToString());
            //        System.Data.DataTable dt = bllUser_Dept.GetByID(deptID);
            //        if(dt.Rows.Count>0)
            //        {
            //            if(dt.Rows[0]["level"].ToString()=="0")
            //                lblMessage.Text = string.Format("顶级部门不能删除");
            //        }
            //        if (bllUser_Dept.CheckLevel(deptID))
            //        {
            //            lblMessage.Text = string.Format("有下级单位，不能删除");
            //        }
            //        else if (bllUser_Dept.Delete(deptID))
            //        {
            //            lblMessage.Text = string.Format("[ID：{0}]项目已被删除！", deptID);
            //            bindData();
            //        }
            //        else
            //        {
            //            lblMessage.Text = "删除失败！";
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }

     
         
    }
}