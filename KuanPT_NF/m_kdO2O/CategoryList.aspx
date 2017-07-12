<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="IMCustSys.CategoryList" %>

<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
<%@ Register Src="Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="kpt" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Default/Common.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Default/SmartGridView.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScripts/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/select-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/jquery.validate.min.js"></script>
    <title>产品分类列表</title>
      <style> 
             select {  
                min-width:80px;
                min-height: 30px;
                opacity: 1; 
                font: 14px/20px "Microsoft YaHei";
                color: #f80;
                outline:#808080  double  thin; 
            } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" />
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="index.aspx">首页</a></li>
                <li>产品分类管理</li>
            </ul>
        </div>
        <div class="formbody">
            <ul class="inputform">  
                <li>
                    <label>分类名称</label>
                    <div class="vocation">
                        <asp:TextBox ID="txtCategoryName" CssClass="dfinput" style="width:200px;" runat="server"></asp:TextBox>
                    </div>
                </li>  
                <li>
                    <label>&nbsp;</label> 
                       <asp:Button ID="SearchButton" runat="server" Text="查询"
            CssClass="scbtn" OnClick="SearchButton_Click" ToolTip="查询产品分类" /> &nbsp&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="导出数据"    CssClass="scbtn" ID="btnExportXLS" OnClick="btnExportXLS_Click" ValidationGroup="ExportXLS"
            ToolTip="导出数据到EXCEL" />
                </li> 
            </ul>
            <div class="formtitle"><span>产品分类列表</span><asp:Literal ID="lblMessage" runat="server"></asp:Literal></div>

            <yyc:SmartGridView ID="sgvCpList" CssClass="tablelist" PageSize="20" AllowPaging="true" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow" AlternatingRowStyle-CssClass="odd"
                Width="100%"   OnPageIndexChanging="SgvCpList_PageIndexChanging"  OnRowCancelingEdit="sgv_Cancel" OnRowEditing="sgv_Edit" OnRowUpdating="sgv_Update" PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Right" PagerSettings-Position="Bottom" PagerSettings-FirstPageText="首页" PagerSettings-NextPageText="下页" PagerSettings-LastPageText="末页" PagerSettings-PreviousPageText="前页" PagerSettings-PageButtonCount="5">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Literal ID="ltlCategoryId" runat="server" Text='<%# Eval("CategoryId")%>'></asp:Literal><asp:HiddenField ID="hLevel" runat="server" Value='<%# Eval("CategoryId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="分类名称">
                        <HeaderStyle Width="35%" />
                        <ItemTemplate>                        
                            <%# Server.HtmlEncode(GetCategoryFullName((IMCustSys.Model.Category)Container.DataItem))%>
                        </ItemTemplate>
                        <EditItemTemplate>
                              <kpt:SimpleTextBox ID="txtCategoryName" runat="server" Text='<%# Eval("CategoryName")%>' CssClass="dfinput" ErrorMessage="分类名称不能为空！" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="上级分类">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# GetParentCategoryName(Eval("ParentCategoryId"))%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                           <%# Convert.ToBoolean(Eval("Published"))==true?"启用":"停用"%>
                        </ItemTemplate> 
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkPublished" runat="server" Checked='<%#Convert.ToBoolean(Eval("Published")) %>' />
                        </EditItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="显示顺序">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("DisplayOrder")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="描述">
                        <HeaderStyle Width="20%" />
                        <ItemTemplate>
                            <%# Eval("Description")%>
                        </ItemTemplate>
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="操作">
                        <HeaderStyle Width="15%" />
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbtUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lbtCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <a href="CategoryDetails.aspx?CategoryId=<%#Eval("CategoryId") %>">详细</a>
                             <asp:LinkButton ID="lbtEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="编辑"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </yyc:SmartGridView>
        </div>
    </form>
</body>
</html>
