<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="VinoSOFT_TFI.Pagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Confirmar Compra</h2>
        <hr />
        <h3>Total $: </h3><asp:Literal ID="ltlTotal" runat="server" Text=""></asp:Literal>
        <hr />
        <asp:Button ID="btnConfirmar" runat="server" CssClass="btn btn-primary" Text="Pagar" OnClick="btnConfirmar_Click"/>
        <hr />
        <asp:Button ID="btnSeguirComprando" runat="server" CssClass="btn btn-secondary" text="Seguir Comprando" OnClick="btnSeguirComprando_Click"/>
        <asp:Literal ID="ltlErrorStock" runat="server" Visible="false"></asp:Literal>
    </div>
</asp:Content>
