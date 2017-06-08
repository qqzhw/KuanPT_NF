<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampaignAdd.aspx.cs" Inherits="KuanPT_NF.m_kdO2O.CampaignAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:FileUpload ID="uploadImg" runat="server" ToolTip="请选择图片上传" />
        </div>
        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="上传" />
    </form>
</body>
</html>
