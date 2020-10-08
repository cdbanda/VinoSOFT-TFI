using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Newsletter
    {
        MPP.MPP_Newsletter mapperNewsletter = new MPP.MPP_Newsletter();
        
        public bool verificarMailExistente(BE.BE_UsuarioSuscripcion usuario) {
            return mapperNewsletter.verificarMailExistente(usuario);
        }

        public int insertarMail(BE.BE_UsuarioSuscripcion usuario) {
            if (verificarMailExistente(usuario))
            {
                return 1;
            }
            else {
                return mapperNewsletter.insertarMail(usuario);
            }
        }

        public int borrarMail(string mail) {
            return mapperNewsletter.borrarMail(mail);
        }

    }
}
