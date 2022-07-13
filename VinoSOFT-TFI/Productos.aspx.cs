using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class Productos : System.Web.UI.Page
    {
        BLL.BLL_Producto gestorProducto = new BLL.BLL_Producto();
        ClienteACL gestorPermisos = new ClienteACL();


        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    if (gestorPermisos.EstaLogueado())
                    {
                        ActualizarBarraNavegacionLogin();
                    }
                    listarProductos();
                }
        }

        protected void listarProductos() {
            List<BE.BE_Producto> lista = new List<BE.BE_Producto>();
            lista = gestorProducto.listarProducto();
            if(lista != null)
            {
                if (lista.Count > 0)
                {
                    lista = AgregarFormatoImagenes(lista);

                    repeaterProducto.DataSource = null;
                    repeaterProducto.DataBind();

                    repeaterProducto.DataSource = lista;
                    repeaterProducto.DataBind();
                }
                else
                {
                    ltlNoHayProductos.Visible = true;
                }

            }
            else
            {
                ltlNoHayProductos.Visible = true;
            }

        }

        private List<BE.BE_Producto> AgregarFormatoImagenes(List<BE.BE_Producto> lista)
        {
            string formato = "data:image/jpeg;base64,";
            if (lista.Count > 0)
            {
                foreach (BE.BE_Producto producto in lista)
                {
                    producto.IMAGEN = formato + producto.IMAGEN;
                }
                return lista;
            }
            return lista;
        }

        public void ActualizarBarraNavegacionLogin()
        {
            BE.BE_Cliente usuario = (BE.BE_Cliente)Session["ClienteLogueado"];

            ((MasterPage)Master).carritoVisible = true;
            ((MasterPage)Master).perfilUsuarioLogeado = true;
            ((MasterPage)Master).lblNombreUsuario = "Hola, " + usuario.NOMBRE;

            ((MasterPage)Master).perfilUsuarioNoLogeado = false;
        }
    }
}