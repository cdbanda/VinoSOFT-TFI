using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Bitacora
    {
        private BE_Evento evento;

        public BE_Evento EVENTO
        {
            get { return evento; }
            set { evento = value; }
        }

        private DateTime fechaHora;

        public DateTime FECHAHORA
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        private int idBitacora;

        public int IDBITACORA
        {
            get { return idBitacora; }
            set { idBitacora = value; }
        }

        private string observacion;

        public string OBSERVACION
        {
            get { return observacion; }
            set { observacion = value; }
        }

        private string impacto;

        public string IMPACTO
        {
            get { return impacto; }
            set { impacto = value; }
        }

        private BE_Usuario usuario;

        public BE_Usuario USUARIO
        {
            get { return usuario; }
            set { usuario = value; }
        }

    }
}
