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
            mostrarPopUp("¿Desea realizar el backup?");
        }

        private void generarBackup()
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
                    ModalPopUpMensajes.Show();
                    LabelMensaje.Text = "Error al generar el Backup";
                }

            }
            catch (Exception ex)
            {
                ModalPopUpMensajes.Show();
                LabelMensaje.Text = ex.ToString();
            }

            Server.Transfer("AdminBackup.aspx");
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
            //Se saco el flush para redireccionar correctamente.
            //Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();

        }

        protected void ButtonRestore_Click(object sender, EventArgs e)
        {
             generarRestore();
        }

        private void generarRestore() {
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
                        ModalPopUpMensajes.Show();
                        LabelMensaje.Text = "Restore realizado con exito.";
                    }
                }
                catch (Exception ex)
                {
                    ModalPopUpMensajes.Show();
                    LabelMensaje.Text = ex.ToString();

                }
            }
            else
            {
                ModalPopUpMensajes.Show();
                LabelMensaje.Text = "No se selecciono el archivo.";
            }
        }

        protected void DgvBackup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DgvBackup.PageIndex = e.NewPageIndex;
            this.llenarGrilla();
        }

        private void mostrarPopUp(string mensaje) {
            mp1.Show();
            mjsBodyMP.Text = mensaje;
        }

        protected void BtnOk_Click(object sender, EventArgs e) {
            generarBackup();
        }

        protected void BtnCancel_Click(object sender, EventArgs e) {

                mp1.Hide();
                Server.Transfer("~/AdminBackup.aspx");
        }
    }
}