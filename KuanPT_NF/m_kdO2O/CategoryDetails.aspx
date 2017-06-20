<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.CategoryDetails" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>

<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>

<%@ Register Src="Modules/SelectCategoryControl.ascx" TagName="SelectCategoryControl" TagPrefix="uc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScripts/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/select-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/jquery.validate.min.js"></script> 
    <title>分类编辑</title>
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
                <li><a href="CategoryList.aspx">分类管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>分类编辑</span></div>
            <ul class="forminfo">
                <li>
                    <label>上级分类</label>
                    <uc1:SelectCategoryControl ID="ParentCategory"   runat="server" />
                </li>
                <li>
                    <label>
                        分类名称
                    </label>
                    <kpt:SimpleTextBox ID="txtName" runat="server" CssClass="dfinput" ErrorMessage="分类名称不能为空！" />
                </li>
                <li>
                    <label>首页显示 </label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <asp:CheckBox ID="chkHomePage" runat="server" EnableTheming="false"></asp:CheckBox>
                    </div>
                </li>
                <li>
                    <label>发布</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <asp:CheckBox ID="chkPublished" runat="server" Checked="true" />
                    </div>
                </li>
                <li>
                    <label>显示顺序</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" style="width: 80px;" ID="txtDisplayOrder"
                            Value="0" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                    </div>
                </li>
                <li>
                    <label>描述</label>
                    <asp:TextBox ID="txtDesc" Rows="5" runat="server" Wrap="true" TextMode="MultiLine" CssClass="dfinput" Style="width: 600px; text-align: left;   vertical-align: top; height: 200px;" />
                </li>
                <li></li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnAdd" runat="server" CssClass="scbtn" Text="确认保存" OnClick="btnAdd_Click" />
                </li>
            </ul>

        </div>
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
    </form>
</body>
</html>

