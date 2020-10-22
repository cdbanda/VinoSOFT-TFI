<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="VinoSOFT_TFI.Noticias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Repeater ID="repeaterNoticia" runat="server">
           <ItemTemplate>
               <table>
                   <tr>
                       <td>
                           <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("titulo")%>'></asp:Label>
                           <br />
                           <asp:Label ID="lblfecha" runat="server" Text='<%# Eval("fechaModificacion")%>'></asp:Label>
                           <asp:Label ID="lblCate" runat="server" Text='<%# Eval("categoria.nombre")%>'></asp:Label>
                           <br />
                           <asp:Literal ID="litCuerpo" runat="server" Text='<%# Eval("cuerpo")%>'></asp:Literal>
                           <br />
                       </td>
                   </tr>
               </table>
           </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
