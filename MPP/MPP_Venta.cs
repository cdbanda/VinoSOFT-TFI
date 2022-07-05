using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Venta
    {
        DAL.SQLHelper SQLHelper = new DAL.SQLHelper();

        public BE.BE_Venta GetPorID(int idVenta)
        {
            DataSet ds = new DataSet();
            BE.BE_Venta venta = new BE.BE_Venta();
            Hashtable filtros = new Hashtable();

            filtros.Add("@idventa", idVenta);
            ds = SQLHelper.Leer("venta_obtenerporID", filtros);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                venta.IDVENTA = int.Parse(dr["id_venta"].ToString());
                venta.IDFACTURA = int.Parse(dr["id_factura"].ToString());
                venta.IDCLIENTE = int.Parse(dr["id_cliente"].ToString());
                venta.NOMBRECLIENTE = dr["apellido_cliente"].ToString() + ", " + dr["nombre_cliente"].ToString();
                venta.FECHA = DateTime.Parse(dr["fecha"].ToString());
                venta.ESTADO = dr["estado"].ToString();
                venta.MONTOTOTAL = float.Parse(dr["monto_total"].ToString());

            }

            return venta;
        }

        public bool ActualizarEstado(int idVenta, string estado)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idVenta", idVenta);
            hdatos.Add("@estado", estado);
            bool ok = SQLHelper.Escribir("venta_actualizarEstado", hdatos);
            return ok;
        }

        public List<BE.BE_Venta> GetVentasPorCliente(int idCliente)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idcliente", idCliente);

            List<BE.BE_Venta> listado = new List<BE.BE_Venta>();
            ds = SQLHelper.Leer("ventas_obtenerporCliente", hdatos);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    BE.BE_Venta venta = new BE.BE_Venta();
                    venta.IDVENTA = int.Parse(dr["id_venta"].ToString());
                    venta.IDFACTURA = int.Parse(dr["id_factura"].ToString());
                    venta.FECHA = DateTime.Parse(dr["fecha"].ToString());
                    venta.ESTADO = dr["estado"].ToString();
                    venta.MONTOTOTAL = float.Parse(dr["monto_total"].ToString());
                    listado.Add(venta);
                }
            }

            return listado;
        }

        public BE.BE_Venta_Detalle AgregarProducto(int idVenta, BE.BE_Venta_Detalle ventadetalle) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idventa", idVenta);
            hdatos.Add("@idproducto", ventadetalle.PRODUCTO.IDPRODUCTO);
            hdatos.Add("@cantidad", ventadetalle.CANTIDAD);
            int idventaDetalle = GetUltimoIDDetalleVenta() + 1;
            hdatos.Add("@iddetalleventa", idventaDetalle);

            bool guardado = SQLHelper.Escribir("venta_agregardetalle", hdatos);
            ventadetalle.IDVENTADETALLE = idventaDetalle;
            return ventadetalle;
        }

        public int GetUltimoIDDetalleVenta() {
            int id = 0;

            DataSet ds = new DataSet();
            ds = SQLHelper.Leer("venta_buscarDetalleUltimoID", null);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    id = int.Parse(item["id_venta_detalle"].ToString());
                }
            }
            return id;
        }


        public bool AnularVenta(BE.BE_Venta venta)
        {
            return false;
        }


        public BE.BE_Venta CrearCarrito(BE.BE_Cliente cliente)
        {
            BE.BE_Venta venta = new BE.BE_Venta();
            venta.IDCLIENTE = cliente.IDCLIENTE;
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@idcliente", cliente.IDCLIENTE);
            int idVenta = ultimoIDVenta() + 1;

            hdatos.Add("@idventa", idVenta);
            hdatos.Add("@abierta", 1); //venta abierta
            bool guardado = SQLHelper.Escribir("venta_crear", hdatos);
            if (guardado) {
                venta.IDVENTA = idVenta;
                return venta;
            }
            else
            {
                return venta = null;
            }
        }
        public bool agregarVenta(BE.BE_Venta venta) {
            bool ok = false;

            Hashtable hdatos = new Hashtable();
            hdatos.Add("@id_cliente", venta.IDCLIENTE);
            hdatos.Add("@fecha", venta.FECHA);
            hdatos.Add("@montoTotal", venta.MONTOTOTAL);

            ok = SQLHelper.Escribir("venta_insertar", hdatos);

            return ok;
        }

        public int ultimoIDVenta() {
            int id = 0;

            DataSet ds = new DataSet();
            ds = SQLHelper.Leer("venta_buscarUltimoID", null);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    id = int.Parse(item["id_venta"].ToString());
                }
            }
            return id;
        }

        public bool EditarItem(BE.BE_Venta_Detalle detalleVenta)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Idventadetalle", detalleVenta.IDVENTADETALLE);
            hdatos.Add("@cantidad", detalleVenta.CANTIDAD);

            bool guardado = SQLHelper.Escribir("venta_editardetalle", hdatos);
            return guardado;

        }

        public bool EliminarItem(BE.BE_Venta_Detalle detalleVenta)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@Idventadetalle", detalleVenta.IDVENTADETALLE);

            bool guardado = SQLHelper.Escribir("venta_eliminardetalle", hdatos);
            return guardado;

        }

        public bool EliminarVenta(BE.BE_Venta venta)
        {
            return false;
        }

        public bool FinalizarVenta(BE.BE_Venta venta) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idventa", venta.IDVENTA);
            hdatos.Add("@montototal", venta.MONTOTOTAL);
            hdatos.Add("@idfactura", venta.IDFACTURA);

            bool guardado = SQLHelper.Escribir("venta_finalizar", hdatos);
            return guardado;
        }

        public bool Guardar(BE.BE_Venta venta)
        {
            return false;
        }

        public bool IncrementarCantidad(BE.BE_Venta_Detalle detalleVenta) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idventadetalle", detalleVenta.IDVENTADETALLE);

            bool guardado = SQLHelper.Escribir("venta_incrementarCantidadProductoAgregado", hdatos);
            return guardado;

        }

        public List<BE.BE_Venta> Listar(Hashtable filtros = null)
        {
            DataSet ds = new DataSet();
            List<BE.BE_Venta> listado = new List<BE.BE_Venta>();

            ds = SQLHelper.Leer("ventas_listar", filtros);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    BE.BE_Venta venta = new BE.BE_Venta();
                    venta.IDVENTA = int.Parse(dr["id_venta"].ToString());
                    venta.IDFACTURA = int.Parse(dr["id_factura"].ToString());
                    venta.IDCLIENTE = int.Parse(dr["id_cliente"].ToString());
                    venta.NOMBRECLIENTE = dr["apellido_cliente"].ToString() + ", " + dr["nombre_cliente"].ToString();
                    venta.FECHA = DateTime.Parse(dr["fecha"].ToString());
                    venta.ESTADO = dr["estado"].ToString();
                    venta.MONTOTOTAL = float.Parse(dr["monto_total"].ToString());
                    listado.Add(venta);
                }
            }

            return listado;

        }

        public int ProductoAgregado(BE.BE_Venta_Detalle detalleVenta)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@idventa", detalleVenta.IDVENTA);
            hdatos.Add("@idproducto", detalleVenta.PRODUCTO.IDPRODUCTO);

            ds = SQLHelper.Leer("venta_validarProductoAgregado", hdatos);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                return int.Parse(dr["id_venta_detalle"].ToString());
            }
            return -1;

        }

        public List<BE.BE_Venta_Detalle> GetDetalleVenta(BE.BE_Venta venta)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idventa", venta.IDVENTA);
            List<BE.BE_Venta_Detalle> listado = new List<BE.BE_Venta_Detalle>();

            ds = SQLHelper.Leer("venta_obtenerdetalles",hdatos);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    BE.BE_Venta_Detalle ventadetalle = new BE.BE_Venta_Detalle();
                    BE.BE_Producto producto = new BE.BE_Producto();
                    ventadetalle.IDVENTADETALLE = int.Parse(dr["id_venta_detalle"].ToString());
                    ventadetalle.IDVENTA = int.Parse(dr["id_venta"].ToString());
                    ventadetalle.MONTO = float.Parse(dr["precio_unitario"].ToString());
                    ventadetalle.CANTIDAD = int.Parse(dr["cantidad"].ToString());
                    //Se crea la property Subtotal para el datagridview
                    ventadetalle.SUBTOTAL = ventadetalle.CANTIDAD * ventadetalle.MONTO;

                    producto.IDPRODUCTO = int.Parse(dr["id_producto"].ToString());
                    producto.NOMBRE = dr["producto_nombre"].ToString();
                    producto.DESCRIPCIONCORTA = dr["producto_descripcioncorta"].ToString();
                    producto.IMAGEN = dr["producto_linkimagen"].ToString();
                    ventadetalle.PRODUCTO = producto;
                    listado.Add(ventadetalle);
                }
            }
            return listado;
        }

        public BE.BE_Venta VerificarCarritoAbierto(int idCliente)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            BE.BE_Venta venta = new BE.BE_Venta();
            hdatos.Add("@idcliente", idCliente);

            ds = SQLHelper.Leer("venta_verificarcarritoabierto",hdatos);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    venta.IDVENTA = int.Parse(dr["id_venta"].ToString());
                    venta.IDCLIENTE = int.Parse(dr["id_cliente"].ToString());
                    venta.FECHA = DateTime.Parse(dr["fecha"].ToString());
                    List<BE.BE_Venta_Detalle> detalles = new List<BE.BE_Venta_Detalle>();
                    detalles = GetDetalleVenta(venta);
                    venta.ITEMS = detalles;
                }
                
            }
            else
            {
                venta.IDVENTA = -1;
            }
            return venta;
        }
    }
}
