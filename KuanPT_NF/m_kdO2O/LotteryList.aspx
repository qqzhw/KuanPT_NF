<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LotteryList.aspx.cs" Inherits="IMCustSys.LotteryList" %>

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
                <li><a href="LotteryList.aspx">首页</a></li>
                <li>抽奖活动管理</li>
            </ul>
        </div>
        <div class="formbody">
            <ul class="inputform">  
                <li>
                    <label>活动名称</label>
                    <div class="vocation">
                        <asp:TextBox ID="txtName" CssClass="dfinput" style="width:120px;" runat="server"></asp:TextBox>
                    </div>
                </li>  
                <li>
                    <label>&nbsp;</label> 
                       <asp:Button ID="SearchButton" runat="server" Text="查询"
            CssClass="scbtn" OnClick="SearchButton_Click" ToolTip="查询活动" /> &nbsp&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="导出数据"    CssClass="scbtn" ID="btnExportXLS" OnClick="btnExportXLS_Click" ValidationGroup="ExportXLS"
            ToolTip="导出数据到EXCEL" />
                </li> 
            </ul>
            <div class="formtitle"><span>抽奖活动列表</span><asp:Literal ID="lblMessage" runat="server"></asp:Literal></div>

            <yyc:SmartGridView ID="sgvCpList" CssClass="tablelist" PageSize="20" AllowPaging="true" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow" AlternatingRowStyle-CssClass="odd"
                Width="100%"   OnPageIndexChanging="SgvCpList_PageIndexChanging"  OnRowCancelingEdit="sgv_Cancel" OnRowEditing="sgv_Edit" OnRowUpdating="sgv_Update" PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Right" PagerSettings-Position="Bottom" PagerSettings-FirstPageText="首页" PagerSettings-NextPageText="下页" PagerSettings-LastPageText="末页" PagerSettings-PreviousPageText="前页" PagerSettings-PageButtonCount="5">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Literal ID="ltlLotteryId" runat="server" Text='<%# Eval("LotteryId")%>'></asp:Literal><asp:HiddenField ID="hLevel" runat="server" Value='<%# Eval("LotteryId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="关键词">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("KeyWord")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="活动名称">
                        <HeaderStyle Width="50" />
                        <ItemTemplate>
                            <%# Eval("LotteryName")%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="开始时间">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("BeginDate").ToString()%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="结束时间">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("EndDate").ToString()%>
                        </ItemTemplate>
                    </asp:TemplateField> 
                      <asp:TemplateField HeaderText="活动人数">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("PersonCount")%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                        <asp:TemplateField HeaderText="最大抽奖次数">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("MaxLotteryCount")%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                          <asp:TemplateField HeaderText="每日次数">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("TodayLotteryCount")%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                      <asp:TemplateField HeaderText="兑奖密码">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <%# Eval("LotteryPassword")%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作">
                        <HeaderStyle Width="10%" /> 
                        <ItemTemplate>
                            <a href="LotteryDetails.aspx?LotteryId=<%#Eval("LotteryId") %>&LotteryName=<%#Eval("LotteryName") %>">详细</a> 
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </yyc:SmartGridView>
        </div>
    </form>
</body>
</html>
