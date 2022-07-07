using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminLogin : System.Web.UI.Page
    {

        BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();
        BLL.BLL_Seguridad gestorSeguridad = new BLL.BLL_Seguridad();

        AdminACL gestorPermisos = new AdminACL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (gestorPermisos.EstaLogueado())
            {
                Response.Redirect("AdminDefault.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void btnLoginPage_Click(object sender, EventArgs e)
        {
            BE.BE_Usuario respuesta = gestorSeguridad.LoginUsuario(UCUsuarioPass.usuario, UCUsuarioPass.contrasena);
            if (respuesta != null)
            {
                if (respuesta.ESEMPLEADO)
                {
                    Session["UsuarioLogueado"] = respuesta;
                    Response.Redirect("AdminDefault.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();

                    if (respuesta.ESADMIN)
                    {

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

    }
}