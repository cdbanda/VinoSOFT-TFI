using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminCambiarContrasenia : System.Web.UI.Page
    {
        BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
        AdminACL gestorPermisos = new AdminACL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    ActualizarBarraNavegacionLogin();
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


        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();
            BE.BE_Usuario usuario = new BE.BE_Usuario();
            usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            string oldContrasena = gestorSeguridad.Encriptar(iptContraseniaAnterior.Text);
            if (iptContraseniaNueva.Text == iptContraseniaNuevaRep.Text)
            {
                if (oldContrasena.Equals(usuario.CONTRASENA))
                {
                    string newContrasena = gestorSeguridad.Encriptar(iptContraseniaNueva.Text);
                    usuario.CONTRASENA = newContrasena;
                    bool guardado = gestorUsuario.modificarContrasenia(usuario);
                    if (guardado)
                    {
                        ltlError.Visible = false;
                        ltlOK.Text = "Contraseña guardada con éxito.";
                        ltlOK.Visible = true;
                        LimpiarTxtBoxes(Page);
                    }
                    else
                    {
                        ltlOK.Visible = false;
                        ltlError.Text = "Error al actualizar la contraseña.";
                        ltlError.Visible = true;
                    }
                }
                else
                {
                    ltlOK.Visible = false;
                    ltlError.Text = "La contraseña actual no es correcta.";
                    ltlError.Visible = true;
                }
            }
            else
            {
                ltlOK.Visible = false;
                ltlError.Text = "Las contraseñas a cambiar no conciden.";
                ltlError.Visible = true;
            }
        }

        private void LimpiarTxtBoxes(Control c)
        {
            foreach (Control c1 in c.Controls)
            {
                if (c1.GetType() == typeof(TextBox))
                {
                    ((TextBox)c1).Text = "";
                }
                if (c1.HasControls())
                {
                    LimpiarTxtBoxes(c1);
                }
            }
        }
    }
}