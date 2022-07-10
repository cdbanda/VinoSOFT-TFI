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
                    <div class="col-md-5">
                    <asp:Button ID="btnVolver" runat="server" text="Volver al Catálogo" CssClass="btn btn-primary" OnClick="btnVolver_Click"/>
                    </div>
                   <br />
                    <div class="col-md-5">
                        <div class="text-center">
                            <asp:Image ID="imgProducto" Width="300" Height="300" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-7">
                        
                        <div>
                            <h3><asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h3>
                        </div>
                        <div>
                            <asp:Literal ID="ltlDescripcionCorta" runat="server"></asp:Literal>
                        </div>
                        <div>
                            <h4>Precio: $ <asp:Literal ID="ltlPrecio" runat="server"></asp:Literal> </h4>
                        </div>
                        <div>
                            <strong style="color: green"><asp:Literal ID="ltlHayStock" runat="server" Visible="false" Text="Hay STOCK"></asp:Literal> </strong>
                            <strong style="color: red"><asp:Literal ID="ltlNoHayStock" runat="server" Visible="false" Text="Sin STOCK"></asp:Literal></strong>
                        </div>

                        <div class="">
                            <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-success" Visible="false" Text="Agregar al Carrito" OnClick="btnAgregarCarrito_Click"/>
                        </div>
                    </div>
                </div>
            </div>
            <!--- fin detalle producto -->
            <hr />
            <div class="container">
                <div class="col-md-12">
                    <section class="container"  runat="server" id="seccionInsertarComentarios" visible="true">
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
                                    <asp:Button ID="btnGuardarComentario" CssClass="btn btn-warning" runat="server" Text="Enviar" Visible="true" OnClick="btnGuardarComentario_Click" />
                                </form>
                            </div>
                         <hr />
                    </section>

                    <section runat="server" id="seccionComentariosPosteados" visible="true" >
                          <!-- Comentarios posteados --->
                        <h3>Comentarios: </h3>
                        <br />
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
                    <section runat="server" id="seccionNoHayComentarios" visible="false"  >
                        <h3>Sin Comentarios. </h3>
                    </section>
                    </div>
                </div>
        </div>
    </div>
    </asp:Content>