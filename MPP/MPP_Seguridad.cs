using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPP_Seguridad
    {
        BE.BE_Usuario usuarioLogueado = new BE.BE_Usuario();
        BE.BE_Cliente clienteLogeado = new BE.BE_Cliente();


        DAL.SQLHelper SQLHelper = new DAL.SQLHelper();

        public bool EsAdministrador(int idUsuario)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@idUsuario", idUsuario);
            ds = SQLHelper.Leer("esAdministrador", hdatos);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                int cant = int.Parse(dr["cant"].ToString());
                return cant > 0;
            }
            return false;
        }

        public BE.BE_Usuario CargarPermisos(BE.BE_Usuario usuario)
        {

            CargarPermisosPersonales(usuario);
            CargarPermisosDeFamilia(usuario);

            return usuario;
        }

        public BE.BE_Usuario GetUsuarioLogueado()
        {
            return usuarioLogueado;
        }

        public BE.BE_Cliente GetClienteLogueado()
        {
            return clienteLogeado;
        }

        private void CargarDatosCliente(DataRow dr)
        {
            usuarioLogueado.CLIENTE = null;
            if (dr["id_cliente"].ToString() != "") //ver con digitos
            {
                if (int.Parse(dr["id_cliente"].ToString()) > 0) {
                    BE.BE_Cliente cliente = new BE.BE_Cliente();

                    cliente.NOMBRE = dr["nombre"].ToString();
                    cliente.APELLIDO = dr["apellido"].ToString();
                    cliente.EMAIL = dr["email"].ToString();
                    cliente.DNI = int.Parse(dr["dni"].ToString());
                    cliente.DOMICILIO = dr["domicilio"].ToString();
                    cliente.CIUDAD = dr["ciudad"].ToString();
                    cliente.TELEFONO = dr["telefono"].ToString();
                    cliente.IDCLIENTE = int.Parse(dr["id_cliente"].ToString());
                    cliente.CONTRASENA = dr["contrasenia"].ToString();

                    usuarioLogueado.CLIENTE = cliente;
                }
            }
        }

        public BE.BE_Usuario LoginUsuario(string usuario, string password)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@usuario", usuario);

            ds = SQLHelper.Leer("LoginUsuario", hdatos);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow dr = ds.Tables[0].Rows[0];

                this.usuarioLogueado.IDUSUARIO = int.Parse(dr["id_usuario"].ToString());
                this.usuarioLogueado.NOMBRE = dr["nombre"].ToString();
                this.usuarioLogueado.APELLIDO = dr["apellido"].ToString();
                this.usuarioLogueado.CONTRASENA = dr["contrasenia"].ToString();
                this.usuarioLogueado.EMAIL = dr["email"].ToString();
                this.usuarioLogueado.TELEFONO = dr["telefono"].ToString();
                this.usuarioLogueado.ACTIVO = bool.Parse(dr["activo"].ToString());
                this.usuarioLogueado.ESEMPLEADO = bool.Parse(dr["es_empleado"].ToString());
                this.usuarioLogueado.DNI = int.Parse(dr["dni"].ToString());
           

                string passDB = this.usuarioLogueado.CONTRASENA;

                if (passDB == password)
                {
                    //CargarDatosCliente(dr);
                    return usuarioLogueado;
                }
                else
                {
                    return null;
                }
            }
        
        }

        public BE.BE_Cliente LoginCliente(string usuario, string password)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@cliente", usuario);

            ds = SQLHelper.Leer("LoginCliente", hdatos);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow dr = ds.Tables[0].Rows[0];

                this.clienteLogeado.IDCLIENTE = int.Parse(dr["id_usuario"].ToString());
                this.clienteLogeado.NOMBRE = dr["nombre"].ToString();
                this.clienteLogeado.APELLIDO = dr["apellido"].ToString();
                this.clienteLogeado.CONTRASENA = dr["contrasenia"].ToString();
                this.clienteLogeado.EMAIL = dr["email"].ToString();
                this.clienteLogeado.TELEFONO = dr["telefono"].ToString();
                //this.clienteLogeado.ACTIVO = bool.Parse(dr["activo"].ToString());
                this.clienteLogeado.DNI = int.Parse(dr["dni"].ToString());
                this.clienteLogeado.DOMICILIO = dr["domicilio"].ToString();

                string passDB = this.clienteLogeado.CONTRASENA;

                if (passDB == password)
                {
                    //CargarDatosCliente(dr);
                    return clienteLogeado;
                }
                else
                {
                    return null;
                }
            }

        }


        private BE.BE_Usuario CargarPermisosDeFamilia(BE.BE_Usuario usuario) {
            
            CargarFamilias(usuario);
            if(usuario.LISTAFAMILIA.Count > 0)
            {
                ArrayList idsFamilias = new ArrayList();
                foreach(BE.BE_Familia familia in usuario.LISTAFAMILIA)
                {
                    idsFamilias.Add(familia.IDFAMILIA);
                }

                DataSet ds = new DataSet();
                Hashtable hdatos = new Hashtable();

                hdatos.Add("idsFamilias", string.Join(",", idsFamilias.ToArray()));
                ds = SQLHelper.Leer("Seguridad_GetPermisosFamilias",hdatos);
                if(ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if(dt != null)
                    {
                        foreach(DataRow dr in dt.Rows)
                        {
                            BE.BE_Permiso permiso = new BE.BE_Permiso();
                            permiso.IDPERMISO = int.Parse(dr["id_permiso"].ToString());
                            permiso.DESCRIPCION = dr["descripcion"].ToString();
                            permiso.CODIGO = dr["codigo"].ToString();
                            permiso.TIPO = 1;
                            if(PermisoYaCargado(permiso.IDPERMISO, usuario) == false)
                            {
                                usuario.LISTAPERMISO.Add(permiso);
                            }
                        }
                    }
                }
                return usuario;
            }
            else
            {
                return usuario;
            }
        }

        private bool PermisoYaCargado(int idPermiso, BE.BE_Usuario usuario)
        {
            foreach(BE.BE_Permiso permiso in usuario.LISTAPERMISO)
            {
                if(permiso.IDPERMISO == idPermiso)
                {
                    return true;
                }
            }
            return false;
        }

        private BE.BE_Usuario CargarPermisosPersonales(BE.BE_Usuario usuario)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@idusuario", usuario.IDUSUARIO);
            ds = SQLHelper.Leer("seguridad_getpermisosheredadosporusuario", hdatos);

            usuario.LISTAPERMISO = new List<BE.BE_Permiso>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    BE.BE_Permiso permiso = new BE.BE_Permiso();
                    permiso.IDPERMISO = int.Parse(dr["id_permiso"].ToString());
                    permiso.DESCRIPCION = dr["descripcion"].ToString();
                    permiso.TIPO = int.Parse(dr["tipo"].ToString());
                    permiso.CODIGO = dr["codigo"].ToString();

                    usuario.LISTAPERMISO.Add(permiso);
                }
                return usuario;
            }
            else
            {
                return usuario;
            }
        }

        private BE.BE_Usuario CargarFamilias(BE.BE_Usuario usuario)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@idusuario", usuario.IDUSUARIO);
            ds = SQLHelper.Leer("seguridad_getfamiliasporusuario", hdatos);
            usuario.LISTAFAMILIA = new List<BE.BE_Familia>();

            if(ds.Tables[0].Rows.Count > 0) {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    BE.BE_Familia familia = new BE.BE_Familia();
                    familia.IDFAMILIA = int.Parse(dr["id_familia"].ToString());
                    familia.NOMBRE = dr["nombre"].ToString();
                    usuario.LISTAFAMILIA.Add(familia);
                }
                return usuario;
            }
            else
            {
                return usuario;
            } 
        }
    }
}
