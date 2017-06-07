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
    public partial class DeptManage : System.Web.UI.Page
    {
       // User_Dept bllUser_Dept = new User_Dept();

        protected void Page_Load(object sender, EventArgs e)
        {
          //  BLL.sys_admin.PageRole(",13,");

            if (!Page.IsPostBack)
            {
                init();
            }
        }

        private void init()
        {
            // 一级模块列表
            //ddlDeptTop.DataSource = bllUser_Dept.GetDeptTop();
            //ddlDeptTop.DataTextField = "DeptName";
            //ddlDeptTop.DataValueField = "DeptId";
            //ddlDeptTop.DataBind();
            //ddlDeptTop.Items.Insert(0, new ListItem("无", "0"));

            //bindData();
        }

        private void BindData()
        {
            // 模块列表
            //sgvDeptList.DataSource = bllUser_Dept.GetDeptList();
            //sgvDeptList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbDeptName.Text != "")
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

        protected void sgv_Cancel(object sender, GridViewCancelEditEventArgs e)
        {
            ((GridView)sender).EditIndex = -1;
            BindData();
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

        protected void sgv_Edit(object sender, GridViewEditEventArgs e)
        {
            ((GridView)sender).EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void sgv_Update(object sender, GridViewUpdateEventArgs e)
        {
            //User_DeptInfo user_DeptInfo = new User_DeptInfo();

            GridView gv = ((GridView)sender);

            GridViewRow row = gv.Rows[e.RowIndex];
            //user_DeptInfo.DeptId = int.Parse(((Literal)row.FindControl("ltlDeptId")).Text);
            //user_DeptInfo.DeptName = ((TextBox)row.FindControl("tbDeptName")).Text;
            //user_DeptInfo.Level= int.Parse(((HiddenField)row.FindControl("hLevel")).Value);
            //if(user_DeptInfo.Level==0)
            //    user_DeptInfo.DeptType = 1;
            //else
            //{
            //    System.Data.DataTable dt = bllUser_Dept.GetByID(user_DeptInfo.Level);
            //    int dtype = int.Parse(dt.Rows[0]["deptType"].ToString());
            //    user_DeptInfo.DeptType = dtype + 1;
            //}

            //if (user_DeptInfo.DeptName.Length > 30)
            //{
            //    MessageBox.Show("部门名称应小于30字", MessageBoxAction.Redirect, "DeptManage.aspx");
            //    Response.End();
            //}

            //if (bllUser_Dept.CheckDept(user_DeptInfo.DeptName))
            //{
            //    MessageBox.Show("部门名称已存在，请检查！", MessageBoxAction.Redirect, "DeptManage.aspx");
            //    Response.End();
            //}

            //if (user_DeptInfo.DeptName != "")
            //{
            //    lblMessage.Text = "修改" + (bllUser_Dept.Modify(user_DeptInfo) ? "成功" : "失败");
            //    gv.EditIndex = -1;
            //    bindData();
            //}
            //else
            //{
            //    MessageBox.Show("请填写后提交！", MessageBoxAction.Redirect, "DeptManage.aspx");
            //    Response.End();
            //}
        }
    }
}