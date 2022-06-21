using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class Login : System.Web.UI.Page
    {

        BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
        BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UsuarioLogeado"] != null)
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void btnLoginPage_Click(object sender, EventArgs e)
        {

            //if (VerificarSesionIniciada() == false)
            //{
            //    //tomo los datos del control de usuario 
            //    string contrasena = UCUsuarioPass.contrasena;
            //    string usuario = UCUsuarioPass.usuario;

            //    bool resultado = gestorUsuario.verificarUsuario(usuario, contrasena);


            //}
            //else { 
               
            //}
        }
    }
}