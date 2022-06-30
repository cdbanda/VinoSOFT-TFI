using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminVentasLista : System.Web.UI.Page
    {
        BLL.BLL_Venta gestorVentas = new BLL.BLL_Venta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDgv();
            }
        }

        private void llenarDgv()
        {
            List<BE.BE_Venta> lista = new List<BE.BE_Venta>();
            lista = gestorVentas.Listar();

            dgvVentas.DataSource = null;
            dgvVentas.DataSource = lista;
            dgvVentas.DataBind();

        }

        protected void dgvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dgvVentas_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvVentas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = dgvVentas.Rows[e.NewEditIndex];
            string idVenta = row.Cells[0].Text;

            Response.Redirect("AdminVentasEditar.aspx?id=" + idVenta);
        }
    }
}