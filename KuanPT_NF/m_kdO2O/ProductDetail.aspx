<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.ProductDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<link rel="stylesheet" type="text/css" href="../Content/Styles/bootstrap.min.css" />
	<link rel="stylesheet" type="text/css" href="../Content/Styles/theme.css" />
	<link rel="stylesheet" type="text/css" href="../Content/Styles/animate.css" />
	<link rel="stylesheet" type="text/css" href="../Content/Styles/Search.css" />
	<script type="text/javascript" src="../Scripts/jquery.min.js"></script>
	<script type="text/javascript" src="../Scripts/kendo.mobile.min.js"></script>
	<title>产品详细</title>
</head>
<body>
	<form id="form1" runat="server">
		<div class="row">
			<div class="col-md-12">
				<div class="note note-danger">
					<a href="KdListView.aspx"><span style="font-size: 30px;">〈</span>   </a>
					<div style="text-align: center; width: 100%; margin-top: -32px;">
						<p><span style="font-size: 18px;">产品详细</span></p>
					</div>
				</div>
			</div>
		</div>

		<div class="row widget-row">
			<div class="col-md-12"> 
				<div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 borderedbottom">
					<div class="widget-thumb-wrap row">
						<div class="col-xs-pull-12">
							<div class="widget-thumb-body">
								<div>
									<span class="widget-thumb-title pcenter">
										<img src="../Content/Images/test20.png" /></span>
									<div class="widget-thumb-title pcenter" style="margin-top: 2px;"><span>套餐内容：</span><span style="color: #79ACF2">手机+58</span> </div>
									<div class="widget-thumb-title pcenter"><span>说明：</span><span style="color: red">20M+收视+手机成员1个  ¥78元/月</span></div>								 
								</div>
							</div>
						</div>
					</div>
				</div>			  
			</div>
			<div class="col-md-12"> 
				<div class="widget-thumb widget-bg-color-white text-uppercase  borderedbottom">
					<div class="widget-thumb-wrap">
					  <img src="../Content/Images/chuzhuang.png" alt="" />
						<div style="margin-left:140px;margin-top:-43px;"><span style="font-size:30px;font-weight:800">100元</span></div>
					</div>
				</div> 

			</div>
			<div class="col-md-12"> 
				<div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 borderedbottom">
					<div class="widget-thumb-wrap row"> 
						<div class="col-xs-pull-12">
							<div class="widget-thumb-body" >
							     <img src="../Content/Images/huodongneirong.png" alt="" style="margin-left:10px;"/>
								<div style="margin-left:30px;">
								 <p style="padding-left:16px;padding-right:4px;font-size:14px;font-weight:600; color:#A0A0A0">
								    1.资费说明:全家话费用满108元,20M宽带免费使用，高清收视免费看。								 
							       <br />
									2.设备说明:机顶盒(150元)+光猫免费用。用户退订宽带套餐需退还机顶盒设备；机顶盒副机150元买断。								 
								</p>
								</div>
							
							</div> 
							</div>
						</div>
					</div>
				</div> 
		 
		 <div class="col-md-12"> 
				<div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 borderedbottom">
					<div class="widget-thumb-wrap row"> 
						<div class="col-xs-pull-12">
							<div class="widget-thumb-body" >
							     <img src="../Content/Images/wenxintishi.png" alt="" style="margin-left:10px;"/>
								<div style="margin-left:30px;">
								 <p style="padding-left:16px;padding-right:4px;font-size:14px;font-weight:600; color:#A0A0A0">
								    1、因业务发展较快，掌厅介绍内容仅供参考，尤其涉及设备费及初装费等信息会根据业务发展不定期进行调整，最终以当地工作人员解释为准。 
							       <br />
								   2、不限量套餐变更说明：如用户办理或变更宽带资费，原不限量流量包月套餐将自动取消，且不再恢复。<br />
								   3、因地址覆盖等原因可能会出现无法安装的情况，敬请谅解，我们后续将尽快解决，感谢您的支持。<br />
							       4、协议期为一年。
								</p>
								</div> 
							</div> 
							 
						</div>
					</div>
		 	     </div>
			</div>
				<div class="col-md-12">
				<!-- BEGIN WIDGET THUMB -->
				<div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 bordered" style="background-color:#EFF2FC">
				
					<div class="widget-thumb-wrap row" >  
							<button class="btn blue btn-block">10086电话预约</button> 
					</div>
				</div>
			</div>
	</form>
</body>
</html>
