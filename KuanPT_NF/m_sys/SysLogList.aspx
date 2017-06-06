<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysLogList.aspx.cs" Inherits="IMCustSys.SysLogList" %>
<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  
    <link href="../CSS/jquery-ui.css" rel="stylesheet" />
     <link href="../CSS/style.css" rel="stylesheet" />
    <script src="../JavaScripts/jquery-1.12.4.min.js"></script>
    <script src="../JavaScripts/jquery-ui.js"></script>
    <script src="../JavaScripts/jquery-ui-zh.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tbDateS").datepicker({ dateFormat: "yy-mm-dd" });
            $("#tbDateE").datepicker({ dateFormat: "yy-mm-dd" });
        });
    </script>
</head>
<body>
    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="index.aspx">首页</a></li>
            <li>日志查询</li>
        </ul>
    </div>

    <div class="formbody">
        <form id="form1" runat="server">
            <ul class="seachform">

                <li>
                    <label>Date</label>
                    <asp:TextBox ID="tbDateS" runat="server"></asp:TextBox>-<asp:TextBox ID="tbDateE" runat="server"></asp:TextBox>
                    </li>
                <li>
                    <label>Logger</label>
                    <asp:TextBox ID="tbLogger" runat="server"></asp:TextBox>
                </li>

                <li>
                    <label>Message</label>
                    <asp:TextBox ID="tbMessage" runat="server"></asp:TextBox>
                </li>
                <li>
                    <label>&nbsp;</label><asp:Button ID="btSearch" runat="server" Text="查询" OnClick="btSearch_Click" /></li>
            </ul>
            <yyc:SmartGridView ID="sgvLogList" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                Width="100%" AllowPaging="True" OnPageIndexChanging="sgv_PageIndexChanging" PageSize="20">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="LogID">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("LogID")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <HeaderStyle Width="15%" />
                        <ItemTemplate>
                            <%# Eval("Date","{0:yyyy-MM-dd HH:mm}")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thread">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("Thread")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Level">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("Level")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Logger">
                        <HeaderStyle Width="15%" />
                        <ItemTemplate>
                            <%# Eval("Logger")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Message">
                        <HeaderStyle Width="20%" />
                        <ItemTemplate>
                            <%# Eval("Message") %>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exception">
                        <HeaderStyle Width="20%" />
                        <ItemTemplate>
                            <span title='<%# Eval("Exception").ToString().Replace("'","") %>'> <%# Eval("Exception").ToString().Length > 15? Eval("Exception").ToString().Substring(0,15) + "...": Eval("Exception") %></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerTemplate>
                        <div class="pagin">
    	                    <div class="message">共<i class="blue"><%# ((GridView)Container.NamingContainer).PageCount %></i>页，当前显示第&nbsp;<i class="blue"><%# ((GridView)Container.NamingContainer).PageIndex + 1 %>&nbsp;</i>页</div>
                            <ul class="paginList">
                                <li class="paginItem">
                                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev" CommandName="Page" 
                                        Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'><image src="../images/pre.gif"></image></asp:LinkButton></li>
                                <li class="paginItem">
                                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                        Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'><image src="../images/next.gif"></image></asp:LinkButton></li>
                            </ul>
                        </div>
                </PagerTemplate>
            </yyc:SmartGridView>
        </form>
    </div>
</body>
</html>
