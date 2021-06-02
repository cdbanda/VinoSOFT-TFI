using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class CU_UsuarioPass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string usuario {
            get { return txtBoxUserName.Text; }
            set { txtBoxUserName.Text = value; }
        }

        public string contrasena {
            get { return txtBoxPassword.Text; }
        }
    }
}