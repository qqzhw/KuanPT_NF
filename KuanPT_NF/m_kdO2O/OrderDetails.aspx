<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.OrderDetails" %>
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
    <link href="/Editor/themes/default/default.css" rel="stylesheet" />
    <link href="~/Editor/plugins/code/prettify.css" rel="stylesheet" />
    <script src="/Editor/kindeditor-all-min.js"></script>
    <script charset="utf-8" src="/Editor/lang/zh-CN.js"></script>
    <script charset="utf-8" src="/Editor/plugins/code/prettify.js"></script>
    <title>修改订单</title>   
    <style> 
             select {  
                min-width:150px;
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
                <li><a href="OrderList.aspx">订单管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>编辑订单</span></div>
            <ul class="forminfo">
                <li>
                    <label>定购产品</label>
                    <asp:DropDownList ID="ddlShops" runat="server" CssClass="select1"></asp:DropDownList>
                    <i>选择定购产品</i>
                </li>
                <li>
                    <label>客户名称</label>
                     <kpt:SimpleTextBox ID="txtCustomerName" runat="server" CssClass="dfinput" ErrorMessage="客户名称不能为空！" />
                </li>
                <li>
                    <label>客户身份证号</label>
                     <asp:TextBox ID="txtCustomerID" runat="server" CssClass="dfinput" />
                </li>
                  <li>
                    <label>客户电话</label>
                     <asp:TextBox ID="txtCustomerTel" runat="server" CssClass="dfinput" />
                </li>
                 <li>
                    <label>客户地址</label>
                     <asp:TextBox ID="txtCustomerAddress" runat="server" CssClass="dfinput" />
                </li>
                   <li>
                    <label>支付宝账户</label>
                     <asp:TextBox ID="txtAliAccount" runat="server" CssClass="dfinput" />
                </li> 
                <li>
                    <label>佣金</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtCommission"
                            Value="0" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                    </div>
                </li> 
                 <li>
                    <label>订单状态</label>
                    <asp:DropDownList ID="ddlOrderStatus" runat="server" ></asp:DropDownList>
                   
                </li>
                  <li>
                    <label>支付方式</label>
                     <asp:TextBox ID="txtPayType" runat="server" CssClass="dfinput" />
                </li>
                 <li>
                    <label>付款状态</label>
                    <asp:DropDownList ID="ddlPaymentStatus" runat="server" ></asp:DropDownList>
               
                </li>
                 <li>
                    <label>付款金额</label> 
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtPayPrice"
                            Value="0" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                </li>
                 <li>
                    <label>付款佣金</label> 
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtPayComission"
                            Value="0" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                </li>
                  <li>
                    <label>备注</label>
                   <asp:TextBox ID="txtDesc" Rows="5" runat="server" Wrap="true" TextMode="MultiLine" CssClass="dfinput" Style="width: 600px; text-align: left;   vertical-align: top; height: 200px;" />
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
                KindEditor.ready(function (K) {
                    var editor1 = K.create('#ttContent1', {
                        cssPath: '/Editor/plugins/code/prettify.css',
                        uploadJson: '/Editor/asp.net/upload_json.ashx',
                        fileManagerJson: '/Editor/asp.net/file_manager_json.ashx',
                        allowFileManager: true,
                        langType: 'zh-CN'
                    });
                    prettyPrint();
                    var editor2 = K.create('#ttContent2', {
                        cssPath: '/Editor/plugins/code/prettify.css',
                        uploadJson: '/Editor/asp.net/upload_json.ashx',
                        fileManagerJson: '/Editor/asp.net/file_manager_json.ashx',
                        allowFileManager: true,
                        langType: 'zh-CN'
                    });
                    prettyPrint();
                }); 
            });
            $("#form1").validate({
                debug: false, // 调试，不提交 false
                errorPlacement: function (error, element) { }, // 不提示文字
                rules: {
                    txtCustomerName: "required",
                    txtCustomerTel: "required",
                }
            });
            
        </script>
    </form>
</body>
</html>

