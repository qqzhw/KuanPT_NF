<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelList.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.ChannelList" %>

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
    <title>渠道列表</title>
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
                <li>渠道管理</li>
            </ul>
        </div>
        <div class="formbody">
            <ul class="inputform">  
                <li>
                    <label>渠道名称</label>
                    <div class="vocation">
                        <asp:TextBox ID="txtChannelName" CssClass="dfinput" style="width:200px;" runat="server"></asp:TextBox>
                    </div>
                </li>  
                <li>
                    <label>&nbsp;</label> 
                       <asp:Button ID="SearchButton" runat="server" Text="查询"
            CssClass="scbtn" OnClick="SearchButton_Click" ToolTip="查询渠道" /> &nbsp&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" Text="导出数据"    CssClass="scbtn" ID="btnExportXLS" OnClick="btnExportXLS_Click" ValidationGroup="ExportXLS"
            ToolTip="导出数据到EXCEL" />
                </li> 
            </ul>
            <div class="formtitle"><span>渠道列表</span><asp:Literal ID="lblMessage" runat="server"></asp:Literal></div>

            <yyc:SmartGridView ID="sgvCpList" CssClass="tablelist" PageSize="20" AllowPaging="true" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow" AlternatingRowStyle-CssClass="odd"
                Width="100%"   OnPageIndexChanging="SgvCpList_PageIndexChanging"  OnRowCancelingEdit="sgv_Cancel" OnRowEditing="sgv_Edit" OnRowUpdating="sgv_Update" PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Right" PagerSettings-Position="Bottom" PagerSettings-FirstPageText="首页" PagerSettings-NextPageText="下页" PagerSettings-LastPageText="末页" PagerSettings-PreviousPageText="前页" PagerSettings-PageButtonCount="5">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Literal ID="ltlChannelId" runat="server" Text='<%# Eval("ChannelId")%>'></asp:Literal><asp:HiddenField ID="hLevel" runat="server" Value='<%# Eval("ChannelId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="渠道名称">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("ChannelName")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                              <kpt:SimpleTextBox ID="txtChannelName" runat="server" Text='<%# Eval("ChannelName")%>' CssClass="dfinput" ErrorMessage="渠道名称不能为空！" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="渠道编码">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("ChannelCode")%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="渠道标签">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("ChannelLable")%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="渠道链接">
                        <HeaderStyle Width="30%" />
                        <ItemTemplate>
                            <%# Eval("ChannelUrl")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                        <HeaderStyle Width="20%" />
                        <ItemTemplate>
                            <%# Eval("ChannelDesc")%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                     
                    <asp:TemplateField HeaderText="渠道状态">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                             <%# Convert.ToBoolean(Eval("Published"))==true?"启用":"停用"%>
                        </ItemTemplate>
                        <EditItemTemplate>
                          <asp:CheckBox ID="chkPublished" runat="server" Checked='<%#Convert.ToBoolean(Eval("Published")) %>' />
                        </EditItemTemplate>
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
                            <a href="ChannelDetails.aspx?ChannelId=<%#Eval("ChannelId") %>">详细</a>
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

