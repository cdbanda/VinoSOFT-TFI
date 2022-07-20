using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class CambiarContrasenia : System.Web.UI.Page
    {
        BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();
        ClienteACL gestorPermisos = new ClienteACL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
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

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();
            BE.BE_Cliente cliente = new BE.BE_Cliente();
            cliente = (BE.BE_Cliente)Session["ClienteLogueado"];

            string oldContrasena = gestorSeguridad.Encriptar(iptContraseniaAnterior.Text);
            if (iptContraseniaNueva.Text == iptContraseniaNuevaRep.Text)
            {
                if (oldContrasena.Equals(cliente.CONTRASENA))
                {
                    string newContrasena = gestorSeguridad.Encriptar(iptContraseniaNueva.Text);
                    cliente.CONTRASENA = newContrasena;
                    bool guardado = gestorCliente.CambiarContrasena(cliente);
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