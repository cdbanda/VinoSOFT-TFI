using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace MPP
{
    public class MPP_Reporte
    {
        DAL.SQLHelper SQLhelper = new DAL.SQLHelper();

        public DataSet VentasPorEstadoCantidad()
        {
            DataSet ds = new DataSet();
            ds = SQLhelper.Leer("reporte_VentasPorEstadoCantidad", null);

            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public DataSet CantidadProductosVendidos()
        {
            DataSet ds = new DataSet();
            ds = SQLhelper.Leer("reporte_cantidadProductosVendidos", null);

            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

    }
}
