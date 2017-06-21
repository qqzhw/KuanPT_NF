<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelDetails.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.ChannelDetails" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScripts/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/select-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/jquery.validate.min.js"></script> 
    <title>渠道修改</title>   
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" />
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="ShopList.aspx">渠道管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>渠道添加</span></div>
            <ul class="forminfo">
                <li>
                    <label>渠道编码</label>
                    <kpt:SimpleTextBox ID="txtChannelCode" runat="server" CssClass="dfinput" ErrorMessage="产品类型不能为空！" />
                </li>
                <li>
                    <label>渠道名称</label>
                     <kpt:SimpleTextBox ID="txtChannelName" runat="server" CssClass="dfinput" ErrorMessage="产品名称不能为空！" />
                </li>
                  <li>
                    <label>渠道标签</label>
                     <asp:TextBox ID="txtChannelLable" runat="server" CssClass="dfinput" />
                </li>
                 <li>
                    <label>渠道URL</label>
                     <asp:TextBox ID="txtChannelUrl" runat="server" CssClass="dfinput" /><i>如：http://192.168.1.100/?code=weixin</i>
                </li> 
                 <li>
                    <label>是否发布</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <asp:CheckBox ID="chkPublished" runat="server" Checked="true" /><i>默认发布</i>
                    </div>
                </li>    
                  <li>
                    <label>显示顺序</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtDisplayOrder"
                            Value="0" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                    </div>
                </li> 
                    <li>
                    <label>备注 </label>
                     <asp:TextBox Rows="5" ID="txtDesc" TextMode="MultiLine" style="line-height:18px;"  Wrap="true"  runat="server" Height="100"  CssClass="dfinput" />
                </li> 
                <li>
                  
                </li>
                   <li>
                  
                </li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnAdd" runat="server"   CssClass="scbtn" Text="确认保存" OnClick="BtnAdd_Click" />
                </li>
            </ul>

        </div>
        <script type="text/javascript">
            $(document).ready(function (e) {
                $("#form1").validate({
                    debug: false, // 调试，不提交 false
                    errorPlacement: function (error, element) { }, // 不提示文字
                    rules: {
                        tbName: "required",
                    }
                });
            });
        </script>
    </form>
</body>
</html>
