﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NumericTextBox.ascx.cs" Inherits="KuanPT_NF.Modules.NumericTextBox" %>
<asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="txtValue"
    Font-Name="verdana" Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<asp:RangeValidator ID="rvValue" runat="server" ControlToValidate="txtValue"
    Type="Integer" Display="None"></asp:RangeValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rvValueE" TargetControlID="rvValue"  
    HighlightCssClass="validatorCalloutHighlight" />