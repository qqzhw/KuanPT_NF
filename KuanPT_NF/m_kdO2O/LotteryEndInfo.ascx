<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotteryEndInfo.ascx.cs" Inherits="IMCustSys.LotteryEndInfo" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="kpt" %>
<ul class="forminfo"> 
 
    <li>
        <label>活动图片</label>
        <asp:FileUpload ID="uploadImg" CssClass="file" runat="server" ToolTip="请选择图片上传" />
       
    </li> 
      <li>
        <label>结束公告</label>
        <asp:TextBox  ID="txtDesc"  TextMode="MultiLine" Rows="5"   style="width:700px;height:100px;" CssClass="dfinput"  runat="server"></asp:TextBox>
    </li> 
    <li>
        <label>结束说明</label>
        <asp:TextBox  ID="txtNotice"  TextMode="MultiLine" Rows="8"  style="width:700px;height:150px;"  CssClass="dfinput"  runat="server"></asp:TextBox>
    </li> 
</ul>