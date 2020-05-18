using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Backup
    {
        private int idBackup;

        public int IDBACKUP
        {
            get { return idBackup; }
            set { idBackup = value; }
        }

        private string ruta;

        public string RUTA
        {
            get { return ruta; }
            set { ruta = value; }
        }

        private DateTime fecha;

        public DateTime FECHA
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
