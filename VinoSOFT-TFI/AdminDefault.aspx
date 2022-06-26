<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="VinoSOFT_TFI.AdminDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
    <div class="jumbotron">
        <h1>Bienvenido <asp:Literal ID="nombreEmpleado" runat="server"></asp:Literal> </h1>
        <p>Esta plataforma le permitirá gestionar los distintos modulos del sistema.</p>
    </div>
</asp:Content>
