<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="VinoSOFT_TFI.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="text-align: center">
        <div>
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
    <div class="row">
        <asp:Repeater ID="repeaterProducto" runat="server">
           <ItemTemplate>
               <div>
                   <a class="alert-danger"> Hola</a>
               </div>
           </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
