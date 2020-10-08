using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class RegistracionNewsletter : System.Web.UI.Page
    {
        BLL.BLL_Newsletter gestorNewsletter = new BLL.BLL_Newsletter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiarPantalla();
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

                // validate the Captcha to check we're not dealing with a bot
                bool isHuman = ExampleCaptcha.Validate(CaptchaCodeTextBox.Text);

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

                BE.BE_UsuarioSuscripcion usuario = new BE.BE_UsuarioSuscripcion();
                usuario.EMAIL = CU_Mail.Text;
                foreach (ListItem item in checkBoxListReg.Items)
                {
                    if (string.Equals(item.Value, "Imagenes") && item.Selected)
                    {
                        usuario.IMAGENES = 1;
                    }
                    if (string.Equals(item.Value, "Riego") && item.Selected)
                    {
                        usuario.RIEGO = 1;
                    }
                    if (string.Equals(item.Value, "Humedad") && item.Selected)
                    {
                        usuario.HUMEDAD = 1;
                    }
                }

                int resultado = gestorNewsletter.insertarMail(usuario);

                if (resultado == 0)
                {
                    ModalPopUpMensajes.Show();
                    LabelMensaje.Text = "Registracion realizada con éxito";
                }
                else if (resultado == 1)
                {
                    ModalPopUpMensajes.Show();
                    LabelMensaje.Text = "El email ya está registrado.";
                }
                else if (resultado == 2) {
                    ModalPopUpMensajes.Show();
                    LabelMensaje.Text = "Hubo un error al registrar el email.";
                }
            }
        }

        protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = chkTyC.Checked;
        }

        protected void limpiarPantalla()
        {
            chkTyC.Checked = false;
            //TextBox impMail = (TextBox)CU_Mail.FindControl("inpEnviarEmail");
            CU_Mail.Text = "";
            foreach (ListItem item in checkBoxListReg.Items)
            {
                item.Selected = false;
            }

        }
    }
}
