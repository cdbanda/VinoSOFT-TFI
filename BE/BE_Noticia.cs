using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Noticia
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string categoria;

        public string CATEGORIA
        {
            get { return categoria; }
            set { categoria = value; }
        }


        private string titulo;

        public string TITULO
        {
            get { return titulo; }
            set { titulo = value; }
        }

        private string cuerpo;

        public string CUERPO
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }

    }
}
