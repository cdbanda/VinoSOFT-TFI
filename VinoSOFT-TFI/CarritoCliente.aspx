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
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptItemsCarrito" runat="server">
                    <ItemTemplate>
                     <tr>
                         <td>
                             <div class="row">
                                 <div class="col-sm-2">
                                     <img src="<%# (Container.DataItem as BE.BE_Venta_Detalle).PRODUCTO.LINKIMAGEN %>" width="100" height="100" />
                                 </div>
                                 <div class="col-sm-10">
                                     <h4> <%# (Container.DataItem as BE.BE_Venta_Detalle).PRODUCTO.NOMBRE %></h4>
                                     <p><%# (Container.DataItem as BE.BE_Venta_Detalle).PRODUCTO.DESCRIPCIONCORTA %></p>
                                 </div>
                             </div>
                         </td>
                         <td>$ <%# (Container.DataItem as BE.BE_Venta_Detalle).MONTO %></td>
                         <td>
                             <input type="number" min="1" max="5" id="cant_<%# (Container.DataItem as BE.BE_Venta_Detalle).IDVENTADETALLE %>"
                                 class="form-control text-center" value="<%# (Container.DataItem as BE.BE_Venta_Detalle).CANTIDAD %>" />
                         </td>
                         <td class="text-center">
                             <span data-value="<%# (Container.DataItem as BE.BE_Venta_Detalle).MONTO * (Container.DataItem as BE.BE_Venta_Detalle).CANTIDAD %>">
                             </span>
                         </td>
                         <td>
                             <asp:Button ID="btnEditar" CssClass="btn btn-primary btn-sm" Text="Actualizar" runat="server" />
                             <asp:Button ID="btnEliminar" CssClass="btn btn-danger btn-sm" Text="Eliminar" runat="server" />
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
                    <td><a href="Productos.aspx" class="btn btn-primary"><i class="fa fa-angle-left"></i> Continuar comprando</a></td>
                    <td colspan="2"></td>
                    <td class="text-center"><strong>Total $<span id="total"></span></strong></td>
                    <td><a href="Pagar.aspx" class="btn btn-success btn-block">Comprar <i class="fa fa-angle-right"></i></a></td>
                </tr>
            </tfoot>
        </table>

    </div>
</asp:Content>
