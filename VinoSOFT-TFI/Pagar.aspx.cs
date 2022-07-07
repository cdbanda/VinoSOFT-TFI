using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class Pagar : System.Web.UI.Page
    {

        BE.BE_Venta venta = new BE.BE_Venta();
        ClienteACL gestorPermisos = new ClienteACL();
        BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
        BLL.BLL_Producto gestorProductos = new BLL.BLL_Producto();

        BE.BE_Cliente cliente;
        BE.BE_Venta carrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    //gestorPermisos.validarAccesoCliente();
                    //pruebaCliente();
                    CargarDataCarrito();
                    ActualizarBarraNavegacionLogin();
                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
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

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            cliente = (BE.BE_Cliente)Session["ClienteLogueado"];
            carrito = gestorVentas.GetCarrito(cliente.IDCLIENTE);

            if (carrito != null)
            {
                BE.BE_Venta ventaActual = carrito;

                float total = 0;

                foreach (BE.BE_Venta_Detalle item in carrito.ITEMS)
                {

                    if (gestorProductos.ValidarStock(item.PRODUCTO) - gestorProductos.ObtenerStockMinimo(item.PRODUCTO) >= item.CANTIDAD)
                    {
                        total = total + (item.CANTIDAD * item.MONTO);
                    }
                    else
                    {
                        ltlErrorStock.Text = "No hay stock para el producto " + item.PRODUCTO.NOMBRE;
                        ltlErrorStock.Visible = true;
                        return;
                    }
                }
                ventaActual.MONTOTOTAL = total;
                ventaActual.IDFACTURA = 0;

                bool finalizada = gestorVentas.FinalizarVenta(ventaActual);
                if (finalizada)
                {
                    Response.Redirect("Inicio.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                
            }
        }

        protected void btnSeguirComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void CargarDataCarrito()
        {
            cliente = (BE.BE_Cliente)Session["ClienteLogueado"];

            if (cliente != null)
            {
                carrito = gestorVentas.GetCarrito(cliente.IDCLIENTE);
                float total = 0;
                if (carrito != null)
                {
                    foreach (BE.BE_Venta_Detalle item in carrito.ITEMS)
                    {
                        total = total + (item.CANTIDAD * item.MONTO);
                    }
                }

                ltlTotal.Text = total.ToString();
            }
        }

        //private void pruebaCliente()
        //{


        //    if (Session["UsuarioLogueado"] == null)
        //    {
        //        BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();
        //        clientePrueba = gestorCliente.getPorID(3);
        //        Session["UsuarioLogueado"] = clientePrueba;
        //    }
        //    else
        //    {
        //        clientePrueba = new BE.BE_Cliente();
        //        clientePrueba = (BE.BE_Cliente)Session["UsuarioLogueado"];
        //    }
        //}
    }
}