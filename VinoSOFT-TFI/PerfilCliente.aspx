<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilCliente.aspx.cs" Inherits="VinoSOFT_TFI.PerfilCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-md-3 col-md-5">
            <h3>Mis Datos</h3>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-8">
            <div class="">
                <div class="form-group">
                    <asp:HiddenField ID="iptIdUsuario" runat="server" />
   <%--                 <label class="col-sm-3">Email: </label>
                    <div class="col-sm-9">
                    <asp:TextBox ID="iptEmail" CssClass="form-control" ClientIDMode="Static" runat="server" MaxLength="320"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredFieldValidator_iptEmail" runat="server" ForeColor="Red" ErrorMessage="Campo Requerido" ControlToValidate="iptEmail"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regularExpressionValidator_iptEmail" runat="server" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="iptEmail" ErrorMessage="Formato de Email inválido"></asp:RegularExpressionValidator>
                    </div>
                    </div>--%>
                 <div class="form-group">
                        <label class="col-sm-3">Usuario: </label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="iptUsuario" CssClass="form-control" runat="server" MaxLength="100" ReadOnly="True" Enabled="False"></asp:TextBox>
                       </div>
                 </div>
                <div class="form-group">
                        <label for="iptContrasenia" class="col-sm-3">Contrase&ntilde;a *</label>
                        <div class="col-sm-9">
                           <asp:Button id="btnCambiarContrasenia" ClientIDMode="Static" runat="server" CssClass="btn btn-warning" OnClick="btnCambiarContrasenia_Click" Text="Cambiar Contrase&ntilde;a"/>
                        </div>
                 </div>
                <div class="form-group">
                        <label for="iptNombre" class="col-sm-3">Nombre *</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="iptNombre" ClientIDMode="Static" required="required" class="form-control" MaxLength="30" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreRequerido" runat="server" ForeColor="red" ErrorMessage="Campo requerido" ControlToValidate="iptNombre"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="iptApellido" class="col-sm-3">Apellido *</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="iptApellido" ClientIDMode="Static" required="required" class="form-control" MaxLength="30" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ApellidoRequerido" runat="server" ForeColor="red" ErrorMessage="Campo requerido" ControlToValidate="iptApellido"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="iptCuitDNI" class="col-sm-3">D.N.I.</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="iptDNI" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RequiredFieldValidator_iptDNI" ForeColor="Red" ControlToValidate="iptDNI" runat="server" ErrorMessage="Campo Requerido"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rangeValidator_iptStock" runat="server" ForeColor="Red" ErrorMessage="El número tiene que ser válido."
                     ControlToValidate="iptDNI" MaximumValue="99999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="iptTelefono" class="col-sm-3" >Tel&eacute;fono</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="iptTelefono" runat="server" ClientIDMode="Static" MaxLength="15" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                     <div class="form-group">
                        <label for="iptDomicilio" class="col-sm-3">Domicilio</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="iptDomicilio" class="form-control" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_iptDomicilio" runat="server" ForeColor="red" ErrorMessage="Campo requerido" ControlToValidate="iptDomicilio"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="iptCiudad" class="col-sm-3">Ciudad</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="iptCiudad" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator_iptCiudad" runat="server" ForeColor="red" ErrorMessage="Campo requerido" ControlToValidate="iptCiudad"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-3">
                            <asp:Button ID="btnModificarDatos" class="btn btn-success" runat="server" Text="Guardar" OnClick="btnModificarDatos_Click" />
                        </div>
                    </div>

            </div>
        </div>
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
