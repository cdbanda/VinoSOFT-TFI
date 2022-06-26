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
            object respuesta = gestorSeguridad.Login(UCUsuarioPass.usuario, UCUsuarioPass.contrasena);
            if(respuesta is BE.BE_Usuario)
            {
                BE.BE_Usuario dataUsuario = (BE.BE_Usuario)respuesta;
                if (dataUsuario.ESEMPLEADO) {
                    Response.Redirect("AdminDefault.aspx");

                }
                else
                {
                    BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();
                    dataUsuario.CLIENTE.VENTA = gestorVentas.GetCarrito(dataUsuario.CLIENTE.IDCLIENTE);
                    Session["venta"] = dataUsuario.CLIENTE.VENTA;
                    Response.Redirect("Inicio.aspx");
                }
            }


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