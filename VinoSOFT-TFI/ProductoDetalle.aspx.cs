using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class ProductoDetalle : System.Web.UI.Page
    {
        BLL.BLL_Producto gestorProducto = new BLL.BLL_Producto();
        BE.BE_Producto producto = new BE.BE_Producto();
        ClienteACL gestorPermisos = new ClienteACL();
        BLL.BLL_Venta gestorVenta = new BLL.BLL_Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null || int.TryParse(Request.QueryString["id"], out _))
                {
                    int idProd = int.Parse(Request.QueryString["id"]);
                    producto = gestorProducto.listarProductoPorID(idProd);
                    if (producto == null)
                    {
                        Response.Redirect("/Productos.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        completarPaginaConProducto();


                        if (gestorPermisos.EstaLogueado())
                        {
                            ActualizarBarraNavegacionLogin();
                            btnAgregarCarrito.Visible = true;
                            btnGuardarComentario.Visible = true;
                        }

                    }

                }
                else
                {
                    Response.Redirect("/Productos.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        protected void completarPaginaConProducto() {
            ltlPrecio.Text = producto.PRECIO.ToString();
            ltlTitulo.Text = producto.NOMBRE;
            ltlDescripcionCorta.Text = producto.DESCRIPCIONCORTA;
            iptCodigo.Value = producto.IDPRODUCTO.ToString();
            imgProducto.ImageUrl = "data:image/jpeg;base64," + producto.IMAGEN;
            completarComentarios();
        }

        protected void actualizarRepeaterComentarios() {
            producto.COMENTARIOS = gestorProducto.listarComentariosPorID(producto.IDPRODUCTO);
            completarComentarios();
            limpiarTxt();
        }

        protected void limpiarTxt()
        {
            txtAutor.Text = null;
            txtComentario.Text = null;

        }

        protected void completarComentarios()
        {
            if (producto.COMENTARIOS.Count > 0)
            {
                rptComentarios.Visible = true;
                rptComentarios.DataMember = "BE_ProductoComentario";
                rptComentarios.DataSource = producto.COMENTARIOS;
                rptComentarios.DataBind();


            }
            else
            {
                //ocultar div de comentarios.
            }
        }

        protected void btnGuardarComentario_Click(object sender, EventArgs e)
        {
            try {
                BE.BE_ProductoComentario comentario = new BE.BE_ProductoComentario();
                comentario.COMENTARIO = txtComentario.Text;
                comentario.FECHAHORA = DateTime.Now;
                comentario.ACTIVO = 1;
                comentario.IDPRODUCTO = producto.IDPRODUCTO;
                comentario.AUTOR = txtAutor.Text;

                gestorProducto.insertarComentario(comentario);

                //actualizarRepeaterComentarios();
                limpiarTxt();
                Response.Redirect("/ProductoDetalle.aspx?id=" + producto.IDPRODUCTO.ToString(),false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch
            {

            }


        }

        public void ActualizarBarraNavegacionLogin()
        {
            BE.BE_Cliente usuario = (BE.BE_Cliente)Session["ClienteLogueado"];

            ((MasterPage)Master).carritoVisible = true;
            ((MasterPage)Master).perfilUsuarioLogeado = true;
            ((MasterPage)Master).lblNombreUsuario = "Hola, " + usuario.NOMBRE;

            ((MasterPage)Master).perfilUsuarioNoLogeado = false;
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            BE.BE_Cliente cliente = gestorPermisos.GetClienteLogueado();

            if (Session["ClienteLogueado"] != null)
            {
                //    BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();
                //    clientePrueba = gestorCliente.getPorID(3);
                //    Session["ClienteLogueado"] = clientePrueba;
                //}
                //else
                //{
                //    clientePrueba = new BE.BE_Cliente();
                //    clientePrueba = (BE.BE_Cliente)Session["ClienteLogueado"];
                //}

                BE.BE_Venta venta = gestorVenta.GetCarrito(cliente.IDCLIENTE);
                int idVenta = venta.IDVENTA;

                BE.BE_Producto producto = new BE.BE_Producto();
                producto.IDPRODUCTO = int.Parse(iptCodigo.Value);

                BE.BE_Venta_Detalle ventaDetalle = new BE.BE_Venta_Detalle();
                ventaDetalle.IDVENTA = idVenta;
                ventaDetalle.PRODUCTO = producto;
                ventaDetalle.CANTIDAD = 1;

                bool agregado = gestorVenta.AgregarProducto(idVenta, ventaDetalle);
                if (agregado)
                {
                    Response.Redirect("Productos.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
    }
