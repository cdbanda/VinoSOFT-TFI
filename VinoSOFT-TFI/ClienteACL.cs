using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VinoSOFT_TFI
{
    public class ClienteACL : System.Web.UI.Page
    {
        BE.BE_Cliente clienteLogeado = new BE.BE_Cliente();

        public bool EstaLogueado()
        {
            clienteLogeado = (BE.BE_Cliente)Session["ClienteLogueado"];
            if(clienteLogeado == null)
            {
                return false;
            }
            return true;
        }

        //public bool ValidarEmpleado()
        //{
        //    if (EstaLogueado())
        //    {
        //        clienteLogeado = (BE.BE_Cliente)Session["ClienteLogueado"];
        //        if(clienteLogeado.ESEMPLEADO == true)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //public bool ValidarPermiso(string codPermiso)
        //{
        //    if(codPermiso != null)
        //    {
        //        return TienePermiso(codPermiso);
        //    }
        //    return false;
        //}

        public BE.BE_Cliente GetClienteLogueado()
        {
            if (EstaLogueado())
            {
                return clienteLogeado;
            }
            return null;
        }

        public int GetIdCliente()
        {
            BE.BE_Cliente infoCliente = GetClienteLogueado();
            return infoCliente.IDCLIENTE;
        }

        //public int GetIdCliente()
        //{
        //    BE.BE_Usuario infoUsuario = GetUsuarioLogueado();
        //    return infoUsuario.IDUSUARIO;
        //}

        //public void ValidarAcceso(string codPermiso = null)
        //{
        //    if (EstaLogueado()==false)
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //    if(codPermiso != null)
        //    {
        //        if (ValidarPermiso(codPermiso) == false){
        //            Response.Redirect("Inicio.aspx");
        //        }
        //    }
        //}


        public void validarAccesoCliente() 
            {
            if(EstaLogueado() == false)
            {
                Response.Redirect("Login.aspx");
            }
            int idCliente = GetIdCliente();

            if(idCliente < 0)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            }

        public bool TienePermiso()
        {
            if (HttpContext.Current.Session["ClienteLogeado"] == null)
            {
                return false;
            }
            clienteLogeado = (BE.BE_Cliente)Session["ClienteLogueado"];
            return true;
            //foreach (BE.BE_Permiso permiso in clienteLogeado.)
            //{
            //    if (permiso.CODIGO == CodPermisoValidar)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        public void ActualizarBarraNavegacionLogin()
        {
            ((MasterPage)Master).carritoVisible = true;
            ((MasterPage)Master).perfilUsuarioLogeado = true;
            ((MasterPage)Master).lblNombreUsuario = "Hola, "+clienteLogeado.NOMBRE;

            ((MasterPage)Master).perfilUsuarioNoLogeado = false;
        }

        public void ActualizarBarraNavegacionLogout()
        {
            ((MasterPage)Master).carritoVisible = false;
            ((MasterPage)Master).perfilUsuarioLogeado = false;
            ((MasterPage)Master).lblNombreUsuario = "Hola, " + clienteLogeado.NOMBRE;

            ((MasterPage)Master).perfilUsuarioNoLogeado = true;
        }

    }
}