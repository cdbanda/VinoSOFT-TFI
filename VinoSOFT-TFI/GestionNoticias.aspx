<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionNoticias.aspx.cs" Inherits="VinoSOFT_TFI.GestionNoticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2>Gestion Noticias</h2>
    </div>
    <div class="block full">
            <div class="table-responsive">
                <div class="form-group">
                    <asp:LinkButton ID="BtnNueva" runat="server" Text="Nueva Noticia" PostBackUrl="~/EditarNoticia.aspx"
                        CssClass="btn btn-success">
                    </asp:LinkButton>
                </div>
                <asp:UpdatePanel runat="server" ID="updateDGV" UpdateMode="Conditional">
                    <ContentTemplate>
                     
                    <asp:GridView ID="DGVNoticias" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None" 
                    CssClass="table table-striped table-hover" 
                    AllowPaging="True" GridLines="None" 
                    emptydatatext="No Hay datos."
                    OnPageIndexChanging="DGVNoticias_PageIndexChanging"
                    DataKeyNames="Id"
                    PageSize="10">
                    <pagersettings mode="NextPreviousFirstLast"
                        firstpagetext="First"
                        lastpagetext="Last"
                        nextpagetext="Next"
                        previouspagetext="Prev"   
                        position="Bottom"/> 
                      
                    <pagerstyle
                      height="30px"
                      verticalalign="Bottom"
                      horizontalalign="Center"/>

                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="Codigo" />
                        <asp:BoundField DataField="Titulo" HeaderText="Título" />
                        <asp:TemplateField HeaderText="Categoria">
                            <ItemTemplate>
                                <%# Eval("Categoria.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Fechacreacion" HeaderText="Fecha Creacion" />
                        <asp:BoundField DataField="Habilitado" HeaderText="Publicado" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkEditar" runat="server" Text="Editar" 
                                    CssClass="btn btn-success"
                                    PostBackUrl='<%# "~/EditarNoticia.aspx?ID=" + Container.DataItemIndex %>'></asp:LinkButton>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="LinkBorrar" runat="server" Text="Borrar" 
                                    CssClass="btn btn-danger" OnClick="BtnBorrar_Click"
                                    ></asp:Button>
                                </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                 </ContentTemplate>  
<%--                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DgvBackup" EventName="PageIndexChanging" />
                    </Triggers>--%>
            </asp:UpdatePanel>
            </div>
        <div class="form-group">
             <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-light" />
        </div>
        </div>


<asp:HiddenField ID="hidForModel" runat="server" />

<!-- ModalPopupExtender -->
<ajaxtoolkit:ModalPopupExtender ID="mp1" runat="server" 
    PopupControlID="ModalPanel" 
    TargetControlID="hidForModel"
    BackgroundCssClass="modalBackground"
    BehaviorID="PopUp"
    >
</ajaxtoolkit:ModalPopupExtender>

<asp:Panel ID="ModalPanel" runat="server" CssClass="modal-content modal-sm" Style="display:none">
    <asp:UpdatePanel ID="UpdateModalPopUp" runat="server">
        <ContentTemplate>
            <div id="body" class="modal-body">
                 <asp:label runat="server" ID="mjsBodyMP"></asp:label>
                <asp:HiddenField runat="server" ID="HFIdNoticia" />
            </div>
            <div id="footer" class="modal-footer">
                <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="btn-success" onclick="BtnOk_Click"
                    OnClientClick="return HidePopControl()"/>
                <asp:Button id="btnCancel" runat="server" Text="Cancelar" CssClass="btn-danger" onclick="BtnCancel_Click"/>
            </div>
        </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnOK" />
        <asp:PostBackTrigger ControlID="btnCancel" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
<!-- ModalPopupExtender -->

<!-- Script para cerrar el Modal en OK event -->

<script type="text/javascript">
        $(function () {
            $("#btnOK").click(function () {
                HidePopControl();
            })
        });
        function HidePopControl() {
            var modalPopup = $find('PopUp');
            modalPopup.hide();
        }
</script>

</asp:Content>
