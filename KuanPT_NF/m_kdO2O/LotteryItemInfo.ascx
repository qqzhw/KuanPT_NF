<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotteryItemInfo.ascx.cs" Inherits="IMCustSys.LotteryItemInfo" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="kpt" %>
<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
  <div class="formtitle"><span>奖项列表</span><asp:Literal ID="lblMessage" ClientIDMode="Inherit" runat="server"></asp:Literal></div>

            <yyc:SmartGridView ID="sgvCpList" CssClass="tablelist" PageSize="20" AllowPaging="true" runat="server" AutoGenerateColumns="False" MouseOverCssClass="OverRow" AlternatingRowStyle-CssClass="odd"
                Width="100%"   OnPageIndexChanging="SgvCpList_PageIndexChanging" OnRowCommand="sgv_RowCommand"  OnRowCancelingEdit="sgv_Cancel" OnRowEditing="sgv_Edit" OnRowUpdating="sgv_Update" PagerSettings-Mode="NextPreviousFirstLast" PagerStyle-HorizontalAlign="Right" PagerSettings-Position="Bottom" PagerSettings-FirstPageText="首页" PagerSettings-NextPageText="下页" PagerSettings-LastPageText="末页" PagerSettings-PreviousPageText="前页" PagerSettings-PageButtonCount="5">
                <EmptyDataTemplate>
                    <span class="f14px">没有信息！</span>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <HeaderStyle Width="20px" />
                        <ItemTemplate>
                            <asp:Literal ID="ltllotteryItemId" runat="server" Text='<%# Eval("LotteryItemId")%>'></asp:Literal><asp:HiddenField ID="hLevel" runat="server" Value='<%# Eval("LotteryItemId")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="奖项名称">
                        <HeaderStyle Width="30%" />
                        <ItemTemplate>
                            <%# Eval("ItemName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="奖品名称">
                        <HeaderStyle Width="30%" />
                        <ItemTemplate>
                            <%# Eval("AwardName")%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="奖品数量">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("AwardCount")%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="实际数量">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("CurrentCount")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="中奖概率">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <%# Eval("AwardPercent")%>
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
                            <asp:LinkButton ID="btnDelete" CommandName="DeleteItem" CommandArgument='<%# Eval("LotteryItemId") %>'
                                OnClientClick="javascript:return confirm('是否确认要删除？');" runat="server" ToolTip="删除"
                                CausesValidation="false">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </yyc:SmartGridView>
<br />
 <asp:Button ID="btnAdd" runat="server" CssClass="scbtn" Text="添加奖项"  />
<script type="text/javascript">
    function OpenWindow(query, w, h, scroll) {
        var l = (screen.width - w) / 2;
        var t = (screen.height - h) / 2;

        winprops = 'resizable=1, height=' + h + ',width=' + w + ',top=' + t + ',left=' + l + 'w';
        if (scroll) winprops += ',scrollbars=1';
        var f = window.open(query, "_blank", winprops);
    }
</script>