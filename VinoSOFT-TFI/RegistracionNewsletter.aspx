<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistracionNewsletter.aspx.cs" Inherits="VinoSOFT_TFI.RegistracionNewsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">

        <div class="page-header">
            <h1>Suscribase a nuestro Newsletter</h1>
        </div>

        <div class="well">Reciba las novedades de nuestra empresa, solo debe registrar su correo electrónico.</div>
        <div class="row">
            <div class="col-md-8 col-md-offset-1">
                <div class="form-horizontal">

                    <div class="form-group">
                        <label for="email" class="col-sm-2 control-label">E-mail</label>
                        <div class="col-sm-6">
                           <asp:TextBox ID="inpAltaEmail" CssClass="form-control" runat="server" MaxLength="320"></asp:TextBox>
                           <asp:RequiredFieldValidator ForeColor="Red"  ID="EmailRequerido" runat="server" ErrorMessage="Campo requerido  (Max 320 caracteres)" ControlToValidate="inpAltaEmail"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="inpAltaEmail" ErrorMessage="Formato de Email inválido"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6 col-sm-offset-2">
                            <h4>Noticias a recibir por correo.</h4>
                            <label>
                                <asp:CheckBoxList ID="checkBoxListReg" runat="server" AutoPostBack="true" SelectionMode="Multiple">
                                    <asp:ListItem Value="Riego">Riego</asp:ListItem>
                                    <asp:ListItem Value="Humedad">Humedad y Temperatura</asp:ListItem>
                                    <asp:ListItem Value="Imagenes">Imagenes con Drones</asp:ListItem>
<%--                                    <asp:ListItem Value="Todos">Seleccionar Todo</asp:ListItem>--%>
                                </asp:CheckBoxList>
                           
                            </label>
                        </div>
                    </div>

                    <hr />
                    <div class="col-sm-6 col-sm-offset-2">
                            <label>
                                <asp:CheckBox ID="chkTyC" CssClass="checkboxTyC" runat="server" />
                                Acepto los <a href="TerminosYCondiciones.aspx">T&eacute;rminos y Condiciones</a>
                                <span runat="server" style="color:red" id="ErrorTyC" visible="false">Debe aceptar los t&eacute;rminos y condiciones.</span>
                                <asp:CustomValidator runat="server" ID="CheckBoxRequired" ForeColor="Red"  EnableClientScript="true" 
                                    OnServerValidate="CheckBoxRequired_ServerValidate"
                                    ClientValidationFunction="CheckBoxRequired_ClientValidate">
                                    Debe aceptar los t&eacute;rminos y condiciones.                                   
                                </asp:CustomValidator>
                            </label>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-9 col-sm-offset-2">
                             <BotDetect:WebFormsCaptcha ID="ExampleCaptcha" runat="server" 
	                            UserInputID="CaptchaCodeTextBox" />
                             <asp:TextBox ID="CaptchaCodeTextBox" runat="server" />
                        </div>
                    </div>

                     <div class="form-group">
                        <div class="col-sm-9 col-sm-offset-2">
                            <asp:Button ID="btnRegistrar" CssClass="btn btn-success" runat="server" Text="Registrarme" OnClick="btnRegistrar_Click" />
                        </div>
                     </div>
                 </div>
            </div>
        </div>
</div>

</asp:Content>
