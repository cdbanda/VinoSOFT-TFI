using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Cliente
    {
        MPP.MPP_Cliente mapperCliente = new MPP.MPP_Cliente();
        BLL.BLL_Seguridad gestorSeguridad = new BLL_Seguridad();

        public bool crear(BE.BE_Cliente cliente)
        {
            //Se encripta la contraseña
            cliente.CONTRASENA = gestorSeguridad.Encriptar(cliente.CONTRASENA);
            return mapperCliente.Crear(cliente);
        }

        public bool editar(BE.BE_Cliente cliente)
        {
            return mapperCliente.Editar(cliente);
        }

        //public bool eliminar(BE.BE_Cliente cliente)
        //{
        //    return mapperCliente.eliminar(cliente);
        //}
    }
}
