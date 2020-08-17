<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CU_UsuarioPass.ascx.cs" Inherits="VinoSOFT_TFI.CU_UsuarioPass" %>

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