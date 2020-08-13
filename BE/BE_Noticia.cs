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

        private BE.BE_Categoria categoria;

        public BE.BE_Categoria CATEGORIA
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

        private int habilitado;

        public int HABILITADO
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private DateTime fechaCreacion;

        public DateTime FECHACREACION
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        private DateTime fechaModificacion;

        public DateTime FECHAMODIFICACION
        {
            get { return fechaModificacion; }
            set { fechaModificacion = value; }
        }

    }
}
