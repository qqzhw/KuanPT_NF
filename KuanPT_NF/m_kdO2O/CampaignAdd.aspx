<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampaignAdd.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.CampaignAdd" %>

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
    <link href="~/Editor/plugins/code/prettify.css" rel="stylesheet" />
    <script src="/Editor/kindeditor-all-min.js"></script>
    <script charset="utf-8" src="/Editor/lang/zh-CN.js"></script>
    <script charset="utf-8" src="/Editor/plugins/code/prettify.js"></script>
    <title>活动添加</title>
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
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="uploadImg" CssClass="file" runat="server" ToolTip="请选择图片上传" />

        </div>
        <asp:Button runat="server" CssClass="btn" ID="btnSave" OnClick="btnSave_Click" Text="上传" />
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">活动管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>活动添加</span></div>
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
                    <div class="form-group">
                        <label class="control-label col-md-3">Default1</label>
                        <div class="col-md-3">
                            <div class="fileinput fileinput-exists" data-provides="fileinput">
                                <div class="input-group input-large">
                                    <div class="form-control uneditable-input input-fixed input-medium" data-trigger="fileinput">
                                        <i class="fa fa-file fileinput-exists"></i>&nbsp;
                                         <span class="fileinput-filename">43.png</span>
                                    </div>
                                    <span class="input-group-addon btn default btn-file">
                                        <span class="fileinput-new">Select file </span>
                                        <span class="fileinput-exists">Change </span>
                                        <input type="hidden" value="" name="" />
                                        <input type="file" name="..." />
                                    </span>
                                    <a href="javascript:;" class="input-group-addon btn red fileinput-exists" data-dismiss="fileinput">Remove </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnAdd" runat="server" Text="确认保存" OnClick="btnAdd_Click" />
                </li>
            </ul>


        </div>
    </form>
</body>
</html>
