<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarNoticia.aspx.cs" Inherits="VinoSOFT_TFI.EditarNoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h3>Editar Noticia
                </h3>
                <div class="form-group">
                    <label>Titulo de la Noticia</label>
                    <asp:TextBox ID="TxtTitulo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red"  ID="TituloRequerido" runat="server" 
                        ErrorMessage="Campo requerido  (Max 320 caracteres)" 
                        ControlToValidate="TxtTitulo"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Categoria</label>
                    <asp:DropDownList ID="DDCategorias" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <asp:Label ID ="LblFechaCreacion" Text="Fecha Creacion" runat="server"> <asp:TextBox ID="TxtFechaCreacion" runat="server" Enabled="false"></asp:TextBox></asp:Label>
                </div>

                <div class="form-group">
                    <asp:Label ID ="LblFechaModificacion" Text="Fecha Modificacion" runat="server"> <asp:TextBox ID="TxtFechaModificacion" runat="server" Enabled="false"></asp:TextBox></asp:Label>
                </div>
                <div class="form-group">
                    <asp:CheckBox ID="ChkHabilitado" runat="server" Text="Habilitado" />
                </div>
                <asp:HiddenField ID="HFIdNoticia" runat="server" Value="" />
                

                <div class="form-group">
                    <asp:TextBox ID="txtEditor" TextMode="MultiLine" runat="server" Width="500" Height="400" />
                    <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server"
                        TargetControlID="txtEditor">
                    </ajaxToolkit:HtmlEditorExtender>
                    <div class="form-group">
                        <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="btnVolver_Click" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" onclick="btnGuardar_Click"/>
                        <asp:Button ID="BtnPrevisua" runat="server" Text="Previsualizar" CssClass="btn btn-warning" OnClick="BtnPrevisua_Click" />
                    </div>
                    <div >
                        <hr />
                        <asp:Literal ID="LiteralHTML" runat="server"></asp:Literal>
                    </div>
<%--                    <div class="form-group">
                        <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-light" />
                    </div>--%>
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


</asp:Content>
