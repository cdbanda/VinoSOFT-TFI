using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class DesregistracionNewsletter : System.Web.UI.Page
    {
        BLL.BLL_Newsletter gestorNoticia = new BLL.BLL_Newsletter();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Request.QueryString["EMAIL"]) == false)
            {
                int resultado = gestorNoticia.borrarMail(Request.QueryString["EMAIL"].ToString());
                if (resultado == 0) {
                    LblMensaje.Text = "El email borrado con exito de nuestra base.";
                }
                if (resultado == 1) {
                    LblMensaje.Text = "La cuenta de email no existe en nuestra base.";
                }
            }
            else
            {
                LblMensaje.Text = "Falta parametro.";
            }
        }
        

        protected void BtnInicio_Click(object sender, EventArgs e) {
            Response.Redirect("~/Inicio.aspx");
        }
    }
}