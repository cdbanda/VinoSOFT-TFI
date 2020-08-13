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
        MPP_Categoria mapperCategoria = new MPP_Categoria();
        public bool InsertarNoticia(BE.BE_Noticia noticia)
        {
            bool ok = false;

            Hashtable datos = new Hashtable();
            datos.Add("@categoria", noticia.CATEGORIA.ID);
            datos.Add("@cuerpo", noticia.CUERPO);
            datos.Add("@titulo", noticia.TITULO);
            datos.Add("@fechacreacion", noticia.FECHACREACION);
            datos.Add("@fechamodificacion", noticia.FECHAMODIFICACION);
            datos.Add("@habilitado", noticia.HABILITADO);
            datos.Add("@idNoticia", noticia.ID);

            ok = sqlHelper.Escribir("noticia_insertar", datos);

            return ok;
        }

        public int ObtenerUltimoIDNoticia() {
            int id = 0;
            DataSet ds = new DataSet();

            ds = sqlHelper.Leer("noticia_obtenerUltimoID",null);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                         id = int.Parse(item["id_noticia"].ToString());
                    }
                }
            }
            return id;
        }

        public bool ActualizarNoticia(BE.BE_Noticia noticia)
        {
            bool ok = false;

            Hashtable datos = new Hashtable();
            datos.Add("@categoria", noticia.CATEGORIA.ID);
            datos.Add("@cuerpo", noticia.CUERPO);
            datos.Add("@titulo", noticia.TITULO);
            datos.Add("@fechacreacion", noticia.FECHACREACION);
            datos.Add("@fechamodificacion", noticia.FECHAMODIFICACION);
            datos.Add("@habilitado", noticia.HABILITADO);
            datos.Add("@idNoticia", noticia.ID);

            ok = sqlHelper.Escribir("noticia_actualizar", datos);

            return ok;
        }

        public List<BE.BE_Noticia> Listar(Hashtable filtros) {

            List<BE.BE_Noticia> lista = new List<BE.BE_Noticia>();
            DataSet ds = new DataSet();

            ds = sqlHelper.Leer("noticia_listar", filtros);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        BE.BE_Noticia unaNoti = new BE.BE_Noticia();
                        unaNoti.ID = int.Parse(item["id_noticia"].ToString());
                        unaNoti.TITULO = item["titulo"].ToString();
                        unaNoti.CUERPO = item["cuerpo"].ToString();
                        unaNoti.HABILITADO = int.Parse(item["habilitado"].ToString());
                        unaNoti.FECHACREACION = DateTime.Parse(item["fechacreacion"].ToString());
                        unaNoti.FECHAMODIFICACION = DateTime.Parse(item["fechamodificacion"].ToString());
                        unaNoti.CATEGORIA = mapperCategoria.BuscarCategoriaPorID(int.Parse(item["categoria"].ToString()));
                        lista.Add(unaNoti);
                    }
                }
            }

            return lista;
        }

        public BE.BE_Noticia BuscarNoticiaPorID(int id) {
            BE.BE_Noticia noticia = new BE.BE_Noticia();
            DataSet ds = new DataSet();

            Hashtable filtros = new Hashtable();
            filtros.Add("@id", id);

            ds = sqlHelper.Leer("noticia_buscarporID", filtros);


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        noticia.ID = int.Parse(item["id_noticia"].ToString());
                        noticia.TITULO = item["titulo"].ToString();
                        noticia.CUERPO = item["cuerpo"].ToString();
                        noticia.HABILITADO = int.Parse(item["habilitado"].ToString());
                        noticia.FECHACREACION = DateTime.Parse(item["fechacreacion"].ToString());
                        noticia.FECHAMODIFICACION = DateTime.Parse(item["fechamodificacion"].ToString());
                        noticia.CATEGORIA = mapperCategoria.BuscarCategoriaPorID(int.Parse(item["categoria"].ToString()));
                    }
                }
            }

            return noticia;
        }

        public bool BorrarNoticia(int id) {
            bool ok = false;

            Hashtable datos = new Hashtable();

            datos.Add("@id", id);

            ok = sqlHelper.Escribir("noticia_borrar", datos);

            return ok;
        }
    }
}
