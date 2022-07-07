using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class BLL_Reporte
    {
        MPP.MPP_Reporte mapperReporte = new MPP.MPP_Reporte();

        public DataSet VentasPorEstadoCantidad()
        {
            return mapperReporte.VentasPorEstadoCantidad();
        }

        public DataSet CantidadProductosVendidos()
        {
            return mapperReporte.CantidadProductosVendidos();
        }
    }
}
