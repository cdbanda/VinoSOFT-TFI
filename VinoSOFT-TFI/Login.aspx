<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VinoSOFT_TFI.Login" %>
<%@ Register Src="~/CU_UsuarioPass.ascx" TagName="UsuarioPass" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container col-xs-12 col-md-12 text-center">
        <div class="row justify-content-center">
            <div class="col-md-4 col-md-offset-4">
                <div class="text-center">
                    <h2>Ingresar</h2>
                    <p>Use su email y contrase&ntilde;a para iniciar sesion.</p>
                </div>

                <uc:UsuarioPass ID="UCUsuarioPass" runat="server"></uc:UsuarioPass>
                <div class="text-center">
                    <strong style="color:red;"><asp:literal ID="ltlError" runat="server" text="ERROR" Visible="false"></asp:literal></strong>
                </div>
                <br />
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="text-center">
                                <asp:Button ID="btnLoginPage" runat="server" Text="Ingresar" TabIndex="3" CssClass="form-control btn btn-success" onclick="btnLoginPage_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
<%--                    <div class="col-lg-6">
                        <div class="text-center">
                            <a href="#" tabindex="4">&iquest;Olvid&oacute; su contrase&ntilde;a?</a>
                        </div>
                    </div>--%>
                </div>
                <div class="text-center">
                    <a href="RegistrarNuevoCliente.aspx">Registrarse</a>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
