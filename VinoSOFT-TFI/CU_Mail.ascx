<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CU_Mail.ascx.cs" Inherits="VinoSOFT_TFI.CU_Mail" %>
                    <div class="form-group">
                        <label>E-mail</label>
                        <div>
                           <asp:TextBox ID="inpEnviarEmail" CssClass="form-control" runat="server" MaxLength="320"></asp:TextBox>
                           <asp:RequiredFieldValidator ForeColor="Red"  ID="EmailRequerido" runat="server" ErrorMessage="Campo requerido  (Max 320 caracteres)" ControlToValidate="inpEnviarEmail"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="inpEnviarEmail" ErrorMessage="Formato de Email inválido"></asp:RegularExpressionValidator>
                        </div>
                    </div>