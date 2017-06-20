<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs" Inherits="KuanPT_NF.Modules.DatePicker" %>

<asp:TextBox runat="server" ID="txtDateTime"  CssClass="dfinput"  style="width:120px;"/>
<asp:ImageButton runat="Server" ID="btnCalendar" ImageUrl="~/images/Calendar_scheduleHS.png" AlternateText="显示日期" />
<br />
<ajaxToolkit:CalendarExtender runat="server" ID="ajaxCalendar" TargetControlID="txtDateTime" PopupButtonID="btnCalendar" /> 