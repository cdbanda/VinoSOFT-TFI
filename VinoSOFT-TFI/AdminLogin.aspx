<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="VinoSOFT_TFI.AdminLogin" %>
<%@ Register Src="~/CU_UsuarioPass.ascx" TagName="UsuarioPass" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headBackend" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoBackendMasterPage" runat="server">
   <hr >

   <div class="container col-xs-12 col-md-12 text-center">
        <div class="row justify-content-center">
            <div class="col-md-4 col-md-offset-4">
                <div class="text-center">
                    <h2>Portal de Admininstración</h2>
                    <p>Use su email y contrase&ntilde;a para iniciar sesion.</p>
                </div>

                <uc:UsuarioPass ID="UCUsuarioPass" runat="server"></uc:UsuarioPass>

                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="text-center">
                                <asp:Button ID="btnLoginPage" runat="server" Text="Ingresar" TabIndex="3" CssClass="form-control btn btn-success" OnClick="btnLoginPage_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            
            </div>
        </div>
    </div>
</asp:Content>
