using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminVentasLista : System.Web.UI.Page
    {
        BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
        AdminACL gestorPermisos = new AdminACL();

        const string COD_PERMISO = "MOD_VENTAS";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    if (gestorPermisos.TienePermiso(COD_PERMISO, (BE.BE_Usuario)Session["UsuarioLogueado"]))
                    {
                        llenarDgv();
                        ActualizarBarraNavegacionLogin();
                    }
                    else
                    {
                        Response.Redirect("AdminLogin.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
        public void ActualizarBarraNavegacionLogin()
        {
            BE.BE_Usuario usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            ((Backend)Master).MenuUsuarioNoLogeado = false;
            ((Backend)Master).MenuUsuarioLogeado = true;
            ((Backend)Master).NombreUsuario = "Hola, " + usuario.NOMBRE;
            ((Backend)Master).MenuInicio = true;

            ActualizarMenuesPorPermisos();
        }

        public void ActualizarMenuesPorPermisos()
        {
            BE.BE_Usuario usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            ((Backend)Master).MenuAdmFzas = gestorPermisos.TienePermiso("MOD_ADM_FZAS", usuario);
            ((Backend)Master).MenuSeguridad = gestorPermisos.TienePermiso("MOD_SEGURIDAD", usuario);
            ((Backend)Master).MenuVentas = gestorPermisos.TienePermiso("MOD_VENTAS", usuario);
            ((Backend)Master).MenuMkt = gestorPermisos.TienePermiso("MOD_MKT", usuario);
        }

        private void llenarDgv()
        {
            List<BE.BE_Venta> lista = new List<BE.BE_Venta>();
            lista = gestorVentas.Listar();

            dgvVentas.DataSource = null;
            dgvVentas.DataSource = lista;
            dgvVentas.DataBind();

        }

        protected void dgvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvVentas.PageIndex = e.NewPageIndex;
            this.llenarDgv();
        }

        protected void dgvVentas_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvVentas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = dgvVentas.Rows[e.NewEditIndex];
            string idVenta = row.Cells[0].Text;

            Response.Redirect("AdminVentasEditar.aspx?id=" + idVenta);
        }
    }
}