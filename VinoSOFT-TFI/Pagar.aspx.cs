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
        BLL.BLL_Bitacora gestorBitacora = new BLL.BLL_Bitacora();

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
                    CargarDataCliente();
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
                    BE.BE_Evento evt = new BE.BE_Evento();
                    evt.IDEVENTO = BE.BE_Evento.VENTA_FINALIZADA;
                    gestorBitacora.registrarEvento(evt, "fecha: " + DateTime.Now.ToString(), -1);

                    mp1.Show();
                    //Response.Redirect("Inicio.aspx", false);
                    //Context.ApplicationInstance.CompleteRequest();
                    mjsBodyMP.Text = "Gracias por su Compra, su pago fue confirmado.";
                    mjsRedireccion.Text = "Será redirigido a la página de inicio.";
                }
                
            }
        }

        protected void btnSeguirComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void CargarDataCliente()
        {
            cliente = (BE.BE_Cliente)Session["ClienteLogueado"];
            ltlNombreCliente.Text = cliente.NOMBRE + " " + cliente.APELLIDO;
            ltlDNICliente.Text = cliente.DNI.ToString();
            ltlDireccionCliente.Text = cliente.DOMICILIO;
            ltlTelefonoCliente.Text = cliente.TELEFONO;

        }

        private void CargarDataCarrito()
        {
            cliente = (BE.BE_Cliente)Session["ClienteLogueado"];

            if (cliente != null)
            {
                BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
                carrito = gestorVentas.GetCarrito(cliente.IDCLIENTE);
                if (carrito.ITEMS.Count > 0)
                {

                    carrito.ITEMS = AgregarFormatoImagenes(carrito.ITEMS);
                    dgvCarrito.DataSource = null;
                    dgvCarrito.DataMember = "BE_Venta_Detalle";
                    dgvCarrito.DataSource = carrito.ITEMS;
                    dgvCarrito.DataBind();
                    ltlTotal.Text = CalcularTotal(carrito.ITEMS).ToString();
                }
            }
        }


        private float CalcularTotal(List<BE.BE_Venta_Detalle> lista)
        {
            float total = 0;
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    foreach (BE.BE_Venta_Detalle vtaDetalle in lista)
                    {
                        total = total + vtaDetalle.SUBTOTAL;
                    }
                    return total;
                }
                else
                {
                    return total;
                }
            }
            else
            {
                return total;
            }
        }

        private List<BE.BE_Venta_Detalle> AgregarFormatoImagenes(List<BE.BE_Venta_Detalle> lista)
        {
            string formato = "data:image/jpeg;base64,";
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    foreach (BE.BE_Venta_Detalle vtaDetalle in lista)
                    {
                        vtaDetalle.PRODUCTO.IMAGEN = formato + vtaDetalle.PRODUCTO.IMAGEN;
                    }
                    return lista;
                }
            }
            return lista;
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {
            mp1.Hide();
            Server.Transfer("Inicio.aspx",false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}