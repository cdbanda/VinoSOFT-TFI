using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Usuario
    {
        DAL.SQLHelper sqlHelper = new DAL.SQLHelper();

        public BE.BE_Usuario getPorID(int id)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", id);
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("usuario_obtenerporid", hdatos);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    BE.BE_Usuario usuario = new BE.BE_Usuario();
                    BE.BE_Cliente clienteAsociado = new BE.BE_Cliente();
                    clienteAsociado.IDCLIENTE = 0;

                    usuario.IDUSUARIO = int.Parse(item["id_usuario"].ToString());
                    usuario.NOMBRE = item["nombre"].ToString();
                    usuario.APELLIDO = item["apellido"].ToString();
                    usuario.EMAIL = item["email"].ToString();
                    usuario.TELEFONO = Convert.IsDBNull(item["telefono"]) ? "" : item["telefono"].ToString();
                    usuario.CONTRASENA = item["contrasenia"].ToString();
                    usuario.ESEMPLEADO = bool.Parse(item["es_empleado"].ToString());
                    usuario.DNI = Convert.IsDBNull(item["dni"]) ? 0 : int.Parse(item["dni"].ToString());
                    usuario.ACTIVO = bool.Parse(item["activo"].ToString());

                    if(item["idCliente"] != null && int.TryParse(item["idCliente"].ToString(),out _))
                    {
                        clienteAsociado.IDCLIENTE = int.Parse(item["idCliente"].ToString());
                    }

                    usuario.CLIENTE = clienteAsociado;
                    usuario.LISTAFAMILIA = getFamiliasPorUsuario(usuario.IDUSUARIO);
                    usuario.LISTAPERMISO = getPermisosPorUsuario(usuario.IDUSUARIO);

                    return usuario;
                }
            }
            return null;
        }

        private List<BE.BE_Familia> getFamiliasPorUsuario(int idUsuario)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            List<BE.BE_Familia> listado = new List<BE.BE_Familia>();
            ds = sqlHelper.Leer("familia_obtenerporusuario", hdatos);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    BE.BE_Familia familia = new BE.BE_Familia();
                    familia.IDFAMILIA = int.Parse(dr["id_familia"].ToString());
                    familia.NOMBRE = dr["nombre"].ToString();
                    listado.Add(familia);
                }
            }
            return listado;
        }

        private List<BE.BE_Permiso> getPermisosPorUsuario(int idUsuario)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);

            ds = sqlHelper.Leer("permisos_obtenerporusuario", hdatos);
            List<BE.BE_Permiso> listado = new List<BE.BE_Permiso>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BE.BE_Permiso permiso = new BE.BE_Permiso();
                permiso.IDPERMISO = int.Parse(dr["id_permiso"].ToString());
                permiso.DESCRIPCION = dr["descripcion"].ToString();
                permiso.CODIGO = dr["codigo"].ToString();
                permiso.TIPO = int.Parse(dr["tipo"].ToString());
                listado.Add(permiso);
            }
            return listado;
        }

        public bool VerificarSiFamiliaExisteEnUsuario(int idFamilia, int idUsuario)
        {

            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idFamilia", idFamilia);

            ds = sqlHelper.Leer("usuario_VerificarSiFamiliaExisteEnUsuario", hdatos);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarSiPermisoExisteEnUsuario(int idPermiso, int idUsuario)
        {

            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idPermiso", idPermiso);

            ds = sqlHelper.Leer("usuario_VerificarSiPermisoExisteEnUsuario", hdatos);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }



        public bool agregarFamilia(int idFamilia, int idUsuario)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idFamilia", idFamilia);
            hdatos.Add("@id", BuscarUltimoIDUsuarioFamilia() + 1); //suma 1 al ultimo id de la tabla usuario_familia
            bool realizado = sqlHelper.Escribir("familia_agregarusuario", hdatos);
            return realizado;
        }

        private int BuscarUltimoIDUsuarioFamilia()
        {
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("familia_BuscarUltimoIDUsuarioFamilia", null);
            int id = 0;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    id = int.Parse(item["id"].ToString());
                }
            }
            return id;
        }

        private int BuscarUltimoIDUsuarioPermiso()
        {
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("familia_BuscarUltimoIDUsuarioPermiso", null);
            int id = 0;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    id = int.Parse(item["id"].ToString());
                }
            }
            return id;
        }

        public bool agregarPermiso(int idUsuario, BE.BE_Permiso permiso)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idPermiso", permiso.IDPERMISO);
            hdatos.Add("@tipo", permiso.TIPO);
            hdatos.Add("@id", BuscarUltimoIDUsuarioPermiso() + 1);
            bool realizado = sqlHelper.Escribir("usuario_agregarpermiso", hdatos);
            return realizado;
        }

        public bool crear(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();
            int id = BuscarUltimoIDUsuario() + 1;

            hdatos.Add("@nombre", usuario.NOMBRE);
            hdatos.Add("@apellido", usuario.APELLIDO);
            hdatos.Add("@contrasena", usuario.CONTRASENA);
            hdatos.Add("@email", usuario.EMAIL);
            hdatos.Add("@telefono", usuario.TELEFONO);
            hdatos.Add("@dni", usuario.DNI);
            hdatos.Add("@activo", usuario.ACTIVO);
            hdatos.Add("@esempleado", usuario.ESEMPLEADO);
            hdatos.Add("@id", id);

            bool resutado = sqlHelper.Escribir("usuario_crear", hdatos);
            //CrearhashContraseña(id, 0);

            if (resutado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool CrearhashContraseña(int id, int esCambio) {
        //    string hash = GenerarHashRecuperacionContrasena(25);

        //    Hashtable hdatos = new Hashtable();
        //    hdatos.Add("@idUsuario", id);
        //    hdatos.Add("@hash", hash);
        //    hdatos.Add("@solicitoCambio", esCambio);

        //    bool resultado = sqlHelper.Escribir("usuario_crearHash",hdatos);

        //    if (resultado)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        public int BuscarUltimoIDUsuario()
        {
            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("usuario_buscarUltimoID", null);
            int id = 0;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow item = ds.Tables[0].Rows[0];
                    id =  int.Parse(item["id_usuario"].ToString());
                }
            }
            return id;
        }

        public bool desbloquear(BE.BE_Usuario usuario)
        {
            usuario.ACTIVO = true;
            return true;
        }

        public bool editar(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@nombre", usuario.NOMBRE);
            hdatos.Add("@apellido", usuario.APELLIDO);
            hdatos.Add("@contrasena", usuario.CONTRASENA);
            hdatos.Add("@email", usuario.EMAIL);
            hdatos.Add("@telefono", usuario.TELEFONO);
            hdatos.Add("@dni", usuario.DNI);
         
            hdatos.Add("@idUsuario", usuario.IDUSUARIO);
            hdatos.Add("@activo", usuario.ACTIVO);
            hdatos.Add("@esempleado", usuario.ESEMPLEADO);

            bool resultado = sqlHelper.Escribir("usuario_modificar", hdatos);

            if (resultado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool eliminar(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", usuario.IDUSUARIO);
            return sqlHelper.Escribir("usuario_eliminar", hdatos);
        }

        public List<BE.BE_Usuario> listar(Hashtable filtros)
        {
            List<BE.BE_Usuario> lista = new List<BE.BE_Usuario>();

            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("usuario_leer", filtros);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        BE.BE_Cliente clienteAsociado = new BE.BE_Cliente();
                        clienteAsociado.IDCLIENTE = 0;

                        BE.BE_Usuario usuario = new BE.BE_Usuario();
                        usuario.IDUSUARIO = int.Parse(item["id_usuario"].ToString());
                        usuario.NOMBRE = item["nombre"].ToString();
                        usuario.APELLIDO = item["apellido"].ToString();
                        usuario.EMAIL = item["email"].ToString();
                        usuario.TELEFONO = Convert.IsDBNull(item["telefono"]) ? "" : item["telefono"].ToString();
                        usuario.CONTRASENA = item["contrasenia"].ToString();
                        usuario.ESEMPLEADO = bool.Parse(item["es_empleado"].ToString());
                        usuario.DNI = Convert.IsDBNull(item["dni"]) ? 0 : int.Parse(item["dni"].ToString());
                        usuario.ACTIVO = bool.Parse(item["activo"].ToString());

                        if (item["idCliente"] != null && int.TryParse(item["idCliente"].ToString(), out _))
                        {
                            clienteAsociado.IDCLIENTE = int.Parse(item["idCliente"].ToString());
                        }

                        usuario.LISTAFAMILIA = getFamiliasPorUsuario(usuario.IDUSUARIO);
                        usuario.LISTAPERMISO = getPermisosPorUsuario(usuario.IDUSUARIO);
                        usuario.CLIENTE = clienteAsociado;

                        lista.Add(usuario);
                    }
                }
            }

            return lista;
        }

        public static string GenerarHashRecuperacionContrasena(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

        public bool modificarContrasenia(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idusuario", usuario.IDUSUARIO);
            hdatos.Add("@contrasenia", usuario.CONTRASENA);
            bool resultado = sqlHelper.Escribir("usuario_cambiarcontrasenia", hdatos);
            return resultado;
        }

        public bool quitarFamilia(int idUsuario, int idFamilia)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idFamilia", idFamilia);

            bool resultado = sqlHelper.Escribir("usuario_quitarFamilia", hdatos);
            return resultado;
        }

        public bool quitarPermiso(int idUsuario, int idPermiso)
        {
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idPermiso", idPermiso);

            bool resultado = sqlHelper.Escribir("usuario_quitarPermiso", hdatos);
            return resultado;
        }

        public bool puedeEliminarUsuario(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", usuario.IDUSUARIO);

            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("usuario_esadmin", hdatos);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataSet dscantidad = new DataSet();
                dscantidad = sqlHelper.Leer("usuario_haymasadmins", null);
                DataRow dr = dscantidad.Tables[0].Rows[0];
                int cant = int.Parse(dr["cantidad"].ToString());
                return cant > 1;
            }
            return true;

        }

        public bool validarExistente(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();
            int ok = 0;
            hdatos.Add("@emailUsuario", usuario.EMAIL);

            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("usuario_validarexistente", hdatos);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        ok = int.Parse(item["resultado"].ToString());
                    }
                }
            }

            if (ok == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool ValidarEmail(string email) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@email", email);
            string mail="";

            DataSet ds = new DataSet();
            ds = sqlHelper.Leer("usuario_validaremail",hdatos);
            if (ds.Tables.Count > 0) {
                if (ds.Tables[0].Rows.Count > 0) {
                    foreach (DataRow item in ds.Tables[0].Rows) {
                        mail = item["email"].ToString();
                    }
                }
            }

            if (email == mail)
            {
                return true;
            }
            else {
                return false;
            }

        }

        public bool BorrarMailSuscripcion(string email) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@email", email);

            bool resultado = sqlHelper.Escribir("usuario_BorrarMailSuscripcion", hdatos);
            return resultado;
        }
    }
}
