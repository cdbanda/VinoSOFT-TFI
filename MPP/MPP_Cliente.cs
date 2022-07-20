using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Cliente
    {
        DAL.SQLHelper SQLHelper = new DAL.SQLHelper();
        //ID para familia del cliente,
        const int ID_FAMILIA_CLIENTE = 2;
        MPP.MPP_Usuario mapperUsuario = new MPP_Usuario();

        public BE.BE_Cliente GetPorID(int id)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@id", id);
            DataSet ds = new DataSet();
            BE.BE_Cliente cliente = new BE.BE_Cliente();

            ds = SQLHelper.Leer("cliente_obtenerPorID", hdatos);
            if(ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
               
                cliente.IDCLIENTE = int.Parse(dr["id_cliente"].ToString());
                cliente.NOMBRE = dr["nombre"].ToString();
                cliente.APELLIDO = dr["apellido"].ToString();
                cliente.EMAIL = dr["email"].ToString();
                cliente.CONTRASENA = dr["contrasena"].ToString();
                cliente.DNI = int.Parse(dr["dni"].ToString());
                cliente.DOMICILIO = dr["domicilio"].ToString();
                cliente.CIUDAD = dr["ciudad"].ToString();
                cliente.TELEFONO = dr["telefono"].ToString();


            }
            return cliente;
        }

        public bool Crear(BE.BE_Cliente cliente)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@nombre", cliente.NOMBRE);
            hdatos.Add("@apellido", cliente.APELLIDO);
            hdatos.Add("@domicilio", cliente.DOMICILIO);
            hdatos.Add("@dni", cliente.DNI);
            hdatos.Add("@ciudad", cliente.CIUDAD);
            hdatos.Add("@telefono", cliente.TELEFONO);
            hdatos.Add("@contrasena", cliente.CONTRASENA);
            hdatos.Add("@email", cliente.EMAIL);

            int idCliente = ObtenerUltimoID() + 1;
            if(idCliente < 1)
            {
                idCliente = 1;
            }
            hdatos.Add("@idcliente", idCliente);
            cliente.IDCLIENTE = idCliente;


            bool guardado = SQLHelper.Escribir("Cliente_crear",hdatos);
            //se asigna familia
            if (guardado)
            {
                int idUsuario = mapperUsuario.BuscarUltimoIDUsuario() + 1;
                
                bool clienteGuardado = CrearUsuario(cliente);
                bool asigFamilia = AsignarFamilia(idUsuario);
                return clienteGuardado;
                
            }
            else
            {
               return guardado;
            }

        }

        public bool CrearUsuario(BE.BE_Cliente cliente)
        {
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@nombre", cliente.NOMBRE);
            hdatos.Add("@apellido", cliente.APELLIDO);
            hdatos.Add("@domicilio", cliente.DOMICILIO);
            hdatos.Add("@dni", cliente.DNI);
            hdatos.Add("@ciudad", cliente.CIUDAD);
            hdatos.Add("@telefono", cliente.TELEFONO);
            hdatos.Add("@contrasena", cliente.CONTRASENA);
            hdatos.Add("@email", cliente.EMAIL);
            hdatos.Add("@idCliente", cliente.IDCLIENTE);
            hdatos.Add("@activo", 1); //el cliente no tiene acceso a la parte admin, se habilita desde la gestion del usuario.
            hdatos.Add("@esempleado", 0);
            int idUsuario = mapperUsuario.BuscarUltimoIDUsuario() + 1;
            hdatos.Add("@id", idUsuario);


            bool guardado = SQLHelper.Escribir("usuario_crear", hdatos);
            return guardado;
        }

        public int ObtenerUltimoID()
        {
            int id = 0;
            DataSet ds = new DataSet();

            ds = SQLHelper.Leer("Cliente_obtenerUltimoID", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                id = int.Parse(dr["id_cliente"].ToString());
            }

            return id;
        }

        public bool Editar(BE.BE_Cliente cliente)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@nombre", cliente.NOMBRE);
            hdatos.Add("@apellido", cliente.APELLIDO);
            hdatos.Add("@domicilio", cliente.DOMICILIO);
            hdatos.Add("@dni", cliente.DNI);
            hdatos.Add("@ciudad", cliente.CIUDAD);
            hdatos.Add("@telefono", cliente.TELEFONO);
            hdatos.Add("@contrasena", cliente.CONTRASENA);
            hdatos.Add("@email", cliente.EMAIL);
            hdatos.Add("@idCliente", cliente.IDCLIENTE);

            bool guardado = SQLHelper.Escribir("Cliente_actualizar", hdatos);

            return guardado;

        }

        public bool AsignarFamilia(int idUsuario)
        {
            bool ok = false;
            MPP.MPP_Usuario mapperUsuario = new MPP_Usuario();

            ok = mapperUsuario.agregarFamilia(ID_FAMILIA_CLIENTE, idUsuario);
            return ok;
        }

        public bool validarExistentePorMail(BE.BE_Cliente cliente)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@email", cliente.EMAIL);

            DataSet ds = new DataSet();
            ds = SQLHelper.Leer("cliente_validarExistentePorMail", hdatos);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool eliminar(BE.BE_Cliente cliente)
        {
            return false; //hacerlo en caso de ser necesario.
        }

        public List<BE.BE_Cliente> listar()
        { //crear si es necesario
            List<BE.BE_Cliente> listado = new List<BE.BE_Cliente>();
            return listado;
        }

        public bool CambiarContrasenia(BE.BE_Cliente cliente)
        {

            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idCliente", cliente.IDCLIENTE);
            hdatos.Add("@contrasenia", cliente.CONTRASENA);

            return SQLHelper.Escribir("Cliente_CambiarContrasenia", hdatos);

        }
    }
}
