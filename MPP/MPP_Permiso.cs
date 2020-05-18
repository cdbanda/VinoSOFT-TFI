using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Permiso
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();
        public List<BE.BE_Permiso> listar(Hashtable filtros) {
            DataSet ds = new DataSet();
            List<BE.BE_Permiso> listado = new List<BE.BE_Permiso>();

            ds = sqlHelper.Leer("permisos_obtener",filtros);
            if (ds.Tables[0].Rows.Count > 0) {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    BE.BE_Permiso permiso = new BE.BE_Permiso();
                    permiso.IDPERMISO = int.Parse(dr["id_permiso"].ToString());
                    permiso.CODIGO = dr["codigo"].ToString();
                    permiso.DESCRIPCION = dr["descripcion"].ToString();
                    listado.Add(permiso);
                }
            }
            return listado;
        }
    }
}
