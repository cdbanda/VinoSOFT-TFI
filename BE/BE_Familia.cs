using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Familia
    {
        private int idFamilia;

        public int IDFAMILIA
        {
            get { return idFamilia; }
            set { idFamilia = value; }
        }

        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private List<BE_Permiso> listaPermiso;

        public List<BE_Permiso> LISTAPERMISO
        {
            get { return listaPermiso; }
            set { listaPermiso = value; }
        }

    }
}
