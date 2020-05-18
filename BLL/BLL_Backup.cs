using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Backup
    {
        MPP.MPP_Backup mapperBackup = new MPP.MPP_Backup();

        public List<BE.BE_Backup> listar (Hashtable filtros){

            return mapperBackup.listar(filtros);
        }

        public bool eliminar(BE.BE_Backup backup) {
            bool ok = true;
            return ok;
        }

        public bool registrarBackup(string ruta) {
            return mapperBackup.registrarBackup(ruta);
        }

        public bool realizarBackup(string ruta) {
            //string fecha_backup = DateTime.Now.ToShortDateString();
            //string basepath = System.IO.Directory.GetCurrentDirectory();
            return mapperBackup.realizarBackup(ruta);
        }

        public bool restaurarBackup(string ruta) {
            return mapperBackup.restaurarBackup(ruta);
        }

        public BE.BE_Backup obtenerPorID(int idBackup) {
            return mapperBackup.obtenerPorID(idBackup);
        }
    }
}
