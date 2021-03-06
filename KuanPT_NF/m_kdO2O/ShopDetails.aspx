﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ShopDetails.aspx.cs" Inherits="IMCustSys.ShopDetails" %>

<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>
<%@ Register Src="Modules/SelectCategoryControl.ascx" TagName="SelectCategoryControl" TagPrefix="kpt" %>

<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScripts/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/select-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/jquery.validate.min.js"></script>
    <link href="/Editor/themes/default/default.css" rel="stylesheet" />
    <link href="/Editor/plugins/code/prettify.css" rel="stylesheet" />
    <script src="/Editor/kindeditor-all-min.js"></script>
    <script charset="utf-8" src="/Editor/lang/zh-CN.js"></script>
    <script charset="utf-8" src="/Editor/plugins/code/prettify.js"></script>
    <title>产品编辑</title>
    <style>
        .file input {
            padding: 6px 12px;
            min-width: 206px;
            font-size: 14px;
            font-weight: 400;
            height: 34px;
            color: #555;
            background-color: #fff;
            border: 1px solid #c2cad8;
            -webkit-box-shadow: none;
            box-shadow: none;
            -webkit-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        .file .btn {
            display: inline-block;
            margin-bottom: 0;
            font-weight: 400;
            text-align: center;
            vertical-align: middle;
            touch-action: manipulation;
            cursor: pointer;
            border: 1px solid transparent;
            white-space: nowrap;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857;
            border-radius: 4px;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        .file a {
            text-shadow: none;
            color: #337ab7;
        }

        .file {
            position: relative;
            display: inline-block;
            background: #D0EEFF;
            border: 1px solid #99D3F5;
            border-radius: 4px;
            padding: 4px 12px;
            overflow: hidden;
            color: #1E88C7;
            text-decoration: none;
            text-indent: 0;
            line-height: 20px;
        }

            .file input {
                position: absolute;
                font-size: 100px;
                right: 0;
                top: 0;
                opacity: 0;
            }

            .file:hover {
                background: #AADFFD;
                border-color: #78C3F3;
                color: #004974;
                text-decoration: none;
            }
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
                <li><a href="ShopList.aspx">产品管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>产品添加</span></div>
            <ul class="forminfo">
                  <li>
                    <label>产品分类</label>
                     <kpt:SelectCategoryControl ID="ShopCategory"   runat="server" />
                </li>
                <li>
                    <label>产品类型</label>
                    <kpt:SimpleTextBox ID="txtShopType" runat="server" CssClass="dfinput" ErrorMessage="产品类型不能为空！" />
                </li>
                <li>
                    <label>产品名称</label>
                    <kpt:SimpleTextBox ID="txtShopName" runat="server" CssClass="dfinput" ErrorMessage="产品名称不能为空！" />
                </li>
                <li>
                    <label>产品短述</label>
                    <asp:TextBox ID="txtShortDesc" runat="server" CssClass="dfinput" />
                </li>
                <li>
                    <label>产品价格 </label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <kpt:NumericTextBox runat="server" CssClass="dfinput" ID="txtPrice"
                            Value="0" RequiredErrorMessage="不能为空！"
                            RangeErrorMessage="数字范围在0-99999之间！"
                            MinimumValue="0" MaximumValue="99999"></kpt:NumericTextBox>
                    </div>
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
                    <label>状态</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <asp:CheckBox ID="chkPublished" runat="server" Checked="true" /><i>选中:上架,未选中:下架</i>
                    </div>
                </li>
                <li>
                    <label>首页显示</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <asp:CheckBox ID="chkHomepage" runat="server" Checked="true" /><i>首页显示</i>
                    </div>
                </li>
                <li>
                    <label>热销产品</label>
                    <div style="vertical-align: middle; padding-top: 8px;">
                        <asp:CheckBox ID="chkHot" runat="server" Checked="true" /><i>首页显示</i>
                    </div>
                </li>
                <li>
                    <label>产品图片</label>
                    <asp:Image ID="imgShop" runat="server" Style="width: 120px" AlternateText="图片" />
                    <asp:Button ID="btnRemoveImg" runat="server" OnClick="btnRemoveImg_Click" Visible="false" CssClass="btn" Style="margin-bottom: 10px" Text="删除图片" CausesValidation="false" />
                    <asp:HiddenField ID="hiddenImgPath" runat="server" />
                    <asp:FileUpload ID="uploadImg" CssClass="file" runat="server" ToolTip="请选择图片上传" />

                </li>
                <li>
                    <label>首页大图</label>
                    <asp:Image ID="imgBigPicture" runat="server" Style="height: 120px" AlternateText="图片" />
                    <asp:Button ID="btnRemoveBigImg" runat="server" OnClick="btnRemoveBigImg_Click" Visible="false" CssClass="btn" Style="margin-bottom: 10px" Text="删除图片" CausesValidation="false" />
                    <asp:HiddenField ID="HiddenBigImg" runat="server" />
                    <asp:FileUpload ID="uploadBigImg" CssClass="file" runat="server" ToolTip="请选择图片上传" />

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
                    <label>产品描述</label>
                    <textarea id="ttContent1" cols="100" rows="8" style="width: 700px; height: 260px; visibility: hidden;" runat="server"></textarea>
                </li>
                <li>
                    <label>备注</label>
                    <textarea id="ttContent2" cols="100" rows="5" style="width: 700px; height: 200px; visibility: hidden;" runat="server"></textarea>
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
                $("#btnAdd").on("click", function () {
                    var content = $(".ke-edit-iframe").contents().find(".ke-content").html().trim();
                    if (content.length === 0) {
                        alert("请输入活动内容！");
                        return;
                    }
                });

            });
            $("#form1").validate({
                debug: false, // 调试，不提交 false
                errorPlacement: function (error, element) { }, // 不提示文字
                rules: {
                    tbName: "required",
                    ttContent1: "required",
                    ttContent2: "required"
                }
            });

        </script>
    </form>
</body>
</html>

