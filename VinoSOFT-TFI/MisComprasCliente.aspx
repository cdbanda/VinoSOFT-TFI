<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisComprasCliente.aspx.cs" Inherits="VinoSOFT_TFI.ClienteMisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mis compras</h2>
    <hr />


    <div runat="server" id="div_tbl_vtas" visible="false">
        <table class="table table-bordered table-hover table-hover">
            <thead>
                <tr>
                    <th>Fecha</th>
                    <th>Monto</th>
                    <th>Estado</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptVtas" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# (Container.DataItem as BE.BE_Venta).FECHA.ToString()  %></td>
                            <td>$ <%# (Container.DataItem as BE.BE_Venta).MONTOTOTAL %></td>
                            <td ><%# (Container.DataItem as BE.BE_Venta).ESTADO   %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
