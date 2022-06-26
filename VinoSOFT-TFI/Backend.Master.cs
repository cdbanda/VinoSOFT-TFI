using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class Backend : System.Web.UI.MasterPage
    {
        ACL gestorPermisos = new ACL();
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemAdmFzas.Visible = gestorPermisos.TienePermiso("MOD_ADM_FZAS");
            ItemMkt.Visible = gestorPermisos.TienePermiso("MOD_MKT");
            ItemVentas.Visible = gestorPermisos.TienePermiso("MOD_VENTAS");
            ItemSeguridad.Visible = gestorPermisos.TienePermiso("MOD_SEGURIDAD");
        }

        public string isActive(string pag)
        {
            string urlActual = HttpContext.Current.Request.Url.AbsoluteUri;
            string pagActual = urlActual.Substring(urlActual.LastIndexOf("/")+1);
            if(pag == pagActual)
            {
                return "active";
            }
            return "";
        }

        public string isActive(string[] pags)
        {
            string urlActual = HttpContext.Current.Request.Url.AbsoluteUri;
            string pagActual = urlActual.Substring(urlActual.LastIndexOf("/") + 1);
            if (pags.Contains(pagActual))
            {
                return "active";
            }
            return "";
        }
    }
}