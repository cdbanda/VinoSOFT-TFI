using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool carritoVisible
        {
            get { return liCarrito.Visible; }
            set { liCarrito.Visible = value; }
        }

        public bool perfilUsuarioNoLogeado
        {
            get { return ddUsuarioNoLogueo.Visible; }
            set { ddUsuarioNoLogueo.Visible = value; }
        }

        public bool perfilUsuarioLogeado
        {
            get { return ddUsuarioLogueado.Visible; }
            set { ddUsuarioLogueado.Visible = value; }

        }

        public string lblNombreUsuario
        {
            get { return lblUsuario.Text; }
            set { lblUsuario.Text = value; }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();
            gestorSeguridad.Logout();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Inicio.aspx",false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}