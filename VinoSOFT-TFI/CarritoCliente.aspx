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
                                <h4><%# %></h4>
                            </td>
                            <td>
                                $<%# %>
                            </td>
                            <td>
                                $<%# %>
                            </td>
                            <td>
                                $<%# %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

    </div>
</asp:Content>
