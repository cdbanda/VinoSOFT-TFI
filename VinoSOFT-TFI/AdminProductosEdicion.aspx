<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminProductosEdicion.aspx.cs" Inherits="VinoSOFT_TFI.AdminProductosEdicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
    <div class="form-group clearfix">
        <a href="AdminProductosLista.aspx" class="btn btn-info pull-left">Volver al Listado</a>
        <a href="AdminProductosEdicion.aspx" class="btn btn-default pull-left">Nuevo</a>
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger pull-right" Visible="false" Text="Eliminar" OnClick="btnEliminar_Click" />
    </div>
    <asp:HiddenField ID="iptCodigo" runat="server" />
    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Nombre: </label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="iptNombre" runat="server" ClientIDMode="Static" required="required" CssClass="form-control" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator_Nombre" ControlToValidate="iptNombre" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Descripción: </label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="iptDescripcion" runat="server" ClientIDMode="Static" required="required" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator_Descripcion" ControlToValidate="iptDescripcion" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Descripción corta: </label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="iptDescripcionCorta" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Categoría: </label>
            </div>
            <div class="col-md-11">
                <asp:DropDownList id="ddCategoria" runat="server" CssClass="form-control" ClientIDMode="Static" required="required" 
                    AutoPostBack="true" AppendDataBoundItems="true">
                    <asp:ListItem Value="">Seleccione una categoría</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Categoria" ForeColor="Red" ControlToValidate="ddCategoria" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Stock: </label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="iptStock" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Stock Mínimo: </label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="iptStockMinimo" runat="server" ClientIDMode="Static" required="required" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator_iptStockMinimo" ControlToValidate="iptStockMinimo" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Precio: </label>
            </div>
            <div class="col-md-11">
                <asp:TextBox ID="iptPrecio" runat="server" ClientIDMode="Static" required="required" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator_iptPrecio" ControlToValidate="iptPrecio" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Foto: </label>
            </div>
            <div class="col-md-11">
                <asp:FileUpload ID="iptFoto" runat="server"  />
                <br />
                <asp:Image ID="imgFotoSubida" width="200" Height="200" runat="server" />
            </div>
        </div>
    </div>
    <!-- Campo -->

    <!-- Campo -->
    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Activo: </label>
            </div>
            <div class="col-md-11">
                <asp:DropDownList id="ddActivo" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <!-- Campo -->

    <div class="form-group clearfix">
        <a href="AdminProductosLista.aspx" class="btn btn-info pull-left">Volver al Listado</a>
        <input type="reset" class="btn btn-warning pull-left" name="cancelar" value="Cancelar" />
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click"/>
    </div>

</asp:Content>
