<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.OrderList" %>

<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
<%@ Register Src="Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="kpt" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Default/Common.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/Default/SmartGridView.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScripts/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/select-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/jquery.validate.min.js"></script>
    <title>订单列表</title>
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
                <li>订单管理</li>
            </ul>
        </div>
        <div class="formbody">
            <ul class="inputform">
                <li>
                    <label>开始时间</label>
                    <div class="vocation">
                        <kpt:DatePicker runat="server" ID="ctrlStartDatePicker" />
                    </div>
                </li>
                <li>
                    <label>截止时间</label>
                    <div class="vocation">
                        <kpt:DatePicker runat="server" ID="ctrlEndDatePicker" />
                    </div>
                </li>
                <li>
                    <label>客户手机</label>
                    <div class="vocation">
                        <asp:TextBox ID="txtCustomerTel" CssClass="dfinput" style="width:120px;" runat="server"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label>订单状态</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlOrderStatus" runat="server"  /> 
                    </div>
                </li>
                <li>
                    <label>付款状态</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlPaymentStatus" runat="server" />
                    </div>
                </li>
                <li>
                    <label>&nbsp;</label> 
                       <asp:Button ID="SearchButton" runat="server" Text="查询"
            CssClass="scbtn" OnClick="SearchButton_Click" ToolTip="查询订单" /> &nbsp&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="导出数据"    CssClass="scbtn" ID="btnExportXLS" OnClick="btnExportXLS_Click" ValidationGroup="ExportXLS"
            ToolTip="导出数据到EXCEL" />
                </li> 
            </ul>
            <div class="formtitle"><span>订单列表</span><asp:Literal ID="lblMessage" runat="server"></asp:Literal></div>

            <yyc:SmartGridView ID="sgvCpList" CssClass="tablelist" PageSize="20" AllowPaging="true" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow" AlternatingRowStyle-CssClass="odd"
                Width="100%"   OnPageIndexChanging="SgvCpList_PageIndexChanging"  OnRowCancelingEdit="sgv_Cancel" OnRowEditing="sgv_Edit" OnRowUpdating="sgv_Update" PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Right" PagerSettings-Position="Bottom" PagerSettings-FirstPageText="首页" PagerSettings-NextPageText="下页" PagerSettings-LastPageText="末页" PagerSettings-PreviousPageText="前页" PagerSettings-PageButtonCount="5">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Literal ID="ltlDeptId" runat="server" Text='<%# Eval("OrderId")%>'></asp:Literal><asp:HiddenField ID="hLevel" runat="server" Value='<%# Eval("OrderId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订单号">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("OrderNo")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="产品类型">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("ShopType")%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="产品名称">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("ShopName")%>
                        </ItemTemplate> 
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
                      <asp:TemplateField HeaderText="客户名称">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("CustomerName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="客户名称">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("CustomerName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="客户身份证">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("IdCard")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="客户电话">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("CustomerTel")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="客户地址">
                        <HeaderStyle Width="30%" />
                        <ItemTemplate>
                            <%# Eval("CustomerTel")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订单状态">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# GetOrderStatusName(Eval("OrderState"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="付款状态">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate> 
                      <%#GetPaymentStatusName(Eval("PaymentStatus"))%>
                        </ItemTemplate>
                        <EditItemTemplate>
                          <asp:TextBox runat="server" ID="txtp" />
                        </EditItemTemplate>
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
                            <a href="OrderDetails.aspx?OrderId=<%#Eval("OrderId") %>">详细</a>
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
