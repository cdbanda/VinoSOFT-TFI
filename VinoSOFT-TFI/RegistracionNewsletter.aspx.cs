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

            if (IsPostBack)
            {
                // validate the Captcha to check we're not dealing with a bot
                bool isHuman = ExampleCaptcha.Validate(CaptchaCodeTextBox.Text);

                CaptchaCodeTextBox.Text = null; // clear previous user input

                if (!isHuman)
                {
                    // TODO: Captcha validation failed, show error message  
                    Response.Write("<script language=javascript>alert('Error en Captcha.');</script>");
                }
                else
                {
                    // TODO: captcha validation succeeded; execute the protected action

                    //    BE.BE_UsuarioSuscripcion usuario = new BE.BE_UsuarioSuscripcion();
                    //    usuario.EMAIL = inpAltaEmail.Text;
                    //    foreach (ListItem item in checkBoxListReg.Items)
                    //    {
                    //        if (string.Equals(item.Value, "Imagenes") && item.Selected)
                    //        {
                    //            usuario.IMAGENES = 1;
                    //        }
                    //        if (string.Equals(item.Value, "Riego") && item.Selected)
                    //        {
                    //            usuario.RIEGO = 1;
                    //        }
                    //        if (string.Equals(item.Value, "Humedad") && item.Selected)
                    //        {
                    //            usuario.HUMEDAD = 1;
                    //        }
                    //    }

                    //    ok = gestorNewsletter.insertarMail(usuario);


                    Response.Write("<script language=javascript>alert('Susbcripcion realizada con exito.');</script>");
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
