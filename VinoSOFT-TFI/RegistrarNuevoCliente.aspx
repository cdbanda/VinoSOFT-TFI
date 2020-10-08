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

                <uc:Mail ID="UC_Mail" runat="server"></uc:Mail>

                <div class="form-group">
                    <label>Contrase&ntilde;a</label>
                    <asp:TextBox ID="txtBoxPassword" runat="server" TabIndex="2" CssClass="form-control" placeholder="Contrase&ntilde;a"
                        MaxLength="20" AutoComplete="off" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Repita Contrase&ntilde;a</label>
                    <asp:TextBox ID="txtBoxRepContrasena" runat="server" TabIndex="3" CssClass="form-control" placeholder="Repita Contrase&ntilde;a"
                        MaxLength="20" AutoComplete="off" TextMode="Password"></asp:TextBox>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="text-center">
                                <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" TabIndex="4" CssClass="form-control btn btn-success" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
