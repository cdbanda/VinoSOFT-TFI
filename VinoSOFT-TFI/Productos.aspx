﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="VinoSOFT_TFI.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h3>Nuestros Productos</h3>
    </div>
    <hr />
    <br />
    <div class="row">
        <asp:Repeater ID="repeaterProducto" runat="server" Visible="true">
           <ItemTemplate>
               <div class="col-sm-4 col-lg-4 col-md-4">
                   <div class="">
                       <asp:Image ID="imgProd" Width="200" Height="200" ImageUrl="<%# (Container.DataItem as BE.BE_Producto).IMAGEN %>" runat="server" />
                       <h4 class="pull-right">$ <%# (Container.DataItem as BE.BE_Producto).PRECIO %></h4>
                       <asp:label ID="lblIDProducto" runat="server" visible="false">"<%# (Container.DataItem as BE.BE_Producto).IDPRODUCTO %>"</asp:label>
                       <h4><a href="/ProductoDetalle.aspx?id=<%# (Container.DataItem as BE.BE_Producto).IDPRODUCTO %>">
                           <asp:Literal ID="ltlNombre" runat="server" Text="<%# (Container.DataItem as BE.BE_Producto).NOMBRE %>"> </asp:Literal>
                           </a>
                       </h4>
                       <h6>
                           <asp:literal  ID="ltlCate" runat="server" Text="<%# (Container.DataItem as BE.BE_Producto).CATEGORIA.NOMBRE %>"></asp:literal>
                       </h6>
                       <p>
                           <asp:Literal ID="ltlDescCorta" runat="server" Text="<%# (Container.DataItem as BE.BE_Producto).DESCRIPCIONCORTA %>"></asp:Literal>
                       </p>
                   </div>
               </div>
           </ItemTemplate>

        </asp:Repeater>
    </div>
    <div class="row">
        <strong class="h4" style="text-align:center;"><asp:Literal ID="ltlNoHayProductos" runat="server" Visible="false" Text="No hay productos para mostrar."></asp:Literal></strong>
    </div>



</asp:Content>
