<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminProductosLista.aspx.cs" Inherits="VinoSOFT_TFI.AdminProductosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <strong>
                <asp:literal ID="ltlProductos" runat="server">Productos</asp:literal>
            </strong>
            <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-primary pull-right" Text="Nuevo" OnClick="btnNuevo_Click" />     
        </div>

        <div class="block full">
            <div style="border-top: 1px solid black"></div>
            <asp:GridView ID="dgvProductos" runat="server" AllowSorting="true" AutoGenerateColumns="false" BorderStyle="None" CssClass="table table-striped table-hover" AllowPaging="true"
                gridlines="None" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="dgvProductos_PageIndexChanging" OnPageIndexChanged="dgvProductos_PageIndexChanged" PageSize="15"
                 OnRowEditing="dgvProductos_RowEditing" OnRowDeleting="dgvProductos_RowDeleting" >
                <Columns>
                    <asp:BoundField DataField="idProducto" headertext="Código" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Categoria.Nombre" Headertext="Categoria" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:CommandField ShowEditButton="true" EditText="Editar" ControlStyle-CssClass="btn btn-xs btn-secondary" HeaderText="Editar" />
                    <asp:CommandField ShowDeleteButton="true" EditText="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" HeaderText="Eliminar" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
