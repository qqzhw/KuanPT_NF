<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KLAuditList.aspx.cs" Inherits="IMCustSys.KLAuditList" %>
<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="index.aspx">首页</a></li>
            <li>知识库审核</li>
        </ul> 
    </div>
    
    <div class="formbody">
        <form id="form1" runat="server">
            <yyc:SmartGridView ID="sgvKLContentList" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow"
                Width="100%">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("KLContentId")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="类型">
                        <HeaderStyle Width="20%" />
                        <ItemTemplate>
                            <%# Eval("ClassName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标题">
                        <HeaderStyle Width="40%" />
                        <ItemTemplate>
                            <%# Eval("Title")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布时间">
                        <HeaderStyle Width="20%" />
                        <ItemTemplate>
                            <%# Eval("AddDate","{0:yyyy-MM-dd HH:mm}")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:HyperLink ID="blAudit" NavigateUrl='<%# string.Format("KLAudit.aspx?id={0}",Eval("KLContentId").ToString()) %>' runat="server">审核</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </yyc:SmartGridView>
        </form>
    </div>
</body>
</html>
