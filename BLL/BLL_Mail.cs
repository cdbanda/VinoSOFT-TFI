using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BLL
{
    public class BLL_Mail
    {
        public string dominio = "http://localhost:9500";

        //TIPO = 1 : Confirmacion
        //TIPO = 2 : Consulta
        //TIPO = 3 : Newsletter

        private string bodyEmail;

        public void cargarPlantilla(int tipo)
        {
            if (tipo == 2)
            {
                //bodyEmail = File.ReadAllText(@"D:\VinoSOFT\VinoSOFT\PlantillasMails\Email_Consulta.html", Encoding.UTF8);
                bodyEmail = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"PlantillasMails\" + "Email_Consulta.html"));
            }
            if (tipo == 1)
            {

            }
            if (tipo == 3)
            {

            }
        }

        public bool enviarMailConfirmacion()
        {
            //va el mail del cliente
            string email = "cdbanda@gmail.com";
            string host = dominio;
            string link = host; //falta la confirmacion

            string body = "<p>Por favor, para confirmar la registracion, ingrese en el siguiente link: </p>";
            string subject = "Confirmacion de registro. - VinoSoft S.A.";

            return enviarEmail(email, body, subject);

        }

        public bool enviarMailContacto(string email, string body, string nombre)
        {
            //va el mail de vinosoft
            string mail = "registraciovinosoft@gmail.com";
            string subject = nombre + " tiene una consulta.";
            int tipo = 2;
            cargarPlantilla(tipo);
            string mensaje = reemplazarValoresMail(bodyEmail, email, body, nombre);
            return enviarEmail(mail, mensaje, subject);
        }

        public string reemplazarValoresMail(string mail, string email, string body, string nombre)
        {
            mail = mail.Replace("{{name_person}}", nombre);
            mail = mail.Replace("{{consulta_person}}", body);
            mail = mail.Replace("{{mail_person}}", email);
            return mail;

        }

        public bool enviarEmail(string email, string body, string subject)
        {
            System.Net.Mail.MailMessage mensaje = new System.Net.Mail.MailMessage();
            System.Net.Mail.SmtpClient smtpCliente = new System.Net.Mail.SmtpClient();

            //Configuracion del smtp
            smtpCliente.Credentials = new System.Net.NetworkCredential("registraciovinosoft@gmail.com", "softvino123");
            smtpCliente.Host = "smtp.gmail.com";
            smtpCliente.Port = 587;
            smtpCliente.EnableSsl = true;

            //configuracion del mensaje

            mensaje.To.Add(email);
            mensaje.From = new System.Net.Mail.MailAddress("registraciovinosoft@gmail.com", "VinoSoft S.A.", System.Text.Encoding.UTF8);
            mensaje.Subject = subject;
            mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
            mensaje.Body = body;
            mensaje.BodyEncoding = System.Text.Encoding.UTF8;
            mensaje.Priority = System.Net.Mail.MailPriority.Normal;
            mensaje.IsBodyHtml = true;

            //envio
            try
            {
                smtpCliente.Send(mensaje);
                Console.Write("Mensaje enviado correctamente");
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

    }
}
