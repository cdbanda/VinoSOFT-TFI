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
        BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();
        ClienteACL gestorPermisos = new ClienteACL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(gestorPermisos.EstaLogueado())
            {
                Response.Redirect("Inicio.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void btnLoginPage_Click(object sender, EventArgs e)
        {
            BE.BE_Cliente respuesta = gestorSeguridad.LoginCliente(UCUsuarioPass.usuario, UCUsuarioPass.contrasena);

            if (respuesta is null)
            {

                ltlError.Text = "El usuario y/o contraseña son incorrectos.";
                ltlError.Visible = true;
                return;
            }
            else
            {


                Session["ClienteLogueado"] = respuesta;
                Response.Redirect("Inicio.aspx",false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }



    }
}