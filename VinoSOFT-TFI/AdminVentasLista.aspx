<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminVentasLista.aspx.cs" Inherits="VinoSOFT_TFI.AdminVentasLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
     <div class="content-header">
        <div class="header-section">
            <h3>
                <strong>Ventas</strong>
                <!-- <a href="AdminVentasEditar.aspx" class="btn btn-primary pull-right">Nuevo</a><br /> -->
            </h3>
        </div>
    </div>

    <div>
        <div>
            <div style="border-top: 1px solid black;"></div>
            <asp:GridView ID="dgvVentas" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None" CssClass="table table-striped table-hover" 
                AllowPaging="True" GridLines="None" PagerStyle-HorizontalAlign="Right" OnPageIndexChanging="dgvVentas_PageIndexChanging" OnPageIndexChanged="dgvVentas_PageIndexChanged"
                OnRowEditing="dgvVentas_RowEditing" 
                ize="15">
                <Columns>
                    <asp:BoundField DataField="IdVenta" HeaderText="Codigo" />
                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="MontoTotal" HeaderText="Monto" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" ControlStyle-CssClass="label label-default" />
                    <asp:CommandField ShowEditButton="True" EditText="Editar" ControlStyle-CssClass="btn btn-xs btn-warning" HeaderText="Editar"  />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
