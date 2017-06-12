<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SimpleTextBox.ascx.cs" Inherits="KuanPT_NF.Modules.SimpleTextBox" %>
<asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="txtValue"   Font-Names="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />
 