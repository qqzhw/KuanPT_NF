<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopList.aspx.cs" Inherits="IMCustSys.ShopList" %>
<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
<%@ Register Src="Modules/SelectCategoryControl.ascx" TagName="SelectCategoryControl" TagPrefix="kpt" %>

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
     
    <title>产品列表</title>
    <style>
         select {  
                min-width:150px;
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
      <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="index.aspx">首页</a></li>
                <li>产品管理</li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>产品列表</span><asp:Literal ID="lblMessage" runat="server"></asp:Literal></div>
              <ul class="inputform">

                <li>
                    <label>产品分类</label>
                    <div class="vocation">
                        <kpt:SelectCategoryControl ID="ShopCategory"   runat="server" />
                    </div>
                </li>
                <li>
                    <label>产品名称</label>
                    <asp:TextBox ID="tbName" runat="server"  CssClass="dfinput" ></asp:TextBox>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnSearch" runat="server" CssClass="scbtn" Text="查 询" OnClick="btnSearch_Click" />
                </li>

            </ul>
            <yyc:SmartGridView ID="sgvCpList" CssClass="tablelist" PageSize="20" AllowPaging="true" runat="server"   AutoGenerateColumns="False" MouseOverCssClass="OverRow" AlternatingRowStyle-CssClass="odd"
                Width="100%" OnRowCommand="sgv_RowCommand"  OnPageIndexChanging="SgvCpList_PageIndexChanging"   PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Right" PagerSettings-Position="Bottom" PagerSettings-FirstPageText="首页" PagerSettings-NextPageText="下页" PagerSettings-LastPageText="末页" PagerSettings-PreviousPageText="前页" PagerSettings-PageButtonCount="5">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Literal ID="ltlDeptId" runat="server" Text='<%# Eval("ShopId")%>'></asp:Literal><asp:HiddenField ID="hLevel" runat="server" Value='<%# Eval("ShopId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="产品类型">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("ShopType")%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="产品类别">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# GetCategory(Convert.ToInt32(Eval("CategoryId")))%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="产品名称">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("ShopName")%>
                        </ItemTemplate>
                         <EditItemTemplate>
                            <asp:TextBox ID="txtShopName" CssClass="scinput" runat="server" Text='<%# Eval("ShopName")%>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="产品价格(元)">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("Price")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="佣金(元)">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("Commission")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="首页显示">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("ShowOnHomePage"))==true?"是":"否"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="热销产品">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Convert.ToBoolean(Eval("IsHotShop"))==true?"<span style='color:orangered'>是</span>":"否"%>
                        </ItemTemplate>
                            <EditItemTemplate>
                            <asp:CheckBox ID="chkHot"   runat="server"  Checked='<%# Eval("IsHotShop")%>'></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="简述">
                        <HeaderStyle Width="45%" />
                        <ItemTemplate>
                            <%# Eval("ShortDescription")%>
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
                            <a href="ShopDetails.aspx?ShopId=<%#Eval("ShopId") %>" >编辑</a> 
                            <asp:LinkButton ID="btnDelete" CommandName="DeleteItem" CommandArgument='<%# Eval("ShopId") %>'
                                OnClientClick="javascript:return confirm('是否确认要下架当前产品？');" runat="server" ToolTip="下架当前产品"
                                CausesValidation="false">下架</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns> 
            </yyc:SmartGridView>             
        </div>
    </form>
</body>
</html>
