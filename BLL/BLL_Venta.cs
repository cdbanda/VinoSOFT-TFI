using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Venta
    {
        MPP.MPP_Venta mapperVenta = new MPP.MPP_Venta();

        public BE.BE_Venta GetPorID(int idVenta) {
            return mapperVenta.GetPorID(idVenta);
        
        }

        public bool ActualizarEstado(int idVenta, string estado)
        {
            return mapperVenta.ActualizarEstado(idVenta, estado);
        }

        public List<BE.BE_Venta> GetVentasPorClientes(int idCliente) {
            return mapperVenta.GetVentasPorCliente(idCliente);

             }

        public bool AgregarProducto(int idVenta, BE.BE_Venta_Detalle detalleVenta)
        {
            MPP.MPP_Producto mapperProductos = new MPP.MPP_Producto();
            int stockSuficiente = mapperProductos.ValidarStock(detalleVenta.PRODUCTO);
            if(stockSuficiente < detalleVenta.CANTIDAD)
            {
                return false;
            }
            int iddteVenta = mapperVenta.ProductoAgregado(detalleVenta);

            if (iddteVenta > 0)
            {
                detalleVenta.IDVENTA = iddteVenta;
                return mapperVenta.IncrementarCantidad(detalleVenta);
            }
            else {
                detalleVenta = mapperVenta.AgregarProducto(idVenta,detalleVenta);
                return detalleVenta.IDVENTADETALLE > 0; //true
                
            }
        }

        public bool AnularVenta(BE.BE_Venta venta)
        {
            return false;
        }

        public bool Editar(BE.BE_Venta_Detalle detalleVenta)
        {
            return false;
        }

        public bool EliminarItem(BE.BE_Venta_Detalle detalleVenta)
        {
            return mapperVenta.EliminarItem(detalleVenta);
        }

        public bool EditarItem(BE.BE_Venta_Detalle detalleVenta)
        {
            return mapperVenta.EditarItem(detalleVenta);
        }

        public bool FinalizarVenta(BE.BE_Venta venta)
        {
            return mapperVenta.FinalizarVenta(venta);
        }

        public BE.BE_Venta GetCarrito(int idCliente)
        {
            BE.BE_Venta venta = new BE.BE_Venta();
            venta = mapperVenta.VerificarCarritoAbierto(idCliente);
            if(venta.IDVENTA < 0)
            {
                //evento bitacora
                BE.BE_Cliente cliente = new BE.BE_Cliente();
                cliente.IDCLIENTE = idCliente;
                venta = mapperVenta.CrearCarrito(cliente);
            }
            return venta;
        }

        public bool Guardar(BE.BE_Venta venta)
        {
            return false;
        }

        public List<BE.BE_Venta> Listar(Hashtable filtros = null)
        {
            return mapperVenta.Listar(filtros);
        }
    }
}
