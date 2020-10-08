using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class Noticias : System.Web.UI.Page
    {
        BLL.BLL_Noticia gestorNoticia = new BLL.BLL_Noticia();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void RellenarRepeater() {
            List<BE.BE_Noticia> lista = new List<BE.BE_Noticia>();
            repeaterNoticia.DataSource = lista;
            repeaterNoticia.DataBind();
        } 
    }
}