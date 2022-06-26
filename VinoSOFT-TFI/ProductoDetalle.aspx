<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductoDetalle.aspx.cs" Inherits="VinoSOFT_TFI.ProductoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="iptCodigo" runat="server" />

    <div class="container-fluid">
        <div class="content-wrapper">
            <!-- parte de detalle producto -->
            <div class="item-container">
                <div class="container">
                    <div class="">
                        <asp:Image ID="imgProducto" CssClass="img-thumbnail" ImageUrl="/Publicidad/img/thumb/drone_thumb.jpg" runat="server" />
                    </div>
                    <div class="col-md-7">
                        <a href="Productos.aspx" class="pull-right">Volver al Catalogo</a>
                        <div class="">
                            <asp:Literal ID="ltlTitulo" runat="server"></asp:Literal>
                        </div>
                        <div class="">
                            <asp:Literal ID="ltlDescripcionCorta" runat="server"></asp:Literal>
                        </div>
                        <div class=""> $
                            <asp:Literal ID="ltlPrecio" runat="server"></asp:Literal>
                        </div>
                        <div class="" runat="server" id="divEnStock" visible="true">En Stock</div>
                        <div class="" runat="server" id="divSinStock" visible="false">Sin Stock</div>
                        <hr />
                        <div class="">
                            <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-success" Text="Agregar al Carrito" OnClick="btnAgregarCarrito_Click"/>
                        </div>
                        <div class="">

                        </div>
                    </div>
                </div>
            </div>
            <!--- fin detalle producto -->
            <div class="container">
                <div class="col-md-12">
                    <section class="container">
                            <div>
                                <h4>Dejar un Comentario:</h4>
                                <form role="form">
                                    <div class="form-group">
                                        <label>Autor:</label>
                                        <asp:TextBox ID="txtAutor" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Comentario:</label>
                                        <asp:TextBox ID="txtComentario" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnGuardarComentario" CssClass="btn btn-primary" runat="server" Text="Enviar" OnClick="btnGuardarComentario_Click" />
                                </form>
                            </div>
                    </section>
                    <section>
                          <!-- Comentarios posteados --->
                            <asp:Repeater id="rptComentarios" runat="server" Visible="false">
                                <ItemTemplate>
                                    <div class="media">
                                        <div class="media-body">
                                            <h4 class="media-heading">
                                                <asp:Literal ID="ltlAutor" runat="server" Text="<%# (Container.DataItem as BE.BE_ProductoComentario).AUTOR %>"></asp:Literal>
                                                <small class="">
                                                    <asp:Literal ID="ltlFecha" runat="server" text="<%# (Container.DataItem as BE.BE_ProductoComentario).FECHAHORA.ToString() %>"></asp:Literal>
                                                </small>
                                            </h4>
                                            <asp:Literal ID="ltlComentario" runat="server" Text="<%# (Container.DataItem as BE.BE_ProductoComentario).COMENTARIO %>"></asp:Literal>
                                        </div>                                   
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <!-- fin comentarios posteados -->
                        </section>
                    </div>
                </div>
        </div>
    </div>



</asp:Content>
