using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_UsuarioSuscripcion
    {

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string email;

        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }

        private int riego;

        public int RIEGO
        {
            get { return riego; }
            set { riego = value; }
        }

        private int humedad;

        public int HUMEDAD
        {
            get { return humedad; }
            set { humedad = value; }
        }

        private int imagenes;

        public int IMAGENES
        {
            get { return imagenes; }
            set { imagenes = value; }
        }

    }
}
