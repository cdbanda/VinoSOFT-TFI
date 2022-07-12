using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class Backend : System.Web.UI.MasterPage
    {

        BLL.BLL_Bitacora gestorBitacora = new BLL.BLL_Bitacora();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool MenuMkt
        {
            get { return ItemMkt.Visible; }
            set { ItemMkt.Visible = value; }
        }

        public bool MenuSeguridad
        {
            get { return ItemSeguridad.Visible; }
            set { ItemSeguridad.Visible = value; }
        }

        public bool MenuAdmFzas
        {
            get { return ItemAdmFzas.Visible; }
            set { ItemAdmFzas.Visible = value; }
        }

        public bool MenuVentas
        {
            get { return ItemVentas.Visible; }
            set { ItemVentas.Visible = value; }
        }

        public bool MenuInicio
        {
            get { return ItemInicio.Visible; }
            set { ItemInicio.Visible = value; }
        }

        public string NombreUsuario
        {
            get { return lblUsuario.Text; }
            set { lblUsuario.Text = value; }
        }

        public bool MenuUsuarioLogeado
        {
            get { return ddUsuarioLogueado.Visible; }
            set { ddUsuarioLogueado.Visible = value; }
        }

        public bool MenuUsuarioNoLogeado
        {
            get { return ddUsuarioNoLogueado.Visible; }
            set { ddUsuarioNoLogueado.Visible = value; }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
             BE.BE_Usuario usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            BE.BE_Evento evt = new BE.BE_Evento();
            evt.IDEVENTO = BE.BE_Evento.LOGOUT_OK;
            gestorBitacora.registrarEvento(evt, "fecha: " + DateTime.Now.ToString(), usuario.IDUSUARIO);


            BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();
            gestorSeguridad.Logout();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("AdminLogin.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}