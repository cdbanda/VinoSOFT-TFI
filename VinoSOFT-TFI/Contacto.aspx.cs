using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class Contacto : System.Web.UI.Page
    {
        BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string nombre = iptNombre.Text;
                string email = iptEmail.Text;
                string mensaje = iptMensaje.Text;
                bool ok = gestorCliente.enviarMailContacto(email, mensaje, nombre);
                if (ok)
                {
                    Response.Write(("Mail enviado correctamente."));
                }
                else
                {
                    Response.Write(("Error al enviar el mail."));
                }
                limpiarControles();
            }
        }

        protected void limpiarControles()
        {
            foreach (var control in this.Controls)
            {
                var textbox = control as TextBox;
                if (textbox != null)
                    textbox.Text = string.Empty;
            }

        }
    }
}