using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Venta
    {
        private int idVenta;

        public int IDVENTA
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        private int idCliente;

        public int IDCLIENTE
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private DateTime fecha;

        public DateTime FECHA
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private List<BE_Venta_Detalle> items;

        public List<BE_Venta_Detalle> ITEMS

        {
            get { return items; }
            set { items = value; }
        }

        private float montoTotal;

        public float MONTOTOTAL
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        private int idFactura;

        public int IDFACTURA
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

    }
}
