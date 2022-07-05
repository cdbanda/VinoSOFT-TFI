using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Venta_Detalle
    {
        private int idVentaDetalle;

        public int IDVENTADETALLE
        {
            get { return idVentaDetalle; }
            set { idVentaDetalle = value; }
        }

        private int idVenta;

        public int IDVENTA
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        private int cantidad;

        public int CANTIDAD
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private float monto;

        public float MONTO
        {
            get { return monto; }
            set { monto = value; }
        }

        private BE_Producto producto;

        public BE_Producto PRODUCTO
        {
            get { return producto; }
            set { producto = value; }
        }

        private float subtotal;

        public float SUBTOTAL
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

    }
}
