<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecuperarContrasena.aspx.cs" Inherits="VinoSOFT_TFI.RecuperarContrasena" %>
<%@ Register TagPrefix="CUMail" TagName="UserMail" Src="~/CU_Mail.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-xs-12 col-md-12 text-center">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="text-center">
                    <h2>Recuperar Contraseña</h2>
                    <p>Ingrese su email para poder continuar con su recuperación.</p>
                </div>

                <div class="form-horizontal">

                    <CUMail:UserMail runat="server" id="CU_Mail"></CUMail:UserMail>

                     <div class="form-group">
                        <div>
                             <BotDetect:WebFormsCaptcha ID="RecuperarCaptcha" runat="server" 
	                            UserInputID="CaptchaCodeTextBox" CssClass="align-self-center" />
                             <asp:TextBox ID="CaptchaCodeTextBox" runat="server"/>
                        </div>
                    </div>

                     <div class="form-group">
                        <div>
                            <asp:Button ID="btnEnviar" CssClass="btn btn-success" runat="server" Text="Enviar" />
                        </div>
                     </div>


                </div>

            </div>
        </div>
    </div>
</asp:Content>
