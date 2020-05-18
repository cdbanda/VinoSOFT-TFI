using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BLL
{
    public class BLL_Familia
    {
        MPP.MPP_Familia mapperFamilia = new MPP.MPP_Familia();

        public BE.BE_Familia obtenerPorId(int idFamilia) {
            return mapperFamilia.obtenerPorID(idFamilia);
        }

        public bool agregarPermiso(BE.BE_Permiso permiso, int idFamilia) {
            return mapperFamilia.agregarPermiso(permiso, idFamilia);
        }

        public bool crear(BE.BE_Familia familia)
        {
            if (mapperFamilia.validarExistente(familia))
            {
                return false;
            }
            else {
                familia.IDFAMILIA = 0;
                return mapperFamilia.crear(familia);
            }
        }

        public bool editar(BE.BE_Familia familia) {
            if (mapperFamilia.validarExistente(familia))
            {
                return false;
            }
            else {
                return mapperFamilia.editar(familia);
            }
        }

        public bool eliminar(BE.BE_Familia familia) {
            return mapperFamilia.eliminar(familia);
        }

        public bool quitarPermiso(int idFamilia, int idPermiso) {
            return mapperFamilia.quitarPermiso(idFamilia,idPermiso);
        }

        public List<BE.BE_Familia> listar(Hashtable filtros = null) {
            return mapperFamilia.listar(filtros);
        }
    }
}
