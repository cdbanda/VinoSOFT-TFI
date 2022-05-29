﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Producto
    {
        private int idProduto;

        public int IDPRODUCTO
        {
            get { return idProduto; }
            set { idProduto = value; }
        }

        private int activo;

        public int ACTIVO
        {
            get { return activo; }
            set { activo = value; }
        }

        private int idCategoria;

        public int IDCATEGORIA
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string linkImagen;

        public string LINKIMAGEN
        {
            get { return linkImagen; }
            set { linkImagen = value; }
        }

        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private float precio;

        public float PRECIO
        {
            get { return precio; }
            set { precio = value; }
        }

        private string descripcionCorta;

        public string DESCRIPCIONCORTA
        {
            get { return descripcionCorta; }
            set { descripcionCorta = value; }
        }

        private List<BE.BE_ProductoComentario> comentarios;

        public List<BE.BE_ProductoComentario> COMENTARIOS
        {
            get { return comentarios; }
            set { comentarios = value; }
        }

    }
}
