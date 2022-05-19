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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void listarProductos() {
            List<BE.BE_Producto> lista = new List<BE.BE_Producto>();
            lista = gestorProducto.listarProducto();

            
        
        }
    }
}