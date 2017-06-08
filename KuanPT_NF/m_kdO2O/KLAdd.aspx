<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KLAdd.aspx.cs" Inherits="KuanPT_NF.KLAdd"  validateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title> 
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
    <script>
        $(document).ready(function (e) {
            $(".select1").uedSelect({
                width: 300
            });

            $("#form1").validate({
                debug: false, // 调试，不提交 false
                errorPlacement: function (error, element) { }, // 不提示文字
                rules: {
                    tbTitle: "required",
                    tbKeyWords: "required",
                    ttContent1: "required",
                    ttContent2: "required"
                  }
            });
        });

        KindEditor.ready(function (K) {
            var editor1 = K.create('#ttContent1', {
                cssPath: 'Editor/plugins/code/prettify.css',
                uploadJson: 'Editor/asp.net/upload_json.ashx',
                fileManagerJson: 'Editor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                langType: 'zh-CN'
            });
            prettyPrint();

            var editor2 = K.create('#ttContent2', {
                cssPath: 'Editor/plugins/code/prettify.css',
                uploadJson: 'Editor/asp.net/upload_json.ashx',
                fileManagerJson: 'Editor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                langType: 'zh-CN'
            });
            prettyPrint();

        });
    </script>
</head>
<body>
   

 
        <form id="form1" runat="server">
  <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="#">知识库管理</a></li>
        </ul>
    </div>
  <div class="formbody">
        <div class="formtitle"><span>知识添加</span></div>
            <ul class="forminfo">
                <li>
                    <label>知识分类</label>
                    <div class="vocation">
                        <asp:DropDownList ID="ddlClass" CssClass="select1" runat="server"></asp:DropDownList>
                    </div>
                </li>
                <li>
                    <label>标题</label><asp:TextBox ID="tbTitle" runat="server" EnableTheming="false" CssClass="dfinput"></asp:TextBox></li>
                <li>
                    <label>设备型号</label><asp:TextBox ID="tbProductType" runat="server" EnableTheming="false" CssClass="dfinput"></asp:TextBox><i>多个关键字用,隔开</i></li>
                <li>
                    <label>系统版本</label><asp:TextBox ID="tbSysVer" runat="server" EnableTheming="false" CssClass="dfinput"></asp:TextBox><i>多个关键字用,隔开</i>
                </li>
                <li>
                    <label>关键字</label><asp:TextBox ID="tbKeyWords" runat="server" EnableTheming="false" CssClass="dfinput"></asp:TextBox><i>多个关键字用,隔开</i>
                </li>
                <li>
                    <label>问题内容</label>
                    <textarea id="ttContent1" cols="100" rows="8" style="width: 700px; height: 260px; visibility: hidden;" runat="server"></textarea>
                </li>
                <li>
                    <label>解决办法</label>
                    <textarea id="ttContent2" cols="100" rows="8" style="width: 700px; height: 260px; visibility: hidden;" runat="server"></textarea>
                </li>
                <li>
                    <label>备注</label><asp:TextBox ID="tbRemark" runat="server" EnableTheming="false" CssClass="dfinput"></asp:TextBox></li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnAdd" runat="server" Text="确认保存" OnClick="btnAdd_Click" />

                </li>
            </ul> 


  </div>
        </form>

   
</body>
</html>
