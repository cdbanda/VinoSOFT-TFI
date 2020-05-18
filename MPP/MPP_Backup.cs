using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace MPP
{
    public class MPP_Backup
    {
        DAL.SQLHelper SQLhelp = new DAL.SQLHelper();

        public List<BE.BE_Backup> listar(Hashtable filtros) {
            DataSet ds = new DataSet();
            ds = SQLhelp.Leer("backups_obtener",filtros);

            List<BE.BE_Backup> listado = new List<BE.BE_Backup>();
            if (ds.Tables.Count > 0) {
                if (ds.Tables[0].Rows.Count > 0) {
                    foreach (DataRow item in ds.Tables[0].Rows) {
                        BE.BE_Backup unBkp = new BE.BE_Backup();
                        unBkp.IDBACKUP = int.Parse(item["id_backup"].ToString());
                        unBkp.RUTA = item["ruta"].ToString();
                        unBkp.FECHA = DateTime.Parse(item["fecha"].ToString());
                        listado.Add(unBkp);
                    }
                }
            }

            return listado;
        }

        public bool registrarBackup(string ruta) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@rutaGenerada", ruta);
            bool guardado = SQLhelp.Escribir("backup_registrarRealizado",hdatos);
            return guardado;
        }

        public bool realizarBackup(string rutaGenerada) {
            bool ok;
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@rutaGenerada",rutaGenerada);

            ok = SQLhelp.generarBackup("backup_crear", hdatos);

            return ok;
        }

        public bool restaurarBackup(string ruta) {
            bool ok;

            ok = SQLhelp.generarBase(ruta);
            return ok;
        }

        public BE.BE_Backup obtenerPorID(int idBackup) {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idBackup", idBackup);
            ds = SQLhelp.Leer("backups_obtener", hdatos);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    BE.BE_Backup unBK = new BE.BE_Backup();
                    unBK.IDBACKUP = int.Parse(item["id_backup"].ToString());
                    unBK.FECHA = DateTime.Parse(item["fecha"].ToString());
                    unBK.RUTA = item["ruta"].ToString();
                    return unBK;
                }
            }
            return new BE.BE_Backup();

        }


    }
}
