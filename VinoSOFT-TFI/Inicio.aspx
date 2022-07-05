<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="VinoSOFT_TFI.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="jumbotron">
    <div class="container">
      <h1>Bienvenido<asp:label ID="lblNombreCliente" runat="server" Text=""></asp:label> a VinoSOFT</h1>
      <p>Somos una empresa que se dedica a la comercialización de soluciones para el viñedo.</p>
      <p>A través de los productos para el riego, sensores de temperatura y humedad, y de imagenes aereas, permite mejorar la calidad de la uva.</p>
      <p>Nuestras soluciones de alta calidad y enfocados a estas necesidades de negocio, permitira a cada productor tener un control de la plantación y poder ser mas competitivo.</p>

        <div style="text-align: center">
            <asp:UpdatePanel ID="updatePanelAds" runat="server">
                <ContentTemplate>
                    <asp:AdRotator ID="AdRotatorDefault" runat="server"
                        AdvertisementFile="~/Publicidad/publicidad.xml"
                        Height="200px"
                        Width="300px" />
                    <asp:Timer ID="Timer1" Interval="3000" runat="server" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
      </div>
  </div>
</asp:Content>
