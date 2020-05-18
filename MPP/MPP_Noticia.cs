using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace MPP
{
    public class MPP_Noticia
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();
        public bool insertarNoticia(BE.BE_Noticia noticia) {
            bool ok = false;

            Hashtable datos = new Hashtable();
            datos.Add("@categoria", noticia.CATEGORIA);
            datos.Add("@cuerpo", noticia.CUERPO);
            datos.Add("@titulo", noticia.TITULO);

            ok = sqlHelper.Escribir("noticia_escribir", datos);

            return ok;
        }
    }
}
