using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public class BLL_Seguridad
    {
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        private string myKey = "MD5";

        BE.BE_Usuario usuarioLogueado = new BE.BE_Usuario();
        BE.BE_Cliente clienteLogueado = new BE.BE_Cliente();

        public object Login(string usuario, string password)
        {
            string passwordEncriptado = Encriptar(password);
            MPP.se
        }



        public string Encriptar(string texto)
        {
            string encriptado = "";
            if (texto.Trim() == "")
            {
                encriptado = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(myKey));
                des.Mode = CipherMode.ECB;
                ICryptoTransform encrypt = des.CreateEncryptor();
                byte[] buff = UnicodeEncoding.ASCII.GetBytes(texto);
                encriptado = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            return encriptado;
        }

        public string Desencriptar(string hash)
        {
            string texto = "";
            if (hash != "")
            {
                if (hash.Trim() == "")
                {
                    texto = "";
                }
                else
                {
                    des.Key = hashmd5.ComputeHash((new UnicodeEncoding().GetBytes(myKey)));
                    des.Mode = CipherMode.ECB;
                    ICryptoTransform desencrypta = des.CreateDecryptor();
                    byte[] buff = Convert.FromBase64String(hash);

                    texto = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length));

                }
            }
            return texto;
        }

        //--------------------- Verificador MD5

        private MD5 crearMD5()
        {
            MD5 md5Hash = MD5.Create();
            return md5Hash;
        }

        public string generarHash(string entrada)
        {
            string hash = GetMd5Hash(crearMD5(), entrada);
            return hash;
        }

        public bool verificar(string entrada, string hash)
        {
            if (verifyMd5Hash(crearMD5(), entrada, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GetMd5Hash(MD5 md5Hash, string entrada)
        {
            //Convert the input string to a byte array and compute the hash.
            Byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(entrada));

            //Create a new Stringbuilder to collect the bytes
            //and create a string.

            StringBuilder sBuilder = new StringBuilder();

            //Loop through each byte of the hashed data 
            //and format each one as a hexadecimal string.

            int i;

            for (i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            //Return the hexadecimal string.

            return sBuilder.ToString();
        }

        //Verify a hash against a string.
        private bool verifyMd5Hash(MD5 md5Hash, string entrada, string hash)
        {
            //Hash the input.
            string hashDeEntrada = GetMd5Hash(md5Hash, entrada);

            int ok;
            //Create a StringComparer an compare the hashes.
            ok = string.Compare(hashDeEntrada, hash, StringComparison.OrdinalIgnoreCase);

            if (ok == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
