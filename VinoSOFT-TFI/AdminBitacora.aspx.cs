using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminBitacora : System.Web.UI.Page
    {
        BLL.BLL_Bitacora gestorBitacora = new BLL.BLL_Bitacora();
        AdminACL gestorPermisos = new AdminACL();

        const string COD_PERMISO = "MOD_SEGURIDAD";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    if (gestorPermisos.TienePermiso(COD_PERMISO, (BE.BE_Usuario)Session["UsuarioLogueado"]))
                    {
                        llenarDvg();
                        llenarFiltroEventos();
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

        private void llenarDvg(Hashtable filtros = null)
        {
            List<BE.BE_Bitacora> registros = new List<BE.BE_Bitacora>();
            registros = gestorBitacora.listarBitacora(filtros);
            //txtCantRegistros.Text = registros.Count.ToString();

            DgvBitacora.AutoGenerateColumns = false;
            DgvBitacora.DataSource = registros;
            DgvBitacora.DataBind();
        }


        private void llenarFiltroEventos()
        {
            List<BE.BE_Evento> registros = new List<BE.BE_Evento>();
            registros = gestorBitacora.listarEventos();

            ddFiltroEvento.DataTextField = "Nombre";
            ddFiltroEvento.DataValueField = "IdEvento";
            ddFiltroEvento.DataSource = registros;
            ddFiltroEvento.DataBind();
        }
        protected void DgvBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DgvBitacora.PageIndex = e.NewPageIndex;
            this.llenarDvg();
        }

        protected void DgvBitacora_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Hashtable filtros = new Hashtable();
            filtros = getFiltros();
            llenarDvg(filtros);
        }

        private Hashtable getFiltros()
        {
            Hashtable filtros = new Hashtable();
            if (filtroPalabraClave.Text != null)
            {
                filtros.Add("@Observacion", filtroPalabraClave.Text);
            }
            int idEvento;
            if (int.TryParse(ddFiltroEvento.SelectedValue, out idEvento))
            {
                idEvento = int.Parse(ddFiltroEvento.SelectedValue);
                filtros.Add("@idEvento", idEvento);
            }
            DateTime fechaDesde;
            if (DateTime.TryParse(filtroFechaDesde.Text, out fechaDesde))
            {
                fechaDesde = DateTime.Parse(filtroFechaDesde.Text);
                filtros.Add("@fechaDesde", fechaDesde);
            }
            DateTime fechaHasta;
            if (DateTime.TryParse(filtroFechaHasta.Text, out fechaHasta))
            {
                fechaHasta = DateTime.Parse(filtroFechaHasta.Text);
                filtros.Add("@fechaHasta", fechaHasta);
            }
            return filtros;
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
    }
}