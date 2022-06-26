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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gestorPermisos.validarAccesoCliente();
                CargarDataCarrito();
            }
            catch {
                Response.Redirect("Inicio.aspx");

            }
        }

        private void CargarDataCarrito()
        {
            if(gestorPermisos.GetIdCliente() > 0)
            {
                BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
                BE.BE_Venta carrito = gestorVentas.GetCarrito(gestorPermisos.GetIdCliente());
                if(carrito != null) {
                    rptItemsCarrito.DataSource = null;
                    rptItemsCarrito.DataBind();
                    rptItemsCarrito.DataMember = "BE_Venta_Detalle";
                    rptItemsCarrito.DataSource = carrito.ITEMS;
                    rptItemsCarrito.DataBind();


                    } 
            }
        }


    }
}