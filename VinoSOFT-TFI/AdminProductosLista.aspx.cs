using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminProductosLista : System.Web.UI.Page
    {
        BLL.BLL_Producto gestorProducto = new BLL.BLL_Producto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDgv();
            }
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            LlenarDgv();
        }

        protected void dgvProductos_PageIndexChanged(object sender, EventArgs e)
        {
            LlenarDgv();
        }

        protected void dgvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = dgvProductos.Rows[e.NewEditIndex];
            string idProducto = row.Cells[0].Text;

            Response.Redirect("AdminProductosEdicion.aspx?id=" + idProducto);
        }

        protected void dgvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            GridViewRow row = dgvProductos.Rows[e.RowIndex];
            string idProd = row.Cells[0].Text;

            if (int.TryParse(idProd, out _))
            {
                BE.BE_Producto producto = new BE.BE_Producto();
                producto.IDPRODUCTO = int.Parse(idProd);
                bool eliminado = gestorProducto.eliminarProducto(producto);

                if (eliminado)
                {
                    Response.Redirect("AdminProductosLista.aspx");
                }
            }

        }

        private void LlenarDgv()
        {
            List<BE.BE_Producto> lista = new List<BE.BE_Producto>();
            lista = gestorProducto.listarProducto();

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;
            dgvProductos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminProductosEdicion.aspx");
        }
    }
}