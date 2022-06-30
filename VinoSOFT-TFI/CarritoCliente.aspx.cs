using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class CarritoCliente : System.Web.UI.Page
    {
        BE.BE_Venta venta = new BE.BE_Venta();
        ACL gestorPermisos = new ACL();

        BE.BE_Cliente clientePrueba;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //gestorPermisos.validarAccesoCliente();
                pruebaCliente();
                CargarDataCarrito();
            }
            catch {
                Response.Redirect("Inicio.aspx");

            }
        }

        private void CargarDataCarrito()
        {
            if(true) //gestorPermisos.GetIdCliente() > 0
            {
                BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
                //BE.BE_Venta carrito = gestorVentas.GetCarrito(gestorPermisos.GetIdCliente());
                BE.BE_Venta carrito = gestorVentas.GetCarrito(clientePrueba.IDCLIENTE);
                if (carrito != null) {
                    rptItemsCarrito.DataSource = null;
                    rptItemsCarrito.DataBind();
                    rptItemsCarrito.DataMember = "BE_Venta_Detalle";
                    rptItemsCarrito.DataSource = carrito.ITEMS;
                    rptItemsCarrito.DataBind();


                    } 
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