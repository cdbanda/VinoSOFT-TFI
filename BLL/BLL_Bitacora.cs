using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;

namespace BLL
{
    public class BLL_Bitacora
    {
        MPP.MPP_Bitacora mapperBitacora = new MPP.MPP_Bitacora();

        public List<BE.BE_Evento> listarEventos(Hashtable filtros = null) {
            return mapperBitacora.listarEventos(filtros);
        }

        public List<BE.BE_Bitacora> listarBitacora(Hashtable filtros = null) {
            return mapperBitacora.listarBitacora(filtros);
        }

        public bool registrarEvento(BE.BE_Evento evento, string obs = "", int idUsuario = 0) {
            BE.BE_Bitacora objBitacora = new BE.BE_Bitacora();
            //int idUsuarioLogeado = getIdUsuarioLogeado();
            //if (idUsuario > 0) {
            //    idUsuarioLogeado = idUsuario;
            //}

            objBitacora.EVENTO = evento;
            objBitacora.USUARIO = new BE.BE_Usuario();
            objBitacora.USUARIO.IDUSUARIO = idUsuario;
            objBitacora.OBSERVACION = obs;
            bool registrado = mapperBitacora.registrarEvento(objBitacora);
            return registrado;
        }

        //private int getIdUsuarioLogeado() {
        //    BE.BE_Usuario usuario = (BE.BE_Usuario)System.Web.HttpContext.Current.Session["UsuarioLogeado"];
        //    if (usuario == null) {
        //        return usuario.IDUSUARIO;
        //    }
        //    return 0;
        //}
    }
}
