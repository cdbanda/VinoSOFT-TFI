using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class SQLHelper
    {
        SqlConnection conexion;
        SqlTransaction tx;

        //private string connectionstringtxt(string db)
        //{
        //    string basepath = System.IO.Directory.GetCurrentDirectory();
        //    string dircompleto = basepath + @"/conexion.txt";
        //    string[] linea = null;
        //    string conexion = null;

        //    if (File.Exists(dircompleto))
        //    {
        //        linea = File.ReadAllLines(dircompleto);

        //        if (db == "GYC")
        //        {
        //            conexion = linea[0];
        //        }
        //        if (db == "master")
        //        {
        //            conexion = linea[1];
        //        }
        //    }
        //    return conexion;
        //}

        public void Abrir()
        {
            //string db = "VINOSOFT";
            conexion = new SqlConnection();
            //conexion.ConnectionString = connectionstringtxt(db);
            conexion.ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VINOSOFT;Data Source=INSPIRON14\SQLEXPRESS";
            conexion.Open();
        }

        public void AbrirMaster()
        {
            //string db = "master";
            conexion = new SqlConnection();
            //conexion.ConnectionString = connectionstringtxt(db);
            conexion.ConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=master;Data Source=HPMINI";
            conexion.Open();
        }

        public void iniciarTX()
        {
            tx = conexion.BeginTransaction();
        }

        public void confirmarTX()
        {
            tx.Commit();
            tx = null;
        }

        public void deshacerTX()
        {
            tx.Rollback();
            tx = null;
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }

        public bool Escribir(string consulta, Hashtable HashDatos)
        {
            int fa = 0;
            SqlCommand cmd = new SqlCommand();
            Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = consulta;
            cmd.Connection = conexion;
            bool ok = false;

            if (HashDatos != null)
            {
                foreach (string dato in HashDatos.Keys)
                {
                    cmd.Parameters.AddWithValue(dato, HashDatos[dato]);
                }
            }

            iniciarTX();
            if (tx != null)
            {
                cmd.Transaction = tx;
            }

            try
            {
                fa = cmd.ExecuteNonQuery();
            }
            catch
            {
                fa = -1;
            }

            if (fa > -1)
            {
                confirmarTX();
                ok = true;
            }
            else
            {
                deshacerTX();
                ok = false;
            }

            cmd.Dispose();
            cmd = null;
            GC.Collect();
            Cerrar();
            return ok;
        }

        public DataSet Leer(string consulta, Hashtable HashDatos)
        {
            Abrir();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexion;

            if (HashDatos != null)
            {
                foreach (string dato in HashDatos.Keys)
                {
                    cmd.Parameters.AddWithValue(dato, HashDatos[dato]);
                }
            }
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            DataSet tabla = new DataSet();
            adaptador.Fill(tabla);
            Cerrar();
            return tabla;
        }


        public bool generarBackup(string consulta, Hashtable HashDatos)
        {

            int fa = 0;
            bool ok = false;
            SqlCommand cmd = new SqlCommand();
            Abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = consulta;
            cmd.Connection = conexion;

            if (HashDatos != null)
            {
                foreach (string dato in HashDatos.Keys)
                {
                    cmd.Parameters.AddWithValue(dato, HashDatos[dato]);
                }
            }

            try
            {
                fa = cmd.ExecuteNonQuery();
                ok = true;
            }
            catch
            {
                fa = -1;
                ok = false;
            }
            cmd.Dispose();
            cmd = null;
            GC.Collect();
            Cerrar();
            return ok;
        }

        public bool generarBase(string restore)
        {
            bool ok;

            AbrirMaster();
            string linea1 = "USE master;";
            string linea2 = "CREATE DATABASE VINOSOFT;";
            string alter = "ALTER DATABASE VINOSOFT SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            string linea3 = "RESTORE DATABASE VINOSOFT FROM DISK = '" + restore + "' WITH REPLACE;";

            SqlCommand cmd1 = new SqlCommand(linea1, conexion);
            SqlCommand cmd2 = new SqlCommand(linea2, conexion);
            SqlCommand cmd3 = new SqlCommand(linea3, conexion);
            SqlCommand cmdAlter = new SqlCommand(alter, conexion);

            try
            {
                cmd1.ExecuteNonQuery();
                cmdAlter.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                ok = true;

            }
            catch
            {
                try
                {
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    ok = false;
                }
                catch
                {
                    ok = false;
                }

            }

            return ok;
        }
    }
}