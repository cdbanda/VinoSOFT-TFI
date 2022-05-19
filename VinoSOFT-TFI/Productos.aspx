<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="VinoSOFT_TFI.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

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

    <div class="row">
        <p>productos:</p>
        <asp:Repeater ID="repeaterProducto" runat="server">
           <ItemTemplate>
               <div class="col-sm-4 col-lg-4 col-md-4">
                   <div class="">
                       <asp:Image ID="imgProd" ImageUrl="/Publicidad/img/thumb/drone_thumb.jpg" runat="server" />
                       <h4 class="pull-right">$ 1000</h4>
                       <h4><a href="">Producto Ampliado</a>
                           <asp:Literal ID="ltlNombre" runat="server" Text="Dron"></asp:Literal>
                       </h4>
                       <h6>
                           <asp:literal  ID="ltlCate" runat="server" Text="Categoria"></asp:literal>
                       </h6>
                       <p>
                           <asp:Literal ID="ltlDescCorta" runat="server" Text="descripcion corta"></asp:Literal>
                       </p>
                   </div>
               </div>
           </ItemTemplate>

        </asp:Repeater>
    </div>



</asp:Content>
