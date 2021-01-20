using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Usuario
    {
        private bool activo;

        public bool ACTIVO
        {
            get { return activo; }
            set { activo = value; }
        }

        private string apellido;

        public string APELLIDO
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string contraseña;

        public string CONTRASEÑA
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        private string email;

        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }

        private string telefono;

        public string TELEFONO
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private List<BE_Familia> listaFamilia;

        public List<BE_Familia> LISTAFAMILIA
        {
            get { return listaFamilia; }
            set { listaFamilia = value; }
        }

        private int idUsuario;

        public int IDUSUARIO
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }


        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private List<BE_Permiso> listaPermiso;

        public List<BE_Permiso> LISTAPERMISO
        {
            get { return listaPermiso; }
            set { listaPermiso = value; }
        }

        private int dni;

        public int DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        private string domicilio;

        public string DOMICILIO
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        private bool esAdmin;

        public bool ESADMIN
        {
            get { return esAdmin; }
            set { esAdmin = value; }
        }

        private bool esEmpleado;

        public bool ESEMPLEADO
        {
            get { return esEmpleado; }
            set { esEmpleado = value; }
        }

        private string ciudad;

        public string CIUDAD
        {
            get { return ciudad; }
            set { ciudad = value; }
        }


    }
}
