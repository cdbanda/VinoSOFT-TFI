using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace BLL
{
    public class BLL_Producto
    {
        MPP.MPP_ProductoComentario mapperProdComen = new MPP.MPP_ProductoComentario();
        MPP.MPP_Producto mapperProducto = new MPP.MPP_Producto();

        public bool actualizarProducto(BE.BE_Producto unProducto)
        {
            bool ok = mapperProducto.actualizar(unProducto);

            return ok;
        }

        public bool insertarProducto(BE.BE_Producto unProducto) {
            bool ok = mapperProducto.insertar(unProducto);

            return ok;
        }

        public bool eliminarProducto(BE.BE_Producto unProducto)
        {
            bool ok = mapperProducto.eliminar(unProducto);
            return ok;
        }

        public List<BE.BE_Producto> listarProducto()
        {
            Hashtable filtros = new Hashtable();
            filtros = null;
            List<BE.BE_Producto> lista = mapperProducto.listar(filtros);

            return lista;
        }

        public bool insertarComentario(BE.BE_ProductoComentario unComentario) {
            bool ok = mapperProdComen.insertarComentario(unComentario);
            return ok;
        }

        public List<BE.BE_ProductoComentario> listarComentariosPorID(int idProducto) {

            Hashtable datos = new Hashtable();
            datos.Add("@id",idProducto);

            List<BE.BE_ProductoComentario> lista = new List<BE.BE_ProductoComentario>();
            lista = mapperProdComen.listarPorID(datos);
            return lista;
        }

        public BE.BE_Producto listarProductoPorID(int id) {
            Hashtable filtros = new Hashtable();
            filtros.Add("@id", id);
            BE.BE_Producto producto = new BE.BE_Producto();
            producto = mapperProducto.listarProductoPorID(filtros);
            //Agregar lista de comentarios
            producto.COMENTARIOS = listarComentariosPorID(id);
            return producto;
        
        }

        public int ValidarStock(BE.BE_Producto producto)
        {
            return mapperProducto.ValidarStock(producto);
        }

        public bool DescontarStock(int cantidad, BE.BE_Producto producto)
        {
            return mapperProducto.DescontarStock(cantidad,producto);
        }

        public int ObtenerStockMinimo(BE.BE_Producto producto)
        {
            return mapperProducto.ObtenerStockMinimo(producto);
        }

   }
}
