<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUsuariosEditar.aspx.cs" Inherits="VinoSOFT_TFI.AdminUsuariosEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group clearfix">
        <a href="AdminUsuariosLista.aspx" class="btn btn-info pull-left">Volver al Listado</a>
        <a href="AdminUsuariosEditar.aspx" class="btn btn-warning pull-left">Nuevo</a>
        <asp:Button id="btnEliminar" runat="server" CssClass="btn btn-danger pull-right" UseSubmitBehavior="false" Visible="false" Text="Eliminar" />
    </div>
    <asp:HiddenField ID="iptCodigo" runat="server" />

    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Usuario:</label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="iptUsuario" runat="server" ClientIDMode="Static" required="required" MaxLength="150" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="iptUsuario"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-1">
                <label>Contrseña:</label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="iptContrasena" runat="server" ClientIDMode="Static" required="required" MaxLength="15" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="iptContrasena"></asp:RequiredFieldValidator>

                <asp:TextBox ID="txtPwdGuardada" Visible="false" Enabled="false" CssClass="form-control" ReadOnly="true" value="*********" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Nombre:</label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="iptNombre" runat="server" ClientIDMode="Static" required="required" MaxLength="30" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="iptNombre"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-1">
                <label>Apellido:</label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="iptApellido" runat="server" ClientIDMode="Static" required="required" MaxLength="30" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="iptApellido"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>

    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>Telefono:</label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="iptTelefono" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <label>Email:</label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="iptEmail" runat="server" ClientIDMode="Static" MaxLength="230" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group clearfix">
        <div class="row">
            <div class="col-md-1">
                <label>DNI:</label>
            </div>
            <div class="col-md-5">
                <asp:TextBox ID="iptDNI" runat="server" CssClass="form-control" MaxLength="8" Max="99999999" TextMode="Number"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group clearfix">
		<div class="row">
			<div class="col-md-1">
				<label>Activo:</label>
	    	</div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddActivo" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem Selected="True" value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
            </div>
		</div>
	</div>
    <!-- Lugar para las familias y permisos -->

    <hr />

    <asp:PlaceHolder ID="phAsignarFamiliaPermisos" Visible="true" runat="server">
        <div class="row">
            <div class="col-md-6">
                <div class="col-md-12"><span class="lead">Asignar Roles</span></div>

                    <div class="col-md-10">
                        <asp:DropDownList ID="ddFamilias" CssClass="form-control" runat="server" AppendDataBoundItems="true" ValidationGroup="vgAgregarFamilia">
                            <asp:ListItem Enabled="true" Selected="True" Value="">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator_ddFamilias" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="ddFamilias"
                            ValidationGroup="vgAgregarFamilia"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2">
                        <asp:Button id="btnAgregarfamilia" OnClick="btnAgregarfamilia_Click" runat="server" CssClass="btn btn-sm btn-warning" Text="Agregar" ValidationGroup="vgAgregarFamilia" />
                    </div>
                    <div class="col-md-12">
                        <asp:GridView ID="dgvFamilias" runat="server" CssClass="table table-hover table-bordered" BorderStyle="None" 
                    ItemType="BE_Familia" AutoGenerateColumns="false" BorderWidth="0" OnRowDeleting="dgvFamilias_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="IdFamilia" HeaderText="Codigo" ReadOnly="true" SortExpression="IdFamilia" ControlStyle-BorderStyle="None" /><asp:BoundField />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="true" SortExpression="Nombre" ControlStyle-BorderStyle="None" /><asp:BoundField />
                            <asp:CommandField ShowDeleteButton="true"   DeleteText="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" ControlStyle-BorderStyle="None" HeaderText="Eliminar" />
                        </Columns>
                    </asp:GridView>
                    </div>
               </div>
            <div class="col-md-6">
                <div class="col-md-12"><span class="lead">Asignar Permisos</span></div>
<%--                <div class="col-md-6">
                    <asp:DropDownList ID="ddPermisos" CssClass="form-control" runat="server" AppendDataBoundItems="true" ValidationGroup="vgAgregarPermiso">
                        <asp:ListItem Enabled="true" Selected="True" Value="">Seleccione...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator_ddPermisos" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="ddPermisos"
                         ValidationGroup="vgAgregarPermiso"></asp:RequiredFieldValidator>
                </div>--%>
<%--                <div class="col-md-4">
                    <asp:DropDownList ID="ddTipoPermiso" CssClass="form-control" runat="server" ValidationGroup="vgAgregarPermiso">
                        <asp:ListItem Value="">Seleccione...</asp:ListItem>
                        <asp:ListItem Value="1">Permitir</asp:ListItem>
                        <asp:ListItem Value="0">Denegar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator_ddTipoPermiso" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="ddTipoPermisos"
                         ValidationGroup="vgAgregarPermiso"></asp:RequiredFieldValidator>
                </div>--%>
<%--                <div class="col-md-2">
                    <asp:Button ID="btnAgregarPermiso" OnClick="btnAgregarPermiso_Click" runat="server" CssClass="btn btn.sm btn-warning" Text="Agregar" ValidationGroup="vgAgregarPermiso" />
                </div>--%>
                <div class="col-md-12">
                    <asp:gridview ID="dgvPermisos" CssClass="table table-hover table-bordered" BorderStyle="None" itemtype="BE_Permiso" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="idPermiso" HeaderText="Codigo" ReadOnly="true" SortExpression="IdPermiso" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Nombre" ReadOnly="true" SortExpression="Descripcion" />
                           <%-- <asp:BoundField DataField="Tipo" HeaderText="Tipo" ReadOnly="true" SortExpression="Tipo" />--%>
<%--                            <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" ControlStyle-CssClass="btn btn-xs btn-danger" ControlStyle-BorderStyle="None" HeaderText="Eliminar" />--%>
                        </Columns>
                    </asp:gridview>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>

    <div class="form-group clearfix">
        <a href="AdminUsuariosLista.aspx" class="btn btn-info pull-left">Volver al Listado</a>
        <input type="reset" class="btn btn-secondary pull-left" name="cancelar" value="Cancelar" />
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" />
    </div>

</asp:Content>

