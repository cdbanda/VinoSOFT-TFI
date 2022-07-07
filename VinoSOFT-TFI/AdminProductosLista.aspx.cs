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
        AdminACL gestorPermisos = new AdminACL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (gestorPermisos.EstaLogueado())
                {
                    LlenarDgv();
                    ActualizarBarraNavegacionLogin();
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
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

            Response.Redirect("AdminProductosEdicion.aspx?id=" + idProducto,false);
            Context.ApplicationInstance.CompleteRequest();
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
                    Response.Redirect("AdminProductosLista.aspx",false);
                    Context.ApplicationInstance.CompleteRequest();
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
            Response.Redirect("AdminProductosEdicion.aspx",false);
            Context.ApplicationInstance.CompleteRequest();
        }

        public void ActualizarBarraNavegacionLogin()
        {
            BE.BE_Usuario usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            ((Backend)Master).MenuUsuarioNoLogeado = false;
            ((Backend)Master).MenuUsuarioLogeado = true;
            ((Backend)Master).NombreUsuario = "Hola, " + usuario.NOMBRE;
            ((Backend)Master).MenuInicio = true;

            ActualizarMenuesPorPermisos();

        }

        public void ActualizarMenuesPorPermisos()
        {
            BE.BE_Usuario usuario = (BE.BE_Usuario)Session["UsuarioLogueado"];

            ((Backend)Master).MenuAdmFzas = gestorPermisos.TienePermiso("MOD_ADM_FZAS", usuario);
            ((Backend)Master).MenuSeguridad = gestorPermisos.TienePermiso("MOD_SEGURIDAD", usuario);
            ((Backend)Master).MenuVentas = gestorPermisos.TienePermiso("MOD_VENTAS", usuario);
            ((Backend)Master).MenuMkt = gestorPermisos.TienePermiso("MOD_MKT", usuario);
            //((Backend)Master).MenuAdmFzas = gestorPermisos.TienePermiso("MOD_ADM_FZAS", usuario);
            //((Backend)Master).MenuAdmFzas = gestorPermisos.TienePermiso("MOD_ADM_FZAS", usuario);
        }
    }
}