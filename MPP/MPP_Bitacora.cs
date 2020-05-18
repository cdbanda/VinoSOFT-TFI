using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Bitacora
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();
        public List<BE.BE_Evento> listarEventos(Hashtable filtros) {
            DataSet ds = new DataSet();
            List<BE.BE_Evento> listado = new List<BE.BE_Evento>();
            ds = sqlHelper.Leer("eventos_leer",filtros);
            if (ds.Tables[0].Rows.Count > 0) {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    BE.BE_Evento evento = new BE.BE_Evento();
                    evento.IDEVENTO = int.Parse(dr["id_evento"].ToString());
                    evento.NOMBRE = dr["nombre"].ToString();
                    listado.Add(evento);
                }
            }

            return listado;
        }

        public List<BE.BE_Bitacora> listarBitacora(Hashtable filtros) {
            DataSet ds = new DataSet();
            List<BE.BE_Bitacora> listado = new List<BE.BE_Bitacora>();
            ds = sqlHelper.Leer("bitacora_leer",filtros);
            if (ds.Tables[0].Rows.Count > 0) {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    BE.BE_Usuario usuario = new BE.BE_Usuario();
                    usuario.IDUSUARIO = int.Parse(dr["id_usuario"].ToString());
                    //int num;
                    //if (System.Convert.IsDBNull(dr["id_usuario"]) && int.TryParse(dr["id_usuario"].ToString(), out num) && int.Parse(dr["id_usuario"].ToString()) > 0) {
                    //    usuario = new BE.BE_Usuario();
                    //    usuario.IDUSUARIO = int.Parse(dr["id_usuario"].ToString());
                    //    usuario.NOMBRE = System.Convert.IsDBNull(dr["nombre_usuario"]) ? "" : dr["nombre_usuario"].ToString();
                    //    usuario.APELLIDO = System.Convert.IsDBNull(dr["nombre_apellido"]) ? "" : dr["nombre_apellido"].ToString();
                    //}
                    BE.BE_Bitacora bitacora = new BE.BE_Bitacora();
                    bitacora.IDBITACORA = int.Parse(dr["id_bitacora"].ToString());
                    bitacora.EVENTO = new BE.BE_Evento();
                    bitacora.EVENTO.IDEVENTO = int.Parse(dr["id_evento"].ToString());
                    bitacora.EVENTO.NOMBRE = System.Convert.IsDBNull(dr["evento"]) ? "" : dr["evento"].ToString();
                    
                    bitacora.USUARIO = usuario;
                    bitacora.FECHAHORA = DateTime.Parse(dr["fechahora"].ToString());
                    bitacora.OBSERVACION = System.Convert.IsDBNull(dr["observacion"]) ? "" : dr["observacion"].ToString();
                    bitacora.IMPACTO = getNombreCriticidad(int.Parse(dr["criticidad"].ToString()));
                    listado.Add(bitacora);
                }
            }
            return listado;

        }

        public bool registrarEvento(BE.BE_Bitacora bitacora) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@IdEvento",bitacora.EVENTO.IDEVENTO);
            hdatos.Add("@IdUsuario",bitacora.USUARIO.IDUSUARIO);
            hdatos.Add("@Observacion",bitacora.OBSERVACION);
            return sqlHelper.Escribir("bitacora_registrar",hdatos);
        }

        public static string getNombreCriticidad(int idCriticidad) {
            string nombre = "";
            if (BE.BE_Evento.nombresCriticidad.ContainsKey(idCriticidad)) {
                if (BE.BE_Evento.nombresCriticidad.TryGetValue(idCriticidad, out nombre)){
                    return nombre;
                }
            }
            return nombre;
        }
    }
}
