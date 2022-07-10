<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminProductosEdicion.aspx.cs" Inherits="VinoSOFT_TFI.AdminProductosEdicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
    <div class="form-group clearfix">
        <a href="AdminProductosLista.aspx" class="btn btn-info">Volver al Listado</a>
        <a href="AdminProductosEdicion.aspx" class="btn btn-primary pull-left">Nuevo</a>
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Visible="false" Text="Eliminar" OnClick="btnEliminar_Click" />
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
                <asp:RequiredFieldValidator id="RequiredFieldValidator_Nombre" ControlToValidate="iptNombre" runat="server" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator id="RequiredFieldValidator_Descripcion" ControlToValidate="iptDescripcion" runat="server" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator id="RequiredFieldValidator_iptStock" ForeColor="Red" ControlToValidate="iptStock" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rangeValidator_iptStock" runat="server" ForeColor="Red" ErrorMessage="El número tiene que en el rango de 0 a 100"
                     ControlToValidate="iptStock" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
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
                <asp:RequiredFieldValidator id="RequiredFieldValidator_iptStockMinimo" ForeColor="Red" ControlToValidate="iptStockMinimo" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rangeValidator_iptStockMinimo" runat="server" ForeColor="Red" ErrorMessage="El número tiene que en el rango de 0 a 5"
                     ControlToValidate="iptStockMinimo" MaximumValue="5" MinimumValue="0" Type="Integer"></asp:RangeValidator>
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
                <asp:RequiredFieldValidator id="RequiredFieldValidator_iptPrecio" ForeColor="Red" ControlToValidate="iptPrecio" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rangeValidator_iptPrecio" runat="server" ForeColor="Red" ErrorMessage="El precio tiene que en el rango de 0 a 2000000"
                     ControlToValidate="iptPrecio" MaximumValue="2000000" MinimumValue="0" Type="Double"></asp:RangeValidator>
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
        <a href="AdminProductosLista.aspx" class="btn btn-info">Volver al Listado</a>
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click"/>
    </div>

<asp:HiddenField ID="hidForModel" runat="server" />

<!-- ModalPopUpRestore -->
<ajaxtoolkit:ModalPopupExtender ID="mp1" runat="server" 
    PopupControlID="ModalPanel" 
    TargetControlID="hidForModel"
    BackgroundCssClass="modalBackground"
    BehaviorID="PopUp"
    >
</ajaxtoolkit:ModalPopupExtender>

<asp:Panel ID="ModalPanel" runat="server" CssClass="modal-content modal-sm" Style="display:none">
    <asp:UpdatePanel ID="UpdateModalPopUp" runat="server">
        <ContentTemplate>
            <div id="body" class="modal-body">
                 <asp:label runat="server" ID="mjsBodyMP"></asp:label>
            </div>
            <div id="footer" class="modal-footer">
                <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="btn-success" onclick="BtnOk_Click"
                    />
            </div>
        </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnOK" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Panel>

<!-- ModalPopupRestore -->
</asp:Content>
