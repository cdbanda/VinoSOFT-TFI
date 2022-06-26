<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminFamiliasLista.aspx.cs" Inherits="VinoSOFT_TFI.AdminFamiliasLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
    <div>
        <div>
            <strong>
                <asp:literal ID="ltlFamilia" runat="server">Familias</asp:literal>
            </strong>
            <a href="AdminFamiliasEdicion.aspx" class="btn btn-primary pull-right">
                <asp:Literal ID="ltlFamiliaNuevo" runat="server" Text="Nuevo"></asp:Literal>
            </a>        
        </div>

        <div class="block full">
            <div style="border-top: 1px solid black"></div>
            <asp:GridView ID="dgvFamilias" runat="server" AllowSorting="true" AutoGenerateColumns="false" BorderStyle="None" CssClass="table table-striped table-hover" AllowPaging="true"
                gridlines="None" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="dgvFamilias_PageIndexChanging" OnPageIndexChanged="dgvFamilias_PageIndexChanged" PageSize="15"
                 OnRowEditing="dgvFamilias_RowEditing" >
                <Columns>
                    <asp:BoundField DataField="idFamilia" headertext="Código" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:CommandField ShowEditButton="true" EditText="Editar" ControlStyle-CssClass="btn btn-xs btn-secondary" HeaderText="Editar" />
                    <asp:CommandField ShowDeleteButton="true" EditText="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" HeaderText="Eliminar" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
