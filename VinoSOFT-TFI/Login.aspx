<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VinoSOFT_TFI.Login" %>
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

                <div class="form-group">
                    <label>Usuario</label>
                    <asp:TextBox ID="txtBoxUserName" runat="server" TabIndex="1" CssClass="form-control" placeholder="Usuario"
                        MaxLength="20" AutoComplete="off"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Contrase&ntilde;a</label>
                    <asp:TextBox ID="txtBoxPassword" runat="server" TabIndex="2" CssClass="form-control" placeholder="Contrase&ntilde;a"
                        MaxLength="20" AutoComplete="off" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="text-center">
                                <asp:Button ID="btnLoginPage" runat="server" Text="Ingresar" TabIndex="3" CssClass="form-control btn btn-success" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-6">
                        <div class="text-center">
                            <a href="#" tabindex="4">&iquest;Olvid&oacute; su contrase&ntilde;a?</a>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
