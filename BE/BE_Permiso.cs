using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Permiso
    {
        private string codigo;

        public string CODIGO
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int idPermiso;

        //1 = Permite
        //0 = Deniega

        public int IDPERMISO
        {
            get { return idPermiso; }
            set { idPermiso = value; }
        }

    }
}
