using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_ProductoComentario
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();

        public List<BE.BE_ProductoComentario> listarPorID(Hashtable filtros)
        {
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("productoComentario_listarPorID", filtros);

            List<BE.BE_ProductoComentario> listado = new List<BE.BE_ProductoComentario>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        BE.BE_ProductoComentario unComentario = new BE.BE_ProductoComentario();

                        unComentario.IDCOMENTARIO = int.Parse(item["id_comentario"].ToString());
                        unComentario.AUTOR = item["autor"].ToString();
                        unComentario.COMENTARIO = item["comentario"].ToString();
                        unComentario.ACTIVO = int.Parse(item["activo"].ToString());
                        //unComentario.IDPRODUCTO = int.Parse(item["id_producto"].ToString());
                        unComentario.FECHAHORA = DateTime.Parse(item["fechaHora"].ToString());


                        listado.Add(unComentario);
                    }
                }
            }

            return listado;
        }

        public bool insertarComentario(BE.BE_ProductoComentario unComentario) {

            Hashtable hdatos = new Hashtable();
            hdatos.Add("@autor", unComentario.AUTOR);
            hdatos.Add("@activo", unComentario.ACTIVO);
            hdatos.Add("@idProducto", unComentario.IDPRODUCTO);
            hdatos.Add("@fechaHora", unComentario.FECHAHORA);
            hdatos.Add("@comentario",unComentario.COMENTARIO);
            return sqlHelper.Escribir("productoComentario_registrar", hdatos);
        }
    }
}
