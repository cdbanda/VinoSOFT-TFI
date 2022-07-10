<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminVentasEditar.aspx.cs" Inherits="VinoSOFT_TFI.AdminVentasEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
    <br />
    <div class="form-groupclearfix">
        <asp:Button ID="BtnVolver" runat="server" CssClass="btn btn-primary" Text="Volver al listado" OnClick="BtnVolver_Click"/>
    </div>
    <br />
    <asp:HiddenField ID="iptCodigo" runat="server" />
    <div>
        <strong><h3>Editar Venta</h3></strong>
    </div>
    <hr />
    <div class='form-group clearfix'>
        <div class='row'>
            <div class='col-md-2'>
                <strong><label>Cliente:</label></strong>
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
                <strong><label>Monto Total:</label></strong>
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
                <strong><label>Fecha:</label></strong>
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
                <strong><label>Estado:</label></strong>
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
                <br />
                <asp:label runat="server" ID="mjsRedireccion"></asp:label>
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
