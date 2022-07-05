using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Cliente
    {

        private int idCliente;

        public int IDCLIENTE
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        private string apellido;

        public string APELLIDO
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string contrasena;

        public string CONTRASENA
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        private string ciudad;

        public string CIUDAD
        {
            get { return ciudad; }
            set { ciudad = value; }
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

        private string email;

        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }

        private BE.BE_Venta venta;

        public BE.BE_Venta VENTA
        {
            get { return venta; }
            set { venta = value; }
        }

        private float saldoFavor;

        public float SALDOFAVOR
        {
            get { return saldoFavor; }
            set { saldoFavor = value; }
        }

        private string telefono;

        public string TELEFONO
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string origen;

        public string ORIGEN
        {
            get { return origen; }
            set { origen = value; }
        }

        private List<BE.BE_Permiso> listaPermisos;

        public List<BE.BE_Permiso> LISTAPERMISOS
        {
            get { return LISTAPERMISOS; }
            set { LISTAPERMISOS = value; }
        }


    }
}
