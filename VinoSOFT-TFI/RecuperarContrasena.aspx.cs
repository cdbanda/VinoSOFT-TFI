using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class RecuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnenviar_Onclick(object sender, EventArgs e) {
            // validate the Captcha to check we're not dealing with a bot
            bool isHuman = RecuperarCaptcha.Validate(CaptchaCodeTextBox.Text);

            CaptchaCodeTextBox.Text = null; // clear previous user input

            if (!isHuman)
            {
                // TODO: Captcha validation failed, show error message  
                ModalPopUpMensajes.Show();
                LabelMensaje.Text = "Error en el captcha.";
            }
            else
            {
                // TODO: captcha validation succeeded; execute the protected action

            }
        }
    }
}