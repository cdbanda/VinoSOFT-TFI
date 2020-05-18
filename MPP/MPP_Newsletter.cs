using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace MPP
{
    public class MPP_Newsletter
    {
        DAL.SQLHelper SQLhelp = new DAL.SQLHelper();

        public bool verificarMailExistente(BE.BE_UsuarioSuscripcion usuario) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@emailUsuario",usuario.EMAIL);
            int ok = 0;
            DataSet ds = new DataSet();
            ds = SQLhelp.Leer("suscripcion_validarExistente", hdatos);

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
            else
            {
                return false;
            }

        }

        public bool insertarMail(BE.BE_UsuarioSuscripcion usuario)
        {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@mail", usuario.EMAIL);
            hdatos.Add("@riego", usuario.RIEGO);
            hdatos.Add("@humedad",usuario.HUMEDAD);
            hdatos.Add("@imagenes", usuario.IMAGENES);

            bool guardado = SQLhelp.Escribir("suscripcion_insertar", hdatos);
            return guardado;
        }

        public bool borrarMail(string mail) {
            Hashtable hdatos = new Hashtable();
            hdatos.Add("@mail", mail);

            bool ok = SQLhelp.Escribir("suscripcion_borrar", hdatos);
            return ok;
        }

    }
}
