<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotteryItemInfo.ascx.cs" Inherits="KuanPT_NF.m_kdO2O.LotteryItemInfo" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="kpt" %>
<ul class="forminfo">
    <li>
        <label>奖项名称</label>
        <kpt:SimpleTextBox ID="txtName" runat="server" CssClass="dfinput" ErrorMessage="产品类型不能为空！" />
    </li>
    <li>
        <label>奖品名称</label>
        <kpt:SimpleTextBox ID="txtKeyword" runat="server" CssClass="dfinput" ErrorMessage="产品名称不能为空！" />
    </li>
    <li>
        <label>奖品数量</label>
        <asp:TextBox ID="txtLotteryInfo"  runat="server" CssClass="dfinput" />
    </li>
    <li>
        <label>实际数量 </label>
        <div style="vertical-align: middle; padding-top: 8px;">
           <kpt:DatePicker runat="server" ID="ctrlStartDatePicker" />
        </div>
    </li>
     <li>
        <label>活动人数 </label>
         <kpt:DatePicker runat="server" ID="ctrlEndDatePicker" />
    </li>
    <li>
        <label>每日抽奖次数</label>
          <asp:TextBox  ID="txtRepeatTips"    CssClass="dfinput"  runat="server"></asp:TextBox>
    </li>  
    <li>
        <label>最多抽奖次数</label>
        <asp:FileUpload ID="uploadImg" CssClass="file" runat="server" ToolTip="请选择图片上传" />
       
    </li>  
    <li>
        <label>中奖概率</label>
        <asp:TextBox ID="txtLotteryPassword"   CssClass="dfinput"   runat="server"></asp:TextBox>
    </li> 
     <li><label></label>
           <a href="javascript:open_win();" class="scbtn" >新增奖项</a>
     </li>
</ul>
<script type="text/javascript">
function open_win() 
{
   
    window.open ('orderlist.aspx', 'newwindow', 'height=600,width=1024,top=80,left=100,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')
}
</script>