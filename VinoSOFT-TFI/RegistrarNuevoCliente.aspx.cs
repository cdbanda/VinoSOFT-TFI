﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinoSOFT_TFI
{
    public partial class RegistrarNuevoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        private bool VerificarContrasena()
        {
            if (txtBoxContrasena.Text == txtBoxRepContrasena.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VerificarCaptcha()
        {
            bool isHuman = RecuperarCaptcha.Validate(CaptchaCodeTextBox.Text);

            CaptchaCodeTextBox.Text = null; // clear previous user input

            if (!isHuman)
            {
                // TODO: Captcha validation failed, show error message  
                return false;
            }
            else
            {
                // TODO: captcha validation succeeded; execute the protected action
                return true;
            }

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (VerificarContrasena())
            {
                if (VerificarCaptcha())
                {
                    CargarCliente();
                }
                else {
                    ModalPopUpMensajes.Show();
                    LabelMensaje.Text = "Error en el Captcha.";
                }
                
            }
            else {
                ModalPopUpMensajes.Show();
                LabelMensaje.Text = "Las contraseñas no Coinciden.";
            }
        }

        private void CargarCliente() {
            BE.BE_Usuario usuario = new BE.BE_Usuario();
            BLL.BLL_Usuario gestorUsuario = new BLL.BLL_Usuario();

            usuario.APELLIDO = txtBoxApellido.Text;
            usuario.NOMBRE = txtBoxNombre.Text;
            usuario.DOMICILIO = txtBoxDir.Text;
            usuario.CIUDAD = txtBoxCiudad.Text;
            usuario.EMAIL = UC_Mail.Text;
            usuario.DNI = int.Parse(txtBoxDNI.Text);
            usuario.TELEFONO = txtBoxTelefono.Text;

        }
    }
}
 