using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class ClienteMisCompras : System.Web.UI.Page
    {
        BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
        ClienteACL gestorPermisos = new ClienteACL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    ActualizarBarraNavegacionLogin();
                    CargarData();
                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                }
            }

        }

        private void CargarData()
        {
            BE.BE_Cliente cliente = new BE.BE_Cliente();
            cliente = (BE.BE_Cliente)Session["ClienteLogueado"];

            List<BE.BE_Venta> lista = gestorVentas.GetVentasPorClientes(cliente.IDCLIENTE);

            if (lista != null)
            {
                rptVtas.DataSource = null;
                rptVtas.DataMember = "BE_Venta";
                rptVtas.DataSource = lista;
                rptVtas.DataBind();
                div_tbl_vtas.Visible = true;
            }
            else
            {
                div_tbl_vtas.Visible = false;
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
    }
}