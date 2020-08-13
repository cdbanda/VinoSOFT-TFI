using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MPP
{
    public class MPP_Categoria
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();

        public List<BE.BE_Categoria> Listar(Hashtable filtros)
        {
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("categoria_leer", filtros);

            List<BE.BE_Categoria> listado = new List<BE.BE_Categoria>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        BE.BE_Categoria unaCate = new BE.BE_Categoria();
                        unaCate.ID = int.Parse(item["id_categoria"].ToString());
                        unaCate.NOMBRE = item["nombre"].ToString();
                        
                        listado.Add(unaCate);
                    }
                }
            }

            return listado;
        }

        public BE.BE_Categoria BuscarCategoriaPorID(int id) {
            DataSet ds = new DataSet();

            Hashtable filtros = new Hashtable();
            filtros.Add("@id",id);

            ds = sqlHelper.Leer("categoria_BuscarPorID", filtros);

            BE.BE_Categoria categoria = new BE.BE_Categoria();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        categoria.ID = int.Parse(item["id_categoria"].ToString());
                        categoria.NOMBRE = item["nombre"].ToString();
                    }
                }
            }

            return categoria;
        }
    }
}
