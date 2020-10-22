using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if (!IsPostBack) {
                RellenarRepeater();
            }
        }

        private void RellenarRepeater() {
            List<BE.BE_Noticia> lista = new List<BE.BE_Noticia>();
            lista = gestorNoticia.Listar(null);
            lista = DecodificarHTML(lista);
            repeaterNoticia.DataSource = lista;
            repeaterNoticia.DataBind();
        }

        private List<BE.BE_Noticia> DecodificarHTML(List<BE.BE_Noticia> lista) {
            foreach (BE.BE_Noticia noti in lista) {
                noti.CUERPO = WebUtility.HtmlDecode(noti.CUERPO);
            }
            return lista;
        }
    }
}