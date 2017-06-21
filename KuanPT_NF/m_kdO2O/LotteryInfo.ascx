﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotteryInfo.ascx.cs" Inherits="KuanPT_NF.m_kdO2O.LotteryInfo" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/DatePicker.ascx" TagName="DatePicker" TagPrefix="kpt" %>
<ul class="forminfo">
    <li>
        <label>活动名称</label>
        <kpt:SimpleTextBox ID="txtName" runat="server" CssClass="dfinput" ErrorMessage="产品类型不能为空！" />
    </li>
    <li>
        <label>关键词</label>
        <kpt:SimpleTextBox ID="txtKeyword" runat="server" CssClass="dfinput" ErrorMessage="产品名称不能为空！" />
    </li>
    <li>
        <label>兑奖信息</label>
        <asp:TextBox ID="txtLotteryInfo"  runat="server" CssClass="dfinput" />
    </li>
    <li>
        <label>活动开始时间 </label>
        <div style="vertical-align: middle; padding-top: 8px;">
           <kpt:DatePicker runat="server" ID="ctrlStartDatePicker" />
        </div>
    </li>
     <li>
        <label>结束时间 </label>
         <kpt:DatePicker runat="server" ID="ctrlEndDatePicker" />
    </li>
    <li>
        <label>重复抽奖提示</label>
          <asp:TextBox  ID="txtRepeatTips"    CssClass="dfinput"  runat="server"></asp:TextBox>
    </li>  
    <li>
        <label>活动图片</label>
        <asp:FileUpload ID="uploadImg" CssClass="file" runat="server" ToolTip="请选择图片上传" />
       
    </li> 
      <li>
        <label>简介</label>
        <asp:TextBox  ID="txtDesc"  TextMode="MultiLine" Rows="5"   style="width:700px;height:100px;" CssClass="dfinput"  runat="server"></asp:TextBox>
    </li> 
    <li>
        <label>活动说明</label>
        <asp:TextBox  ID="txtNotice"  TextMode="MultiLine" Rows="8"  style="width:700px;height:150px;"  CssClass="dfinput"  runat="server"></asp:TextBox>
    </li>
    <li>
        <label>兑奖密码</label>
        <asp:TextBox ID="txtLotteryPassword"   CssClass="dfinput"   runat="server"></asp:TextBox>
    </li> 
       <li>
        <label>活动URL</label>
        <asp:TextBox ID="txtUrl"   CssClass="dfinput"   runat="server"></asp:TextBox>
    </li> 
</ul>
<script type="text/javascript">
    $(document).ready(function (e) {
          
    });
    $("#form1").validate({
        debug: false, // 调试，不提交 false
        errorPlacement: function (error, element) { }, // 不提示文字
        rules: {
            txtName: "required",
         
        }
    });

</script>