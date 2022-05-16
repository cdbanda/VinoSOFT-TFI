using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<BE.BE_Producto> listarProducto()
        {
            List<BE.BE_Producto> lista = mapperProducto.listar();

            return lista;
        }

   }
}
