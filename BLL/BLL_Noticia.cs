using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Noticia
    {
        MPP.MPP_Noticia mapperNoticia = new MPP.MPP_Noticia();
        public bool insertarNoticia(BE.BE_Noticia noticia) {
            return mapperNoticia.insertarNoticia(noticia);
        }
    }
}
