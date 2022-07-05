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
        MPP.MPP_Categoria mapperCategoria = new MPP_Categoria();

        public List<BE.BE_Producto> listar(Hashtable filtros) {
            
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("producto_listar", filtros);
            BE.BE_Categoria categoria = new BE.BE_Categoria();

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
                        unProducto.IMAGEN = item["link_imagen"].ToString();
                        categoria = mapperCategoria.BuscarCategoriaPorID(int.Parse(item["id_categoria"].ToString()));
                        unProducto.CATEGORIA = categoria;
                        unProducto.NOMBRE = item["nombre"].ToString();
                        unProducto.PRECIO = float.Parse(item["precio"].ToString());
                        unProducto.IDPRODUCTO = int.Parse(item["id_producto"].ToString());
                        unProducto.DESCRIPCIONCORTA = item["descripcion_corta"].ToString();
                        unProducto.STOCK = int.Parse(item["stock"].ToString());
                        unProducto.STOCKMINIMO = int.Parse(item["stock_minimo"].ToString());

                        listado.Add(unProducto);
                    }
                }
            }

            return listado;
        }

        public BE.BE_Producto listarProductoPorID(Hashtable filtros)
        {

            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("producto_listarPorID", filtros);

            BE.BE_Producto unProducto = new BE.BE_Producto();
            BE.BE_Categoria categoria = new BE.BE_Categoria();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {

                        unProducto.ACTIVO = int.Parse(item["activo"].ToString());
                        unProducto.DESCRIPCION = item["descripcion"].ToString();
                        unProducto.IMAGEN = item["link_imagen"].ToString();
                        categoria = mapperCategoria.BuscarCategoriaPorID(int.Parse(item["id_categoria"].ToString()));
                        unProducto.CATEGORIA = categoria;
                        unProducto.DESCRIPCIONCORTA = item["descripcion_corta"].ToString();
                        unProducto.NOMBRE = item["nombre"].ToString();
                        unProducto.PRECIO = float.Parse(item["precio"].ToString());
                        unProducto.IDPRODUCTO = int.Parse(item["id_producto"].ToString());
                        unProducto.STOCK = int.Parse(item["stock"].ToString());
                        unProducto.STOCKMINIMO = int.Parse(item["stock_minimo"].ToString());
                    }
                }
            }

            return unProducto;

        }

        public bool actualizar(BE.BE_Producto unProducto)
        {
            Hashtable datos = new Hashtable();
            datos.Add("@activo", unProducto.ACTIVO);
            datos.Add("@idProducto", unProducto.IDPRODUCTO);
            datos.Add("@id_categoria", unProducto.CATEGORIA.ID);
            datos.Add("@descripcion", unProducto.DESCRIPCION);
            datos.Add("@descripcionCorta", unProducto.DESCRIPCIONCORTA);
            datos.Add("@link_imagen", unProducto.IMAGEN);
            datos.Add("@nombre", unProducto.NOMBRE);
            datos.Add("@precio", unProducto.PRECIO);
            datos.Add("@stock", unProducto.STOCK);
            datos.Add("@stockMinimo", unProducto.STOCKMINIMO);

            bool ok = sqlHelper.Escribir("producto_actualizar", datos);

            return ok;
        }

        public bool insertar(BE.BE_Producto unProducto)
        {
            Hashtable datos = new Hashtable();
            datos.Add("@activo", unProducto.ACTIVO);
            datos.Add("@id_categoria", unProducto.CATEGORIA.ID);
            datos.Add("@descripcion", unProducto.DESCRIPCION);
            datos.Add("@descripcionCorta", unProducto.DESCRIPCIONCORTA);
            datos.Add("@link_imagen", unProducto.IMAGEN);
            datos.Add("@nombre", unProducto.NOMBRE);
            datos.Add("@precio", unProducto.PRECIO);
            datos.Add("@stock", unProducto.STOCK);
            datos.Add("@stockMinimo", unProducto.STOCKMINIMO);


            bool ok = sqlHelper.Escribir("producto_insertar", datos);

            return ok;
        }

        public bool eliminar(BE.BE_Producto unProducto)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idProducto", unProducto.IDPRODUCTO);

            bool ok = sqlHelper.Escribir("producto_eliminar", hdatos);

            return ok;
        }

        public int ValidarStock(BE.BE_Producto producto)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idproducto", producto.IDPRODUCTO);

            ds = sqlHelper.Leer("producto_validarStock", hdatos);

            int stock = 0;

            if (ds.Tables.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                stock = int.Parse(dr["stock"].ToString());
            }

            return stock;
        }

        public bool DescontarStock(int cantidad, BE.BE_Producto producto)
        {
            bool guardado;
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idproducto", producto.IDPRODUCTO);
            hdatos.Add("@cantidad", cantidad);

            guardado = sqlHelper.Escribir("producto_descontarStock", hdatos);

            return guardado;
        }
    }
}
