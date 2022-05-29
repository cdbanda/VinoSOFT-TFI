using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;


namespace MPP
{
    public class MPP_Producto
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();

        public List<BE.BE_Producto> listar(Hashtable filtros) {
            
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("productos_listar", filtros);

            List<BE.BE_Producto> listado = new List<BE.BE_Producto>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        BE.BE_Producto unProducto = new BE.BE_Producto();
                        unProducto.ACTIVO = int.Parse(item["activo"].ToString());
                        unProducto.DESCRIPCION = item["descripcion"].ToString();
                        unProducto.LINKIMAGEN = item["link_imagen"].ToString();
                        unProducto.IDCATEGORIA = int.Parse(item["id_categoria"].ToString());
                        unProducto.NOMBRE = item["nombre"].ToString();
                        unProducto.PRECIO = float.Parse(item["precio"].ToString());
                        unProducto.IDPRODUCTO = int.Parse(item["id_producto"].ToString());
                        unProducto.DESCRIPCIONCORTA = item["descripcion_corta"].ToString();
                        listado.Add(unProducto);
                    }
                }
            }

            return listado;
        }

        public BE.BE_Producto listarProductoPorID(Hashtable filtros)
        {

            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("productos_listarPorID", filtros);

            BE.BE_Producto unProducto = new BE.BE_Producto();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {

                        unProducto.ACTIVO = int.Parse(item["activo"].ToString());
                        unProducto.DESCRIPCION = item["descripcion"].ToString();
                        unProducto.LINKIMAGEN = item["link_imagen"].ToString();
                        unProducto.IDCATEGORIA = int.Parse(item["id_categoria"].ToString());
                        unProducto.DESCRIPCIONCORTA = item["descripcion_corta"].ToString();
                        unProducto.NOMBRE = item["nombre"].ToString();
                        unProducto.PRECIO = float.Parse(item["precio"].ToString());
                        unProducto.IDPRODUCTO = int.Parse(item["id_producto"].ToString());
                    }
                }
            }

            return unProducto;

        }

        public bool actualizar(BE.BE_Producto unProducto)
        {
            Hashtable datos = new Hashtable();
            datos.Add("@id_producto", unProducto.IDPRODUCTO);
            datos.Add("@activo", unProducto.ACTIVO);
            datos.Add("@id_categoria", unProducto.IDCATEGORIA);
            datos.Add("@descripcion",unProducto.DESCRIPCION);
            datos.Add("@link_imagen",unProducto.LINKIMAGEN);
            datos.Add("@nombre", unProducto.NOMBRE);
            datos.Add("@precio", unProducto.PRECIO);

            bool ok = sqlHelper.Escribir("producto_actualizar", datos);

            return ok;
        }

        public bool insertar(BE.BE_Producto unProducto)
        {
            Hashtable datos = new Hashtable();
            datos.Add("@activo", unProducto.ACTIVO);
            datos.Add("@id_categoria", unProducto.IDCATEGORIA);
            datos.Add("@descripcion", unProducto.DESCRIPCION);
            datos.Add("@link_imagen", unProducto.LINKIMAGEN);
            datos.Add("@nombre", unProducto.NOMBRE);
            datos.Add("@precio", unProducto.PRECIO);

            bool ok = sqlHelper.Escribir("producto_insertar", datos);

            return ok;
        }
    }
}
