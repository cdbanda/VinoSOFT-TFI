using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BLL
{
    public class BLL_Permiso
    {
        MPP.MPP_Permiso mapperPermiso = new MPP.MPP_Permiso();
        public List<BE.BE_Permiso> listar(Hashtable hdatos) {
            return mapperPermiso.listar(hdatos);
        }
    }
}
