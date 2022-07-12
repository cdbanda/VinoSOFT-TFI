<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminFamiliasEdicion.aspx.cs" Inherits="VinoSOFT_TFI.AdminFamiliasEdicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">

    <br />
    <div class="form-group clearfix">
        <a href="AdminFamiliasLista.aspx" class="btn btn-info">Volver al Listado</a>
        <a href="AdminFamiliasEdicion.aspx" class="btn btn-primary">Nuevo Rol</a>
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger pull-right" Visible="false" Text="Eliminar" OnClick="btnEliminar_Click" />
    </div>
    <div class="form-group clearfix">
        <h3>
            <asp:Literal ID="ltlNombrePagina" runat="server">Editar Rol</asp:Literal>
        </h3>
    </div>
    <asp:HiddenField ID="iptCodigo" runat="server" />

    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-6">
                <label>Nombre:</label>
                <asp:TextBox ID="iptNombre" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="iptNombre"></asp:RequiredFieldValidator>
                <!-- ver de poner validador-->

            </div>

            <asp:PlaceHolder id="phAsignarFamiliasPermisos" Visible="false" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <div class="col-md-12"><label>Asignar Permisos</label></div>
                        <div class="col-md-12">
                            <asp:DropDownList ID="ddPermisos" CssClass="form-control" AppendDataBoundItems="true" runat="server" ValidationGroup="vgAgregarPermiso">
                                <asp:ListItem Enabled="true" Selected="True" Value="">Seleccione...</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddPermisos" runat="server" ErrorMessage="Campo requerido" ControlToValidate="ddPermisos" ValidationGroup="vgAgregarPermiso"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnAgregarPermiso" OnClick="BtnAgregarPermiso_Click" runat="server" CssClass=" btn btn-warning" Text="Agregar" ValidationGroup="vgAgregarPermiso" />
                        </div>
                        <label style="color:red"><asp:Literal id="ltlErrorPermiso" runat="server" Visible="false"></asp:Literal></label>
                        <div class="col-md-12">
                            <asp:GridView ID="dgvPermisos" OnRowDeleting="dgvPermisos_RowDeleting" CssClass="table table-hover table-bordered" BorderStyle="None" Itemtype="BE_Permiso" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="idPermiso" HeaderText="Codigo" ReadOnly="true" SortExpression="idPermiso"></asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Nombre" ReadOnly="true" SortExpression="Descripcion"></asp:BoundField>
                                    <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" ControlStyle-CssClass="btn btn-danger" ControlStyle-BorderStyle="None" headertext="Eliminar" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

        </div>
    </div>

    <div class="form-group clearfix">
         <a href="AdminFamiliasLista.aspx" class="btn btn-info">Volver al Listado</a>
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
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
