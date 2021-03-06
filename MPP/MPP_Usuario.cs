﻿using System;
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
                    usuario.IDUSUARIO = int.Parse(item["id_usuario"].ToString());
                    usuario.NOMBRE = item["nombre"].ToString();
                    usuario.APELLIDO = item["apellido"].ToString();
                    usuario.EMAIL = item["email"].ToString();
                    usuario.TELEFONO = Convert.IsDBNull(item["telefono"]) ? "" : item["telefono"].ToString();
                    usuario.CONTRASEÑA = item["contrasenia"].ToString();
                    //ver si hay pregunta de seguridad
                    usuario.ESEMPLEADO = bool.Parse(item["es_empleado"].ToString());
                    usuario.DNI = Convert.IsDBNull(item["dni"]) ? 0 : int.Parse(item["dni"].ToString());
                    usuario.ACTIVO = bool.Parse(item["activo"].ToString());
                    usuario.LISTAFAMILIA = getFamiliaPorUsuario(usuario.IDUSUARIO);
                    usuario.LISTAPERMISO = getPermisosUsuario(usuario.IDUSUARIO);
                    return usuario;
                }
            }
            return null;
        }

        private List<BE.BE_Familia> getFamiliaPorUsuario(int idUsuario)
        {
            DataSet ds = new DataSet();
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", hdatos);
            List<BE.BE_Familia> listado = new List<BE.BE_Familia>();
            ds = sqlHelper.Leer("familias_obtenerporusuario", hdatos);
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

        private List<BE.BE_Permiso> getPermisosUsuario(int idUsuario)
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
                listado.Add(permiso);
            }
            return listado;
        }
        public bool agregarFamilia(int idFamilia, int idUsuario)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idFamilia", idFamilia);
            bool realizado = sqlHelper.Escribir("familia_agregarusuario", hdatos);
            return realizado;
        }

        public bool agregarPermiso(int idUsuario, BE.BE_Permiso permiso)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idPermiso", permiso.IDPERMISO);
            bool realizado = sqlHelper.Escribir("usuario_agregarpermiso", hdatos);
            return realizado;
        }

        public bool crear(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();

            hdatos.Add("@nombre", usuario.NOMBRE);
            hdatos.Add("@apellido", usuario.APELLIDO);
            hdatos.Add("@contrasenia", usuario.CONTRASEÑA);
            hdatos.Add("@email", usuario.EMAIL);
            hdatos.Add("@telefono", usuario.TELEFONO);
            hdatos.Add("@dni", usuario.DNI);
            hdatos.Add("@activo", usuario.ACTIVO);
            hdatos.Add("@esempleado", usuario.ESEMPLEADO);

            bool resutado = sqlHelper.Escribir("usuario_crear", hdatos);

            if (resutado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
                    id =  int.Parse(item["id"].ToString());
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
            hdatos.Add("@contrasenia", usuario.CONTRASEÑA);
            hdatos.Add("@email", usuario.EMAIL);
            hdatos.Add("@telefono", usuario.TELEFONO);
            hdatos.Add("@dni", usuario.DNI);
            hdatos.Add("@activo", usuario.ACTIVO);
            hdatos.Add("@esempleado", usuario.ESEMPLEADO);

            bool resutado = sqlHelper.Escribir("usuario_modificar", hdatos);

            if (resutado)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                        BE.BE_Cliente clienteAsoc = new BE.BE_Cliente();
                        clienteAsoc.IDCLIENTE = 0;

                        BE.BE_Usuario usuario = new BE.BE_Usuario();
                        usuario.IDUSUARIO = int.Parse(item["id_usuario"].ToString());
                        usuario.NOMBRE = item["nombre"].ToString();
                        usuario.APELLIDO = item["apellido"].ToString();
                        usuario.EMAIL = item["email"].ToString();
                        usuario.TELEFONO = Convert.IsDBNull(item["telefono"]) ? "" : item["telefono"].ToString();
                        usuario.CONTRASEÑA = item["contrasenia"].ToString();
                        usuario.ESEMPLEADO = bool.Parse(item["es_empleado"].ToString());
                        usuario.DNI = Convert.IsDBNull(item["dni"]) ? 0 : int.Parse(item["dni"].ToString());
                        usuario.ACTIVO = bool.Parse(item["activo"].ToString());
                        //usuario.LISTAFAMILIA = getFamiliaPorUsuario(usuario.IDUSUARIO);
                        //usuario.LISTAPERMISO = getPermisosUsuario(usuario.IDUSUARIO);
                        lista.Add(usuario);
                    }
                }
            }

            return lista;
        }

        public bool modificarContrasenia(BE.BE_Usuario usuario)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idusuario", usuario.IDUSUARIO);
            hdatos.Add("@contrasenia", usuario.CONTRASEÑA);
            bool resultado = sqlHelper.Escribir("usuario_cambiarcontrasenia", hdatos);
            return resultado;
        }

        public bool quitarFamilia(int idUsuario, int idFamilia)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@idUsuario", idUsuario);
            hdatos.Add("@idFamilia", idFamilia);

            bool resultado = sqlHelper.Escribir("usuario_quitarPermiso", hdatos);
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
                dscantidad = sqlHelper.Leer("usuario_haymasadmin", null);
                DataRow dr = dscantidad.Tables[0].Rows[0];
                int cant = int.Parse(dr["cantidad"].ToString());
                return false;
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
