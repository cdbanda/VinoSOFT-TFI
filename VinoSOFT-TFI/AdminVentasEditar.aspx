<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminVentasEditar.aspx.cs" Inherits="VinoSOFT_TFI.AdminVentasEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-groupclearfix">
        <a href="AdminVentasLista.aspx" class="btn btn-info pull-right">Volver al listado</a>
    </div>
    <asp:HiddenField ID="iptCodigo" runat="server" />

    <div class='form-group clearfix'>
        <div class='row'>
            <div class='col-md-2'>
                <label>Cliente:</label>
            </div>
            <div class='col-md-9'>
                <span class="form-control-static">
                    <asp:Literal ID="ltlCliente" runat="server"></asp:Literal></span>
            </div>
        </div>
        <!-- /row -->
    </div>
    <div class='form-group clearfix'>
        <div class='row'>
            <div class='col-md-2'>
                <label>Monto Total:</label>
            </div>
            <div class='col-md-9'>
                <span class="form-control-static">
                    <asp:Literal ID="ltlMontoTotal" runat="server"></asp:Literal></span>
            </div>
        </div>
        <!-- /row -->
    </div>
    <div class='form-group clearfix'>
        <div class='row'>
            <div class='col-md-2'>
                <label>Fecha:</label>
            </div>
            <div class='col-md-9'>
                <span class="form-control-static">
                    <asp:Literal ID="ltlFecha" runat="server"></asp:Literal></span>
            </div>
        </div>
        <!-- /row -->
    </div>
    <div class='form-group clearfix'>
        <div class='row'>
            <div class='col-md-2'>
                <label>Estado:</label>
            </div>
            <div class='col-md-9'>
                <asp:DropDownList ID="ddEstado" runat="server" CssClass="form-control" AutoPostBack="True">
                    <asp:ListItem Value="PAGADA">Pagada</asp:ListItem>
                    <asp:ListItem Value="ENTREGADA">Entregada</asp:ListItem>
                    <asp:ListItem Value="PROCESANDO">Procesando</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <!-- /row -->
    </div>
    <!-- /from-group -->
    <div class="form-group botonera clearfix">
        <input type='reset' class="btn btn-default  pull-left" name='guardar' value='Cancelar' />
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" />
    </div>
        </div>


</asp:Content>
