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
        ACL gestorPermisos = new ACL();
        BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();

        BE.BE_Cliente clientePrueba;
        BE.BE_Venta carrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //gestorPermisos.validarAccesoCliente();
                pruebaCliente();
                CargarDataCarrito();
            }
            catch
            {
                Response.Redirect("Inicio.aspx");

            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (carrito != null)
            {
                BE.BE_Venta ventaActual = carrito;

                float total = 0;
                if (carrito != null)
                {
                    foreach (BE.BE_Venta_Detalle item in carrito.ITEMS)
                    {
                        total = total + (item.CANTIDAD * item.MONTO);
                    }
                }
                ventaActual.MONTOTOTAL = total;
                ventaActual.IDFACTURA = 0;

                bool finalizada = gestorVentas.FinalizarVenta(ventaActual);
                if (finalizada)
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
        }

        protected void btnSeguirComprando_Click(object sender, EventArgs e)
        {
           
        
        
        
        }

        private void CargarDataCarrito()
        {
            if (true) //gestorPermisos.GetIdCliente() > 0
            {   
                //BE.BE_Venta carrito = gestorVentas.GetCarrito(gestorPermisos.GetIdCliente());
                carrito = gestorVentas.GetCarrito(clientePrueba.IDCLIENTE);
                float total = 0;
                if (carrito != null)
                {
                    foreach(BE.BE_Venta_Detalle item in carrito.ITEMS)
                    {
                        total = total + (item.CANTIDAD * item.MONTO);
                    }
                }

                ltlTotal.Text = total.ToString();
            }
        }

        private void pruebaCliente()
        {


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
        }
    }
}