using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BLL
{
    public class BLL_Usuario
    {
        MPP.MPP_Usuario mapperUsuario = new MPP.MPP_Usuario();
        BLL.BLL_Seguridad gestorSeguridad = new BLL_Seguridad();

        public BE.BE_Usuario getPorId(int idUsuario) {
            return getPorId(idUsuario);
        }

        public bool agregarFamilia(int Idfamilia, int idUsuario) {
            return mapperUsuario.agregarFamilia(Idfamilia, idUsuario);
        }

        public bool agregarPermiso(int idUsuario, BE.BE_Permiso permiso) {
            return mapperUsuario.agregarPermiso(idUsuario, permiso);
        }

        public bool crear(BE.BE_Usuario usuario) {
            if (mapperUsuario.validarExistente(usuario)) {
                return false;
            }
            //Se encripta la contraseña
            usuario.CONTRASEÑA = gestorSeguridad.Encriptar(usuario.CONTRASEÑA);
            return mapperUsuario.crear(usuario);
        }

        public bool desbloquear(BE.BE_Usuario usuario) {
            return false;
        }

        public bool editar(BE.BE_Usuario usuario) {
            if (mapperUsuario.validarExistente(usuario)) {
                return false;
            }
            return mapperUsuario.editar(usuario);
        }

        public bool eliminar(BE.BE_Usuario usuario) {
            if (mapperUsuario.puedeEliminarUsuario(usuario))
            {
                return true;
            }
            else {
                return false; // verficar si super admin
            }
        }

        public List<BE.BE_Usuario> listar(Hashtable filtros) {
            return mapperUsuario.listar(filtros);
        }

        public bool modificarContrasenia(BE.BE_Usuario usuario) {
            return mapperUsuario.modificarContrasenia(usuario);
        }

        public bool quitarFamilia(int idUsuario, int idFamilia) {
            return mapperUsuario.quitarFamilia(idUsuario,idFamilia);
        }

        public bool quitarPermiso(int idUsuario, int idPermiso) {
            return mapperUsuario.quitarPermiso(idUsuario,idPermiso);
        }

        public bool ValidarEmail(string email) {
            return mapperUsuario.ValidarEmail(email);
        }

        public bool BorrarMailSuscripcion(string email){
            return mapperUsuario.BorrarMailSuscripcion(email);
        }

        public bool EnviarMailCambioContraseña(string email) {
            return true;
        }

        public bool verificarUsuario(string usuario, string contrasena) {
            
            bool resultado = true;



            return resultado;
        }

    }
}

