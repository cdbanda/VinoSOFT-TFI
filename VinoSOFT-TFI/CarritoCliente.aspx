<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoCliente.aspx.cs" Inherits="VinoSOFT_TFI.CarritoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <section id="seccionHayProductos" runat="server" visible="true">
            <div class="block full">
                <div class="table-responsive">
                    <div style="border-top: 1px solid black;"></div>
                    <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" BorderStyle="None"
                        CssClass="table table-striped table-hover" GridLines="None" PagerStyle-HorizontalAlign="Right"
                        OnRowDeleting="dgvCarrito_RowDeleting"
                        OnRowUpdating="dgvCarrito_RowUpdating">
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
                                    <asp:TextBox ID="txtCantidad" runat="server" Width="50" Text='<%# (Container.DataItem as BE.BE_Venta_Detalle).CANTIDAD %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtotal">
                                <ItemTemplate>
                                    <asp:Label ID="lblSignoPesosSubtotal" runat="server" Text="$ "></asp:Label>
                                    <asp:Label ID="lblSubtotal" runat="server" Text='<%# (Container.DataItem as BE.BE_Venta_Detalle).SUBTOTAL %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Actualizar" ControlStyle-CssClass="btn btn-xs btn-warning" />
                            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" />
                            <%--                            <asp:CommandField ShowEditButton="true" EditText="Actualizar" ControlStyle-CssClass="btn btn-xs btn-warning" HeaderText="" />
                            <asp:CommandField ShowDeleteButton="true" EditText="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" HeaderText="" />--%>
                        </Columns>
                    </asp:GridView>

                    <section id="seccionMjsCliente" runat="server" visible="false">
                        <h3 style="color: red">
                            <asp:Literal ID="ltlMjsCliente" runat="server" Text=""></asp:Literal></h3>
                    </section>

                </div>
                <div class="text-right h4">
                    <asp:Label ID="lblTotal" runat="server" CssClass="font-weight-bold" Text="Total: $"></asp:Label>
                    <asp:Label ID="lblTotalMonto" runat="server" CssClass="font-weight-bold" Text="-"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="btnSeguirComprando" runat="server" Text="Continuar Comprando" CssClass="btn btn-primary text-left" OnClick="btnSeguirComprando_Click" />
                    <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-success pull-right" OnClick="btnPagar_Click" />
                </div>
            </div>
        </section>

        <section id="seccionNoHayProductos" runat="server" visible="false">
            <div class="block full">
                <h3>No hay productos en el Carrito.</h3>
            </div>
        </section>
    </div>
</asp:Content>
