<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="VinoSOFT_TFI.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">

        <div class="page-header">
            <h1>Contactenos</h1>
        </div>

        <div class="well">Si tiene alguna consulta sobre nuestros productos y servicios, complete el siguiente formulario y le responderemos a la brevedad.</div>
        <div class="row">
            <div class="col-md-8 col-md-offset-3">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label for="email" class="col-sm-2 control-label">E-mail</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="iptEmail" CssClass="form-control" runat="server" MaxLength="320"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="EmailRequerido" runat="server" ErrorMessage="Campo requerido  (Max 320 caracteres)" ControlToValidate="iptEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="iptEmail" ErrorMessage="Formato de Email inválido"></asp:RegularExpressionValidator>
                        </div>

                    </div>
                    <div class="form-group">
                        <label for="name" class="col-sm-2 control-label">Nombre</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="iptNombre" CssClass="form-control" MaxLength="50" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="NombreRequerido" runat="server" ErrorMessage="Campo requerido  (Max 10 caracteres)" ControlToValidate="iptNombre"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="name" class="col-sm-2 control-label">Mensaje</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="iptMensaje" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-6">
                            <asp:Button ID="btnEnviar" CssClass="btn btn-success" runat="server" Text="Enviar" OnClick="btnEnviar_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
