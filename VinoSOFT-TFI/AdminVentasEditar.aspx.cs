using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminVentasEditar : System.Web.UI.Page
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
                        CargarInfo();
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


        private void CargarInfo()
        {

            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out _))
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    BE.BE_Venta venta;
                    venta = gestorVentas.GetPorID(id);

                    if (venta != null)
                    {
                        ltlCliente.Text = venta.NOMBRECLIENTE;
                        ltlFecha.Text = venta.FECHA.ToString();
                        ltlMontoTotal.Text = venta.MONTOTOTAL.ToString();
                        ddEstado.SelectedValue = venta.ESTADO;
                        iptCodigo.Value = venta.IDVENTA.ToString();
                    }
                }
                else
                {
                    return;
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idVenta = int.Parse(iptCodigo.Value);
            bool guardado = gestorVentas.ActualizarEstado(idVenta, ddEstado.SelectedValue);
            if (guardado)
            {
                Response.Redirect("AdminVentasLista.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
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
    }
}