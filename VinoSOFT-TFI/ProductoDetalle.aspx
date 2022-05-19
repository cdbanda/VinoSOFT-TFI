<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductoDetalle.aspx.cs" Inherits="VinoSOFT_TFI.ProductoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                            <asp:Literal ID="ltlTitulo" runat="server">Producto</asp:Literal>
                        </div>
                        <div class="">
                            <asp:Literal ID="ltlDescpCorta" runat="server">Drone especial</asp:Literal>
                        </div>
                        <div class="">
                            <asp:Literal ID="ltlPrecio" runat="server">$ 5000</asp:Literal>
                        </div>
                        <div class="" runat="server" id="divEnStock" visible="true">En Stock</div>
                        <div class="" runat="server" id="divSinStock" visible="false">Sin Stock</div>
                        <hr />
                        <div class="">
                            <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-success" Text="Agregar al Carrito" />
                        </div>
                        <div class="">

                        </div>
                    </div>
                </div>
            </div>
            <!--- fin detalle producto -->
            <div class="container-fluid">
                <div class="col-md-12">
                    <!-- Tabs de comentarios / descripcion -->
                    <ul id="tabDescripcion" class="nav nav-tabs">
                        <li><a>Descripcion</a></li>
                        <li><a>Comentarios</a></li>
                    </ul>
                    <div id="tabContenido" class="tab-content">
                        <div class="tab-pane fade" id="comentarios">
                            <section class="container">
                                <asp:Literal ID="ltlDescripcion" runat="server"></asp:Literal>
                            </section>
                        </div>
                    </div>
                    <div class="tab-pane fade">
                        <section class="container">
                            <div>
                                <h4>Dejar un Comentario:</h4>
                                <form role="form">
                                    <div class="form-group">
                                        <label>Autor:</label>
                                        <asp:TextBox ID="iptAutor" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Comentario:</label>
                                        <asp:TextBox ID="txtComentario" TextMode="MultiLine" CssClass="form-control" runat="server">></asp:TextBox>
                                    </div>
                                    <asp:Button ID="btnGuardarComentario" CssClass="btn btn-primary" runat="server" Text="Enviar" />
                                </form>
                            </div>
                            <hr>
                            <div class="" id="divComentarios" runat="server" visible="true">
                                <p class="lead">No hay comentarios para este producto.</p>
                            </div>
                            <!-- Comentarios posteados --->
                            <asp:Repeater id="rptComentarios" runat="server" Visible="true">
                                <ItemTemplate>
                                    <div class="media">
                                        <div class="media-body">
                                            <h4 class="media-heading">
                                                <asp:Literal ID="ltlAutor" runat="server"></asp:Literal>
                                                <small class="">
                                                    <asp:Literal ID="ltlFecha" runat="server"></asp:Literal>
                                                </small>
                                            </h4>
                                            <asp:Literal ID="ltlComentario" runat="server"></asp:Literal>
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
    </div>



</asp:Content>
