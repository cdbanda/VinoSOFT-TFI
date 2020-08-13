using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Categoria
    {
        MPP.MPP_Categoria mapperCategoria = new MPP.MPP_Categoria();

        public List<BE.BE_Categoria> Listar(Hashtable filtros) {
            List<BE.BE_Categoria> lista = new List<BE.BE_Categoria>();
            lista = mapperCategoria.Listar(filtros);
            return lista;

        }
    }
}
