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
        ACL gestorPermisos = new ACL();
        BLL.BLL_Venta gestorVenta = new BLL.BLL_Venta();

        protected void Page_Load(object sender, EventArgs e)
        {

                if (Request.QueryString["id"] != null || int.TryParse(Request.QueryString["id"], out _))
                {
                    int idProd = int.Parse(Request.QueryString["id"]);
                    producto = gestorProducto.listarProductoPorID(idProd);
                    if (producto == null)
                    {
                        Response.Redirect("/Productos.aspx", false);
                    }
                    else
                    {
                        completarPaginaConProducto();
                    }

                }
                else
                {
                    Response.Redirect("/Productos.aspx", false);
                }
            
        }

        protected void completarPaginaConProducto() {
            ltlPrecio.Text = producto.PRECIO.ToString();
            ltlTitulo.Text = producto.NOMBRE;
            ltlDescripcionCorta.Text = producto.DESCRIPCIONCORTA;
            iptCodigo.Value = producto.IDPRODUCTO.ToString();
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
                Response.Redirect("/ProductoDetalle.aspx?id=" + producto.IDPRODUCTO.ToString());

            }
            catch
            {

            }


        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            //BE.BE_Usuario usuario = gestorPermisos.GetUsuarioLogueado(); si el usuario esta logueado
            BE.BE_Cliente clientePrueba;

            if (Session["UsuarioLogueado"] == null)
            {
                BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();
                clientePrueba = gestorCliente.getPorID(3);
                Session["UsuarioLogueado"] = clientePrueba;
            }
            else
            {
                clientePrueba = new BE.BE_Cliente();
                clientePrueba = (BE.BE_Cliente)Session["UsuarioLogueado"];
            }


            //BE.BE_Venta venta = gestorVenta.GetCarrito(gestorPermisos.GetIdCliente());
            BE.BE_Venta venta = gestorVenta.GetCarrito(clientePrueba.IDCLIENTE);
            int idVenta = venta.IDVENTA;

            BE.BE_Producto producto = new BE.BE_Producto();
            producto.IDPRODUCTO = int.Parse(iptCodigo.Value);

            BE.BE_Venta_Detalle ventaDetalle = new BE.BE_Venta_Detalle();
            ventaDetalle.IDVENTA = idVenta;
            ventaDetalle.PRODUCTO = producto;
            ventaDetalle.CANTIDAD = 1;

            bool agregado = gestorVenta.AgregarProducto(idVenta, ventaDetalle);
            if (!agregado)
            {
                Response.Redirect("Inicio.aspx");
            }
           
        }
    }
    }
