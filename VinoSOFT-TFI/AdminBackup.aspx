<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminBackup.aspx.cs" Inherits="VinoSOFT_TFI.AdminBackup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <h3 class="text-left">Backups</h3>
                 </div>
            <div class="col-md-8">
            <asp:UpdatePanel runat="server" ID="btnBkpUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:Button ID="buttonBackup" runat="server" 
                CssClass="btn btn-primary pull-right" 
                UseSubmitBehavior="false" Text="Generar nuevo backup" 
                OnClick="Button1_Click" />
            </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="buttonBackup" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <br />
    <div class="block full">
            <div class="table-responsive">
                <asp:UpdatePanel runat="server" ID="updateDGV" UpdateMode="Conditional">
                    <ContentTemplate>
                     
                    <asp:GridView ID="DgvBackup" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderStyle="None" 
                    CssClass="table table-striped table-hover" 
                    AllowPaging="True" GridLines="None" 
                    emptydatatext="No Hay datos."
                    OnPageIndexChanging="DgvBackup_PageIndexChanging"
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
                        <asp:BoundField DataField="IdBackup" HeaderText="Codigo" />
                        <asp:BoundField DataField="Ruta" HeaderText="Ruta" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    </Columns>
                </asp:GridView>
                 </ContentTemplate>  
<%--                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DgvBackup" EventName="PageIndexChanging" />
                    </Triggers>--%>
            </asp:UpdatePanel>
            </div>
        </div>

    <div class="container">
         <h3>
            <strong>Restore</strong>
         </h3>
         <br />
        <div>
            <label>Seleccione el archivo.</label>
            <asp:UpdatePanel runat="server" ID="btnUpFileUpdatePanel" UpdateMode="Conditional">
                <ContentTemplate>
            <asp:FileUpload ID="FileUploadRestore" runat="server" />
                
            <asp:Button ID="ButtonRestore" runat="server" 
                CssClass="btn btn-primary pull-left" UseSubmitBehavior="false" Text="Restaurar backup" OnClick="ButtonRestore_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="ButtonRestore" />
            </Triggers>
            </asp:UpdatePanel>
       </div>
        </div>
</asp:Content>
