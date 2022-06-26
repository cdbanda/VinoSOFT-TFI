<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminFamiliasEdicion.aspx.cs" Inherits="VinoSOFT_TFI.AdminFamiliasEdicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">


    <div class="form-group  clearfix">
        <a href="AdminFamiliasLista.aspx" class="btn btn-info pull-left">Volver al Listado</a>
        <a href="AdminFamiliasEdicion.aspx" class="btn btn-secondary pull-left">Nuevo</a>
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger pull-right" Visible="false" Text="Eliminar" OnClick="btnEliminar_Click" />
    </div>
    
    <asp:HiddenField ID="iptCodigo" runat="server" />

    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-6">
                <label>Nombre:</label>
                <asp:TextBox ID="iptNombre" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                <!-- ver de poner validador-->

            </div>

            <asp:PlaceHolder id="phAsignarFamiliasPermisos" Visible="false" runat="server">
                <div class="row">
                    <div class="col-md-6">
                        <div class="col-md-12"><label>Asignar Permisos</label></div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddPermisos" CssClass="form-control" AppendDataBoundItems="true" runat="server" ValidationGroup="vgAgregarPermiso">
                                <asp:ListItem Enabled="true" Selected="True" Value="">Seleccione...</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_ddPermisos" runat="server" ErrorMessage="Campo requerido" ControlToValidate="ddPermisos" ValidationGroup="vgAgregarPermisos"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnAgregarPermiso" OnClick="BtnAgregarPermiso_Click" runat="server" CssClass=" btn btn-sm btn-warning" Text="Agregar" ValidationGroup="vgAgregarPermiso" />
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="dgvPermisos" OnRowDeleting="dgvPermisos_RowDeleting" CssClass="table table-hover table-bordered" BorderStyle="None" Itemtype="BE_Permiso" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="idPermiso" HeaderText="Codigo" ReadOnly="true" SortExpression="idPermiso"></asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Nombre" ReadOnly="true" SortExpression="Descripcion"></asp:BoundField>
                                    <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" ControlStyle-BorderStyle="None" headertext="Eliminar" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

        </div>
    </div>

    <div class="form-group clearfix">
         <a href="AdminFamiliasLista.aspx" class="btn btn-info pull-left">Volver al Listado</a>
        <input type="reset" class="btn btn-warning pull-left" name='guardar' value="Cancelar" />
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" />
    </div>

</asp:Content>
