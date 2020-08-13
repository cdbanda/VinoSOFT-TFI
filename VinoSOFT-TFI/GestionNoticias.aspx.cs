using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class GestionNoticias : System.Web.UI.Page
    {
        BLL.BLL_Noticia gestorNoticia = new BLL.BLL_Noticia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                LlenarGrilla();
            }
        }

        protected void DGVNoticias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVNoticias.PageIndex = e.NewPageIndex;
            this.LlenarGrilla();
        }

        protected void LlenarGrilla() {
            List<BE.BE_Noticia> registros = new List<BE.BE_Noticia>();
            registros = gestorNoticia.Listar(null);
            //DgvBackup.AutoGenerateColumns = false;
            DGVNoticias.DataSource = registros;
            DGVNoticias.DataBind();
        }

        protected void BtnBorrar_Click(object sender, EventArgs e) {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;

            //Get the value of column from the DataKeys using the RowIndex.
            int id = Convert.ToInt32(DGVNoticias.DataKeys[rowIndex].Values[0]);
            
            mp1.Show();
            mjsBodyMP.Text = "¿Seguro desea borrar la noticia?";
            HFIdNoticia.Value = id.ToString();
        }
        protected void BtnOk_Click(object sender, EventArgs e)
        {
            int id = int.Parse(HFIdNoticia.Value);
            BorrarNoticia(id);

        }

        protected void BorrarNoticia(int id) {
                if (gestorNoticia.BorrarNoticia(id))
                {
                    Response.Redirect("~/GestionNoticias.aspx");
                }
                else {

                }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            mp1.Hide();
            Server.Transfer("~/GestionNoticias.aspx");
        }

    }
}