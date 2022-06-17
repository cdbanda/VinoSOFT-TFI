using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Cliente
    {
        DAL.SQLHelper SQLHelper = new DAL.SQLHelper();

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

            int idCliente = ObtenerUltimoID();
            if(idCliente < 1)
            {
                idCliente = 1;
            }
            hdatos.Add("@idcliente", idCliente);
            cliente.IDCLIENTE = idCliente;


            bool guardado = SQLHelper.Escribir("Cliente_crear",hdatos);
            //int idUsuario = CrearUsuario(cliente);
            //---

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

                id = int.Parse(dr["id"].ToString());
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

            bool guardado = SQLHelper.Escribir("Cliente_editar", hdatos);

            return guardado;

        }
        
    }
}
