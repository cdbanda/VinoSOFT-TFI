<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesregistracionNewsletter.aspx.cs" Inherits="VinoSOFT_TFI.DesregistracionNewsletter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <asp:Label ID="LblMensaje" runat="server"></asp:Label>
        </div>
        <div class="form-group text-center">
            <asp:Button ID="Btn_Inicio" runat="server" Text="Ir a Inicio" OnClick="BtnInicio_Click" />
        </div>
    </form>
</body>
</html>
