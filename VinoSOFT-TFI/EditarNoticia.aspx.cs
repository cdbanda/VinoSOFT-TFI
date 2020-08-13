using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class EditarNoticia : System.Web.UI.Page
    {
        BLL.BLL_Categoria gestorCategoria = new BLL.BLL_Categoria();
        BLL.BLL_Noticia gestorNoticia = new BLL.BLL_Noticia();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.PreviousPage != null) {

                if (String.IsNullOrEmpty(Request.QueryString["ID"]) == false)
                {
                    ListarCategorias();
                    MostrarNoticia(gestorNoticia.BuscarNoticiaPorID(int.Parse(Request.QueryString["ID"])));
                }
                else {
                    ListarCategorias();
                }
            }
        }

        private void MostrarNoticia(BE.BE_Noticia noticia) {
            TxtTitulo.Text = noticia.TITULO;
            string ContenidoHTMLEditor = WebUtility.HtmlDecode(noticia.CUERPO);
            txtEditor.Text = ContenidoHTMLEditor;
            LiteralHTML.Text = ContenidoHTMLEditor;
            if (noticia.HABILITADO == 1)
            {
                ChkHabilitado.Checked = true;
            }
            else {
                ChkHabilitado.Checked = false;
            }
            TxtFechaCreacion.Text = noticia.FECHACREACION.ToString();
            TxtFechaModificacion.Text = noticia.FECHAMODIFICACION.ToString();
            HFIdNoticia.Value = noticia.ID.ToString();
            DDCategorias.SelectedIndex = noticia.CATEGORIA.ID;

        }

        protected void BtnPrevisua_Click(object sender, EventArgs e) {
            LiteralHTML.Text = txtEditor.Text;
        }

        protected void btnVolver_Click(object sender, EventArgs e) {
            Response.Redirect("~/GestionNoticias.aspx");
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //LiteralHTML.Text = txtEditor.Text;
                BE.BE_Noticia unaNoti = new BE.BE_Noticia();
                BE.BE_Categoria categoria = new BE.BE_Categoria();
                categoria.ID = int.Parse(DDCategorias.SelectedItem.Value);
                categoria.NOMBRE = DDCategorias.SelectedItem.Text;
                unaNoti.CATEGORIA = categoria;
                unaNoti.TITULO = TxtTitulo.Text;
                unaNoti.CUERPO = WebUtility.HtmlEncode(txtEditor.Text);
                if (TxtFechaCreacion.Text != "")
                {
                    unaNoti.FECHACREACION = DateTime.Parse(TxtFechaCreacion.Text);
                }
                else
                {
                    unaNoti.FECHACREACION = DateTime.Now;
                }
                unaNoti.FECHAMODIFICACION = DateTime.Now;
                if (ChkHabilitado.Checked)
                {
                    unaNoti.HABILITADO = 1;
                }
                else
                {
                    unaNoti.HABILITADO = 0;
                }
                if (HFIdNoticia.Value != "")
                {
                    unaNoti.ID = int.Parse(HFIdNoticia.Value);
                    gestorNoticia.ActualizarNoticia(unaNoti);
                }
                else
                {
                    unaNoti.ID = gestorNoticia.ObtenerUltimoIDNoticia();
                    gestorNoticia.InsertarNoticia(unaNoti);
                }
                MostrarNoticia(unaNoti);

                ModalPopUpMensajes.Show();
                LabelMensaje.Text = "Noticia Guardada con exito.";
            }
            catch (Exception ex)
            {
                ModalPopUpMensajes.Show();
                LabelMensaje.Text = "Error al guardar en la base de datos.";
            }
        }
        
        protected void ListarCategorias() {
            DDCategorias.DataSource = null;
            DDCategorias.DataSource = gestorCategoria.Listar(null);
            DDCategorias.DataValueField = "ID";
            DDCategorias.DataTextField = "Nombre";
            DDCategorias.DataBind();
        }

        private void BuscarNoticia(int id) {
            BE.BE_Noticia unaNoticia = new BE.BE_Noticia();
            unaNoticia = gestorNoticia.BuscarNoticiaPorID(id);
        }
    }
}