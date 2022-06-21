using System;
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
            BE.BE_Cliente cliente = new BE.BE_Cliente();
            BLL.BLL_Cliente gestorCliente = new BLL.BLL_Cliente();

            cliente.APELLIDO = txtBoxApellido.Text;
            cliente.NOMBRE = txtBoxNombre.Text;
            cliente.DOMICILIO = txtBoxDir.Text;
            cliente.CIUDAD = txtBoxCiudad.Text;
            cliente.EMAIL = UC_Mail.Text;
            if(int.TryParse(txtBoxDNI.Text, out _))
            {
                cliente.DNI = int.Parse(txtBoxDNI.Text);
            }
            else
            {
                cliente.DNI = 0;
            }
            cliente.TELEFONO = txtBoxTelefono.Text;
            cliente.CONTRASENA = txtBoxContrasena.Text;


            if (gestorCliente.crear(cliente))
            {
                ModalPopUpMensajes.Show();
                LabelMensaje.Text = "Usuario Creado Correctamente.";
                LimpiarTxtBoxes(Page);
            }
            else {
                ModalPopUpMensajes.Show();
                LabelMensaje.Text = "Error al crear el usuario.";
            }
        }

        private void LimpiarTxtBoxes(Control c) {
            foreach (Control c1 in c.Controls)
            {
                if (c1.GetType() == typeof(TextBox))
                {
                    ((TextBox)c1).Text = "";
                }
                if (c1.HasControls())
                {
                    LimpiarTxtBoxes(c1);
                }
            }
        }
    }
}
 