using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    class BE_ProductoComentario
    {
        private int idComentario;

        public int IDCOMENTARIO
        {
            get { return idComentario; }
            set { idComentario = value; }
        }

        private string autor;

        public string AUTOR
        {
            get { return autor; }
            set { autor = value; }
        }

        private int activo;

        public int ACTIVO
        {
            get { return activo; }
            set { activo = value; }
        }

        private int idProducto;

        public int IDPRODUCTO
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private DateTime fechaHora;

        public DateTime FECHAHORA
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

    }
}
