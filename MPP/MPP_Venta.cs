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
                    id = int.Parse(item["id"].ToString());
                }
            }
            return id;
        }

        public bool agregarDetalleVenta(BE.BE_Venta_Detalle ventaDetalle) {
            bool ok = false;

            int id = ultimoIDVenta();

            Hashtable hdatos = new Hashtable();
            hdatos.Add("@id_venta", ventaDetalle.IDVENTA);
            hdatos.Add("@cantidad", ventaDetalle.CANTIDAD);
            hdatos.Add("@id_producto", ventaDetalle.PRODUCTO.IDPRODUCTO);
            hdatos.Add("@monto", ventaDetalle.MONTO);
            hdatos.Add("@id_venta", id);

            ok = SQLHelper.Escribir("venta_detalle_insertar", hdatos);


            return ok;
        }


        public List<BE.BE_Venta> Listar(Hashtable filtros)
        {
            DataSet ds = new DataSet();
            List<BE.BE_Venta> lista = new List<BE.BE_Venta>();

            ds = SQLHelper.Leer("ventas_obtener",filtros);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    BE.BE_Venta unaVenta = new BE.BE_Venta();

                }
            }

            return lista;
        }


    }
}
