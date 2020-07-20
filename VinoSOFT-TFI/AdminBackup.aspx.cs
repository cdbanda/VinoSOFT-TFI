using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminBackup : System.Web.UI.Page
    {
        BLL.BLL_Backup gestorBackup = new BLL.BLL_Backup();
        BLL.BLL_Bitacora gestorBitacora = new BLL.BLL_Bitacora();
        static public string ruta = "/bk/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarGrilla();
            }
        }

        private void llenarGrilla(Hashtable filtros = null)
        {
            List<BE.BE_Backup> registros = gestorBackup.listar(filtros);
            //DgvBackup.AutoGenerateColumns = false;
            DgvBackup.DataSource = registros;
            DgvBackup.DataBind();
        }







        protected void Button1_Click(object sender, EventArgs e)
        {
            string dircompleto = Server.MapPath("~/database/backups/");
            //string rutaGenerada = dircompleto + @"\";
            string fechaArchivo = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() +
                "-" + DateTime.Now.Second.ToString();
            string extension = ".bak";

            string nombreGenerado = "BK" + fechaArchivo + extension;

            try
            {
                bool generado = gestorBackup.realizarBackup(dircompleto + nombreGenerado);
                if (generado)
                {
                    gestorBackup.registrarBackup(dircompleto + nombreGenerado);
                    BE.BE_Evento evt = new BE.BE_Evento();
                    evt.IDEVENTO = BE.BE_Evento.GENERAR_BACKUP;
                    gestorBitacora.registrarEvento(evt, "fecha: " + DateTime.Now.ToString(), 0);

                    DisplayDownloadDialog(nombreGenerado, dircompleto + nombreGenerado);
                }
                else
                {
                    Response.Write("<script>alert('Error al Generar el backup')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
            Response.Redirect("~/AdminBackup.aspx");
        }

        private void descargarArchivo(string nombreArchivo, string dirCompleto)
        {
            try
            {
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.ContentType = "application/octet-stream";
                response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo + ";");
                //response.TransmitFile(Server.MapPath("~/File/001.jpg"));
                response.TransmitFile(dirCompleto);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
        }

        private void DisplayDownloadDialog(string nombreArchivo, string dirCompleto)
        {
            FileStream sourceFile = new FileStream(Server.MapPath("~/database/backups/" + nombreArchivo), FileMode.Open);
            float FileSize;
            FileSize = sourceFile.Length;
            byte[] fileContent = new byte[(int)FileSize];
            sourceFile.Read(fileContent, 0, (int)sourceFile.Length);
            sourceFile.Close();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Length", fileContent.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
            Response.BinaryWrite(fileContent);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        protected void ButtonRestore_Click(object sender, EventArgs e)
        {
            string ubicacion = Server.MapPath("~/database/restore/");

            if (FileUploadRestore.HasFile == true)
            {
                //FileUploadRestore.SaveAs(Server.MapPath("~/UploadedBackup/") + FileUploadRestore.FileName);
                FileUploadRestore.SaveAs(ubicacion + FileUploadRestore.FileName);
                try
                {
                    //string backupfile = Server.MapPath("~/UploadedBackup/") + FileUploadRestore.FileName;
                    string backupfile = ubicacion + FileUploadRestore.FileName;
                    bool ok = gestorBackup.restaurarBackup(backupfile);
                    if (ok)
                    {
                        Response.Write("<script>alert('Restore Hecho.')</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.ToString() + "')</script>");

                }


            }
            else
            {
                Response.Write("<script>alert('No hay archivo seleccionado.')</script>");
            }
        }

        protected void DgvBackup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DgvBackup.PageIndex = e.NewPageIndex;
            this.llenarGrilla();
        }
    }
}