<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoCliente.aspx.cs" Inherits="VinoSOFT_TFI.CarritoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <table>
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Precio</th>
                    <th>Cantidad</th>
                    <th>Subtotal</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptItemsCarrito" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <h5>Producto</h5>
                            </td>
                            <td>
                                <h5>cantidad</h5>
                            </td>
                            <td>
                                <h5>subtotal</h5>
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td class="text-center"><strong>Total </strong></td>
                </tr>
                <tr>
                    <td><a href="Productos.aspx" class="btn btn-warning"><i class="fa fa-angle-left"></i> Continuar comprando</a></td>
                    <td colspan="2"></td>
                    <td class="text-center"><strong>Total $<span id="total"></span></strong></td>
                    <td><a href="Pagar.aspx" class="btn btn-success btn-block">Comprar <i class="fa fa-angle-right"></i></a></td>
                </tr>
            </tfoot>
        </table>

    </div>
</asp:Content>
