<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotteryItemInfo.ascx.cs" Inherits="KuanPT_NF.m_kdO2O.LotteryItemInfo" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="kpt" %>
<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
  <div class="formtitle"><span>奖项列表</span><asp:Literal ID="lblMessage" runat="server"></asp:Literal></div>

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
                            <asp:LinkButton ID="btnDelete" CommandName="DeleteItem" CommandArgument='<%# Eval("LotteryId") %>'
                                OnClientClick="javascript:return confirm('是否确认要删除？');" runat="server" ToolTip="删除"
                                CausesValidation="false">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </yyc:SmartGridView>
<script type="text/javascript">
    function OpenWindow(query, w, h, scroll) {
        var l = (screen.width - w) / 2;
        var t = (screen.height - h) / 2;

        winprops = 'resizable=1, height=' + h + ',width=' + w + ',top=' + t + ',left=' + l + 'w';
        if (scroll) winprops += ',scrollbars=1';
        var f = window.open(query, "_blank", winprops);
    }
</script>