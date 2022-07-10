<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="VinoSOFT_TFI.Pagar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Confirmar Compra</h2>
        <hr />

        <div>
            <h3>Datos de cliente: </h3>
            <hr />
            <div>
                <strong><label>Nombre: </label></strong>
                <asp:Literal ID="ltlNombreCliente" runat="server"></asp:Literal>
            </div>
            <div>
                <strong><label>DNI: </label></strong>
                <asp:Literal ID="ltlDNICliente" runat="server"></asp:Literal>
            </div>
            <div>
                <strong><label>Dirección: </label></strong>
                <asp:Literal ID="ltlDireccionCliente" runat="server"></asp:Literal>
            </div>
            <div>
                <strong><label>Teléfono: </label></strong>
                <asp:Literal ID="ltlTelefonoCliente" runat="server"></asp:Literal>
            </div>
        </div>
        <br />
        <div>
            <h3>Datos de la compra: </h3>
        </div>

        <div class="block full">
                <div class="table-responsive">
                    <div style="border-top: 1px solid black;"></div>
                    <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" BorderStyle="None"
                        CssClass="table table-striped table-hover" GridLines="None" PagerStyle-HorizontalAlign="Right">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="idVentaDetalle" runat="server" Value='<%# (Container.DataItem as BE.BE_Venta_Detalle).IDVENTADETALLE %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Imagen">
                                <ItemTemplate>
                                    <asp:Image ID="Imagen" runat="server" Width="150" Height="150" ImageUrl='<%# (Container.DataItem as BE.BE_Venta_Detalle).PRODUCTO.IMAGEN %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Producto">
                                <ItemTemplate>
                                    <h4>
                                        <asp:Label ID="lblNombreProducto" runat="server" Text='<%# (Container.DataItem as BE.BE_Venta_Detalle).PRODUCTO.NOMBRE %>'></asp:Label></h4>
                                    <p>
                                        <asp:Label ID="lblDescProcducto" runat="server" Text='<%# (Container.DataItem as BE.BE_Venta_Detalle).PRODUCTO.DESCRIPCIONCORTA %>'></asp:Label>
                                    </p>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio">
                                <ItemTemplate>
                                    <asp:Label ID="lblSignoPesosPrecio" runat="server" Text="$ "></asp:Label>
                                    <asp:Label ID="lblPrecio" runat="server" Text='<%# (Container.DataItem as BE.BE_Venta_Detalle).MONTO %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidad" runat="server" Text='<%# (Container.DataItem as BE.BE_Venta_Detalle).CANTIDAD %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtotal">
                                <ItemTemplate>
                                    <asp:Label ID="lblSignoPesosSubtotal" runat="server" Text="$ "></asp:Label>
                                    <asp:Label ID="lblSubtotal" runat="server" Text='<%# (Container.DataItem as BE.BE_Venta_Detalle).SUBTOTAL %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 </div>
            </div>
        
        <hr />
        <h3>Total a pagar $: <asp:Literal ID="ltlTotal" runat="server" Text=""></asp:Literal></h3>
        <hr />
        <div>
            <asp:Button ID="btnSeguirComprando" runat="server" CssClass="btn btn-primary" text="Seguir Comprando" OnClick="btnSeguirComprando_Click"/>
            <asp:Button ID="btnConfirmar" runat="server" CssClass="btn btn-success" Text="Pagar" OnClick="btnConfirmar_Click"/>
        </div>

        <strong style="color:red" class="h3"><asp:Literal ID="ltlErrorStock" runat="server" Visible="false" Text=""></asp:Literal></strong>
    </div>

<asp:HiddenField ID="hidForModel" runat="server" />

<!-- ModalPopUpRestore -->
<ajaxtoolkit:ModalPopupExtender ID="mp1" runat="server" 
    PopupControlID="ModalPanel" 
    TargetControlID="hidForModel"
    BackgroundCssClass="modalBackground"
    BehaviorID="PopUp"
    >
</ajaxtoolkit:ModalPopupExtender>

<asp:Panel ID="ModalPanel" runat="server" CssClass="modal-content modal-sm" Style="display:none">
    <asp:UpdatePanel ID="UpdateModalPopUp" runat="server">
        <ContentTemplate>
            <div id="body" class="modal-body">
                 <asp:label runat="server" ID="mjsBodyMP"></asp:label>
                <br />
                <asp:label runat="server" ID="mjsRedireccion"></asp:label>
            </div>
            <div id="footer" class="modal-footer">
                <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="btn-success" onclick="BtnOk_Click"
                    />
            </div>
        </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnOK" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Panel>

<!-- ModalPopupRestore -->
</asp:Content>
