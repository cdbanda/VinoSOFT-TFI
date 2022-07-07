using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VinoSOFT_TFI
{
    public class AdminACL : System.Web.UI.Page
    {
        BE.BE_Usuario usuarioLogeado = new BE.BE_Usuario();

        public bool EstaLogueado()
        {
            usuarioLogeado = (BE.BE_Usuario)Session["UsuarioLogueado"];
            if(usuarioLogeado == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidarEmpleado()
        {
            if (EstaLogueado())
            {
                usuarioLogeado = (BE.BE_Usuario)Session["UsuarioLogueado"];
                if(usuarioLogeado.ESEMPLEADO == true)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        //public bool ValidarPermiso(string codPermiso)
        //{
        //    if(codPermiso != null)
        //    {
        //        return TienePermiso(codPermiso);
        //    }
        //    return false;
        //}

        public BE.BE_Usuario GetUsuarioLogueado()
        {
            if (EstaLogueado())
            {
                return usuarioLogeado;
            }
            return null;
        }

        public int GetIdUsuario()
        {
            BE.BE_Usuario infoUsuario = GetUsuarioLogueado();
            return infoUsuario.IDUSUARIO;
        }

        public int GetIdCliente()
        {
            BE.BE_Usuario infoUsuario = GetUsuarioLogueado();
            return infoUsuario.IDUSUARIO;
        }

        //public void ValidarAcceso(string codPermiso = null)
        //{
        //    if (EstaLogueado()==false)
        //    {
        //        Response.Redirect("AdminLogin.aspx");
        //    }
        //    if(codPermiso != null)
        //    {
        //        if (ValidarPermiso(codPermiso) == false){
        //            Response.Redirect("AdminDefault.aspx");
        //        }
        //    }
        //}


        public void validarAccesoCliente() 
            {
            if(EstaLogueado() == false)
            {
                Response.Redirect("AdminLogin.aspx");
            }
            int idCliente = GetIdCliente();

            if(idCliente < 0)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("AdminLogin.aspx");
            }
            } 

        //public bool TienePermiso(string CodPermisoValidar)
        //{
        //    if(HttpContext.Current.Session["UsuarioLogeado"] == null)
        //    {
        //        return false;
        //    }
        //    usuarioLogeado = (BE.BE_Usuario)Session["UsuarioLogueado"];

        //    foreach(BE.BE_Permiso permiso in usuarioLogeado.LISTAPERMISO)
        //    {
        //        if(permiso.CODIGO == CodPermisoValidar)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public bool TienePermiso(string CodPermisoValidar, BE.BE_Usuario usuario)
        {
            foreach (BE.BE_Permiso permiso in usuarioLogeado.LISTAPERMISO)
            {
                if (permiso.CODIGO == CodPermisoValidar)
                {
                    return true;
                }
            }
            return false;
        }

    }
}