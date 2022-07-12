using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class BE_Evento
    {
        public static int CAMBIO_CONTRASENIA_CLIENTE = 1;
        public static int EDITAR_CLIENTE = 2;
        public static int CREAR_CLIENTE = 3;
        public static int LOGIN_OK = 4;
        public static int INGRESO_FALLIDO = 5;
        public static int LOGOUT_OK = 6;
        public static int GENERAR_BACKUP = 7;
        public static int RESTAURAR_BACKUP = 8;
        public static int VENTA_FINALIZADA = 9;
        public static int ALTA_PRODUCTO = 10;
        public static int EDITAR_PRODUCTO = 11;

        static public Dictionary<int,string> nombresCriticidad = new Dictionary<int, string>();

        public Dictionary<int,string> NOMBRESCRITICIDAD
        {
            get { return nombresCriticidad; }
            set { nombresCriticidad = value; }
        }

        private int criticidad;

        public int CRITICIDAD
        {
            get { return criticidad; }
            set { criticidad = value; }
        }

        private int idEvento;

        public int IDEVENTO
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        private string nombre;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public BE_Evento() {
            agregarCriticidad();
        }

        private void agregarCriticidad() {
            if (NOMBRESCRITICIDAD.Count == 0)
            {
                NOMBRESCRITICIDAD.Add(1, "Muy Critico");
                NOMBRESCRITICIDAD.Add(2, "Critico");
                NOMBRESCRITICIDAD.Add(3, "Moderado");
                NOMBRESCRITICIDAD.Add(4, "Leve");
            }
        }
    }
}
