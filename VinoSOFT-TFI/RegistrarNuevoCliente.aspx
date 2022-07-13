<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarNuevoCliente.aspx.cs" Inherits="VinoSOFT_TFI.RegistrarNuevoCliente" %>
<%@ Register Src="~/CU_Mail.ascx" TagName="Mail" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-xs-12 col-md-12 text-center">
        <div class="row justify-content-center">
            <div class="col-md-4 col-md-offset-4">
                <div class="text-center">
                    <h2>Regístrese</h2>
                    <p>Ingrese un email y contrase&ntilde;a para poder registrarse.</p>
                </div>

                <div class="form-group">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtBoxNombre" runat="server" TabIndex="1" CssClass="form-control" placeholder="Nombre"
                        MaxLength="20" AutoComplete="off"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Apellido</label>
                    <asp:TextBox ID="txtBoxApellido" runat="server" TabIndex="2" CssClass="form-control" placeholder="Apellido"
                        MaxLength="20" AutoComplete="off"></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <label>DNI</label>
                    <asp:TextBox ID="txtBoxDNI" runat="server" TabIndex="3" CssClass="form-control" placeholder="Documento"
                        MaxLength="20" AutoComplete="off"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Teléfono</label>
                    <asp:TextBox ID="txtBoxTelefono" runat="server" TabIndex="4" CssClass="form-control" placeholder="Teléfono"
                        MaxLength="20" AutoComplete="off"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Dirección</label>
                    <asp:TextBox ID="txtBoxDir" runat="server" TabIndex="5" CssClass="form-control" placeholder="Dirección"
                        MaxLength="20" AutoComplete="off"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Ciudad</label>
                    <asp:TextBox ID="txtBoxCiudad" runat="server" TabIndex="6" CssClass="form-control" placeholder="Ciudad"
                        MaxLength="20" AutoComplete="off"></asp:TextBox>
                </div>
                
                <uc:Mail ID="UC_Mail" runat="server" TabIndex="7"></uc:Mail>

                <div class="form-group">
                    <label>Contrase&ntilde;a</label>
                    <asp:TextBox ID="txtBoxContrasena" runat="server" TabIndex="8" CssClass="form-control" placeholder="Contrase&ntilde;a"
                        MaxLength="20" AutoComplete="off" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Repita Contrase&ntilde;a</label>
                    <asp:TextBox ID="txtBoxRepContrasena" runat="server" TabIndex="9" CssClass="form-control" placeholder="Repita Contrase&ntilde;a"
                        MaxLength="20" AutoComplete="off" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group">
                        <div class="col-sm-9 col-sm-offset-2">
                             <BotDetect:WebFormsCaptcha ID="RecuperarCaptcha" runat="server" 
	                            UserInputID="CaptchaCodeTextBox" />
                             <asp:TextBox ID="CaptchaCodeTextBox" runat="server" />
                        </div>
                    </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="text-center">
                                <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" TabIndex="10" CssClass="form-control btn btn-success" 
                                    Onclick="btnRegistrarse_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- ModalPopUpRestore -->
    <asp:HiddenField ID="HiddenMesajes" runat="server" />

    <ajaxToolkit:ModalPopupExtender ID="ModalPopUpMensajes" runat="server"
        PopupControlID="PanelMensajes"
        TargetControlID="HiddenMesajes"
        BackgroundCssClass="modalBackground"
        CancelControlID="BtnCerrar">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelMensajes" runat="server" CssClass="modal-content modal-sm" Style="display: none">
        <div id="bodyMesajes" class="modal-body">
            <asp:Label runat="server" ID="LabelMensaje"></asp:Label>
        </div>
        <div id="footerMensajese" class="modal-footer">
            <asp:Button ID="BtnCerrar" runat="server" Text="Aceptar" CssClass="btn-info" />
        </div>
    </asp:Panel>

<!-- ModalPopupRestore -->


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
                <asp:Button ID="BtnOK" runat="server" Text="OK" CssClass="btn-success" onclick="BtnOk_Click"/>
            </div>
        </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="BtnOK" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Panel>

<!-- ModalPopupRestore -->

</asp:Content>
