using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminFamiliasLista : System.Web.UI.Page
    {
        BLL.BLL_Familia gestorFamilia = new BLL.BLL_Familia();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LlenarDvg();
            }
        }

        protected void dgvFamilias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvFamilias.PageIndex = e.NewPageIndex;
            LlenarDvg();
        }

        protected void dgvFamilias_PageIndexChanged(object sender, EventArgs e)
        {
            LlenarDvg();
        }

        protected void dgvFamilias_RowEditing(object sender, GridViewEditEventArgs e) {
            GridViewRow row = dgvFamilias.Rows[e.NewEditIndex];
            string idFamilia = row.Cells[0].Text;

            Response.Redirect("AdminFamiliasEdicion.aspx?id=" + idFamilia);
        }

        protected void dgvFamilias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = dgvFamilias.Rows[e.RowIndex];
            string idFam = row.Cells[0].Text;

            if(int.TryParse(idFam, out _)){
                BE.BE_Familia familia = new BE.BE_Familia();
                familia.IDFAMILIA = int.Parse(idFam);
                bool eliminado = gestorFamilia.eliminar(familia);

                if (eliminado)
                {
                    Response.Redirect("AdminFamiliasLista.aspx");
                }
            }

        }

        private void LlenarDvg()
        {
            List<BE.BE_Familia> lista = new List<BE.BE_Familia>();
            lista = gestorFamilia.listar(null);

            dgvFamilias.AutoGenerateColumns = false;
            dgvFamilias.DataSource = null;
            dgvFamilias.DataSource = lista;
            dgvFamilias.DataBind();
        }


    }
}