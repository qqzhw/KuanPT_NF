using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KuanPT_NF.m_kdO2O
{
    public partial class CampaignList : BaseKptPage
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
            int totalRecord = 0;
            int totalPage = 0;
            // 模块列表
            sgvCpList.DataSource = CampaignService.GetPageData(out totalRecord,out totalPage);
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

        protected void sgv_Cancel(object sender, GridViewCancelEditEventArgs e)
        {
            ((GridView)sender).EditIndex = -1;
            BindData();
        }

        protected void sgv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
              int campaignId = 0;

           switch (e.CommandName)
            {
                 case "DeleteItem":  // 删除
                    campaignId = int.Parse(e.CommandArgument.ToString());
                    var campaign = CampaignService.GetCampaignById(campaignId);
                    CampaignService.DeleteCampaign(campaign); 
                     break;
                 default:
                  break;
             }
           
        }

        protected void sgv_Edit(object sender, GridViewEditEventArgs e)
        {
            ((GridView)sender).EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void sgv_Update(object sender, GridViewUpdateEventArgs e)
        { 
            GridView gv = ((GridView)sender);

            GridViewRow row = gv.Rows[e.RowIndex];
           int campaignId= int.Parse(((Literal)row.FindControl("ltlcampaignId")).Text);
            string Name = ((TextBox)row.FindControl("txtCampaignName")).Text;
            var campaign = CampaignService.GetCampaignById(campaignId);
            campaign.CampaignName = Name;
            CampaignService.UpdateCampaign(campaign);
            Response.Redirect("CampaignList.aspx");
        }
    }
}