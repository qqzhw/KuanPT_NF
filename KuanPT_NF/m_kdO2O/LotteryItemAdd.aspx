<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LotteryItemAdd.aspx.cs" Inherits="IMCustSys.LotteryItemAdd" %>
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
    <title>奖项添加</title>   
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" />
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="LotteryList.aspx">活动奖项管理</a></li>
            </ul> 
        </div>
        <div class="formbody">
            <div class="formtitle"><span>奖项添加</span></div>
            <ul class="forminfo">
                <li>
                    <label>活动名称</label>
                    <kpt:SimpleTextBox ID="txtName" runat="server" CssClass="dfinput" ErrorMessage="产品类型不能为空！" />
                </li>
                <li>
                    <label>奖项名称</label>
                     <kpt:SimpleTextBox ID="txtItemName" runat="server" CssClass="dfinput" ErrorMessage="产品名称不能为空！" />
                </li>
                  <li>
                    <label>奖品名称</label>
                     <asp:TextBox ID="txtAwardName" runat="server" CssClass="dfinput" />
                </li>
                 <li>
                    <label>奖品数量</label>
                       <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtAwardCount"
                            Value="1" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                </li> 
                 <li>
                    <label>当前数量</label>
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtCurrentCount"
                            Value="1" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                </li>    
                  <li>
                    <label>中奖几率</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtAwardPercent"
                            Value="0" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                    </div>
                </li> 
                    <li>
                  
                </li>  
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnAdd" runat="server"   CssClass="scbtn" Text="确认保存" OnClick="btnAdd_Click" />
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

 