<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IMCustSys.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<title>德阳移动宽带</title>  
    <link rel="stylesheet" type="text/css" href="/Css/select.css" /> 
	<link rel="stylesheet" type="text/css" href="/Css/style.css" /> 
	<script type="text/javascript" src="/JavaScripts/jquery-1.12.4.js"></script>
	 

</head>

<body style="margin:0px;padding:0px;">
	<form id="form1" runat="server"> 
        <div>
            <div id="leftNav" style="float:left; width:10%;background-color:#C4C6CC;color:white;" >
                <div style="margin-left:20px;margin-top:10px;">
               <ul style="align-content:center;font-size:14px;"> 
                        <li><a href="CampaignList.aspx" target="content" style="color:white;margin-top:5px;">活动管理</a></li>
                  <li><a href="CampaignAdd.aspx" target="content" style="color:white;margin-top:5px;">活动添加</a></li>
                    <li><a href="ChannelList.aspx" target="content" style="color:white;margin-top:5px;">渠道列表</a></li>
                  <li><a href="ChannelAdd.aspx" target="content" style="color:white;margin-top:5px;">渠道添加</a></li>
                    <li><a href="ChannelDataList.aspx" target="content" style="color:white;margin-top:5px;">渠道数据列表</a></li>
                  <li><a href="CategoryList.aspx" target="content" style="color:white;margin-top:5px;">分类列表</a></li>
                       <li><a href="CategoryAdd.aspx" target="content" style="color:white;margin-top:5px;">分类添加</a></li>
                  <li><a href="ShopAdd.aspx" target="content" style="color:white;margin-top:5px;">产品添加</a></li>
                       <li><a href="ShopList.aspx" target="content" style="color:white;margin-top:5px;">产品列表</a></li>
                  <li><a href="OrderList.aspx" target="content" style="color:white;margin-top:5px;">订单列表</a></li>
                     <li><a href="OrderAdd.aspx" target="content" style="color:white;margin-top:5px;">添加订单</a></li>
                        <li><a href="LotteryAdd.aspx" target="content" style="color:white;margin-top:5px;">添加抽奖活动</a></li>
                    <li><a href="LotteryList.aspx" target="content" style="color:white;margin-top:5px;">抽奖列表</a></li>
               </ul>
                    </div>
            </div>
             <div style="float:left;width:90%;height:100%;" >
                   <iframe id="iframepage" name="content" src="ChannelList.aspx" style="width:100%;border:none;" onload="changeFrameHeight()"  scrolling="no" frameborder="0"></iframe>
             </div>
        </div>
        <script type="text/javascript">
            function changeFrameHeight() {
                var ifm = document.getElementById("iframepage");
                ifm.height = document.documentElement.clientHeight - 5;
                var leftNav = document.getElementById("leftNav");
                $("#leftNav").css("height",document.documentElement.clientHeight - 5);
            }
            window.onresize = function () {
                changeFrameHeight();
            }
        </script>
	</form>
</body>
</html>
