<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUsuariosLista.aspx.cs" Inherits="VinoSOFT_TFI.AdminUsuariosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header-section">
        <h3>
            <strong>
                <asp:Literal ID="ltlUsuarios" runat="server" Text="Usuarios"></asp:Literal>
            </strong>
            <a href="AdminUsuariosEditar.aspx" class="btn btn-primary pull-right">
                <asp:Literal ID="ltlNuevo" runat="server" Text="Nuevo"></asp:Literal>
            </a>
        </h3>
    </div>

    <div class="block full">
        <div class="table-responsive">
            <div style="border-top: 1px solid black;"></div>
            <asp:GridView ID="dgvUsuarios" runat="server" AllowSorting="true" AutoGenerateColumns="false" BorderStyle="None"
                CssClass="table table-striped table-hover" AllowPaging="true" GridLines="None" PagerStyle-HorizontalAlign="Right"
                OnPageIndexChanging="dgvUsuarios_PageIndexChanging" OnPageIndexChanged="dgvUsuarios_PageIndexChanged"
                PageSize="15" OnRowEditing="dgvUsuarios_RowEditing" OnRowDeleting="dgvUsuarios_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="IdUsuario" HeaderText="Codigo" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                    <asp:CommandField ShowEditButton="true" EditText="Editar" ControlStyle-CssClass="btn btn-xs btn-warning" HeaderText="Editar" />
                    <asp:CommandField ShowDeleteButton="true" EditText="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" HeaderText="Eliminar" />

                </Columns>
            </asp:GridView>
        </div>

    </div>


</asp:Content>
