<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CambiarContrasenia.aspx.cs" Inherits="VinoSOFT_TFI.CambiarContrasenia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Modificar mi contraseña</h1>
    <div class="row">
        <div class="col-md-6">
            <div>
                <div class="form-group">
                    <label>Contraseña Anterior:</label>
                    <asp:TextBox ID="iptContraseniaAnterior" ClientIDMode="Static" CssClass="form-control" MaxLength="50" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator_iptContraseniaAnterior" ControlToValidate="iptContraseniaAnterior" runat="server" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                 <div class="form-group">
                    <label>Contraseña Nueva:</label>
                    <asp:TextBox ID="iptContraseniaNueva" ClientIDMode="Static" CssClass="form-control" MaxLength="50" TextMode="Password" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator id="RequiredFieldValidator_iptContraseniaNueva" ControlToValidate="iptContraseniaNueva" runat="server" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Repita Contraseña Nueva:</label>
                    <asp:TextBox ID="iptContraseniaNuevaRep" ClientIDMode="Static" CssClass="form-control" MaxLength="50" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator_iptContraseniaNuevaRep" ControlToValidate="iptContraseniaNuevaRep" runat="server" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <h4 style="color:red"><asp:Literal runat="server" ID="ltlError" Text="aaa" Visible="false"></asp:Literal></h4>
                    <h4 style="color:green"><asp:Literal runat="server" ID="ltlOK" Text="aaa" Visible="false"></asp:Literal></h4>
                </div>
                <asp:Button CssClass="btn btn-success btn-lg" ID="btnCambiar" runat="server" Text="Cambiar Contraseña" OnClick="btnCambiar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
