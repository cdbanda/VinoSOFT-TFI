using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class AdminProductosEdicion : System.Web.UI.Page
    {
        BLL.BLL_Producto gestorProducto = new BLL.BLL_Producto();
        BLL.BLL_Categoria gestorCategoria = new BLL.BLL_Categoria();
        const string rutaArchivos = "/img/productos/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropdownCategoria();
                CargarInfo();
            }
        }

        private void CargarDropdownCategoria()
        {
            List<BE.BE_Categoria> lista = new List<BE.BE_Categoria>();
            lista = gestorCategoria.Listar(null);

            ddCategoria.DataSource = null;
            ddCategoria.DataTextField = "Nombre";
            ddCategoria.DataValueField = "id";
            ddCategoria.DataSource = lista;
            ddCategoria.DataBind();
        }

        private void CargarInfo()
        {
            try
            {
                iptDescripcion.Attributes["MaxLength"] = "300";
                iptDescripcionCorta.Attributes["MaxLength"] = "150";
            }
            catch
            {

            }

            if(Request.QueryString["id"] != null)
            {
                if(int.TryParse(Request.QueryString["id"], out _))
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    BE.BE_Producto producto = new BE.BE_Producto();
                    producto = gestorProducto.listarProductoPorID(id);

                    if (producto != null)
                    {
                        iptCodigo.Value = producto.IDPRODUCTO.ToString();
                        iptNombre.Text = producto.NOMBRE;
                        iptDescripcion.Text = producto.DESCRIPCION;
                        iptDescripcionCorta.Text = producto.DESCRIPCIONCORTA;
                        iptPrecio.Text = producto.PRECIO.ToString();
                        iptStock.Text = producto.STOCK.ToString();
                        iptStock.Enabled = false; //si se esta editando no se puede cambiar el stock porque se actualiza al vender o recibir.
                        iptStockMinimo.Text = producto.STOCKMINIMO.ToString();

                        ddActivo.SelectedValue = producto.ACTIVO.ToString();
                        ddCategoria.SelectedValue = producto.CATEGORIA.ID.ToString();

                        if (producto.LINKIMAGEN != null) {
                            imgFotoSubida.Visible = true;
                            imgFotoSubida.ImageUrl = producto.LINKIMAGEN;
                        }

                        btnEliminar.Visible = true;
                    }
                }
                else
                {
                    return;
                }
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if(int.TryParse(iptCodigo.Value, out _))
            {
                int idProducto = int.Parse(iptCodigo.Value);
                BE.BE_Producto producto = new BE.BE_Producto();
                producto.IDPRODUCTO = idProducto;

                bool eliminado = gestorProducto.eliminarProducto(producto);
                if (eliminado)
                {
                    Response.Redirect("AdminProductosListas.aspx");
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE.BE_Producto producto = new BE.BE_Producto();
            BE.BE_Categoria categoria = new BE.BE_Categoria();

            bool guardado = false;

            producto.NOMBRE = iptNombre.Text;
            producto.DESCRIPCION = iptDescripcion.Text;
            producto.DESCRIPCIONCORTA = iptDescripcionCorta.Text;
            categoria.ID = int.Parse(ddCategoria.SelectedValue);
            producto.CATEGORIA = categoria;
            producto.LINKIMAGEN = ""; //implementarlo
            producto.STOCK = int.Parse(iptStock.Text);
            producto.STOCKMINIMO = int.Parse(iptStockMinimo.Text);
            producto.PRECIO = float.Parse(iptPrecio.Text);
            producto.ACTIVO = int.Parse(ddActivo.SelectedValue);


            if (int.TryParse(iptCodigo.Value, out _))
            {
                producto.IDPRODUCTO = int.Parse(iptCodigo.Value);
                guardado = gestorProducto.actualizarProducto(producto);
            }
            else
            {
                producto.IDPRODUCTO = 0;
                guardado = gestorProducto.insertarProducto(producto);
            }

            if (guardado)
            {
                Response.Redirect("AdminProductosLista.aspx");
            }

        }
    }
}