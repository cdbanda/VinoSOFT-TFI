using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Familia
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();

        public BE.BE_Familia obtenerPorID(int id)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idFam", id);
            DataSet ds = new DataSet();

            ds = sqlHelper.Leer("familia_porId", hdatos);
            BE.BE_Familia familia = null;
            if(ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0) {
                    DataRow item = ds.Tables[0].Rows[0];
                    familia = new BE.BE_Familia();
                    familia.IDFAMILIA = int.Parse(item["id_familia"].ToString());
                    familia.NOMBRE = item["nombre"].ToString();
                    familia.LISTAPERMISO = obtenerPermisosFamilia(id);
                }
            }
            return familia;

        }

        private List<BE.BE_Permiso> obtenerPermisosFamilia(int idFamilia) {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idFam",idFamilia);

            ds = sqlHelper.Leer("familiaPermiso_listar",hdatos);
            List<BE.BE_Permiso> listado = new List<BE.BE_Permiso>();
            foreach (DataRow dr in ds.Tables[0].Rows) {
                BE.BE_Permiso permiso = new BE.BE_Permiso();
                permiso.IDPERMISO = int.Parse(dr["id_permiso"].ToString());
                permiso.DESCRIPCION = dr["descripcion"].ToString();
                permiso.CODIGO = dr["codigo"].ToString();
                listado.Add(permiso);
            }
            return listado;
        }

        public bool agregarPermiso(BE.BE_Permiso permiso, int idFamilia) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@IdFamilia",idFamilia);
            hdatos.Add("@IdPermiso",permiso.IDPERMISO);

            bool resultado;
            resultado = sqlHelper.Escribir("familiaPermiso_agregar", hdatos);
            return resultado;
        }

        public bool crear(BE.BE_Familia familia) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@nombre",familia.NOMBRE);
            bool resultado;
            resultado = sqlHelper.Escribir("familia_crear",hdatos);
            return resultado;
        }

        public bool editar(BE.BE_Familia familia) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idFamilia", familia.IDFAMILIA);
            hdatos.Add("@nombre", familia.NOMBRE);
            bool resultado;
            resultado = sqlHelper.Escribir("familia_modificar", hdatos);
            return resultado;
        }

        public bool eliminar(BE.BE_Familia familia) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idFamilia", familia.IDFAMILIA);
            bool resultado;
            resultado = sqlHelper.Escribir("familia_eliminar", hdatos);
            return resultado;
        }

        public bool quitarPermiso(int idFamilia, int idPermiso) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idFamilia", idFamilia);
            hdatos.Add("@idPermiso", idPermiso);
            bool resultado;
            resultado = sqlHelper.Escribir("familia_quitarpermiso",hdatos);
            return resultado;
        }

        public List<BE.BE_Familia> listar(Hashtable filtros) {
            DataSet ds = new DataSet();
            List<BE.BE_Familia> listado = new List<BE.BE_Familia>();
            ds = sqlHelper.Leer("familia_obtener",filtros);

            if (ds.Tables[0].Rows.Count > 0) {
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    BE.BE_Familia familia = new BE.BE_Familia();
                    familia.IDFAMILIA = int.Parse(dr["id_familia"].ToString());
                    familia.NOMBRE = dr["nombre"].ToString();
                    listado.Add(familia);
                }
            }
            return listado;
        }

        public bool validarExistente(BE.BE_Familia familia) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@nombre", familia.NOMBRE);
            hdatos.Add("@idFamilia", familia.IDFAMILIA);
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("familia_validarexistente",hdatos);
            if (ds.Tables.Count > 0) {
                return ds.Tables[0].Rows.Count > 0;
            }
            return false;
        }
    }
}
