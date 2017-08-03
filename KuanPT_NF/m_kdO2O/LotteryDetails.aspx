<%@ Page Language="C#" EnableEventValidation="false" ValidateRequest="false" AutoEventWireup="true" CodeBehind="LotteryDetails.aspx.cs" Inherits="IMCustSys.LotteryDetails" %>
<%@ Register Src="Modules/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="kpt" %>

<%@ Register Src="Modules/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="kpt" %>
<%@ Register Src="LotteryInfo.ascx" TagName="LotteryInfo" TagPrefix="kpt" %>
<%@ Register Src="LotteryEndInfo.ascx" TagName="LotteryEndInfo" TagPrefix="kpt" %>
<%@ Register Src="LotteryItemInfo.ascx" TagName="LotteryItemInfo" TagPrefix="kpt" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/select.css" rel="stylesheet" type="text/css" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScripts/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/select-ui.min.js"></script>
    <script type="text/javascript" src="/JavaScripts/jquery.validate.min.js"></script>
      <script type="text/javascript" src="/JavaScripts/jquery.idTabs.min.js"></script> 
    <link href="/Editor/themes/default/default.css" rel="stylesheet" />
    <link href="/Editor/plugins/code/prettify.css" rel="stylesheet" />
    <script src="/Editor/kindeditor-all-min.js"></script>
    <script charset="utf-8" src="/Editor/lang/zh-CN.js"></script>
    <script charset="utf-8" src="/Editor/plugins/code/prettify.js"></script>
    <title>抽奖活动编辑</title>
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

        .ajax__tab_header {
            background: url(images/tab-line.png) repeat-x bottom;
            font-size: 14px !important;
            font-family: '微软雅黑' !important;
            display: block;
        }

        .ajax__tab_container { 
            font-size: 14px;
        }

        * {
            font-size: 14px;
        }

        .ajax__tab_hover .ajax__tab_inner {
            color: #000;
        }

        .ajax__tab_body {
            background-color: #fff;
            border: solid 1px #41B1E1 !important;
            border-top-width: 0 !important;
        } 
        span {
            display: inline;
            height: 28px;
        } 
        .formtitle{margin-bottom:5px !important;}
        
    </style>
</head>
<body style="min-width:initial !important;">
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1" />
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="LotteryList.aspx">活动管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>活动编辑</span>  <div style="float:right;">
             <asp:Button ID="btnAdd" runat="server"   CssClass="scbtn" Text="确认保存" OnClick="btnAdd_Click" />
                   <asp:Button ID="btnEdit" runat="server"   CssClass="scbtn" Text="保存" OnClick="SaveAndEdit_Click" />
              </div> </div>
            
            <ajaxToolkit:TabContainer runat="server" ID="LotteryTabs" ActiveTabIndex="0">
                <ajaxToolkit:TabPanel runat="server" ID="pnllotteryInfo" HeaderText="活动信息">
                    <ContentTemplate>
                        <kpt:LotteryInfo ID="ctrlLotteryInfo" runat="server" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" ID="pnlLotteryend" HeaderText="活动结束内容">
                    <ContentTemplate>
                        <kpt:LotteryEndInfo ID="ctrlLotteryEndInfo" runat="server" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" ID="pnlLotteryItem" HeaderText="奖项设置">
                    <ContentTemplate>
                        <kpt:LotteryItemInfo ID="ctrlLotteryItemInfo" runat="server" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer> 
          
        </div> 
    </form>
</body>
</html>

 