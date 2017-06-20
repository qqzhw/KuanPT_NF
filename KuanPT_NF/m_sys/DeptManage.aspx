<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptManage.aspx.cs" Inherits="IMCustSys.DeptManage" %>
<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
      <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScripts/jquery-1.12.4.min.js"></script>
    <script src="../JavaScripts/select-ui.min.js"></script>
    <script type="text/javascript" src="../JavaScripts/jquery.validate.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 100
            });

            $("#form1").validate({
                debug: false, // 调试，不提交 false
                errorPlacement: function (error, element) { }, // 不提示文字
                rules: {
                    tbDeptName: "required"
                }
            });
        });
    </script>
</head>
<body>
    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="index.aspx">首页</a></li>
            <li>部门管理</li>
        </ul>
    </div>

    <div class="formbody">

        <form id="form1" runat="server">
            <div class="formtitle"><span>部门添加</span></div>
            <ul class="inputform">

                <li>
                    <label>上级部门</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlDeptTop" runat="server" CssClass="select1"></asp:DropDownList>
                    </div>
                </li>
                <li>
                    <label>部门名称</label>
                    <asp:TextBox ID="tbDeptName" runat="server"></asp:TextBox>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnAdd" runat="server" CssClass="scbtn" Text="确认" OnClick="btnAdd_Click" />
                </li>

            </ul>
            <div class="formtitle"><span>模块列表</span><asp:Literal ID="lblMessage" runat="server"></asp:Literal></div>
            <yyc:SmartGridView ID="sgvDeptList" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                Width="100%" OnRowCommand="sgv_RowCommand" OnRowCancelingEdit="sgv_Cancel" OnRowEditing="sgv_Edit" OnRowUpdating="sgv_Update">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:Literal ID="ltlDeptId" runat="server" Text='<%# Eval("DeptId")%>'></asp:Literal><asp:HiddenField ID="hLevel" runat="server" Value='<%# Eval("level")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部门名称">
                        <HeaderStyle Width="40%" />
                        <ItemTemplate>
                            <%# Eval("DeptName")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbDeptName" CssClass="scinput" runat="server" Text='<%# Eval("DeptName")%>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="上级部门">
                        <HeaderStyle Width="40%" />
                        <ItemTemplate>
                            <%# Eval("ParentDeptName")%>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="操作">
                        <HeaderStyle Width="10%" />
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbtUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lbtCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="编辑"></asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" CommandName="DeleteItem" CommandArgument='<%# Eval("DeptId") %>'
                                OnClientClick="javascript:return confirm('是否确认要删除？');" runat="server" ToolTip="删除"
                                CausesValidation="false">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </yyc:SmartGridView>
        </form>
    </div>
</body>
</html>
