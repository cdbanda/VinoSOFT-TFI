using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Factura
    {
        public const string ESTADO_PAGADA = "PAGADA";
        public const string ESTADO_NC_SIN_USAR = "NC_SIN_USAR";
        public const string ESTADO_NC_USADA = "NC_USADA";
        public const string ESTADO_ANULAR = "ANULADA";
        public const int TIPO_FC = 1;
        public const int TIPO_NC = 2;

        private int idFacturaRelacionado;

        public int IDFACTURARELACIONADO
        {
            get { return idFacturaRelacionado; }
            set { idFacturaRelacionado = value; }
        }

        private int idVenta;

        public int IDVENTA
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        private string ciudad;

        public string CIUDAD
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        private string estado;

        public string ESTADO
        {
            get { return estado; }
            set { estado = value; }
        }

        private DateTime fecha;

        public DateTime FECHA
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int formaPago;

        public int FORMAPAGO
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        private int idFactura;

        public int IDFACTURA
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

        private List<BE.BE_Factura_Detalle> items;

        public List<BE.BE_Factura_Detalle> ITEMS
        {
            get { return items; }
            set { items = value; }
        }

        private float monto;

        public float MONTO
        {
            get { return monto; }
            set { monto = value; }
        }

        private int tipo;

        public int TIPO
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }
}
