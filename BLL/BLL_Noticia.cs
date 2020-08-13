using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Noticia
    {
        MPP.MPP_Noticia mapperNoticia = new MPP.MPP_Noticia();
        public bool InsertarNoticia(BE.BE_Noticia noticia) {
            return mapperNoticia.InsertarNoticia(noticia);
        }

        public List<BE.BE_Noticia> Listar(Hashtable filtros) {
            List<BE.BE_Noticia> lista = new List<BE.BE_Noticia>();

            lista = mapperNoticia.Listar(filtros);

            return lista;
        }

        public bool ActualizarNoticia(BE.BE_Noticia noticia) {
            return mapperNoticia.ActualizarNoticia(noticia);
        }

        public BE.BE_Noticia BuscarNoticiaPorID(int id) {
            BE.BE_Noticia noticia = new BE.BE_Noticia();

            noticia = mapperNoticia.BuscarNoticiaPorID(id);

            return noticia;
        }

        public int ObtenerUltimoIDNoticia() {
            return mapperNoticia.ObtenerUltimoIDNoticia();
        }

        public bool BorrarNoticia(int id) {
            return mapperNoticia.BorrarNoticia(id);
        }
    }
}
